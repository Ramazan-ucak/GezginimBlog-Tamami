using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
namespace GezginimBlog
{
    public partial class UyeOl : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_kayit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_ad.Text) && !string.IsNullOrEmpty(tb_soyad.Text) && !string.IsNullOrEmpty(tb_mail.Text) && !string.IsNullOrEmpty(tb_sifre.Text))
            {
                Uye u = new Uye();
                u.Isim = tb_ad.Text;
                u.Soyad = tb_soyad.Text;
                u.Mail = tb_mail.Text;
                u.Sifre = tb_sifre.Text;
                u.UyelikTarihi = DateTime.Now;
                u.Durum = true;
                if (dm.UyeEkle(u))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                    tb_ad.Text = " ";
                    tb_soyad.Text = " ";
                    tb_mail.Text = " ";
                    tb_sifre.Text = " ";
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kayıt işlemi sırasında bir hata meydana geldi.";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Hiçbir alan boş bırakılamaz";
            }
        }
    }
}