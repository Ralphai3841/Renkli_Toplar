using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//wwww.projevekod.com adresinden indirilmi�tir.
namespace Ball
{
    public partial class Form_top : Form
    {
        bool duraklat = false; // Sa� t�klad���m�zda duraklatma tu�u i�in gerekli de�i�kenimiz
        double hareketX = 0.0; // X konumunda edece�i hareket
        double hareketY = 0.0; // Y konumunda edece�i hareket
        double X = 0.0; // Mevcut X konumu
        double Y = 0.0; // Mevcut Y konumu
        double yercekimi = 0.1; // Z�plamas� i�in gerekli yer �ekimi de�i�keni
        Color renk; // Rengi
        Random rastgeleSayi; // Rastgele bir yerlere z�platmak i�in ve renk belirlemek i�in
                             //wwww.projevekod.com adresinden indirilmi�tir.


        public Form_top()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // Ekrana �izim yapt�rabilmek i�in
            rastgeleSayi = new Random(Environment.TickCount); // rastgele say�ya de�er verme i�lemi
            renk = Color.FromArgb(rastgeleSayi.Next(0, 255), rastgeleSayi.Next(0, 255), rastgeleSayi.Next(0, 255)); // Renk i�in rastgele say�lardan argb kodu getirme
        }
        //wwww.projevekod.com adresinden indirilmi�tir.

        private void BallForm_Paint(object sender, PaintEventArgs e)
        {
            //Formumuzun width ve height de�erleri
            Width = 25; 
            Height = 25;
            
            // Graphics s�n�f� tan�ml�yoruz.
            Graphics g = e.Graphics;
            g.Clear(Color.Cyan);//Formun backgroundunu cyan yapm��t�k cyan olan renkleri siliyoruz formdan yani arkadas� bo� g�r�necek
            g.FillPie(new SolidBrush(renk), 0, 0, Width - 1,
                      Height - 1, 0, 360);
            g.DrawArc(new Pen(Color.Black,2), 0, 0, Width - 1, Height - 1, 0, 360);
            // Ekrana bir tane yuvarlak �izdik.
        }
        //wwww.projevekod.com adresinden indirilmi�tir.

        public void Tick() // Kendi kendine yapaca�� i�lemler
        {
            if (!duraklat && !hareket) // E�er duraklatmad�ksa ve hareket etmiyorsa
            {         
                hareketY += yercekimi;  // yer�ekimi kuvvetini y de ki hareketimize ekliyoruz.
                
                X += hareketX; // mevcut x konumunu hareket etti�i x y�n�ne ekliyoruz
                Y += hareketY; // mevcut y konumunu hareket etti�i y y�n�ne do�ru ekliyoruz.
                Location = new Point((int)X, (int)Y); // Konumunu oraya getiriyoruz ve bu her �izimde ger�ekle�iyor
                
                // ekran x konumunda 0 a gelince yani sol tarafa top de�di�inde hareket x i eksi y�n�ne y yi ise ayn� y�n�nde art�r�yoruz
                if (X < 0)
                {
                    X = 0;
                    hareketX = -hareketX;
                    hareketX *= 0.75;
                    hareketY *= 0.95;
                }
                if (X > Screen.PrimaryScreen.WorkingArea.Width - 1 - Width) // Ekran�n sa��nda de�di�inde topu sol tarafa do�ru g�nderiyoruz bu olaylar x te y de bi de�i�iklik yapm�yoruz
                {
                    X = Screen.PrimaryScreen.WorkingArea.Width - 1 - Width;
                    hareketX = -hareketX;
                    hareketX *= 0.75;
                    hareketY *= 0.95;
                }
                // y konumunda a�a�� geldi�inde tekrar yukar� g�ndermek i�in 0.75 ile �arp�yoruz. x ise hangi y�nde devam ediyorsan ettiriyoruz.
                if (Y < 0)
                {
                    Y = 0;
                    hareketY = -hareketY;
                    hareketY *= 0.75;
                    hareketX *= 0.95;
                }
                if (Y > Screen.PrimaryScreen.WorkingArea.Height - 1 - Height)// yukar� y ye geldi�inde ekran� ta�mas�n diye tekrar a�a�� g�nderiyoruz bu sefer 0.8 lik bir h�zl�
                {
                    Y = Screen.PrimaryScreen.WorkingArea.Height - 1 - Height;
                    hareketY = -hareketY;
                    hareketY *= 0.8; // Bu h�zlar �ok �nemli arkada�lar buradaki de�i�iklikler toplar�n h�z�n� belirliyor
                    hareketX *= 0.95; // E�er bu h�zlar s�f�rdan k���k olmazsa topu g�remezsiniz ekranda
                }

                if (Math.Abs(hareketX) < 0.1 && Math.Abs(hareketY) < 0.5 && DateTime.Now.Second % 3 == 0 && Y > Screen.PrimaryScreen.WorkingArea.Height - 1 - Height - 40)
                {
                    Ziplama(); // En son z�plama yapt�r�yoruz ama e�er top durduysa x ve y de hareket etmiyorsa 3 saniye i�erisinde geri z�plat
                }
            }
        }
        //wwww.projevekod.com adresinden indirilmi�tir.

        bool hareket = false;//mouseyle durdurmak i�in
        Point rel = new Point(); // tutunca mouseyle beraber gelsin
        private void BallForm_MouseUp(object sender, MouseEventArgs e) // topa t�klad���m�z anda
        {
            if (e.Button == MouseButtons.Left) // nesneyi sol t�k ile tuttuysak
            {
                Capture = false; // topu yakalad�k m� hay�r
                hareket = false; // topun hareketini false yapt�k
            }
        }
        //wwww.projevekod.com adresinden indirilmi�tir.
        private void BallForm_MouseDown(object sender, MouseEventArgs e) // topa bas�l� tutarken
        {
            if (e.Button == MouseButtons.Left) // nesneyi sol t�k ile tuttuysak
            {
                rel = e.Location; // konumunu rel de�i�kenine atad�k
                Capture = true; // yakalamay� aktif ettik
                hareket = true; // hareket te art�k m�mk�n yani mouse ile hareket
            }
        }
        //wwww.projevekod.com adresinden indirilmi�tir.
        private void BallForm_MouseMove(object sender, MouseEventArgs e) // topa bas�l� mouseyi hareket ettirirsek
        {
            if (hareket) // t�k yoksa kendi s��ramaya devam eder
            {
                X = Cursor.Position.X - rel.X;
                Y = Cursor.Position.Y - rel.Y;
                
                hareketX += (X - Location.X)/2;
                hareketY += (Y - Location.Y)/2;

                if (hareketX > 2)
                    hareketX = 2;
                if (hareketY > 2)
                    hareketY = 2;
                
                if (duraklat)
                {
                    hareketX = 0;
                    hareketY = 0;
                }
                
                Location = new Point((int)X, (int)Y);
            }
        }
        //wwww.projevekod.com adresinden indirilmi�tir.

        private void cikis_Click(object sender, EventArgs e)
        {
            Close();
            Environment.Exit(0);
        }
        //wwww.projevekod.com adresinden indirilmi�tir.

        private void sag_tik_Click(object sender, EventArgs e)
        {
            duraklat = sag_tik.Checked;
        }
        //wwww.projevekod.com adresinden indirilmi�tir.

        public void Ziplama() // Rastgele z�plama say�s�
        {
            hareketX = (rastgeleSayi.NextDouble() + rastgeleSayi.NextDouble()) - 1;
            hareketY = -(rastgeleSayi.NextDouble());
            hareketX *= 50;
            hareketY *= 50;
            X += hareketX;
            Y += hareketY;
        }
        //wwww.projevekod.com adresinden indirilmi�tir.
    }
}