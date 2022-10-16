using System;
using System.Windows.Forms;

namespace StockMaster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            openFileDialog_FindData.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            button_Next.Enabled = false;
        }

        private void linkLabel_FinamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel_FinamLink.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.finam.ru/profile/moex-akcii/gazprom/export/");
        }

        private void button_Browse_Click(object sender, EventArgs e)
        {
            if (openFileDialog_FindData.ShowDialog() == DialogResult.Cancel)
                return;

            textBox_Path.Text = openFileDialog_FindData.FileName;
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(textBox_Path.Text);
            form.Show();
        }

        private void textBox_Path_TextChanged(object sender, EventArgs e)
        {
            button_Next.Enabled = textBox_Path.Text != "";
        }
    }
}
