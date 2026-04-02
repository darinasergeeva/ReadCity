using Microsoft.EntityFrameworkCore;
using ReadCity.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ReadCity
{
    public partial class FormLoanEdit : Form
    {
        private BookLoan _editingLoan;
        private bool _isEditMode;

        
        public FormLoanEdit()
        {
            InitializeComponent();
            _isEditMode = false;
            LoadComboBoxes();
            numDays.ValueChanged += NumDays_ValueChanged;
            CalculateReturnDate();
        }

        
        public FormLoanEdit(BookLoan loan)
        {
            InitializeComponent();
            _editingLoan = loan;
            _isEditMode = true;
            LoadComboBoxes();
            LoadLoanData();
            numDays.ValueChanged += NumDays_ValueChanged;
            CalculateReturnDate();
        }

        private void LoadComboBoxes()
        {
            using (var db = new BdLibraryContext())
            {
                // При редактировании показываем все книги, при добавлении - только доступные
                var books = db.Books
                    .OrderBy(b => b.NameBook)
                    .ToList();

                // Если это режим добавления, фильтруем только доступные книги
                if (!_isEditMode)
                {
                    books = books.Where(b => b.Available > 0).ToList();
                }

                cbBook.DisplayMember = "NameBook";
                cbBook.ValueMember = "Id";
                cbBook.DataSource = books;

                if (cbBook.Items.Count == 0)
                {
                    cbBook.Items.Add(_isEditMode ? "Нет книг" : "Нет доступных книг");
                    cbBook.Enabled = false;
                }

                // Загрузка читателей
                var readers = db.LibraryCards
                    .OrderBy(r => r.NameLibraryCard)
                    .ToList();

                cbReader.DisplayMember = "NameLibraryCard";
                cbReader.ValueMember = "Id";
                cbReader.DataSource = readers;

                if (cbReader.Items.Count == 0)
                {
                    cbReader.Items.Add("Нет читателей");
                    cbReader.Enabled = false;
                }

                // При редактировании устанавливаем значения
                if (_isEditMode && _editingLoan != null)
                {
                    cbBook.SelectedValue = _editingLoan.IdBooks;
                    cbReader.SelectedValue = _editingLoan.IdLibraryCard;
                }
            }
        }

        
        private void LoadLoanData()
        {
            if (_editingLoan == null) return;

            if (_editingLoan.PlannedReturnDate != null)
            {
                int daysDiff = (_editingLoan.PlannedReturnDate.ToDateTime(TimeOnly.MinValue) - DateTime.Now).Days;
                if (daysDiff > 0 && daysDiff <= 60)
                {
                    numDays.Value = daysDiff;
                }
            }
        }

        private void NumDays_ValueChanged(object sender, EventArgs e)
        {
            CalculateReturnDate();
        }

        private void CalculateReturnDate()
        {
            DateOnly returnDate = DateOnly.FromDateTime(DateTime.Now.AddDays((int)numDays.Value));
            lblReturnDateValue.Text = returnDate.ToString("dd.MM.yyyy");
        }

        private bool ValidateInput()
        {
            if (cbBook.SelectedItem == null || cbBook.Items.Count == 0 || cbBook.SelectedValue == null)
            {
                MessageBox.Show("Выберите книгу для выдачи.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cbReader.SelectedItem == null || cbReader.Items.Count == 0 || cbReader.SelectedValue == null)
            {
                MessageBox.Show("Выберите читателя.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                using (var db = new BdLibraryContext())
                {
                    if (_isEditMode)
                    {
                        var loan = db.BookLoans.Find(_editingLoan.Id);
                        if (loan != null)
                        {
                            loan.PlannedReturnDate = DateOnly.FromDateTime(DateTime.Now.AddDays((int)numDays.Value));
                            db.SaveChanges();

                            MessageBox.Show($"Данные выдачи успешно обновлены!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        int bookId = (int)cbBook.SelectedValue;
                        int readerId = (int)cbReader.SelectedValue;

                        var book = db.Books.Find(bookId);
                        if (book == null || book.Available <= 0)
                        {
                            MessageBox.Show("Эта книга уже недоступна для выдачи.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var firstStatus = db.Statuses.FirstOrDefault();
                        if (firstStatus == null)
                        {
                            MessageBox.Show("В базе данных нет статусов. Обратитесь к администратору.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var loan = new BookLoan
                        {
                            IdBooks = bookId,
                            IdLibraryCard = readerId,
                            DateOfIssue = DateOnly.FromDateTime(DateTime.Now),
                            PlannedReturnDate = DateOnly.FromDateTime(DateTime.Now.AddDays((int)numDays.Value)),
                            ReturnDate = null,
                            IdStatus = firstStatus.Id
                        };

                        db.BookLoans.Add(loan);
                        book.Available--;
                        db.SaveChanges();

                        MessageBox.Show($"Книга \"{book.NameBook}\" успешно выдана!\n" +
                                       $"Читатель: {cbReader.Text}\n" +
                                       $"Дата возврата: {lblReturnDateValue.Text}",
                                       "Успех",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выдаче книги: {ex.Message}\n\n{ex.InnerException?.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}