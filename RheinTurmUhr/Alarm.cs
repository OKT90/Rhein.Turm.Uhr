using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace RheinTurmUhr
{
    public partial class Alarm : Form
    {
        Timer t = new Timer();
        int WIDTH = 300, HEIGHT = 300, secHAND = 140, minHAND = 110, hrHAND = 80;

        System.Timers.Timer myTimer;
        SoundPlayer myPlayer = new SoundPlayer();
        delegate void upDateLable(Label MyLabel, string value);
        //center
        int cx, cy;

        Bitmap bmp;
        Graphics graphics;
        
        public Alarm()
        {
            InitializeComponent();
        }
        // by Loading the Form
        private void Alarm_Load(object sender, EventArgs e)
        {
            //create bitmap
            bmp = new Bitmap(WIDTH + 1, HEIGHT + 1);

            //center
            cx = WIDTH / 2;
            cy = HEIGHT / 2;

            //backcolor
            this.BackColor = Color.Black;

            //timer
            t.Interval = 1000;      //in millisecond
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
            //Elapsed is an event
            myTimer = new System.Timers.Timer(1000);
            myTimer.Elapsed += timerElapsed;
        }
        private void t_Tick(object sender, EventArgs e)
        {
            //create graphics
            graphics = Graphics.FromImage(bmp);

            //get time
            int ss = DateTime.Now.Second;
            int mm = DateTime.Now.Minute;
            int hh = DateTime.Now.Hour;

            int[] handCoord = new int[2];

            //clear
            graphics.Clear(Color.Black);

            //draw circle
            graphics.DrawEllipse(new Pen(Color.White, 1f), 0, 0, WIDTH, HEIGHT);

            //draw figure
            graphics.DrawString("12", new Font("Arial", 12), Brushes.Red,new PointF(140, 2));
            graphics.DrawString("1", new Font("Arial", 12), Brushes.White, new PointF(215, 20));
            graphics.DrawString("2", new Font("Arial", 12), Brushes.White, new PointF(262, 62));
            graphics.DrawString("3", new Font("Arial", 12), Brushes.Red, new PointF(286, 140));
            graphics.DrawString("4", new Font("Arial", 12), Brushes.White, new PointF(270, 209));
            graphics.DrawString("5", new Font("Arial", 12), Brushes.White, new PointF(215, 260));
            graphics.DrawString("6", new Font("Arial", 12), Brushes.Red, new PointF(142, 282));
            graphics.DrawString("7", new Font("Arial", 12), Brushes.White, new PointF(60, 258));
            graphics.DrawString("8", new Font("Arial", 12), Brushes.White, new PointF(12, 202));
            graphics.DrawString("9", new Font("Arial", 12), Brushes.Red, new PointF(0, 140));
            graphics.DrawString("10", new Font("Arial", 12), Brushes.White, new PointF(20, 70));
            graphics.DrawString("11", new Font("Arial", 12), Brushes.White, new PointF(70, 18));

            //second hand
            handCoord = msCoord(ss, secHAND);
            graphics.DrawLine(new Pen(Color.Red, 1f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            //minute hand
            handCoord = msCoord(mm, minHAND);
            graphics.DrawLine(new Pen(Color.White, 2f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            //hour hand
            handCoord = hrCoord(hh % 12, mm, hrHAND);
            graphics.DrawLine(new Pen(Color.White, 3f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            //load bmp in picturebox1
            pictureBox1.Image = bmp;

            //disp time
            this.Text =  hh + ":" + mm + ":" + ss;

            //dispose
            graphics.Dispose();
        }

        //coord for minute and second hand
        private int[] msCoord(int val, int hlen)
        {
            int[] coord = new int[2];
            val *= 6;   //each minute and second make 6 degree

            if (val >= 0 && val <= 180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return coord;
        }

        //coord for hour hand
        private int[] hrCoord(int hval, int mval, int hlen)
        {
            int[] coord = new int[2];

            //each hour makes 30 degree
            //each min makes 0.5 degree
            int val = (int)((hval * 30) + (mval * 0.5));

            if (val >= 0 && val <= 180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return coord;
        }

        // UpDateDataLable Method
        void upDateDataLable(Label myLabel, string value)
        {
            myLabel.Text = value;
        }
        // TimerElapsed Method
        private void timerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour == AlarmTimeSetting.Value.Hour && DateTime.Now.Minute == AlarmTimeSetting.Value.Minute && DateTime.Now.Second == AlarmTimeSetting.Value.Second)
            {
                myTimer.Stop();
                try
                {
                    upDateLable upDate = upDateDataLable;
                    if (Statuslabel.InvokeRequired)
                    {
                        if (Statuslabel.Text == "Läuft.....")
                        {
                            Invoke(upDate, Statuslabel, "Klingelt!!!!");
                        }
                        else if (Statuslabel.Text == "Running.....")
                        {
                            Invoke(upDate, Statuslabel, "Ring!!!!");
                        }
                        else if (Statuslabel.Text == ".....جاري التحميل")
                        {
                            Invoke(upDate, Statuslabel, "!!!!يرن");
                        }
                        
                    }
                        myPlayer.SoundLocation = @"Sound.wav";
                    myPlayer.PlayLooping();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message , "Message" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                }
            }
        }
        // StartBottunFunction Method
        private void startBottunFunction(object sender, EventArgs e)
        {
           
            if(Statuslabel.Text == "Status")
            {
                myTimer.Start();
                Statuslabel.Text = "Läuft.....";
            }
            else if (Statuslabel.Text == "status")
            {
                myTimer.Start();
                Statuslabel.Text = "Running.....";
            }
            else if (Statuslabel.Text == "حالة المنبة")
            {
                myTimer.Start();
                Statuslabel.Text = ".....جاري التحميل";
            }

        }
        // StopBottunFunction Method
        private void stopBottunFunction(object sender, EventArgs e)
        {

            if (Statuslabel.Text == "Klingelt!!!!")
            {
                myTimer.Stop();
                Statuslabel.Text = "Beendet";
                myPlayer.Stop();
            }
            else if (Statuslabel.Text == "Ring!!!!")
            {
                myTimer.Stop();
                Statuslabel.Text = "finished";
                myPlayer.Stop();
            }
            else if (Statuslabel.Text == "!!!!يرن")
            {
                myTimer.Stop();
                Statuslabel.Text = "انتهى";
                myPlayer.Stop();
            }
            
        }
        // End Method
        private void End(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
//using System;
//public class Test
//{
//    public delegate int CalculationHandler(int x, int y);
//    static void Main(string[] args)
//    {
//        Math math = new Math();
//        //create a new instance of the delegate class

//        CalculationHandler sumHandler = new CalculationHandler(math.Sum);
//        //invoke the delegate
//        int result = sumHandler(8, 9);
//        Console.WriteLine("Result is: " + result);
//    }
//}

//public class Math
//{
//    public int Sum(int x, int y)
//    {
//        return x + y;
//    }
//}