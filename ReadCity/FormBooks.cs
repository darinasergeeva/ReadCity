using Microsoft.EntityFrameworkCore;
using ReadCity.Models;
using ReadCity.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ReadCity
{
    public partial class FormBooks : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormBooks(User user, bool guest)
        {
            InitializeComponent();

       
            this.Text = "Библиотечная система - Список книг";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(1000, 600);

       
            dgvBooks.Columns.Clear();

           
            DataGridViewImageColumn colPhoto = new DataGridViewImageColumn();
            colPhoto.Name = "colPhoto";
            colPhoto.HeaderText = "";
            colPhoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPhoto.Width = 60;
            colPhoto.FillWeight = 5;
            dgvBooks.Columns.Add(colPhoto);

          
            DataGridViewTextBoxColumn colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.HeaderText = "Информация о книге";
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colInfo.Width = 700;
            colInfo.FillWeight = 80;
            dgvBooks.Columns.Add(colInfo);

          
            DataGridViewTextBoxColumn colAvailable = new DataGridViewTextBoxColumn();
            colAvailable.Name = "colAvailable";
            colAvailable.HeaderText = "Доступно";
            colAvailable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colAvailable.Width = 80;
            colAvailable.FillWeight = 15;
            dgvBooks.Columns.Add(colAvailable);

           
            dgvBooks.RowTemplate.Height = 70;
            dgvBooks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.ReadOnly = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.BorderStyle = BorderStyle.None;
            dgvBooks.GridColor = Color.LightGray;

        
            dgvBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgvBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(74, 111, 165);
            dgvBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBooks.EnableHeadersVisualStyles = false;

            
            dgvBooks.DefaultCellStyle.Font = new Font("Times New Roman", 9);
            dgvBooks.DefaultCellStyle.Padding = new Padding(5);

            CurrentUser = user;
            IsGuest = guest;

            
            if (lblUserName != null)
            {
                lblUserName.Text = IsGuest ? "Гость" : CurrentUser.FullName;
                lblUserName.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                lblUserName.ForeColor = Color.FromArgb(74, 111, 165);
            }

            LoadBooks();
        }



        private void LoadBooks()
        {
            try
            {
                using (var db = new BdLibraryContext())
                {
                    var books = db.Books
                        .Include(b => b.Author)
                        .Include(b => b.Genre)
                        .Include(b => b.PublishingHouse)
                        .Include(b => b.BookLoans)
                            .ThenInclude(bl => bl.Status)
                        .OrderBy(b => b.NameBook)
                        .ToList();

                    dgvBooks.SuspendLayout();
                    dgvBooks.Rows.Clear();

                    foreach (var book in books)
                    {
                        int rowIndex = dgvBooks.Rows.Add();
                        var row = dgvBooks.Rows[rowIndex];

                        row.Cells[0].Value = GetSmallPlaceholder();
                        row.Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        
                        row.Cells[1].Value = FormatBookInfoCompact(book);

                        
                        row.Cells[2].Value = $"{book.Available}";
                        row.Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        row.Cells[2].Style.Font = new Font("Times New Roman", 11, FontStyle.Bold);

                        ApplyRowStyles(row, book);
                    }

                    dgvBooks.ResumeLayout();
                    dgvBooks.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки книг: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FormatBookInfoCompact(Book book)
        {
            string authorName = book.Author?.NameAuthor ?? "Не указан";
            string publisherName = book.PublishingHouse?.NamePublishingHouse ?? "Не указан";

            string annotation = string.IsNullOrEmpty(book.Annotation) ? "" : book.Annotation;
            if (annotation.Length > 100)
            {
                annotation = annotation.Substring(0, 100) + "...";
            }

            return $"Название книги: {book.NameBook ?? "Н/Д"}\n" +
                   $"Автор: {authorName}\n" +
                   $"Год публикации: {book.YearOfPublication} | Всего {book.Pages} стр.\n" +
                   $"Издательство: {publisherName}\n" +
                   $"Аннотация: {(string.IsNullOrEmpty(annotation) ? "" : annotation)}";
        }

        private void ApplyRowStyles(DataGridViewRow row, Book book)
        {
            if (IsBookOverdue(book))
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D4EDDA");
            }
            else if (book.Available == 0)
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCCCC");
            }
            else if (book.Available <= 2)
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF3CD");
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private bool IsBookOverdue(Book book)
        {
            if (book.BookLoans != null && book.BookLoans.Any())
            {
                return book.BookLoans.Any(loan =>
                    loan.ReturnDate == null &&
                    loan.DateOfIssue < DateOnly.FromDateTime(DateTime.Now.AddDays(-30)));
            }
            return false;
        }

        private Image GetSmallPlaceholder()
        {
            try
            {
                return Resources.book_placeholder;
            }
            catch
            {
                Bitmap placeholder = new Bitmap(50, 70);
                using (Graphics g = Graphics.FromImage(placeholder))
                {
                    g.Clear(Color.FromArgb(240, 248, 255));
                    g.DrawRectangle(Pens.LightGray, 0, 0, 49, 69);
                    g.DrawString("📚",
                        new Font("Segoe UI", 16),
                        Brushes.Gray,
                        new RectangleF(0, 20, 50, 30),
                        new StringFormat { Alignment = StringAlignment.Center });
                }
                return placeholder;
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void btnLogut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Выйти из системы?",
                "Выход",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                var loginForm = new FormLogin();
                loginForm.Show();
            }
        }
    }
}