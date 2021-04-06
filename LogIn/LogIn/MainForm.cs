using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 Menu = new Form3();
            Menu.Show();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.Size = new Size(155, 55);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Size = new Size(150, 50);
        }
    }
}
