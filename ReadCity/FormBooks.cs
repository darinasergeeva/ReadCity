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
        private List<Book> _allBooks;
        private string _currentSortOrder = "asc";

        public FormBooks(User user, bool guest)
        {
            InitializeComponent();

            CurrentUser = user;
            IsGuest = guest;

            this.Text = "Библиотечная система - Список книг";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(1000, 600);

            // Настройка таблицы 
            ConfigureDataGridView();

            if (lblUserName != null)
            {
                lblUserName.Text = IsGuest ? "Гость" : CurrentUser.FullName;
                lblUserName.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                lblUserName.ForeColor = Color.FromArgb(74, 111, 165);
            }

            // Создаем панель поиска 
            CreateSearchFilterPanel();

            ShowOrHideAdminButtons();

            LoadBooks();
        }

        private void ShowOrHideAdminButtons()
        {
            // Проверяем, является ли пользователь администратором
            bool isAdmin = !IsGuest && CurrentUser?.Role?.NameRole == "Администратор";

            // Показываем кнопки только если админ, иначе скрываем
            if (btnAddBook != null)
                btnAddBook.Visible = isAdmin;

            if (btnEditBook != null)
                btnEditBook.Visible = isAdmin;

            if (btnDelete != null)
                btnDelete.Visible = isAdmin;
        }

        private void ConfigureDataGridView()
        {
            dgvBooks.Columns.Clear();

            // Колонка для обложки
            DataGridViewImageColumn colPhoto = new DataGridViewImageColumn();
            colPhoto.Name = "colPhoto";
            colPhoto.HeaderText = "";
            colPhoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPhoto.Width = 60;
            colPhoto.FillWeight = 10;
            dgvBooks.Columns.Add(colPhoto);

            // Колонка для информации
            DataGridViewTextBoxColumn colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.HeaderText = "Информация о книге";
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colInfo.Width = 700;
            colInfo.FillWeight = 100;
            dgvBooks.Columns.Add(colInfo);

            // Колонка для доступности
            DataGridViewTextBoxColumn colAvailable = new DataGridViewTextBoxColumn();
            colAvailable.Name = "colAvailable";
            colAvailable.HeaderText = "Доступно";
            colAvailable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colAvailable.Width = 80;
            colAvailable.FillWeight = 15;
            dgvBooks.Columns.Add(colAvailable);

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "colId";
            colId.HeaderText = "ID";
            colId.Visible = false;  // Скрытая колонка
            dgvBooks.Columns.Add(colId);


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
        }

        private void CreateSearchFilterPanel()
        {
            Panel searchPanel = new Panel();
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Height = 50;
            searchPanel.BackColor = Color.FromArgb(240, 248, 255);
            searchPanel.Padding = new Padding(10, 5, 10, 5);

            // Поиск
            Label lblSearch = new Label();
            lblSearch.Text = "Поиск:";
            lblSearch.Size = new Size(55, 27);
            lblSearch.Font = new Font("Times New Roman", 10);
            lblSearch.Location = new Point(10, 10);

            TextBox txtSearch = new TextBox();
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 27);
            txtSearch.Location = new Point(70, 10);
            txtSearch.Font = new Font("Times New Roman", 10);
            txtSearch.TextChanged += (s, e) => ApplyFilterAndSearch();

            // Сортировка
            Label lblSort = new Label();
            lblSort.Text = "Сортировка:";
            lblSort.Size = new Size(90, 27);
            lblSort.Location = new Point(290, 10);
            lblSort.Font = new Font("Times New Roman", 10);

            ComboBox cbSort = new ComboBox();
            cbSort.Name = "cbSort";
            cbSort.Size = new Size(140, 27);
            cbSort.Location = new Point(385, 10);
            cbSort.Font = new Font("Times New Roman", 10);
            cbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSort.Items.AddRange(new string[] { "По возрастанию", "По убыванию" });
            cbSort.SelectedIndex = 0;
            cbSort.SelectedIndexChanged += (s, e) =>
            {
                _currentSortOrder = cbSort.SelectedIndex == 0 ? "asc" : "desc";
                ApplyFilterAndSearch();
            };

            // Фильтр по издательству
            Label lblFilter = new Label();
            lblFilter.Text = "Издательство:";
            lblFilter.Size = new Size(100, 27);
            lblFilter.Location = new Point(545, 10);
            lblFilter.Font = new Font("Times New Roman", 10);

            ComboBox cbPublisher = new ComboBox();
            cbPublisher.Name = "cbPublisher";
            cbPublisher.Size = new Size(170, 27);
            cbPublisher.Location = new Point(650, 10);
            cbPublisher.Font = new Font("Times New Roman", 10);
            cbPublisher.DropDownStyle = ComboBoxStyle.DropDownList;

            // Загрузка издательств
            using (var db = new BdLibraryContext())
            {
                var publishers = db.PublishingHouses.OrderBy(p => p.NamePublishingHouse).ToList();
                cbPublisher.Items.Add("Все издательства");
                foreach (var p in publishers)
                {
                    cbPublisher.Items.Add(p.NamePublishingHouse);
                }
                cbPublisher.SelectedIndex = 0;
            }
            cbPublisher.SelectedIndexChanged += (s, e) => ApplyFilterAndSearch();

            // Кнопка сброса
            Button btnReset = new Button();
            btnReset.Text = "Сбросить";
            btnReset.Size = new Size(110, 30);
            btnReset.Location = new Point(835, 9);
            btnReset.BackColor = Color.FromArgb(108, 117, 125);
            btnReset.ForeColor = Color.White;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Times New Roman", 9, FontStyle.Bold);
            btnReset.Cursor = Cursors.Hand;
            btnReset.Click += (s, e) =>
            {
                txtSearch.Text = "";
                cbSort.SelectedIndex = 0;
                cbPublisher.SelectedIndex = 0;
            };

            searchPanel.Controls.AddRange(new Control[] {
                lblSearch, txtSearch, lblSort, cbSort, lblFilter, cbPublisher, btnReset
            });

            this.Controls.Add(searchPanel);
        }

        private void ApplyFilterAndSearch()
        {
            if (_allBooks == null) return;

            var filtered = _allBooks.AsEnumerable();

            // Поиск
            var searchControl = this.Controls.Find("txtSearch", true).FirstOrDefault() as TextBox;
            if (searchControl != null && !string.IsNullOrEmpty(searchControl.Text))
            {
                string searchText = searchControl.Text.ToLower();
                filtered = filtered.Where(b =>
                    (b.NameBook?.ToLower().Contains(searchText) ?? false) ||
                    (b.Author?.NameAuthor?.ToLower().Contains(searchText) ?? false) ||
                    (b.Genre?.NameGenre?.ToLower().Contains(searchText) ?? false) ||
                    (b.PublishingHouse?.NamePublishingHouse?.ToLower().Contains(searchText) ?? false)
                );
            }

            // Фильтр по издательству
            var publisherControl = this.Controls.Find("cbPublisher", true).FirstOrDefault() as ComboBox;
            if (publisherControl != null && publisherControl.SelectedItem != null)
            {
                string publisher = publisherControl.SelectedItem.ToString();
                if (publisher != "Все издательства")
                {
                    filtered = filtered.Where(b => b.PublishingHouse?.NamePublishingHouse == publisher);
                }
            }

            // Сортировка
            if (_currentSortOrder == "asc")
            {
                filtered = filtered.OrderBy(b => b.Available);
            }
            else
            {
                filtered = filtered.OrderByDescending(b => b.Available);
            }

            DisplayBooks(filtered.ToList());
        }

        private void LoadBooks()
        {
            try
            {
                using (var db = new BdLibraryContext())
                {
                    _allBooks = db.Books
                        .Include(b => b.Author)
                        .Include(b => b.Genre)
                        .Include(b => b.PublishingHouse)
                        .Include(b => b.BookLoans)
                            .ThenInclude(bl => bl.Status)
                        .OrderBy(b => b.NameBook)
                        .ToList();

                    ApplyFilterAndSearch();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки книг: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayBooks(List<Book> books)
        {
            dgvBooks.SuspendLayout();
            dgvBooks.Rows.Clear();

            foreach (var book in books)
            {
                int rowIndex = dgvBooks.Rows.Add();
                var row = dgvBooks.Rows[rowIndex];

                // Обложка
                row.Cells[0].Value = GetSmallPlaceholder();
                row.Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Информация о книге
                row.Cells[1].Value = FormatBookInfoCompact(book);

                // Доступность
                row.Cells[2].Value = $"{book.Available}";
                row.Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Cells[2].Style.Font = new Font("Times New Roman", 11, FontStyle.Bold);


                row.Cells[3].Value = book.Id;

                ApplyRowStyles(row, book);
            }

            dgvBooks.ResumeLayout();
            dgvBooks.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
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

            return $"{book.NameBook ?? "Н/Д"}\n" +
                   $"{authorName}\n" +
                   $"{book.YearOfPublication} | Всего: {book.Pages} стр. | {publisherName}\n" +
                   $"{(string.IsNullOrEmpty(annotation) ? "" : annotation)}";
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
                Bitmap placeholder = new Bitmap(50, 60);
                using (Graphics g = Graphics.FromImage(placeholder))
                {
                    g.Clear(Color.FromArgb(240, 248, 255));
                    g.DrawRectangle(Pens.LightGray, 0, 0, 49, 59);
                    g.DrawString("📚",
                        new Font("Segoe UI", 14),
                        Brushes.Gray,
                        new RectangleF(0, 15, 50, 30),
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

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            // Проверка, что окно редактирования не открыто
            if (Application.OpenForms.OfType<FormBookEdit>().Any())
            {
                MessageBox.Show("Окно добавления/редактирования уже открыто.",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var editForm = new FormBookEdit(null);
            editForm.FormClosed += (s, args) => LoadBooks(); // Обновляем список после закрытия
            editForm.ShowDialog();
        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            // Проверка, выбрана ли книга
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите книгу для редактирования.\n\n" +
                                "Для выбора книги щелкните по строке с книгой.",
                                "Внимание",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Проверка, что окно редактирования не открыто
            if (Application.OpenForms.OfType<FormBookEdit>().Any())
            {
                MessageBox.Show("Окно редактирования уже открыто.\n\n" +
                                "Закройте его перед редактированием другой книги.",
                                "Внимание",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Получаем ID книги из скрытой колонки
            int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells[3].Value);

            using (var db = new BdLibraryContext())
            {
                var book = db.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Include(b => b.PublishingHouse)
                    .FirstOrDefault(b => b.Id == bookId);

                if (book != null)
                {
                    var editForm = new FormBookEdit(book);
                    editForm.FormClosed += (s, args) => LoadBooks();
                    editForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Книга с ID = {bookId} не найдена в базе данных.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите книгу для удаления.",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells[3].Value);

            using (var db = new BdLibraryContext())
            {
                // Проверка, есть ли у книги выдачи
                var hasLoans = db.BookLoans.Any(bl => bl.IdBooks == bookId);

                if (hasLoans)
                {
                    MessageBox.Show("Невозможно удалить книгу, так как она присутствует в выдаче читателям.",
                        "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить эту книгу?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var book = db.Books.Find(bookId);
                    if (book != null)
                    {

                        db.Books.Remove(book);
                        db.SaveChanges();

                        LoadBooks();

                        MessageBox.Show("Книга успешно удалена.", "Успешно",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}