
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

namespace Ndp_Proje
{
    interface IOyuncuPuanlari
    {

        //X ve Y şeklinde iki tane değişken ve 1 adet SonPuan adında metot tanımlıyorum
        double X { get; set; }
        double Y { get; set; }
        double SonPuan();


    }
}
