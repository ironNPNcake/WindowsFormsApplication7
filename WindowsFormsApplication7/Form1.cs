using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {

        List<Button> przyciski = new List<Button>(4);
        int nadKtorym = 1;
        bool kontrola = false;
        public Form1()
        {
            InitializeComponent();
            przyciski.Add(new Button());
            przyciski.Add(new Button());
            przyciski.Add(new Button());
            przyciski.Add(new Button());
        }
        string[] wejsciowyString = new string[4];
        string[] pierwszyS, drugiS, trzeciS, czwartyS;

        private void ustawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);

            for (int i = 0; i < 4; i++)
            {
                this.Controls.Add(przyciski[i]);

            }
            przyciski[0].Location = new Point(0, t1); przyciski[0].Width = w1;
            przyciski[0].Width = w2; przyciski[1].Location = new Point(przyciski[0].Location.X + przyciski[0].Width, t2);
            przyciski[1].Width = w3; przyciski[2].Location = new Point(przyciski[1].Location.X + przyciski[1].Width, t3);
            przyciski[2].Width = w4; przyciski[3].Location = new Point(przyciski[2].Location.X + przyciski[2].Width, t4);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (przyciski[0].Location.Y + przyciski[0].Height < przyciski[3].Top)
            {
                if (przyciski[0].Location.Y + przyciski[0].Height < przyciski[nadKtorym].Location.Y)
                    przyciski[0].Location = new Point(przyciski[0].Left, przyciski[0].Top + 1);
                //if (przyciski[0].Location.Y+przyciski[0].Height > przyciski[nadKtorym].Location.Y) nadKtorym++;
                if (przyciski[0].Location.Y + przyciski[0].Height == przyciski[nadKtorym].Location.Y)
                    przyciski[0].Location = new Point(przyciski[0].Location.X + 1, przyciski[0].Location.Y);
                if (przyciski[0].Location.X > przyciski[nadKtorym].Location.X + przyciski[nadKtorym].Width) nadKtorym++;
            }
            else { timer1.Stop(); kontrola = true; }


        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            przyciski[0].Top += 2;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right&&kontrola==true)
                przyciski[0].Location = new Point(przyciski[0].Location.X + 10, przyciski[0].Location.Y);
            if (przyciski[0].Location.X > przyciski[3].Location.X + przyciski[3].Width)
            {
                timer2.Start();
            }

        }

        int w1, w2, w3, w4, t1, t2, t3, t4;


        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("abc.txt");
            for(int i =0;i<4;i++)
            {
                wejsciowyString[i] = sr.ReadLine();
            }
            pierwszyS = wejsciowyString[0].Split(' ');
            drugiS = wejsciowyString[1].Split(' ');
            trzeciS = wejsciowyString[2].Split(' ');
            czwartyS = wejsciowyString[3].Split(' ');
            
            t1 = int.Parse( pierwszyS[0]);
            w1 = int.Parse( pierwszyS[1]);
            t2 = int.Parse(drugiS[0]);
            w2 = int.Parse(drugiS[1]);
            t3 = int.Parse(trzeciS[0]);
            w3 = int.Parse(trzeciS[1]);
            t4 = int.Parse(czwartyS[0]);
            w4 = int.Parse(czwartyS[1]);
            //button1.Location = new Point(w1, t1);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch(keyData)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    Form1_KeyDown(this, new System.Windows.Forms.KeyEventArgs(keyData));
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
