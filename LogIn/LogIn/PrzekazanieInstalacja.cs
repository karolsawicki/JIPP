using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Threading;

namespace LogIn
{
    public partial class PrzekazanieInstalacja : Form
    {
        public PrzekazanieInstalacja()
        {
            InitializeComponent();


        }




        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Task.Factory.StartNew
            (
             () =>
             {
                 Thread.Sleep(2000);
                 Invoke(new Action(print));
             }
            );
        }

        private void PrzekazanieInstalacja_Load(object sender, EventArgs e)
        {

        }

        
        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void print()
        {
            Thread.Sleep(2000);
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics grp = panel.CreateGraphics();
            Size formSize = this.ClientSize;
            bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
            grp = Graphics.FromImage(bitmap);
            Point panelLocation = PointToScreen(panel.Location);
            grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 0.9;
            printPreviewDialog1.ShowDialog();

        }
        Bitmap bitmap;
        private void captureScreen()
        {

            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bitmap = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bitmap);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);

        }

        public void txtNazwa_TextChanged(object sender, EventArgs e)
        {
        }
        public void daneDoProtokolu(TextBox text1, TextBox text2, TextBox text3, TextBox text4)

        {

            txtNazwa.Text = text1.Text;
            txtMarka.Text = text2.Text;
            txtModel.Text = text3.Text;
            txtSN.Text = text4.Text;
            Form3 a = new Form3();
            a.czyJestNull += new Form3.delegatWyzwalacz(a_Blad);
        }
        static void a_Blad()
        {
            MessageBox.Show("Pola nie moga byc puste");
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

    }
}
