using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_HastaneRendevu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
          List<Branş> branslist = new List<Branş>();
        public static List<Doktor> doktorlist = new List<Doktor>();
        List<HastaBilgi> hastalist = new List<HastaBilgi>();


        private void btnBransEkle_Click(object sender, EventArgs e)
        {
           cmbBrans.Items.Clear();
           comboBox1.Items.Clear();

           Branş brans = new Branş();
           brans.BransAd = txtBrans.Text;
           branslist.Add(brans);
           MessageBox.Show(brans.ToString() + " adlı branş eklendi");
            
            foreach(Branş branş in branslist)
            {
                cmbBrans.Items.Add(branş);
                comboBox1.Items.Add(branş);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Doktor doktor = new Doktor();
            doktor.AdSoyad = txtDoktorAd.Text;
            doktor.BransAd = cmbBrans.Text;
          

            doktorlist.Add(doktor);
            
            
            MessageBox.Show(doktor.ToString() + " adlı doktor eklendi. Branş: " + doktor.BransAd);

            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
              
                comboBox2.Items.Clear();

            
                foreach(Doktor doktor in doktorlist)
                {
                   if (doktor.BransAd == comboBox1.Text)
                {
                      comboBox2.Items.Add(doktor);
                }
                     
                }
               
            

        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int saat = 9;
            int saatbucuk = 30;
            flowLayoutPanel1.Controls.Clear();
            if (dateTimePicker1.Value <= DateTime.Now)
            {
                MessageBox.Show("Lütfen ileri tarih seçiniz");
            }

            else
            {
                for (int i = 1; i <=10; i++)
                {
                    Button b = new Button();
                    b.Width = 50;
                    b.Height = 30;
                    b.Text = (saat++).ToString() + ":" + (saatbucuk).ToString();
                    this.flowLayoutPanel1.Controls.Add(b);
                    b.Click += B_Click;
                }
            }

           
        }

        private void B_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            HastaBilgi hastaBilgi = new HastaBilgi();
            hastaBilgi.TCKN = textBox1.Text;
            hastaBilgi.HastaAd = textBox2.Text;
            hastaBilgi.HastaSoyad = textBox3.Text;
            hastalist.Add(hastaBilgi);

            foreach (HastaBilgi hasta in hastalist)
            {
                foreach(Doktor doktor in doktorlist)
                {
                    MessageBox.Show( "Randevu Tarihiniz "+ dateTimePicker1.Value.ToShortDateString()  + " Seçtiğiniz Saat:" + b.Text  + "\n" +"Hasta Adı: " + hasta.HastaAd + " Hasta Soyadı: " + hasta.HastaSoyad +" Hasta TCKN: " + hasta.TCKN + "\n" + "Doktor: " + comboBox2.Text + " Branş: " + comboBox1.Text);
                }
                 
            }
            
            b.BackColor = Color.Red;
        }


    }
}
