using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clock
{
    public partial class FormAnalogClock : Form
    {
        Timer timer = new Timer();        
        Bitmap bmp;
        Graphics graph;
        //definicja kolorów
        Pen penSec = new Pen(Color.White, 1f);
        Pen penMin = new Pen(Color.White, 3f);
        Pen penHour = new Pen(Color.White, 6f);
        //wymiary okna
        static int width = 400;
        static int height = 400;
        SetClock setClock = new SetClock(width/2, height/2);
        //point center
        int cx, cy;               

        public FormAnalogClock()
        {
            InitializeComponent();
            bmp = new Bitmap(width, height);
            
            //background color
            pictureBox1.BackColor = Color.Black;
            graph = Graphics.FromImage(bmp);
            //lokalizacja okna z dniem misiąca
            lbdate.Location = new Point(360, height/2+18);

        }

        private void FormAnalogClock_Load(object sender, EventArgs e)
        {
            //środek zegara
            cx = (width / 2);
            cy = (height / 2);
           
            //timer interval
            timer.Interval = 1000;
            timer.Tick += new EventHandler(this.timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //przypisanie danych czasu do zmiennych
            int sec = DateTime.Now.Second;
            int min = DateTime.Now.Minute;
            int hour = DateTime.Now.Hour;
            int day = DateTime.Today.Day;

            //clear pictureBox
            graph.Clear(Color.Black);
           
            //pobranie danych do wyświetlania wskazówki (sekundy)
            int[] pointSec = setClock.SecSetHandOfAClock(140, sec);
            //wyswietlenie wskazówki w danym momencie
            graph.DrawLine(penSec, new Point(cx, cy), new Point(pointSec[0],pointSec[1]));
            //pobranie danych do wyświetlania wskazówki (minuty)
            int[] pointMin = setClock.SecSetHandOfAClock(150, min);
            graph.DrawLine(penMin, new Point(cx, cy), new Point(pointMin[0], pointMin[1]));
            //pobranie danych do wyświetlania wskazówki (godziny)
            int[] pointHour = setClock.HourSetHandOfAClock(100, min, hour);
            graph.DrawLine(penHour, new Point(cx, cy), new Point(pointHour[0], pointHour[1]));

            //wyswietlenie 60 kresek dookoła zegara
            for (int i = 0; i < 60; i++)
            {
                //początek linii
                int[] pointLineS = setClock.SecSetHandOfAClock(188, i);
                //koniec linii
                int[] pointLineF = setClock.SecSetHandOfAClock(194, i);
                //rysowanie linii
                graph.DrawLine(penMin, new Point(pointLineS[0], pointLineS[1]), new Point(pointLineF[0], pointLineF[1]));
            }

            //wyswietlenie cyfr na zegarze
            for (int i = 1; i < 13; i++)
            {
                //pobranie pozycji każdej godziny
                int[] pointStrHr = setClock.SetHourString(175, i);
                //zmiana godziny z int na string
                string strHr = i.ToString();
                //wyświetlenie danej godziny
                graph.DrawString(strHr, new Font("Arial", 18, FontStyle.Bold), Brushes.White, new Point(pointStrHr[0]-12, pointStrHr[1]-12));
                
            }

            //BackColor 'label' dla dnia miesiąca
            lbdate.BackColor = Color.White;
            //przypisanie wartości do 'label' 
            lbdate.Text = day.ToString();
            //rozpączęcie wyświetlania 'label'
            lbdate.Visible = true;
            //przypisanie danych do pictureBox
            pictureBox1.Image = bmp;           
        }

               
        
    }
}
