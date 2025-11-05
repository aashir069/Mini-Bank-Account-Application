using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccountApp
{
    public partial class Form1 : Form
    {
        List<BankAccount> Allaccount = new List<BankAccount>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text)) 
            return;    
            BankAccount bankAccount = new BankAccount(textBox1.Text);

            Allaccount.Add(bankAccount);
            RefreshGuid();
            MessageBox.Show("Account Create Successfully");


        }
        public void RefreshGuid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Allaccount;
            textBox1.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BankAccount SelectAccount = dataGridView1.SelectedRows[0].DataBoundItem as BankAccount;
            SelectAccount.Balance += numericUpDown1.Value;
            RefreshGuid();
            numericUpDown1.Value = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BankAccount SelectAccount = dataGridView1.SelectedRows[0].DataBoundItem as BankAccount;
            if (numericUpDown1.Value > SelectAccount.Balance)
            {
                MessageBox.Show("Maximum withdraw amount reached! You cannot withdraw more than the available balance.",
                                "Insufficient Balance",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // stop further execution
            }

            SelectAccount.Balance -= numericUpDown1.Value;
            RefreshGuid();
            numericUpDown1.Value = 0;
        }
    }
}
