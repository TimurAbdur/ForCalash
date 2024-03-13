using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ForCalash
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Username", 165);
            listView1.Columns.Add("Password", 140);

            using (var BD = new UserBDEntities())
            {
                var users = BD.User.ToList();

                for (int i = 0; i < users.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = users[i].user_id.ToString();
                    lvi.SubItems.Add(users[i].user_name.ToString());
                    lvi.SubItems.Add(users[i].password.ToString());
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
