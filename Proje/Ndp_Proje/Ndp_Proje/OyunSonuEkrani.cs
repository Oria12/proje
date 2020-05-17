
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
    public partial class OyunSonuEkrani : Form
    {
        public OyunSonuEkrani()
        {
            InitializeComponent();
        }


        private void OyunSonuEkrani_Load(object sender, EventArgs e)
        {

            lblO1Kazandi.Visible = false;
            lblO2Kazandi.Visible = false;

            //Oyuncu 0 cana ulaşıp kaybetmiş olmasına rağmen 
            //Diğer formdan buraya gidecekcan değerini 10 şeklinde aktarıyor. Bu yüzden yazdırmadan önce can değerini 10 azaltıyorum.
            if(OyunEkrani.gidecekcan1 == 10)
            {
                OyunEkrani.gidecekcan1 -=10;
            }

            else if (OyunEkrani.gidecekcan2 == 10)
            {
                OyunEkrani.gidecekcan2 -= 10;
            }
            
           

            //Alttaki satırlarda formumdaki labellara diğer formdan bilgi getiriyorum
            lblO1Vd.Text = OyunEkrani.gidecekvdsayac1.ToString();  //lblO1Vd = Label Oyuncu 1 Vurulan Düşman
            lblO1Ai.Text = OyunEkrani.gidecekaisayac1.ToString();          
            lblO1Cd.Text = OyunEkrani.gidecekcan1.ToString();

            lblO2Vd.Text = OyunEkrani.gidecekvdsayac2.ToString();
            lblO2Ai.Text = OyunEkrani.gidecekaisayac2.ToString();
            lblO2Cd.Text = OyunEkrani.gidecekcan2.ToString();




            /*PUAN VERİLERİNİ ÇEKEMİYORUM ÇÜNKÜ: Ben puan verilerini public static olarak genelde tanımlamadım, zamanın içerisinde tanımladım
            üstüne bir de sayac verilerini labellardan çektim. Bundan dolayı ne üsttekiler gibi direkt formdan çağırabiliyorum ne de
            oluşturduğum classlardan veri çekebiliyorum. Genel toplam ve OyunSonuEkrani ödevi güncellerken eklediğim şeyler olduğu ve 
            projeyi bunlara göre dizayn etmediğim için bir tasarım hatasıyla karşılaştım ve çözümü için tüm yapıyı tekrar kurmam gerekmekte.
            Sonuç olarak vakit yetersizliğinden dolayı puan verilerini oyunsonu ekranına taşıyamadım...
            
            /*
            PuanOyuncu1 puan1 = new PuanOyuncu1();
            puan1.X = vdsayac1;
            puan1.Y = aisayac1;
            label4.Text = ("Oyuncu 1\n Puan: " + puan1.SonPuan());   
            */


            //eğer oyuncu 2 nin can barı 0 ise oyuncu 1 i kazanan bölümüne ortalıyorum, değil ise oyuncu 2 yi ortalıyorum
            if (OyunEkrani.gidecekcan2 == 0)
            {
                lblO1Kazandi.Location = new Point(367, 289);
                lblO1Kazandi.Visible = true;
            }
            else
            {
                lblO2Kazandi.Location = new Point(367, 289);
                lblO2Kazandi.Visible = true;
            }





        }


        private void btnGiriseDon_Click(object sender, EventArgs e)
        {
            //Oyuncular giriş ekranı sayfasına dönmek istedikleri için onları GirisEkrani formuna yönlendiriyorum
            OyunSonuEkrani.ActiveForm.Hide();   //OyunSonuEkrani formumu yani istatistik sayfasını gizliyorum
            GirisEkrani frmgiris = new GirisEkrani();   //GirisEkrani ismindeki form sayfama frmgiris ismini veriyorum
            frmgiris.ShowDialog();   //frmgiris ismini verdiğim GirisEkrani sayfamı yani oyunun giriş ekranını açıyorum
        }


        private void btnTekrarOyna_Click(object sender, EventArgs e)
        {
            //Oyuncular oyunu tekrar oynamak istedikleri için oyunu tekrar başlatıyorum
            OyunSonuEkrani.ActiveForm.Hide();   //OyunSonuEkrani formumu yani istatistik sayfasını gizliyorum
            OyunEkrani frmoyun = new OyunEkrani();   //OyunEkrani ismindeki form sayfama frmoyun ismini veriyorum
            frmoyun.ShowDialog();   //frmoyun ismini verdiğim OyunEkrani sayfamı yani oyunu açıyorum
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            //Kullanıcı Çıkış butonuna bastığında onun için bir dialog oluşturuyorum. Dialogun cevabı evet ise oyundan çıkartıyorum.
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Oyundan çıkmak istediğinize emin misiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

       

      
    }
}
