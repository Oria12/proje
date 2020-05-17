
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
    public class Kazandi
    {

        public string mesaj;

        //KURUCU FONKSİYON
        public Kazandi(string msg)
        {
            this.mesaj = msg;           
        }


        //METOT
        public void kazandimetot()
        {

            //Oyun bittiğinde gelecek bir dialog oluşturuyorum. Dialogun cevabı evet ise oyunu tekrardan başlatıyorum hayır ise oyundan çıkartıyorum.
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Tebrikler " + mesaj, "Oyun Bitti", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                //Oyuncular oyun istatistiklerine bakmak istedikleri için istatistiklerin bulunduğu OyunSonuEkrani sayfasını açtırıyorum
                OyunEkrani.ActiveForm.Hide();   //OyunEkrani formumu yani oyun sayfasını gizliyorum
                OyunSonuEkrani frmson = new OyunSonuEkrani();   //OyunSonuEkrani ismindeki form sayfama frmson ismini veriyorum
                frmson.ShowDialog();   //frmson ismini verdiğim OyunSonuEkrani form sayfamı açıyorum
       
            }
            else
            {
                //Oyuncular oyun istatistiklerine bakmak istemedikleri için oyunu tekrar başlatıyorum
                OyunEkrani oyun = new OyunEkrani();   //OyunEkrani ismindeki form sayfama oyun ismini veriyorum
                oyun.ShowDialog();   //oyun ismini verdiğim OyunEkrani form sayfamı açıyorum    
            }      


        }

    }
}
