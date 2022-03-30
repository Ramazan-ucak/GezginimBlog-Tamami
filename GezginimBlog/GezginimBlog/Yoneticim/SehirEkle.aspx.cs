using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace GezginimBlog.Yoneticim
{
    public partial class SehirEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_ekleme_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_sehir.Text))
            {
                Sehir s = new Sehir();
                s.Isim = tb_sehir.Text;
                if (dm.SehirEkle(s))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                    tb_sehir.Text = " ";
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Şehir Eklenirlen Hata oluştu";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Şehir Adı Boş Bırakılamaz";
            }
        }
    }
}