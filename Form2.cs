using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Assignment2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            groupBox1.Parent = pictureBox1;
            groupBox1.BackColor = Color.Transparent;
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox1 ;
            label2.BackColor = Color.Transparent;  
            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;
            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;
            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;
            label6.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;
            label8.Parent = pictureBox1;
            label8.BackColor = Color.Transparent; 
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            cboTypeOfCustomer.Items.Add("Household");
            cboTypeOfCustomer.Items.Add("Administrative agency, public services");
            cboTypeOfCustomer.Items.Add("production units");
            cboTypeOfCustomer.Items.Add("Business services");
            cboTypeOfCustomer.SelectedIndex = 0;
        }

        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            string Name = tbxCustomername.Text;
            double lastMonth = double.Parse(tbxLast.Text);
            double thisMonth = double.Parse(tbxThis.Text);
            int Toc = cboTypeOfCustomer.SelectedIndex;
            double consumption = thisMonth - lastMonth;
            double Price = 0;

            if (tbxCustomername.Text == "")
            {
                MessageBox.Show("Please enter customername!", "Error!");
                return;
            }
            if (lastMonth >= thisMonth)
            {
                MessageBox.Show("The amount of water last month must be less than the amount of water this month.", "Error!");
                return;
            }
            else if ((tbxLast.Text == "") || (tbxThis.Text == ""))
            {
                MessageBox.Show("Please enter water consumption", "Error!");
                return;
            }

            if (Toc == 0) //Household
            {
                int numberPeople = (int)nudNumberOfPeople.Value;
                consumption = consumption / numberPeople;
                if (consumption <= 10)
                {
                    Price = consumption * numberPeople * 5.793;
                }
                else if (consumption <= 20)
                {
                    Price = consumption * numberPeople * 7.052;
                }
                else if (consumption <= 30)
                {
                    Price = consumption * numberPeople * 8.699;
                }
                else if (consumption > 30)
                {
                    Price = consumption * numberPeople * 15.929;
                }
            }
            else if (Toc == 1) //Administrative agency, public services
            {
                Price = consumption * 9.955;
            }
            else if (Toc == 2) //production units
            {
                Price = consumption * 11.615;
            }
            else if (Toc == 3) //Business services
            {
                Price = consumption * 22.068;
            }

            double VAT = 0.1 * Price;
            double EPF = 0.1 * Price;
            double Total = VAT + EPF + Price;


            rtbResult.Clear();
            rtbResult.AppendText($"----------------------Bill----------------------\n");
            rtbResult.AppendText($"Customer Name: {Name}\n");
            rtbResult.AppendText($"Last month's water meter reading: {lastMonth} m3\n");
            rtbResult.AppendText($"This month's water meter reading: {thisMonth} m3\n");
            rtbResult.AppendText($"Consumption: {consumption} m3\n");
            rtbResult.AppendText($"Price: {Price} VND\n");
            rtbResult.AppendText($"VAT: {VAT} VND\n");
            rtbResult.AppendText($"EPF: {EPF} VND\n");
            rtbResult.AppendText($"Total: {Total} VND\n");



            ListViewItem item = new ListViewItem(tbxCustomername.Text);
            item.SubItems.Add(cboTypeOfCustomer.Text);
            item.SubItems.Add(tbxNumberPhone.Text);
            item.SubItems.Add(Total.ToString("F2"));
            listView.Items.Add(item);



            tbxCustomername.Clear();
            tbxLast.Clear();
            tbxThis.Clear();
            cboTypeOfCustomer.SelectedIndex = -1;
            nudNumberOfPeople.Value = nudNumberOfPeople.Minimum;
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            tbxCustomername.Clear();
            tbxNumberPhone.Clear();
            txtSearch.Clear();
            tbxLast.Clear();
            tbxThis.Clear();
            rtbResult.Clear();
            cboTypeOfCustomer.SelectedIndex = -1;
            nudNumberOfPeople.Value = nudNumberOfPeople.Minimum;
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            if (listView.Items.Count > 0)
            {
                listView.Items.Remove(listView.SelectedItems[0]);
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();
            foreach (ListViewItem item in listView.Items)
            {
                item.BackColor = SystemColors.Window; // Reset màu nền
                bool match = false;
                foreach (ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text.ToLower().Contains(searchTerm))
                    {
                        match = true;
                        break;
                    }
                }

                if (match)
                {
                    item.BackColor = Color.Yellow; // Đánh dấu các mục phù hợp
                }
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
