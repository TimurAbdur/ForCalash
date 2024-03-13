using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForCalash
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            SignIn signIp = new SignIn();
            Hide();
            signIp.ShowDialog();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Вы не ввели логин! Пожалуйста повторите попытку!", "Ошибка!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error,
              MessageBoxDefaultButton.Button1);
            else if (textBox2.Text == "") MessageBox.Show("Вы не ввели пароль! Пожалуйста повторите попытку!", "Предупреждение!",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button1);
            else
            {
                using (var BD = new UserBDEntities())
                {
                    if (BD.User.FirstOrDefault(u => u.user_name == textBox1.Text) != null) MessageBox.Show("Такой логин уже есть! Введите другой логин!", "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                    else if (textBox2.Text.Length < 4) MessageBox.Show("Пароль должен состоять из минимум 4 символов! Пожалуйста повторите попытку!", "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                    else
                    {
                        var usersCount = BD.User.ToList().Count;


                        User user = new User();
                        user.user_name = textBox1.Text;
                        user.password = textBox2.Text;
                        user.user_id = (byte)(usersCount + 1);
                        BD.User.Add(user);
                        BD.SaveChangesAsync();
                        MessageBox.Show($"Профиль был успешно создан!", "Сообщение!",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information,
                 MessageBoxDefaultButton.Button1);
                        Hide();
                        MainForm mainForm = new MainForm();
                        mainForm.ShowDialog();
                        Application.Exit();
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.DimGray;
        }
    }
}
