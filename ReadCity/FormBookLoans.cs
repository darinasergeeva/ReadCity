using Microsoft.EntityFrameworkCore;
using ReadCity.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ReadCity
{
    public partial class FormBookLoans : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormBookLoans(User user, bool guest)
        {
            InitializeComponent();

            CurrentUser = user;
            IsGuest = guest;

            this.Text = "Библиотечная система - Выдача книг";
            this.Size = new Size(1300, 700);
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

            LoadLoans();
        }

        private void ConfigureDataGridView()
        {
            dgvLoans.Columns.Clear();

            // Колонка для информации о книге
            DataGridViewTextBoxColumn colBookInfo = new DataGridViewTextBoxColumn();
            colBookInfo.Name = "colBookInfo";
            colBookInfo.HeaderText = "Информация о книге";
            colBookInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colBookInfo.Width = 400;
            dgvLoans.Columns.Add(colBookInfo);

            // Колонка для информации о читателе
            DataGridViewTextBoxColumn colReaderInfo = new DataGridViewTextBoxColumn();
            colReaderInfo.Name = "colReaderInfo";
            colReaderInfo.HeaderText = "Читатель";
            colReaderInfo.Width = 200;
            dgvLoans.Columns.Add(colReaderInfo);

            // Колонка для даты выдачи
            DataGridViewTextBoxColumn colIssueDate = new DataGridViewTextBoxColumn();
            colIssueDate.Name = "colIssueDate";
            colIssueDate.HeaderText = "Дата выдачи";
            colIssueDate.Width = 120;
            dgvLoans.Columns.Add(colIssueDate);

            // Колонка для планируемой даты возврата
            DataGridViewTextBoxColumn colPlannedDate = new DataGridViewTextBoxColumn();
            colPlannedDate.Name = "colPlannedDate";
            colPlannedDate.HeaderText = "План. возврат";
            colPlannedDate.Width = 120;
            dgvLoans.Columns.Add(colPlannedDate);

            // Колонка для даты возврата
            DataGridViewTextBoxColumn colReturnDate = new DataGridViewTextBoxColumn();
            colReturnDate.Name = "colReturnDate";
            colReturnDate.HeaderText = "Дата возврата";
            colReturnDate.Width = 120;
            dgvLoans.Columns.Add(colReturnDate);

            // Колонка для статуса
            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "colStatus";
            colStatus.HeaderText = "Статус";
            colStatus.Width = 100;
            dgvLoans.Columns.Add(colStatus);

            // Скрытая колонка для ID
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "colId";
            colId.HeaderText = "ID";
            colId.Visible = false;
            dgvLoans.Columns.Add(colId);

            dgvLoans.RowTemplate.Height = 50;
            dgvLoans.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvLoans.AllowUserToAddRows = false;
            dgvLoans.ReadOnly = true;
            dgvLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoans.RowHeadersVisible = false;
            dgvLoans.BackgroundColor = Color.White;
            dgvLoans.BorderStyle = BorderStyle.None;
            dgvLoans.GridColor = Color.LightGray;

            dgvLoans.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgvLoans.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(74, 111, 165);
            dgvLoans.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLoans.EnableHeadersVisualStyles = false;

            dgvLoans.DefaultCellStyle.Font = new Font("Times New Roman", 9);
            dgvLoans.DefaultCellStyle.Padding = new Padding(5);
        }

        private void LoadLoans()
        {
            try
            {
                using (var db = new BdLibraryContext())
                {
                    var loans = db.BookLoans
                        .Include(l => l.Book)
                            .ThenInclude(b => b.Author)
                        .Include(l => l.LibraryCard)
                        .Include(l => l.Status)
                        .OrderByDescending(l => l.DateOfIssue)
                        .ToList();

                    dgvLoans.SuspendLayout();
                    dgvLoans.Rows.Clear();

                    foreach (var loan in loans)
                    {
                        int rowIndex = dgvLoans.Rows.Add();
                        var row = dgvLoans.Rows[rowIndex];

                        // Информация о книге
                        string bookInfo = $"{loan.Book?.NameBook ?? "Н/Д"}\n" +
                                          $"{loan.Book?.Author?.NameAuthor ?? "Не указан"}\n" +
                                          $"{loan.Book?.YearOfPublication} | {loan.Book?.Pages} стр.";
                        row.Cells[0].Value = bookInfo;

                        // Информация о читателе
                        row.Cells[1].Value = loan.LibraryCard?.NameLibraryCard ?? "Не указан";

                        // Даты
                        row.Cells[2].Value = loan.DateOfIssue.ToString("dd.MM.yyyy");
                        row.Cells[3].Value = loan.PlannedReturnDate.ToString("dd.MM.yyyy");
                        row.Cells[4].Value = loan.ReturnDate?.ToString("dd.MM.yyyy") ?? "Не возвращена";

                        // Статус
                        string status = loan.ReturnDate == null ? "Выдана" : "Возвращена";
                        row.Cells[5].Value = status;

                        if (loan.ReturnDate == null)
                        {
                            row.Cells[5].Style.ForeColor = Color.FromArgb(220, 53, 69);
                            row.Cells[5].Style.Font = new Font("Times New Roman", 9, FontStyle.Bold);
                        }
                        else
                        {
                            row.Cells[5].Style.ForeColor = Color.FromArgb(40, 167, 69);
                        }

                        // ID
                        row.Cells[6].Value = loan.Id;

                        ApplyRowStyles(row, loan);
                    }

                    dgvLoans.ResumeLayout();
                    dgvLoans.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

                    this.Text = $"Библиотечная система - Выдача книг (Всего: {loans.Count})";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки выдач: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRowStyles(DataGridViewRow row, BookLoan loan)
        {
            // Просроченные выдачи (не возвращены и план.дата меньше сегодня) - светло-красный
            if (loan.ReturnDate == null && loan.PlannedReturnDate < DateOnly.FromDateTime(DateTime.Now))
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCCCC");
            }
            // Возвращенные - светло-зеленый
            else if (loan.ReturnDate != null)
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D4EDDA");
            }
            // Активные - белый
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            var formBooks = new FormBooks(CurrentUser, IsGuest);
            formBooks.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Выйти из системы?", "Выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                var loginForm = new FormLogin();
                loginForm.Show();
            }
        }
    }
}