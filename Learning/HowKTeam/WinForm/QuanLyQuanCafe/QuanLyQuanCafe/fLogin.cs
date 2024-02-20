using QuanLyQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            // Set the culture for the entire application
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string userName = textBoxUserName.Text;
            string passWord = textBoxPassWord.Text;
            if (Login(userName, passWord) == true)
            {
                fTableManager fTableManager = new fTableManager();
                this.Hide();
                fTableManager.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show(this, "Sai tên tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
