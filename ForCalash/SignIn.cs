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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Вы не ввели логин! Пожалуйста повторите попытку!", "Ошибка!",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
            else if (textBox2.Text == "") MessageBox.Show("Вы не ввели пароль! Пожалуйста повторите попытку!", "Ошибка!",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button1);
            else
            {
                using (var BD = new UserBDEntities())
                {
                    if (BD.User.FirstOrDefault(u => u.user_name == textBox1.Text && u.password == textBox2.Text) != null)
                    {
                        Hide();
                        MainForm mainForm = new MainForm();
                        mainForm.ShowDialog();
                        Application.Exit();
                    }
                    else
                        MessageBox.Show("Вы ввели не верный логин или пароль! Пожалуйста повторите попытку!", "Ошибка!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            Hide();
            signUp.ShowDialog();
            Application.Exit();
        }
    }
}
