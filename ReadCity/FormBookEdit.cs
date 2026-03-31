using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ReadCity.Models;

namespace ReadCity
{
    public partial class FormBookEdit : Form
    {
        private Book _editingBook;

        public FormBookEdit(Book book = null)
        {
            InitializeComponent();
            _editingBook = book;

            if (_editingBook == null)
            {
                this.Text = "Добавление книги";
                lblTitle.Text = "Добавление новой книги";
                btnSave.Text = "Добавить";
            }
            else
            {
                this.Text = "Редактирование книги";
                lblTitle.Text = "Редактирование книги";
                btnSave.Text = "Сохранить";
                LoadBookData();
            }

            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            using (var db = new BdLibraryContext())
            {
                // Загрузка авторов
                cbAuthor.DataSource = db.Authors.OrderBy(a => a.NameAuthor).ToList();
                cbAuthor.DisplayMember = "NameAuthor";
                cbAuthor.ValueMember = "Id";

                // Загрузка жанров
                cbGenre.DataSource = db.Genres.OrderBy(g => g.NameGenre).ToList();
                cbGenre.DisplayMember = "NameGenre";
                cbGenre.ValueMember = "Id";

                // Загрузка издательств
                cbPublisher.DataSource = db.PublishingHouses.OrderBy(p => p.NamePublishingHouse).ToList();
                cbPublisher.DisplayMember = "NamePublishingHouse";
                cbPublisher.ValueMember = "Id";
            }
        }

        private void LoadBookData()
        {
            if (_editingBook == null) return;

            txtISBN.Text = _editingBook.Isbn;
            txtName.Text = _editingBook.NameBook;
            txtYear.Text = _editingBook.YearOfPublication.ToString();
            txtPages.Text = _editingBook.Pages.ToString();
            txtAnnotation.Text = _editingBook.Annotation;

            cbAuthor.SelectedValue = _editingBook.IdAuthor;
            cbGenre.SelectedValue = _editingBook.IdGenre;
            cbPublisher.SelectedValue = _editingBook.IdPublishingHouse;
        }

        private bool ValidateInput()
        {
            // Проверка названия
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название книги.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }

            // Проверка года
            if (!int.TryParse(txtYear.Text, out int year) || year < 0 || year > DateTime.Now.Year)
            {
                MessageBox.Show($"Введите корректный год издания (0-{DateTime.Now.Year}).", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtYear.Focus();
                return false;
            }

            // Проверка страниц
            if (!int.TryParse(txtPages.Text, out int pages) || pages <= 0)
            {
                MessageBox.Show("Введите корректное количество страниц (положительное число).", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPages.Focus();
                return false;
            }

            return true;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                using (var db = new BdLibraryContext())
                {
                    if (_editingBook == null)
                    {
                        // Добавление новой книги
                        var newBook = new Book
                        {
                            Isbn = txtISBN.Text,
                            NameBook = txtName.Text,
                            IdAuthor = (int)cbAuthor.SelectedValue,
                            IdGenre = (int)cbGenre.SelectedValue,
                            IdPublishingHouse = (int)cbPublisher.SelectedValue,
                            YearOfPublication = int.Parse(txtYear.Text),
                            Pages = int.Parse(txtPages.Text),
                            Copies = int.Parse(txtTotalCopies.Text),
                            Available = int.Parse(txtAvailableCopies.Text),
                            Annotation = txtAnnotation.Text
                        };
                        db.Books.Add(newBook);
                        db.SaveChanges();

                        MessageBox.Show("Книга успешно добавлена!", "Успешно",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Редактирование книги
                        var book = db.Books.Find(_editingBook.Id);
                        if (book != null)
                        {
                            book.Isbn = txtISBN.Text;
                            book.NameBook = txtName.Text;
                            book.IdAuthor = (int)cbAuthor.SelectedValue;
                            book.IdGenre = (int)cbGenre.SelectedValue;
                            book.IdPublishingHouse = (int)cbPublisher.SelectedValue;
                            book.YearOfPublication = int.Parse(txtYear.Text);
                            book.Pages = int.Parse(txtPages.Text);
                            book.Annotation = txtAnnotation.Text;

                            db.SaveChanges();

                            MessageBox.Show("Данные книги успешно обновлены!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}