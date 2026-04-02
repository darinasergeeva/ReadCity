using Microsoft.EntityFrameworkCore;
using ReadCity.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ReadCity
{
    public partial class FormLoanEdit : Form
    {
        public FormLoanEdit()
        {
            InitializeComponent();
            LoadComboBoxes();

            // Подписка на изменение срока выдачи
            numDays.ValueChanged += NumDays_ValueChanged;
            CalculateReturnDate();
        }

        private void LoadComboBoxes()
        {
            using (var db = new BdLibraryContext())
            {
                // Загрузка книг 
                var books = db.Books
                    .Where(b => b.Available > 0)
                    .OrderBy(b => b.NameBook)
                    .ToList();

                cbBook.DisplayMember = "NameBook";
                cbBook.ValueMember = "Id";
                cbBook.DataSource = books;

                if (cbBook.Items.Count == 0)
                {
                    cbBook.Items.Add("Нет доступных книг");
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
                    int bookId = (int)cbBook.SelectedValue;
                    int readerId = (int)cbReader.SelectedValue;

                    // Проверка, что книга ещё доступна
                    var book = db.Books.Find(bookId);
                    if (book == null || book.Available <= 0)
                    {
                        MessageBox.Show("Эта книга уже недоступна для выдачи.", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Получаем первый статус из таблицы Statuses
                    var firstStatus = db.Statuses.FirstOrDefault();
                    if (firstStatus == null)
                    {
                        MessageBox.Show("В базе данных нет статусов. Обратитесь к администратору.", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Создаем запись о выдаче
                    var loan = new BookLoan
                    {
                        IdBooks = bookId,
                        IdLibraryCard = readerId,
                        DateOfIssue = DateOnly.FromDateTime(DateTime.Now),
                        PlannedReturnDate = DateOnly.FromDateTime(DateTime.Now.AddDays((int)numDays.Value)),
                        ReturnDate = null,
                        IdStatus = firstStatus.Id  // Используем ID первого статуса
                    };

                    db.BookLoans.Add(loan);

                    // Уменьшаем количество доступных экземпляров
                    book.Available--;

                    db.SaveChanges();

                    MessageBox.Show($"Книга \"{book.NameBook}\" успешно выдана!\n" +
                                   $"Читатель: {cbReader.Text}\n" +
                                   $"Дата возврата: {lblReturnDateValue.Text}",
                                   "Успех",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);

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