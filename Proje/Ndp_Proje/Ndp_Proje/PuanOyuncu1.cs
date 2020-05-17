
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
    class PuanOyuncu1 : IOyuncuPuanlari
    {

        //ilk ve ikinci adlarında iki adet değişken tanımlıyorum
        private double ilk;
        private double ikinci;

        //Classımın bağlı olduğu interfacedeki X değişkenime ilk değişkenimin değerini entegre ediyorum.
        public double X
        {
            get { return ilk; }
            set { ilk = value; }
        }

        //Classımın bağlı olduğu interfacedeki Y değişkenime ikinci değişkenimin değerini entegre ediyorum.
        public double Y
        {
            get { return ikinci; }
            set { ikinci = value; }
        }
        //SonPuan adındaki metodumda ilk ve ikinci değerin çarpımını return ediyorum Bu sayede bu metot
        //çağırıldığında tanımlanan 2 değişkenin çarpımına erişilmiş olacak.
        public double SonPuan() { return ilk * ikinci; }


    }
}
