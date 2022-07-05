using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;
using System.Threading;
namespace BlackJeck
{
   
    public partial class anaoyun : Form
    {
        
        public int animationSifirlama = 0;
        public String secilen;
        public int bahis;
        SoundPlayer soundPlayer = new SoundPlayer();
        // destemizi liste olarak oluşturuyoruz
        List<string> Kart = new List<string>()
        {
            "KuA29.png","Ku02.png","Ku03.png","Ku04.png","Ku05.png","Ku06.png","Ku07.png","Ku08.png","Ku09.png","KuT19.png","KuJ19.png","KuQ19.png","KuK19.png",
            "KaA29.png","Ka02.png","Ka03.png","Ka04.png","Ka05.png","Ka06.png","Ka07.png","Ka08.png","Ka09.png","KaT19.png","KaJ19.png","KaQ19.png","KaK19.png",
            "SA29.png","S02.png","S03.png","S04.png","S05.png","S06.png","S07.png","S08.png","S09.png","ST19.png","SJ19.png","SQ19.png","SK19.png",
            "MA29.png","M02.png","M03.png","M04.png","M05.png","M06.png","M07.png","M08.png","M09.png","MT19.png","MJ19.png","MQ19.png","MK19.png"
        };
        // oyuncunun ve kurpiyerin elini tutucak listeleri oluşturuyoruz
        List<string> oyuncueli = new List<string>(); 
        List<string> kurpiyereli = new List<string>(); 
       
        // değişkenlerimiz
        int oyuncudeger = 0; // oyuncu eli toplamı
        int kurpiyerdeger = 0; // kurpiyer eli toplamı
        int oyuncucekilensayac = 0; //oyuncu kac kart cekti
        
        bool asVarMi = false; // as var mı kontrol
        

        // random
        Random random = new Random();

        #region methodlar
       
        public void animationCard()
        {
            pictureBox13.Left -= 8;
            pictureBox13.Top += 3;
            
        }
        int bahisIste()
        {
            bahis bahis =  new bahis();
            bahis.ShowDialog();
            
            label9.Text = (int.Parse(label9.Text) - bahis.oynananBahis).ToString();
            return bahis.oynananBahis;
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Dock = DockStyle.Fill;
            anamenu.muzik.SoundLocation = "theme.wav";
            anamenu.muzik.PlayLooping();
            button1.Visible = false; 
            button2.Visible = false;
        }
        void button3bizim()
        {
            oyuncudeger = 0;
            kurpiyerdeger = 0;
            oyuncueli.Clear();
            kurpiyereli.Clear();
            oyuncucekilensayac = 0;

            button1.Visible = true;
            button2.Visible = true;
            elDagit();
        }
        void kurpiyerKartBuguDuzelt()
        {
            if (pictureBox5.ImageLocation == null) pictureBox5.Visible = false;
            if (pictureBox6.ImageLocation == null) pictureBox6.Visible = false;
            if (pictureBox15.ImageLocation == null) pictureBox15.Visible = false;
            if (pictureBox16.ImageLocation == null) pictureBox16.Visible = false;
        }
        int degerHesapla(List<string> hesaplanan)
        {
            int atanan=0;asVarMi = false;
            foreach (string kart in hesaplanan)
            {
                
                if(int.Parse(kart[kart.Length - 5].ToString()) + int.Parse(kart[kart.Length - 6].ToString()) == 11)
                {
                    asVarMi = true;
                }
                    
                atanan += int.Parse(kart[kart.Length - 5].ToString()) + int.Parse(kart[kart.Length - 6].ToString());
               
            }
            if (atanan > 21 && asVarMi) atanan -= 10;
            return atanan;
        }
        
    void elDagit() // oyuncuuya ve kurpiyere 2 kart verir baslangicta
        {
            pictureBox3.Visible = false; pictureBox4.Visible = false; 
            pictureBox6.Visible = false; pictureBox5.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            oyuncueli.Add(Kart[random.Next(Kart.Count)]);
            oyuncueli.Add(Kart[random.Next(Kart.Count)]); 
            kurpiyereli.Add(Kart[random.Next(Kart.Count)]);
            pictureBox1.ImageLocation = "..\\..\\cardstyle/" + secilen+"/"+oyuncueli[0];
            pictureBox2.ImageLocation = "..\\..\\cardstyle/" + secilen + "/" + oyuncueli[1];
            pictureBox8.ImageLocation = "..\\..\\cardstyle/" + secilen + "/" + kurpiyereli[0];
            pictureBox7.ImageLocation = "..\\..\\cardstyle/" + secilen + "/" + "arka.png";
            oyuncudeger = degerHesapla(oyuncueli); kurpiyerdeger = degerHesapla(kurpiyereli);
            label3.Text = oyuncudeger.ToString();label6.Text = kurpiyerdeger.ToString();
        }

        void kartCek()
        { 
                
                if(oyuncudeger < 21)
                { 
                    oyuncueli.Add(Kart[random.Next(Kart.Count)]);
                }
            
            
           
        }
        void kurpiyerOynar()
        {
            List<PictureBox> kurpiyerDeste = new List<PictureBox>()
            {
                pictureBox8,pictureBox7,pictureBox6,pictureBox5,pictureBox16,pictureBox15
            };
            int i = 1;
            while (true)
            {
                if (i == 1 ) pictureBox6.Visible = true;
                if (i == 2 ) pictureBox5.Visible = true;
                if (i == 3 ) pictureBox16.Visible = true;
                if(i == 4) pictureBox15.Visible = true;
                kurpiyereli.Add(Kart[random.Next(Kart.Count)]);
                kurpiyerDeste[i].ImageLocation = "..\\..\\cardstyle/" + secilen + "/" + kurpiyereli[kurpiyereli.Count - 1];
                
                kurpiyerdeger = degerHesapla(kurpiyereli);
                label6.Text = kurpiyerdeger.ToString();
                if (kurpiyerdeger < 17) i++;
                else break;
            }
            if (oyuncudeger > 21)
            {
                kurpiyerKartBuguDuzelt();
                soundPlayer.SoundLocation = "lost.wav";
                soundPlayer.Play();
                DialogResult cevap = MessageBox.Show("You lost!", "Game over", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);

                if (cevap == DialogResult.Retry)
                {
                    bahis = bahisIste();
                    button3bizim();
                }

            }
            else if (kurpiyerdeger > 21)
            {
                kurpiyerKartBuguDuzelt();
                soundPlayer.SoundLocation = "won.wav";
                soundPlayer.Play();
                DialogResult cevap = MessageBox.Show("You won!", "Game over", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                label9.Text = (int.Parse(label9.Text) + (bahis * 2)).ToString();
                if (cevap == DialogResult.Retry)
                {
                   bahis = bahisIste();
                    button3bizim();
                }
            }
            else if (oyuncudeger == kurpiyerdeger)
            {
                kurpiyerKartBuguDuzelt();
                soundPlayer.SoundLocation = "draw.wav";
                soundPlayer.Play();
                DialogResult cevap = MessageBox.Show("Draw!", "Game over", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                label9.Text = (int.Parse(label9.Text) + (bahis)).ToString();
                if (cevap == DialogResult.Retry)
                {
                    bahis =  bahisIste();
                    button3bizim();
                }
                    
            }
            else if (oyuncudeger <= 21 && oyuncudeger > kurpiyerdeger)
            {
                kurpiyerKartBuguDuzelt();
                soundPlayer.SoundLocation = "won.wav";
                soundPlayer.Play();
                DialogResult cevap = MessageBox.Show("You won!", "Game over", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                label9.Text = (int.Parse(label9.Text) + (bahis * 2)).ToString();
                if (cevap == DialogResult.Retry)
                {
                    bahis = bahisIste();
                    button3bizim();

                }
            }
            else
            {
                kurpiyerKartBuguDuzelt();
                soundPlayer.SoundLocation = "lost.wav";
                soundPlayer.Play();
                DialogResult cevap = MessageBox.Show("You lost!", "Game over", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                if (cevap == DialogResult.Retry)
                {
                    bahis = bahisIste();
                    button3bizim();
                }
            }

        }
        #endregion

        public anaoyun()
        {
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bahis = bahisIste();
           
            button3bizim();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            soundPlayer.SoundLocation = "kartverme.wav";
            soundPlayer.Play();
            timer1.Enabled = true;

            if (oyuncucekilensayac == 0)
            {
                kartCek();
                
                pictureBox3.Visible = true;
                pictureBox3.ImageLocation = "..\\..\\cardstyle/" + secilen + "/" + oyuncueli[oyuncueli.Count - 1];
                oyuncudeger = degerHesapla(oyuncueli); label3.Text = oyuncudeger.ToString();
                oyuncucekilensayac++;
            }else if(oyuncucekilensayac == 1)
            {
                kartCek(); 
                pictureBox4.Visible = true;
                pictureBox4.ImageLocation = "..\\..\\cardstyle/" + secilen + "/" + oyuncueli[oyuncueli.Count - 1];
                oyuncudeger = degerHesapla(oyuncueli); label3.Text = oyuncudeger.ToString();
                oyuncucekilensayac++;
            }
            
            else if (oyuncucekilensayac == 2)
            {
                kartCek(); 
                pictureBox12.Visible = true;
                pictureBox12.ImageLocation = "..\\..\\cardstyle/" + secilen + "/" + oyuncueli[oyuncueli.Count - 1];
                oyuncudeger = degerHesapla(oyuncueli); label3.Text = oyuncudeger.ToString();
                oyuncucekilensayac++;
            }
            else if (oyuncucekilensayac == 3)
            {
                kartCek(); 
                pictureBox11.Visible = true;
                pictureBox11.ImageLocation = "..\\..\\cardstyle/" + secilen + "/" + oyuncueli[oyuncueli.Count - 1];
                oyuncudeger = degerHesapla(oyuncueli); label3.Text = oyuncudeger.ToString();
                oyuncucekilensayac++;
            }
            if (oyuncudeger == 21)
            {
                button2.Visible = false;
                button1.Visible = false;
                kurpiyerOynar();
            }
            else if (oyuncudeger > 21)
            {
                button2.Visible = false;
                button1.Visible = false;
                soundPlayer.SoundLocation = "lost.wav";
                soundPlayer.Play();
                DialogResult cevap = MessageBox.Show("You lost!", "Game over", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                if (cevap == DialogResult.Retry)
                {
                    bahis = bahisIste();
                    button3bizim();
                }

                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kurpiyerOynar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            secilen = "standart";
            pictureBox13.ImageLocation = "..\\..\\cardstyle/" + secilen + "/arka.png";
            pictureBox9.ImageLocation = "..\\..\\cardstyle/" + secilen + "/" + "deste.png";
            panel1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            secilen = "golden";
            pictureBox13.ImageLocation = "..\\..\\cardstyle/" + secilen + "/arka.png";
            pictureBox9.ImageLocation = "..\\..\\cardstyle/" + secilen + "/" + "deste.png";
            panel1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            anamenu anamenu = new anamenu();
            anamenu.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            anamenu anamenu = new anamenu();
            anamenu.Close();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            /*
             * Mavi
Kırmızı
Beyaz
Siyah
Pembe
Yeşil
            */
            switch (domainUpDown1.Text)
            {
                case "Blue":
                    BackgroundImage = null;
                    this.BackColor = System.Drawing.Color.FromArgb(0, 122, 255);
                    this.ForeColor = System.Drawing.Color.Yellow;
                    break;
                case "Red":
                    BackgroundImage = null;
                    this.BackColor = System.Drawing.Color.FromArgb(255, 0, 17);
                    this.ForeColor = System.Drawing.Color.Yellow;
                    break;
                case "White":
                    BackgroundImage = null;
                    this.BackColor = System.Drawing.Color.FromArgb(255,255,255);
                    this.ForeColor = System.Drawing.Color.Black;
                    break;
                case "Black":
                    BackgroundImage = null;
                    this.BackColor = System.Drawing.Color.FromArgb(0,0,0);
                    this.ForeColor = System.Drawing.Color.White;
                    break;
                case "Pink":
                    BackgroundImage = null;
                    this.BackColor = System.Drawing.Color.FromArgb(255, 0, 167);
                    this.ForeColor = System.Drawing.Color.Yellow;
                    break;
                case "Green":
                    BackgroundImage = null;
                    this.BackColor = System.Drawing.Color.FromArgb(0, 51, 20);
                    this.ForeColor = System.Drawing.Color.Yellow;
                    break;
                case "Picture 1":
                    this.BackgroundImage = Properties.Resources.ARKA1;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    this.ForeColor = System.Drawing.Color.Yellow;
                    break;
                case "Picture 2":
                    this.BackgroundImage = Properties.Resources.ARKA3;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    this.ForeColor = System.Drawing.Color.Blue;
                    break;
                case "Picture 3":
                    this.BackgroundImage = Properties.Resources.ARKA6;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    this.ForeColor = System.Drawing.Color.Yellow;
                    break;
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            animationSifirlama++;
            if ( animationSifirlama < 15) animationCard();
            else
            {
                timer1.Stop();
                animationSifirlama = 0;
                pictureBox13.Location = pictureBox9.Location;
                pictureBox13.Left -= 5;
            }
            
        }

       
    }
}
