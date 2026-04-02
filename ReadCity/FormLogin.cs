using Microsoft.EntityFrameworkCore;
using ReadCity.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ReadCity
{
    public partial class FormLogin : Form
    {
        public Models.User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtLogin.Text) || String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new BdLibraryContext())
            {
                var user = db.Users
                    .Include(u => u.Role)  
                    .Where(w => w.Login == txtLogin.Text && w.Password == txtPassword.Text)
                    .FirstOrDefault();

                if (user != null)
                {
                    CurrentUser = user;
                    IsGuest = false;

                    
                    string roleName = user.Role?.NameRole ?? "Роль не загружена";
                    MessageBox.Show($"Добро пожаловать, {user.FullName}!\nВаша роль: {roleName}",
                        "Успешный вход",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnGuest_Click(object sender, EventArgs e)
        {
            CurrentUser = null;
            IsGuest = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}