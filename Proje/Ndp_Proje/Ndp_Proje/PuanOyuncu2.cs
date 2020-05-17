
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ndp_Proje
{
    class PuanOyuncu2 : IOyuncuPuanlari
    {
        
        //PuanOyuncu1 classımla aynı işlemleri yapıyorum. Burada amaç şu: Örneğin oyuncu 1 ve oyuncu 2nin puanları
        //farklı şekilde hesaplanmak istenirse Oyuncu1'in puan sistemini PuanOyuncu1den Oyuncu2'yi ise PuanOyuncu2 den
        //oluşturduğum için oldukça rahat değişiklik yapabilirim.

        private double ilk;
        private double ikinci;

        public double X
        {
            get { return ilk; }
            set { ilk = value; }
        }
        public double Y
        {
            get { return ikinci; }
            set { ikinci = value; }
        }
        public double SonPuan() { return ilk * ikinci; }

        

    }
}
