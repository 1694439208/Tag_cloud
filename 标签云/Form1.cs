using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;


namespace 标签云
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.Cursor 
        }
        System.Drawing.Graphics this_obj { set; get; }
        Random a = new Random();
        public bool mmm { set; get; }//是否停止
        zd d = new zd();
        Bitmap b;//位图
        public bool ddd { set; get; }//判断鼠标是否移动
        public void main()
        {
            b = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            d.y_int = 1;
            Point kkk = new Point();
            kkk.X = this.Width;
            kkk.Y = this.Height;
            mmm = true;
            ArrayList list = new ArrayList();
            ArrayList list_1 = new ArrayList();
            for (int y = 0; y < 150;y++ )
            {
                zd pp = new zd();
                pp.X = a.Next(1, kkk.X);
                pp.Y = a.Next(1, kkk.Y);
                //Console.Write(a.Next(1, 628).ToString()+"\r\n");
                list.Add(pp);
            }
            int j =300;//k控制点数
                
                foreach(zd k in list)
                {
                    zd g = new zd();
                    int h=a.Next(0,4);
                    switch (h)
                    {
                        case 0:
                            g.X = k.X ;//- 1;
                            g.Y = k.Y ;//+ 1;
                            g.x_int = 0;
                            break;
                        case 1:
                            g.X = k.X;// - 1;
                            g.Y = k.Y;// - 1;
                            g.x_int = 1;
                            break;
                        case 2:
                            g.X = k.X;// + 1;
                            g.Y = k.Y;// - 1;
                            g.x_int = 2;
                            break;
                        case 3:
                            g.X= k.X ;//+ 1;
                            g.Y = k.Y;// + 1;
                            g.x_int = 3;
                            break;   
                    }
                    list_1.Add(g);
                }
                ArrayList nam = new ArrayList();
                for (int h = 0; h < j; h++)
                {
                    foreach (zd k in list_1)
                    {
                        zd kk = new zd();
                        switch (k.x_int)
                        {
                            case 0:
                                kk.X = k.X - 1;
                                kk.Y = k.Y + 1;
                                kk.x_int = 0;
                                break;
                            case 1:
                                kk.X = k.X - 1;
                                kk.Y = k.Y - 1;
                                kk.x_int = 1;
                                break;
                            case 2:
                                kk.X = k.X + 1;
                                kk.Y = k.Y - 1;
                                kk.x_int = 2;
                                break;
                            case 3:
                                kk.X = k.X + 1;
                                kk.Y = k.Y + 1;
                                kk.x_int = 3;
                                break;
                        }
                        if (k.X > this.Width || k.X < 0 || k.Y > this.Height || k.Y < 0)
                        {
                            zd dd = new zd();
                            dd.X = a.Next(1, kkk.X);
                            dd.Y = a.Next(1, kkk.Y);
                            nam.Add(dd);
                        }
                        else
                        {
                            nam.Add(kk);
                        }
                    }
                    
                    img_add(nam);
                    list_1.Clear();
                    foreach (zd k in nam)
                    { list_1.Add(k); }
                    nam.Clear();
                    Thread.Sleep(30);
                }
                list.Clear();
                //list_1.RemoveAt(list_1.Count-1);
                foreach (zd hh in list_1)
                { list.Add(hh); }
                list_1.Clear();
            
           
        }
        public void img_add(ArrayList list)
        {
            Point kkk = new Point();
            kkk.X = this.Width;
            kkk.Y = this.Height;
            Color a = Color.FromArgb(-922746881);
            try
            {
                System.Drawing.Graphics gdi = this.CreateGraphics();
                Pen col = new Pen(a, 6);
                //Pen coli = new Pen(System.Drawing.Color.White, 1);
                //col.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                //this.CreateGraphics();
                this_obj = Graphics.FromImage(b);
                this_obj.Clear(Color.Black);

                //Console.Write(d.X.ToString() + "\r\n");
                if (d.X > 0)
                {
                    ddd = true;
                    list.Add(d);
                }
                else { ddd = false; }
                foreach (zd pi in list)
                {
                    foreach (zd pii in list)
                    {

                        double l = gen((pii.X - pi.X) * (pii.X - pi.X) + (pi.Y - pii.Y) * (pi.Y - pii.Y));
                        if (l < 127)
                        {
                            double y = 250 - l * 2;
                            if (y > 255)
                            {
                                y = 255;
                            }
                            if (y < 0)
                            {
                                y = 0;
                            }
                            Color m = Color.FromArgb((int)y, 255, 255, 255);//(1191182335);
                            //Math.Ceiling(1.23);
                            Pen coli = new Pen(m, 1);
                            this_obj.DrawLine(coli, pi.X, pi.Y, pii.X, pii.Y);
                        }

                    }
                }
                foreach (zd picc in list)
                {
                    this_obj.DrawEllipse(col, picc.X, picc.Y, 5, 5);
                }
                gdi.DrawImage(b, 0, 0, b.Width, b.Height);
                this_obj.Dispose();
                gdi.Dispose();
                if (ddd == true)
                {
                    list.RemoveAt(list.Count - 1);
                }
            }
            catch (Exception e){ }
            
            
        }
        public double gen(double shu)
        {
            return Math.Sqrt(shu);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mmm = false;
            //this.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mmm = false;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Width = SystemInformation.VirtualScreen.Width;
            //this.Height = SystemInformation.VirtualScreen.Height;
            Thread s = new Thread(main);
            s.Start();
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            d.X = e.X;
            d.Y = e.Y;
            d.x_int = 0;
            d.y_int = 0;
            Console.Write("x"+e.X.ToString() + "\r\ny" + e.Y.ToString()+"\r\n");
        }
        class zd
        {
            public int X { set; get; }
            public int Y { set; get; }
            public int x_int { set; get; }
            public int y_int { set; get; }
        }
        class dong
        {
            public int x { set; get; }
            public int y { set; get; }
            public int x_int { set; get; }
            public bool bb { set; get; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main();
        }
    }
}
