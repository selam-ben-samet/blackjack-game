using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJeck
{
    public partial class anamenu : Form
    {
       public static  SoundPlayer muzik = new SoundPlayer();
        int para = 0;
        public anamenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            anaoyun oyun = new anaoyun();
            oyun.ShowDialog();
            this.Close();



        }

        private void anamenu_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (para)
            {
                case 0:
                    pictureBox3.Visible = true;
                    para++;
                    break;
                case 1:
                    pictureBox2.Visible = true;
                    para++;
                    break;
                case 2:
                    pictureBox4.Visible = true;
                    para++;
                    break;
                case 3:
                    pictureBox5.Visible = true;
                    para++;
                    break;
                case 4:
                    pictureBox8.Visible = true;
                    para++;
                    break;
                case 5:
                    pictureBox9.Visible = true;
                    para++;
                    break;
                case 6:
                    pictureBox6.Visible = true;
                    para++;
                    break;
                case 7:
                    pictureBox7.Visible = true;
                    para++;
                    break;
                case 8:
                    pictureBox16.Visible = true;
                    para++;
                    break;
                case 9:
                    pictureBox14.Visible = true;
                    para++;
                    break;
                case 10:
                    pictureBox15.Visible = true;
                    para++;
                    break;
                case 11:
                    pictureBox12.Visible = true;
                    para++;
                    break;
                case 12:
                    pictureBox13.Visible = true;
                    para++;
                    break;
                case 13:
                    pictureBox10.Visible = true;
                    para++;
                    break;
                case 14:
                    pictureBox11.Visible = true;
                    para++;
                    break;
                case 15:
                    pictureBox17.Visible = false;
                    para++;
                    break;

            }
            if (para == 16)
            {
                Task.Delay(500);
            timer1.Stop();
            panel1.Visible = false;
                muzik.SoundLocation = "theme.wav";
                muzik.PlayLooping();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel2.Dock = DockStyle.Fill;
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
           if(pictureBox19.Visible == true)
            {
                pictureBox19.Visible = false;
                muzik.Stop();
                pictureBox20.BringToFront();
                pictureBox20.Visible = true;
            }
           

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            if (pictureBox20.Visible == true)
            {
                pictureBox20.Visible = false;
                muzik.PlayLooping();
                pictureBox19.BringToFront();
                pictureBox19.Visible = true;
            }
        }
    }
}
