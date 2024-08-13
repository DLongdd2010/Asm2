using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Assignment2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string Account = tbxAccount.Text;
            string Password = tbxPassword.Text;

            var user = UserStorage.Users.FirstOrDefault(u => u.account == Account && u.password == Password);
            if (user != null)
            {
                MessageBox.Show("Login successful!","Success");
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect login information!","Error!");
                return;
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
