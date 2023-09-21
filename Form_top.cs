using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//wwww.projevekod.com adresinden indirilmiþtir.
namespace Ball
{
    public partial class Form_top : Form
    {
        bool duraklat = false; // Sað týkladýðýmýzda duraklatma tuþu için gerekli deðiþkenimiz
        double hareketX = 0.0; // X konumunda edeceði hareket
        double hareketY = 0.0; // Y konumunda edeceði hareket
        double X = 0.0; // Mevcut X konumu
        double Y = 0.0; // Mevcut Y konumu
        double yercekimi = 0.1; // Zýplamasý için gerekli yer çekimi deðiþkeni
        Color renk; // Rengi
        Random rastgeleSayi; // Rastgele bir yerlere zýplatmak için ve renk belirlemek için
                             //wwww.projevekod.com adresinden indirilmiþtir.


        public Form_top()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // Ekrana çizim yaptýrabilmek için
            rastgeleSayi = new Random(Environment.TickCount); // rastgele sayýya deðer verme iþlemi
            renk = Color.FromArgb(rastgeleSayi.Next(0, 255), rastgeleSayi.Next(0, 255), rastgeleSayi.Next(0, 255)); // Renk için rastgele sayýlardan argb kodu getirme
        }
        //wwww.projevekod.com adresinden indirilmiþtir.

        private void BallForm_Paint(object sender, PaintEventArgs e)
        {
            //Formumuzun width ve height deðerleri
            Width = 25; 
            Height = 25;
            
            // Graphics sýnýfý tanýmlýyoruz.
            Graphics g = e.Graphics;
            g.Clear(Color.Cyan);//Formun backgroundunu cyan yapmýþtýk cyan olan renkleri siliyoruz formdan yani arkadasý boþ görünecek
            g.FillPie(new SolidBrush(renk), 0, 0, Width - 1,
                      Height - 1, 0, 360);
            g.DrawArc(new Pen(Color.Black,2), 0, 0, Width - 1, Height - 1, 0, 360);
            // Ekrana bir tane yuvarlak çizdik.
        }
        //wwww.projevekod.com adresinden indirilmiþtir.

        public void Tick() // Kendi kendine yapacaðý iþlemler
        {
            if (!duraklat && !hareket) // Eðer duraklatmadýksa ve hareket etmiyorsa
            {         
                hareketY += yercekimi;  // yerçekimi kuvvetini y de ki hareketimize ekliyoruz.
                
                X += hareketX; // mevcut x konumunu hareket ettiði x yönüne ekliyoruz
                Y += hareketY; // mevcut y konumunu hareket ettiði y yönüne doðru ekliyoruz.
                Location = new Point((int)X, (int)Y); // Konumunu oraya getiriyoruz ve bu her çizimde gerçekleþiyor
                
                // ekran x konumunda 0 a gelince yani sol tarafa top deðdiðinde hareket x i eksi yönüne y yi ise ayný yönünde artýrýyoruz
                if (X < 0)
                {
                    X = 0;
                    hareketX = -hareketX;
                    hareketX *= 0.75;
                    hareketY *= 0.95;
                }
                if (X > Screen.PrimaryScreen.WorkingArea.Width - 1 - Width) // Ekranýn saðýnda deðdiðinde topu sol tarafa doðru gönderiyoruz bu olaylar x te y de bi deðiþiklik yapmýyoruz
                {
                    X = Screen.PrimaryScreen.WorkingArea.Width - 1 - Width;
                    hareketX = -hareketX;
                    hareketX *= 0.75;
                    hareketY *= 0.95;
                }
                // y konumunda aðaðý geldiðinde tekrar yukarý göndermek için 0.75 ile çarpýyoruz. x ise hangi yönde devam ediyorsan ettiriyoruz.
                if (Y < 0)
                {
                    Y = 0;
                    hareketY = -hareketY;
                    hareketY *= 0.75;
                    hareketX *= 0.95;
                }
                if (Y > Screen.PrimaryScreen.WorkingArea.Height - 1 - Height)// yukarý y ye geldiðinde ekraný taþmasýn diye tekrar aþaðý gönderiyoruz bu sefer 0.8 lik bir hýzlý
                {
                    Y = Screen.PrimaryScreen.WorkingArea.Height - 1 - Height;
                    hareketY = -hareketY;
                    hareketY *= 0.8; // Bu hýzlar çok önemli arkadaþlar buradaki deðiþiklikler toplarýn hýzýný belirliyor
                    hareketX *= 0.95; // Eðer bu hýzlar sýfýrdan küçük olmazsa topu göremezsiniz ekranda
                }

                if (Math.Abs(hareketX) < 0.1 && Math.Abs(hareketY) < 0.5 && DateTime.Now.Second % 3 == 0 && Y > Screen.PrimaryScreen.WorkingArea.Height - 1 - Height - 40)
                {
                    Ziplama(); // En son zýplama yaptýrýyoruz ama eðer top durduysa x ve y de hareket etmiyorsa 3 saniye içerisinde geri zýplat
                }
            }
        }
        //wwww.projevekod.com adresinden indirilmiþtir.

        bool hareket = false;//mouseyle durdurmak için
        Point rel = new Point(); // tutunca mouseyle beraber gelsin
        private void BallForm_MouseUp(object sender, MouseEventArgs e) // topa týkladýðýmýz anda
        {
            if (e.Button == MouseButtons.Left) // nesneyi sol týk ile tuttuysak
            {
                Capture = false; // topu yakaladýk mý hayýr
                hareket = false; // topun hareketini false yaptýk
            }
        }
        //wwww.projevekod.com adresinden indirilmiþtir.
        private void BallForm_MouseDown(object sender, MouseEventArgs e) // topa basýlý tutarken
        {
            if (e.Button == MouseButtons.Left) // nesneyi sol týk ile tuttuysak
            {
                rel = e.Location; // konumunu rel deðiþkenine atadýk
                Capture = true; // yakalamayý aktif ettik
                hareket = true; // hareket te artýk mümkün yani mouse ile hareket
            }
        }
        //wwww.projevekod.com adresinden indirilmiþtir.
        private void BallForm_MouseMove(object sender, MouseEventArgs e) // topa basýlý mouseyi hareket ettirirsek
        {
            if (hareket) // týk yoksa kendi sýçramaya devam eder
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
        //wwww.projevekod.com adresinden indirilmiþtir.

        private void cikis_Click(object sender, EventArgs e)
        {
            Close();
            Environment.Exit(0);
        }
        //wwww.projevekod.com adresinden indirilmiþtir.

        private void sag_tik_Click(object sender, EventArgs e)
        {
            duraklat = sag_tik.Checked;
        }
        //wwww.projevekod.com adresinden indirilmiþtir.

        public void Ziplama() // Rastgele zýplama sayýsý
        {
            hareketX = (rastgeleSayi.NextDouble() + rastgeleSayi.NextDouble()) - 1;
            hareketY = -(rastgeleSayi.NextDouble());
            hareketX *= 50;
            hareketY *= 50;
            X += hareketX;
            Y += hareketY;
        }
        //wwww.projevekod.com adresinden indirilmiþtir.
    }
}