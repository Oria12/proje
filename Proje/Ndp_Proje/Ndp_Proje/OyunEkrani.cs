
/********************************************************    
**              SAKARYA ÜNİVERSİTESİ
**     BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**       BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ
**          NESNEYE DAYALI PROGRAMLAMA DERSİ 
**               2019-2020 BAHAR DÖNEMİ 
**
**                 PROJE NUMARASI: 01 
**             ÖĞRENCİ ADI: ORÇUN HOLTA
**            ÖĞRENCİ NUMARASI: B191200300
**              DERSİN ALINDIĞI GRUP: A
*********************************************************/





using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ndp_Proje
{
    public partial class OyunEkrani : Form  //Bu temel olarak kalıtıma bir örnektir
    {

   
        public OyunEkrani()
        {
            InitializeComponent();

            //Arkaplanı transparan yapmak için gerekli kod
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
        }



        //Oyun sonu ekranına oyun istatistiklerine gönderebilmek için gerekli olan değişkenler
        //Bu değişkenler bu şekilde formda public static tanımlanmalı ki diğer formda da rahat şekilde kullanılabilsin.
        public static int gidecekvdsayac1;
        public static int gidecekvdsayac2;
        public static int gidecekaisayac1;
        public static int gidecekaisayac2;
        public static int gidecekcan1;
        public static int gidecekcan2;

        //public static int gidecektoplam1;
        //public static int gidecektoplam2;





        //ates etkinliklerim için işime yarayacak değişkenler
        //Birden fazla timerda kullanacağım için bu şekilde tanımlıyorum
        public int obirx;
        public int obiry;
        public int oikix;
        public int oikiy;


        Random rnd = new Random();    //Random değer oluşturmak için tanımladığım rnd isimli değişkenim


        
        int genelsayac;    //Oyunun hızını kontrol etmek için gerekli olan sayaç
        //eğer genelsayac değişkenini zaman_tick metotu altında genelsayac=0 şeklinde tanımlarsam zaman timerı her ticklediğinde
        //genelsayac değişkenimi 0lar ve zaman akamaz. Bundan dolayı en yukarıda tanımlıyorum.



      
        private void OyunEkrani_Load(object sender, EventArgs e)
        {

  
            MuzikCal m = new MuzikCal(); //MuzikCal classını çağırabilmek için m isimli bir değişken tanımladım
            m.Cal(); //Class içerisindeki Cal isimli metodumuzu çağırdık bu şekilde formumuz yüklendiği anda yani oyun başladığı anda müzik başladı.


       
            atesTimer.Interval = 50;
            ates2Timer.Interval = 50;
            ates.Visible = false;
            ates2.Visible = false;
            atesTimer.Stop();
            ates2Timer.Stop();
            can1.Value = 100;
            can2.Value = 100;
            

            zaman.Enabled = true;

            oyuncu1.Location = new Point(165, 403);
            oyuncu2.Location = new Point(639, 403);
            can1Yukseltme.Location = new Point(200, -1200);
            can2Yukseltme.Location = new Point(664, -1200);
            
        }


       

        private void zaman_Tick(object sender, EventArgs e)
        {

            //Düşmanların standart hız değerleri
            int dusmanHiziUst = 7;
            int dusmanHiziUst2 = 6;
            int dusmanHiziUst3 = 5;
            int dusmanHiziUst4 = 4;

            //Can Yükseltme ek özelliğinin standart hız değeri
            int canyukseltmehizi = 8;




            /*
             
             //Burada yukarıda tanımladığım değişkenleri dizi kullanarak tanımlamak istedim bu şekilde projemde
             //dizilere de yer verecektim fakat genelde tanımlamam gerekti ve dizileri kullanamadım
             int[] dizi = new int[8];
             dizi[0]= gidecekvdsayac1;
             dizi[1]= gidecekvdsayac2;
             dizi[2]= gidecekaisayac1;
             dizi[3]= gidecekaisayac2;
             dizi[4]= gidecekcan1;
             dizi[5]= gidecekcan2;
             dizi[6]= gidecektoplam1;
             dizi[7]= gidecektoplam2;
    
           */




            int vdsayac1 = Convert.ToInt32(lblVurulanDusman1.Text); // vd = vurulan düşman, oyuncu 1 için geçerli 
            int vdsayac2 = Convert.ToInt32(lblVurulanDusman2.Text); // vd = vurulan düşman, oyuncu 2 için geçerli 
            int aisayac1 = Convert.ToInt32(lblAlinanIyilestirme1.Text); // ai1 = alınan iyileştirme, oyuncu 1 için geçerli
            int aisayac2 = Convert.ToInt32(lblAlinanIyilestirme2.Text); // ai2 = alınan iyileştirme, oyuncu 2 için geçerli
            
            //yukarıda tanımladığım sayaç değerlerini diğer forma geçirmek için tanımladığım değişkenlere eşitliyorum
            gidecekvdsayac1 = vdsayac1;
            gidecekaisayac1 = aisayac1;
            gidecekvdsayac2 = vdsayac2;
            gidecekaisayac2 = aisayac2;



            
            //IPuanYukseltme interfaceinden türettiğim PuanOyuncu1 Classımı çağırıyorum ve içerisindeki işlemi döndürüyorum.
            //İçerisindeki işlem vurulan düşman ile arttırılan can değerinin çarpımını sağlıyor. (İki oyuncu için de aynısı)
            PuanOyuncu1 puan1 = new PuanOyuncu1(); 
            puan1.X = vdsayac1;
            puan1.Y = aisayac1;
            o1puan.Text = ("Oyuncu 1\n Puan: " + puan1.SonPuan());

            //Not: if aisayac==0 ise sadece puanı yazdır vb. bir komut gelebilir


    
            PuanOyuncu2 puan2 = new PuanOyuncu2();
            puan2.X = vdsayac2;
            puan2.Y = aisayac2;
            o2puan.Text = ("Oyuncu 2\n Puan: " + puan2.SonPuan());
         

    

            
       



            //Aşağıda tanımlarda karışmasın diye en üstte tüm düşmanlarımın x ve y koordinatlarına kısa değişken tanımlamaları yapıyorum.  
            int d1x = dusman1.Location.X;
            int d1y = dusman1.Location.Y;

            int d2x = dusman2.Location.X;
            int d2y = dusman2.Location.Y;

            int d3x = dusman3.Location.X;
            int d3y = dusman3.Location.Y;

            int d4x = dusman4.Location.X;
            int d4y = dusman4.Location.Y;

            int d5x = dusman5.Location.X;
            int d5y = dusman5.Location.Y;

            int d6x = dusman6.Location.X;
            int d6y = dusman6.Location.Y;

            int d7x = dusman7.Location.X;
            int d7y = dusman7.Location.Y;

            int d8x = dusman8.Location.X;
            int d8y = dusman8.Location.Y;

            
            int c1yx = can1Yukseltme.Location.X; //c1yx = can1Yukseltme X
            int c1yy = can1Yukseltme.Location.Y; //c1yy = can1Yukseltme Y

            int c2yx = can2Yukseltme.Location.X; //c2yx = can2Yukseltme X
            int c2yy = can2Yukseltme.Location.Y; //c2yy = can2Yukseltme Y

            



            /*Burada bir x düşüncesi oluşturuyorum ve diyorum ki eğer x(herhangi bir nesne) picturebox ise ve Tag'i dusmanUst ise 
            onun her saniye üstünde kalan boşluk dusmanHiziUst değeri kadar olsun. Bu işlemleri zaman timerı içinde yaptığım için
            her saniye pictureboxlarım hareket ediyor. Aynı işlemleri diğer düşmanlar için de uyguluyorum bu şekilde farklı hızlarda gidiyorlar. 
             */
                           
           foreach (Control x in this.Controls)
           {
               if (x is PictureBox && x.Tag=="dusmanUst")
               {
                   x.Top += dusmanHiziUst;                  
               }
           }

          
           foreach (Control x in this.Controls)
           {

               if (x is PictureBox && x.Tag == "dusmanUst2")
               {
                   x.Top += dusmanHiziUst2;                 
               }
           }
         

           foreach (Control x in this.Controls)
           {
               if (x is PictureBox && x.Tag == "dusmanUst3")
               {
                   x.Top += dusmanHiziUst3;                 
               }
           }


           foreach (Control x in this.Controls)
           {
               if (x is PictureBox && x.Tag == "dusmanUst4")
               {
                   x.Top += dusmanHiziUst4;                 
               }
           }




            

           //DÜŞMANLAR CAN BARLARINA DEĞERSE
            
           if (dusman1.Bounds.IntersectsWith(can1.Bounds)) //Düşman 1 Can 1'e değerse olacaklar (Tüm Düşmanlar için aynı kodyapısı var tek açıklama yazdım)
           {
               dusman1.Top += dusmanHiziUst;  //Düşman 1 in üst tarafına dusmanHiziUst değerini yani 5 i ekliyorum bu şekilde aşağı kayıyor
               can1.Value -= 10;  //Oyuncu 1'e ait olan can barını 10 azaltıyorum
               dusman1.Top = -110; //bu kod bakıldığında bir işe yaramasa da her el rastgele yerden gelmesini sağlıyor
               d1x = rnd.Next(0, 350);  //Düşman 1'in X değerini kendi sınırları içerisinde rastgele oluşturuyorum
               d1y = -110;  //Düşman 1'in Y değerini haritanın dışında kalan bir değere eşitliyorum
               dusman1.Location = new Point(d1x, d1y);  //Yeni atadığım X ve Y değişkenlerini Düşman 1'in lokasyonuna atıyorum

           }

           else if (dusman2.Bounds.IntersectsWith(can2.Bounds))
           {
               dusman2.Top += dusmanHiziUst;
               can2.Value -= 10;
               dusman2.Top = -110;
               d2x = rnd.Next(450, 800);
               d2y = -110;            
               dusman2.Location = new Point(d2x, d2y);
           }

           else if (dusman3.Bounds.IntersectsWith(can1.Bounds))
           {
               dusman3.Top += dusmanHiziUst2;
               can1.Value -= 10;
               dusman3.Top = -110;
               d3x = rnd.Next(0, 350);
               d3y = -110;       
               dusman3.Location = new Point(d3x, d3y);

           }

           else if (dusman4.Bounds.IntersectsWith(can2.Bounds))
           {
               dusman4.Top += dusmanHiziUst2;
               can2.Value -= 10;
               dusman4.Top = -110;
               d4x = rnd.Next(450, 800);
               d4y = -110;              
               dusman4.Location = new Point(d4x, d4y);
           }

           else if (dusman5.Bounds.IntersectsWith(can1.Bounds))
           {
               dusman5.Top += dusmanHiziUst3;
               can1.Value -= 10;
               dusman5.Top = -110;
               d5x = rnd.Next(0, 350);
               d5y = -110;
               dusman5.Location = new Point(d5x, d5y);

           }

           else if (dusman6.Bounds.IntersectsWith(can2.Bounds))
           {
               dusman6.Top += dusmanHiziUst3;
               can2.Value -= 10;
               dusman6.Top = -110;
               d6x = rnd.Next(450, 800);
               d6y = -110;
               dusman6.Location = new Point(d6x, d6y);
           }

           else if (dusman7.Bounds.IntersectsWith(can1.Bounds))
           {
               dusman7.Top += dusmanHiziUst4;
               can1.Value -= 10;
               dusman7.Top = -110;
               d7x = rnd.Next(0, 350);
               d7y = -110;
               dusman7.Location = new Point(d7x, d7y);

           }

           else if (dusman8.Bounds.IntersectsWith(can2.Bounds))
           {
               dusman8.Top += dusmanHiziUst4;
               can2.Value -= 10;
               dusman8.Top = -110;
               d8x = rnd.Next(450, 800);
               d8y = -110;
               dusman8.Location = new Point(d8x, d8y);
           }

           



           //ATEŞ 1 DÜŞMANLARA DEĞERSE

           else if (ates.Bounds.IntersectsWith(dusman1.Bounds))  //Oyuncu 1 in ateşi düşman 1'e değerse (Tüm Düşmanlar için aynı kodyapısı var tek açıklama yazdım)
           {
               dusman1.Location = new Point(337, -110);  //Düşman 1'in lokasyonunu sabir bir yere alıyorum
               ates.Location = new Point(obirx, obiry);  //Oyuncu 1'e ait olan ates pictureboxını oyuncu1in orta üstüne gelecek konuma alıyorum     
               ates.Visible = false;  //Oyuncu 1'e ait olan ates pictureboxını gizliyorum
               atesTimer.Stop();  //Ates durumu aktif olmadığı için timerı durduruyorum


               //Tüm Düşmanlar için aynı işlemleri yapıyorum çünkü tüm düşmanlar 1 arttırıyorlar.
               vdsayac1++; //Düşman 1 vurulduğunda vdsayac1 değişkenimi 1 arttırdım
               lblVurulanDusman1.Text = vdsayac1.ToString(); //Yeni vdsayac1 değerimi lblVurulanDusman1'e yazdırdım.
              
           }
           
           else if (ates.Bounds.IntersectsWith(dusman3.Bounds))
           {
               dusman3.Location = new Point(117, -110);
               ates.Location = new Point(obirx, obiry);             
               ates.Visible = false;
               atesTimer.Stop();

               vdsayac1++;
               lblVurulanDusman1.Text = vdsayac1.ToString();
           }
           
           else if (ates.Bounds.IntersectsWith(dusman5.Bounds))
           {
               dusman5.Location = new Point(227, -110);
               ates.Location = new Point(obirx, obiry);              
               ates.Visible = false;
               atesTimer.Stop();

               vdsayac1++;
               lblVurulanDusman1.Text = vdsayac1.ToString();
           }
           
           else if (ates.Bounds.IntersectsWith(dusman7.Bounds))
           {
               dusman7.Location = new Point(7, -110);
               ates.Location = new Point(obirx, obiry);              
               ates.Visible = false;
               atesTimer.Stop();

               vdsayac1++;
               lblVurulanDusman1.Text = vdsayac1.ToString();
           }
           





           //ATEŞ 2 DÜŞMANLARA DEĞERSE (Ateş 1 ile aynı yapıdalar)

           else if (ates2.Bounds.IntersectsWith(dusman2.Bounds))
           {
               dusman2.Location = new Point(447, -110);
               ates2.Location = new Point(oikix, oikiy);               
               ates2.Visible = false;
               ates2Timer.Stop();

               //Tüm Düşmanlar için aynı işlemleri yapıyorum çünkü tüm düşmanlar 1 arttırıyorlar.
               vdsayac2++; //Düşman 2 vurulduğunda vdsayac2 değişkenimi 2 arttırdım 
               lblVurulanDusman2.Text = vdsayac2.ToString(); //Yeni vdsayac2 değerimi lblVurulanDusman2'e yazdırdım.
           }
           
           else if (ates2.Bounds.IntersectsWith(dusman4.Bounds))
           {
               dusman4.Location = new Point(667, -110);
               ates2.Location = new Point(oikix, oikiy);
               ates2.Visible = false;
               ates2Timer.Stop();

               vdsayac2++; 
               lblVurulanDusman2.Text = vdsayac2.ToString(); 
           }
           
           else if (ates2.Bounds.IntersectsWith(dusman6.Bounds))
           {
               dusman6.Location = new Point(557, -110);
              ates2.Location = new Point(oikix, oikiy);               
               ates2.Visible = false;
               ates2Timer.Stop();

               vdsayac2++;
               lblVurulanDusman2.Text = vdsayac2.ToString(); 
           }
          
           else if (ates2.Bounds.IntersectsWith(dusman8.Bounds))
           {
               dusman8.Location = new Point(777, -110);
               ates2.Location = new Point(oikix, oikiy);             
               ates2.Visible = false;
               ates2Timer.Stop();

               vdsayac2++;
               lblVurulanDusman2.Text = vdsayac2.ToString(); 
           }








            //CAN YÜKSELTMESİ KISMI (Karışmasın diye bu şekilde aşağıda tanımladım)
            

           //CAN YÜKSELTMESİ 1 VE 2 NİN KAYMASI İÇİN GEREKLİ OLAN KOD

           foreach (Control x in this.Controls)
           {
               if (x is PictureBox && x.Tag == "canY") //İkisi de aynı tage sahip olduğu için sabit hızda aşağı doğru kayacaklar
               {
                   x.Top += canyukseltmehizi;
               }
           }



           //CAN YÜKSELTMESİ 1 İÇİN GEREKLİ OLAN KODLAR (Yukarıdakilerle aynı işlemler yapılıyor sadece sayısal değerleri farklı)

           
           if (can1Yukseltme.Bounds.IntersectsWith(can1.Bounds) || can1Yukseltme.Bounds.IntersectsWith(can2.Bounds))
           {
               can1Yukseltme.Top += canyukseltmehizi;

               can1Yukseltme.Top = -1200;
               c1yx = rnd.Next(0, 350);
               c1yy = -1200;
               can1Yukseltme.Location = new Point(c1yx, c1yy);
           }

           else if (ates.Bounds.IntersectsWith(can1Yukseltme.Bounds))
           {
               c1yx = rnd.Next(0, 350);
               c1yy = -1200;
               can1Yukseltme.Location = new Point(c1yx, c1yy);

               //Can Barlarımı daha hoş ve efektli gözüksün diye progressbar toolboxı ile yaptım. Fakat progressbarlar
               //0 ila 100 arasında bir değer alabiliyor. Bundan dolayı eğer ben bu if kontrolünü gerçekleştirmeseydim
               //oyuncunun canı 100 iken can özelliğini vurduğunda progressbar 110 değerini alamadığı için oyun çalışmayı durduracaktı.
               if (can1.Value != 100) 
               {
                   can1.Value += 10;
                   aisayac1++; //İyileştirme yapıldığında aisayac1 değişkenimi 1 arttırdım
                   lblAlinanIyilestirme1.Text = aisayac1.ToString(); //Yeni aisayac1 değerimi lblAlinanIyilestirme1'e yazdırdım.
               }              

               ates.Location = new Point(obirx, obiry);
               ates.Visible = false;
               atesTimer.Stop();

           }


            //AYNI İŞLEMLERİN CAN YÜKSELTMESİ 2 İÇİN GEREKLİ OLAN KODLARI

           if (can2Yukseltme.Bounds.IntersectsWith(can1.Bounds) || can2Yukseltme.Bounds.IntersectsWith(can2.Bounds))
           {
               can2Yukseltme.Top += canyukseltmehizi;

               can2Yukseltme.Top = -1200;
               c2yx = rnd.Next(450, 800);
               c2yy = -1200;
               can2Yukseltme.Location = new Point(c2yx, c2yy);
           }

           else if (ates2.Bounds.IntersectsWith(can2Yukseltme.Bounds))
           {
               c2yx = rnd.Next(450, 800);
               c2yy = -1200;
               can2Yukseltme.Location = new Point(c2yx, c2yy);
 
               if (can2.Value != 100)
               {
                   can2.Value += 10;
                   aisayac2++; //İyileştirme yapıldığında aisayac2 değişkenimi 1 arttırdım
                   lblAlinanIyilestirme2.Text = aisayac2.ToString(); //Yeni ai2sayac değerimi lblAlinanIyilestirme2'e yazdırdım.
               }

               ates2.Location = new Point(oikix, oikiy);
               ates2.Visible = false;
               ates2Timer.Stop();

           }






          //CAN 1 veya CAN 2 BELİRLİ SEVİYENİN ALTINA DÜŞERSE YANİ HERHANGİ BİRİ KAYBEDERSE
           if (can1.Value==0)
           {
               zaman.Stop();
               Kazandi o2 = new Kazandi("Oyuncu 2 \n\nOyun istatistiklerine bakmak ister misiniz? "); //Classın Kurucusuna "Oyuncu2"yi gönderdik
               o2.kazandimetot(); //Class içerisindeki metotu çağırdık
           }
             if (can2.Value==0)
           {
               zaman.Stop();
               Kazandi o1 = new Kazandi("Oyuncu 1 \n\nOyun istatistiklerine bakmak ister misiniz? ");
               o1.kazandimetot();
           }


             //Can barları değerlerimi diğer formda kullanabilmek için tanımladığım değişkenlere eşitliyorum
             gidecekcan1 = can1.Value;
             gidecekcan2 = can2.Value;


           


            //ZAMAN KISMI

             /*genelsayac değişkenim 0 dan sonsuza kadar artıyor onun belirli zamanlarında oyunun hızının bulunduğu timer olan
              zaman timer'ının intervalini değiştiriyorum ki düşmanlar daha hızlı şekilde gelsinler.
              Yani aslında düşmanlar hızlanmıyor düşmanların bulunduğu timer hızlanıyor */
             
             switch (genelsayac)
             {
                 case 1:
                     zaman.Interval = 90;
                     break;
                 case 10:
                     zaman.Interval = 84;
                     break;
                 case 15:
                     zaman.Interval = 78;
                     break;
                 case 20:
                     zaman.Interval = 71;
                     break;
                 case 25:
                     zaman.Interval = 64;
                     break;
                 case 30:
                     zaman.Interval = 57;
                     break;
                 case 35:
                     zaman.Interval = 50;
                     break;
                 case 40:
                     zaman.Interval = 42;
                     break;
                 case 45:
                     zaman.Interval = 34;
                     break;
                 case 50:
                     zaman.Interval = 22;
                     break;
                 case 60:
                     zaman.Interval = 20;
                     break;
                 case 70:
                     zaman.Interval = 15;
                     break;
                 case 80:
                     zaman.Interval = 12;
                     break;
                 case 90:
                     zaman.Interval = 9;
                     break;
                 case 100:
                     zaman.Interval = 6;
                     break;

             }

             //zaman.Interval=5 zaten çok hızlı olduğu için oyunun saniyesi belirli bir süreye geldiğinde sabitliyorum.
             if (genelsayac > 105)
             {
                 zaman.Interval = 5;
             }

            

            //Darphanelerin can değerlerini yüzde şeklinde yazdırıyorum
             can1Yuzde.Text = can1.Value.ToString() + "%"; 
             can2Yuzde.Text = can2.Value.ToString() + "%";


          
       }

        private void zamankontrol_Tick(object sender, EventArgs e)
        {
            //zamankontrol timer gerekliliği: oyunun düzgün akabilmesi için intervali 1000 olan bir timera ihtiyaç vardı.
            genelsayac++; //genelsayac değişkenimi zaman timerım her değiştiğinde 1 arttırıyorum bu şekilde saniyeye oranlamış oluyorum
        }
   


       private void Hareket(object sender, KeyEventArgs e)
       {


           /*oyuncu1 i hareket ettirmek için x ve y değerlerine karakterin x ve y değerlerini atıyorum sonra 
           klavyeden basılan tuşa ve konumun haritanın diğer tarafında ve dışında olmamasına dikkat ederek karakteri hareket ettiriyorum  */
            int o1x = oyuncu1.Location.X;
            int o1y = oyuncu1.Location.Y;
          
            if (e.KeyCode == Keys.A && o1x > 20)
            {
                o1x = o1x - 45;
            }

            if (e.KeyCode == Keys.D && o1x < 340)
            {
                o1x = o1x + 45;
            }

            oyuncu1.Location = new Point(o1x, o1y);



            /*oyuncu2 yi hareket ettirmek için x ve y değerlerine karakterin x ve y değerlerini atıyorum sonra 
            klavyeden basılan tuşa ve konumun haritanın diğer tarafında ve dışında olmamasına dikkat ederek karakteri hareket ettiriyorum  */
            int o2x = oyuncu2.Location.X;
            int o2y = oyuncu2.Location.Y;
       
            if (e.KeyCode == Keys.Left && o2x > 480)
            {
                o2x = o2x - 45;
            }

            if (e.KeyCode == Keys.Right && o2x < 800)
            {
                o2x = o2x + 45;
            }

            oyuncu2.Location = new Point(o2x, o2y);





            //F ve L aynı işlemleri yapıyor o yüzden sadece buna açıklamaları yazıyorum
            if (e.KeyCode == Keys.F) //F tuşuna basıldığında 
            {                
                ates.Visible = true; //ates pictureboxımı görünür yapıyorum
                atesTimer.Start();  //atestimerımı çalıştırıyorum ki yukarı doğru ilerlesin
            }

            if (e.KeyCode == Keys.L)
            {                
                ates2.Visible = true;
                ates2Timer.Start();
            }


     
        }





        private void atesTimer_Tick(object sender, EventArgs e)
        {
            //ateş 1 ve iki aynı işlemleri yapıyor o yüzden sadece buna açıklamaları yazıyorum

            ates.Top -= 25; //ateş 1 yani soldaki ateşin hareket hızı
            obirx = (oyuncu1.Location.X) + 12;  //obirx değişkenimi oyuncu 1 pictureboxımın hafif sağına yani aslında ortasına konumlandırıyorum
            //Çünkü:visual studio X i dediğinizde pictureboxın solundan Y si dediğinizde üstünden 0 noktalarını alıyor
            obiry = (oyuncu1.Location.Y) - 7; ////obirx değişkenimi oyuncu 1 pictureboxımın hafif altına yani aslında ortasına konumlandırıyorum
            if (ates.Top < -20) //eğer ates1 haritanın üstünden çıkarsa 
            {
                ates.Location = new Point(obirx, obiry); //atesi tekrardan oyuncu1 in ortasına konumlandırıyorum               
                ates.Visible = false; //Ates pictureboxımı görünmez yapıyorum
                atesTimer.Stop(); //atestimerımı durduruyorum
            }
        }


        private void ates2Timer_Tick(object sender, EventArgs e)
        {
            ates2.Top -= 25;
            oikix = (oyuncu2.Location.X) + 12;
            oikiy = (oyuncu2.Location.Y) - 7;
            if (ates2.Top < -20)
            {
                ates2.Location = new Point(oikix, oikiy);               
                ates2.Visible = false;
                ates2Timer.Stop();
            }
        }

      


      
    }
}
