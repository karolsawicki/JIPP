using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows;
namespace LogIn
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
        }

        public void textBox2_TextChanged_1(object sender, EventArgs e)//user z4112019 wwsiz411
        {

        }

        public void textBox3_TextChanged(object sender, EventArgs e)//haslo wwsiz411
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {


            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=abd.wwsi.edu.pl;Initial Catalog=!Z4112019;User ID=" + textBox2.Text + ";Password=" + textBox3.Text + ";";
            try
            {
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                timer1.Start();
                cnn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd Logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

                textBox2.Clear();
                textBox3.Clear();
                textBox2.Focus();
                
            }



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.0)
            {
                this.Opacity -= 0.025;
            }
            else
            {
                timer1.Stop();
                this.Hide();
                MainForm Menu = new MainForm();
                Menu.Show();
            }


        }
       




    }
}


