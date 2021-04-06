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


namespace LogIn
{
    public partial class Form3 : Form
    {
        DC2 model = new DC2();
        
        public Form3()
        {
            InitializeComponent();

        }



        public event delPassData CzyNull;
        public delegate void delPassData(TextBox text1,TextBox text2, TextBox text3, TextBox text4);
        


        private void btnInstalacja_Click(object sender, EventArgs e)
        {

            //dane do bazy danych
            model.Nazwa = txtNazwa.Text.Trim(); 
            model.Marka = txtMarka.Text.Trim();
            model.Model = txtModel.Text.Trim();
            model.SerialNumber = txtSN.Text.Trim();

           
            using (gfdEntities db = new gfdEntities())
            {
                
                db.DC2.Add(model);
                db.SaveChanges();
            }
            
            wywolajPrzekazanieInstalcja();
            Wyczysc();
            wypelnijDataGridView();
            
        }
        public delegate void delegatWyzwalacz();
        public event delegatWyzwalacz czyJestNull;

     




        private void Form3_Load(object sender, EventArgs e)
        {
            Wyczysc();
            wypelnijDataGridView();
        }
        void Wyczysc()
        {
            txtNazwa.Text = txtModel.Text = txtMarka.Text = txtSN.Text = "";
            btnDeinstalacja.Enabled = false;
            model.IdSprzetu = 0;
            
            
        }
        private void btnDeinstalacja_Click(object sender, EventArgs e)
        {
            using (gfdEntities db = new gfdEntities())
            {
                var entry = db.Entry(model);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    db.DC2.Attach(model);
                    db.DC2.Remove(model);
                db.SaveChanges();
                wypelnijDataGridView();
                Wyczysc();

            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( dataGridView1.CurrentRow.Index != -1)
            {
                model.IdSprzetu = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdSprzetu"].Value);
                using (gfdEntities db = new gfdEntities())
                {
                    model = db.DC2.Where(x => x.IdSprzetu == model.IdSprzetu).FirstOrDefault();
                    txtMarka.Text = model.Marka;
                    txtModel.Text = model.Model;
                    txtNazwa.Text = model.Nazwa;
                    txtSN.Text  = model.SerialNumber;

                }
                btnDeinstalacja.Enabled = true;
            }
        }
        void wypelnijDataGridView()
        {
            using ( gfdEntities db = new gfdEntities())
            {
                dataGridView1.DataSource = db.DC2.ToList<DC2>();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
        
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        
        }

        
        
        private void button1_Click(object sender, EventArgs e)
        {
        }

        void wywolajPrzekazanieInstalcja()
        {
            PrzekazanieInstalacja frm = new PrzekazanieInstalacja();

            delPassData delegujWartosci = new delPassData(frm.daneDoProtokolu);


            delegujWartosci(this.txtNazwa, this.txtMarka, this.txtModel, this.txtSN);

            frm.Show();
        }
        


        }
}
