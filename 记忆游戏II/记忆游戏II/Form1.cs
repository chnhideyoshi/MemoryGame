using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIDE;
using System.IO;
//using System.Media;
using System.Runtime.InteropServices;
using CHNHIDEYOSHI;
//using TANYA;

namespace 记忆游戏II
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "DiamondGreen.ssk";

        }
        public Button[] picbox = new Button[65];
        public TANYA[] a =new TANYA[65];
        public int count =0;
        public int t = 0;
        private string filename = @"MyRecord.chn";
        /// <summary>
        /// sound
        /// </summary>
        public static uint SND_ASYNC = 0x0001;       //发挥异步
        public static uint SND_FILENAME = 0x00020000;//名称是文件名
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, string lpstrReturnString, uint uReturnLength, uint hWndCallback);
        private void play()
        {
            mciSendString(@"close temp_alias", null, 0, 0);
            mciSendString(@"open ""0.wma"" alias temp_alias", null, 0, 0);
            mciSendString("play temp_alias repeat", null, 0, 0);
        }
        private void playsound(int i)
        {
            string dname="1.wav";
            switch (i)
            {
                case 1:break;
                case 2: dname = "2.wav"; break;
                case 3: dname = "3.wav"; break;
            }
            FileStream fsf = new FileStream(dname, FileMode.Open);
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(fsf);
            sp.Play();
            fsf.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        private void write(int count)
        {
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            BinaryWriter w = new BinaryWriter(fs);
            w.Write(count);
            w.Close();
            fs.Close();
        }
        private int read()
        {
            FileStream fs = new FileStream(filename,FileMode.OpenOrCreate);
            BinaryReader r = new BinaryReader(fs);
            
            int s = (int)r.ReadUInt32();
            r.Close();
            fs.Close();
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Form1_Load(object sender, EventArgs e)
        {
           // a = new TANYA[65];
            play();
            picbox[1] = button1; picbox[2] = button2; picbox[3] = button3; picbox[4] = button4;
            picbox[5] = button5; picbox[6] = button6; picbox[7] = button7; picbox[8] = button8;
            picbox[9] = button9; picbox[10] = button10; picbox[11] = button11; picbox[12] = button12;
            picbox[13] = button13; picbox[14] = button14; picbox[15] = button15; picbox[16] = button16;
            picbox[17] = button17; picbox[18] = button18; picbox[19] = button19; picbox[20] = button20;
            picbox[21] = button21; picbox[22] = button22; picbox[23] = button23; picbox[24] = button24;
            picbox[25] = button25; picbox[26] = button26; picbox[27] = button27; picbox[28] = button28;
            picbox[29] = button29; picbox[30] = button30; picbox[31] = button31; picbox[32] = button32;
            picbox[33] = button33; picbox[34] = button34; picbox[35] = button35; picbox[36] = button36;
            picbox[37] = button37; picbox[38] = button38; picbox[39] = button39; picbox[40] = button40;
            picbox[41] = button41; picbox[42] = button42; picbox[43] = button43; picbox[44] = button44;
            picbox[45] = button45; picbox[46] = button46; picbox[47] = button47; picbox[48] = button48;
            picbox[49] = button49; picbox[50] = button50; picbox[51] = button51; picbox[52] = button52;
            picbox[53] = button53; picbox[54] = button54; picbox[55] = button55; picbox[56] = button56;
            picbox[57] = button57; picbox[58] = button58; picbox[59] = button59; picbox[60] = button60;
            picbox[61] = button61; picbox[62] = button62; picbox[63] = button63; picbox[64] = button64;

       
                for (int i = 1; i <= 64; i++)
                {
                    picbox[i].Image = imageList1.Images[0];
                    picbox[i].Click += new EventHandler(Clickallthebtn);
                }
           for (int i = 0; i <= 64; i++)
          {
               a[i] = new TANYA();
           }
            setchao();
            
           // BinaryWriter s = new BinaryWriter(fs);
            //s.Write(99999);
            //s.Close();
            //fs.Close();
            label2.Text = "你的最少步数记录是" + read() ;
            
        


        }

        void Clickallthebtn(object sender, EventArgs e)
        {
            string s = ((Button)sender).Name;
            s=s.Remove(0, 6);
            int num = int.Parse(s);
            action(num);
            //throw new NotImplementedException();
        }
        private int abs(int a)
        {
            if(a<0)
                return -a;
            return a;
        }
        private int check(TANYA[] a)
        {
            for (int i = 1; i <= 64; i++)
            {
                if (a[i].first)
                { return i; }
            }
            return -1;
        }
        private void show(int i)
        {
            picbox[i].Image = imageList1.Images[a[i].picnum];
        }

        private void setchao()
        {
            int s = 64;
            int j = 1;
            int[] b =new int[65]; //{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            for (int y = 0; y <= 64; y++)
            {
                b[y] = y;
            }
                for (int i = 1; i <= 64; i++)
                {
                    Random r = new Random();
                    int temp = r.Next(1, s);
                    a[j].picnum = b[temp];
                    b[temp] = 0;
                    int temp2 = b[s];
                    b[s] = b[temp];
                    b[temp] = temp2;
                    s--;
                    j++;
                }
            //label1.Text = a[1].picnum + " " + a[2].picnum + " " + a[3].picnum + " " + a[4].picnum + " " + a[5].picnum + " " + a[6].picnum + " " + a[7].picnum + " " + a[8].picnum + " " + a[9].picnum + " " + a[10].picnum + " " + a[11].picnum + " " + a[12].picnum + " " + a[13].picnum + " " + a[14].picnum + " " + a[15].picnum + " " + a[16].picnum;

        }
        private bool allchecked()
        {
            for (int i = 1; i <= 64; i++)
            {
                if (a[i].haschecked == false)
                {
                    return false;
                }
            }
            return true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void action(int i)
        {
           // playsound(3);
            int s = check(a);
            if (s == -1)
            {
                a[i].firstop();
                show(i);
            }
            else
            {
                count++;
                label1.Text = "步数：" + count;
                show(i);
                if(abs(a[i].picnum-a[s].picnum)==32)
                {
                    a[i].then(a[s]);
                    picbox[i].Enabled = false;
                    picbox[s].Enabled = false;
                    playsound(1);
                    richTextBox1.Text = new Name().getname(a[i].picnum)+"被揪出来啦！\n"+richTextBox1.Text;
                }
                else
                {
                    //playsound(3);
                    a[s].first = false;
                    timer1.Start();
                   //waitandchange();
                }
            }

            if (allchecked())
            {
                    MessageBox.Show("你胜利了，步数是" + count);
                    playsound(2);
                    if(read()>count)
                    {
                        write(count);
                        label2.Text = "你的最少步数记录是" + count;
                    }
                    
             }
            

        }
        /// <summary>
        /// butclk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;
            if (t == 2)
            {
                t = 0;
                for (int i = 1; i <= 64; i++)
                {
                    if (a[i].haschecked==false&&a[i].first==false)
                    {
                        picbox[i].Image = imageList1.Images[0];
                    }
                }
                timer1.Stop();
            }
            
            //
        }
         

       
        private void button65_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://user.qzone.qq.com/372048647/blog/1256297473");
        }
        ///

    }
}
