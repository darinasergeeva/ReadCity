using System;
using System.Windows.Forms;

namespace ReadCity
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool exitProgram = false;

            while (!exitProgram)
            {
                using (var formLogin = new FormLogin())
                {
                    if (formLogin.ShowDialog() == DialogResult.OK)
                    {
                        using (var formBooks = new FormBooks(
                            formLogin.CurrentUser,
                            formLogin.IsGuest))
                        {
                            var booksResult = formBooks.ShowDialog();

                            if (booksResult == DialogResult.OK || booksResult == DialogResult.Cancel)
                            {
                                // После закрытия FormBooks, выходим из программы
                                exitProgram = true;
                            }
                            else
                            {
                                exitProgram = true;
                            }
                        }
                    }
                    else
                    {
                        // Если нажали Cancel или закрыли форму авторизации
                        exitProgram = true;
                    }
                }
            }
        }
    }
}