using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prayer
{
    public partial class Form1 : Form
    {
        int Counter = 0;
        int progress = 0;
        Random rand= new Random();
        public Form1()
        {
            InitializeComponent();
            timer1.Interval= (Convert.ToInt32(txtNumberOfPrayers.Text) * 1000);
           
        }

        string TextGenerator()
        {
            string[] prayers = new string[]
            {
        "الله أكبر",
        "سبحان الله",
        "الحمد لله",
        "لا إله إلا الله",
        "أستغفر الله",
        "اللهم صل على سيدنا محمد",
        "رب اغفر لي ولوالدي",
        "اللهم إني أعوذ بك من الهم والحزن والعجز والكسل والفقر والجوع والجبن والبخل وغلبة الدين وقهر الرجال",
                // Add your own custom prayer messages here
            };

            string prayer = prayers[Counter]; 
            Counter++; 

            
            if (Counter >= prayers.Length)
            {
                Counter = 0;
            }

            return prayer;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            notifyIcon1.Icon = SystemIcons.Information;
            notifyIcon1.BalloonTipText = TextGenerator();
            notifyIcon1.ShowBalloonTip(10);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer1.Interval = (Convert.ToInt32(txtNumberOfPrayers.Text) * 1000);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progress++;
            label1.Text = progress.ToString();
            


            if (progress==timer1.Interval/1000)
            {
                
                progress = 0;
            }
            
        }
        void Clear()
        {
            timer1.Stop();
            timer2.Stop();
            label1.Text = "0";
            progress = 0;
        }
        private void txtNumberOfPrayers_TextChanged(object sender, EventArgs e)
        {
            Clear();
            if (txtNumberOfPrayers.Text == "")
            {
                txtNumberOfPrayers.Text = "10";
            }
            timer1.Interval = (Convert.ToInt32(txtNumberOfPrayers.Text) * 1000);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

    

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
