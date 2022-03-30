using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.IO;
namespace GezginimBlog.Yoneticim
{
    public partial class DeneyimEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_sehirler.DataSource = dm.SehirListele();
                ddl_sehirler.DataBind();
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            bool resimformat = false;
            Deneyim dny = new Deneyim();
            dny.Baslik = tb_isim.Text;
            dny.Onyazi = tb_onyazı.Text;
            dny.Icerik = tb_icerik.Text;
            dny.Sehir_ID = Convert.ToInt32(ddl_sehirler.SelectedValue);
            dny.Durum = cb_paylas.Checked;
            DataAccessLayer.Yonetici y = (DataAccessLayer.Yonetici)Session["yonetici"];
            dny.EklemeTarih = DateTime.Now;
            dny.Yazar_ID = y.ID;

            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;
                if (uzanti ==".jpg" || uzanti == ".png")
                {
                    string resimadi = Guid.NewGuid() + uzanti;
                    fu_resim.SaveAs(Server.MapPath("~/DeneyimResimler/" + resimadi));
                    dny.GeziResim = resimadi;
                    resimformat = true;

                }
            }
            else
            {
                dny.GeziResim = "none.jpg";
            }
            if (resimformat)
            {
                if (dm.DeneyimEkle(dny))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Hata Oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya uzantısı jpg veya png olmalıdır";
            }
        }
    
       
	

	
    }
}