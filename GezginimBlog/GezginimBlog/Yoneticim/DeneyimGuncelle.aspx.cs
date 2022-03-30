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
    public partial class DeneyimGuncelle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    ddl_sehirler.DataSource = dm.SehirListele();
                    ddl_sehirler.DataBind();
                    int id = Convert.ToInt32(Request.QueryString["ddid"]);
                    Deneyim d = dm.DeneyimGetir(id);
                    tb_isim.Text = d.Baslik;
                    tb_onyazi.Text = d.Onyazi;
                    tb_icerik.Text = d.Icerik;
                    ddl_sehirler.SelectedValue = Convert.ToString(d.Sehir_ID);
                    img_resim.ImageUrl = "../DeneyimResimler/" + d.GeziResim;
                    cb_paylas.Checked = d.Durum;
                }
            }
            else
            {
                Response.Redirect("DeneyimListele.aspx");
            }

        }

        protected void lbtn_guncelle_Click(object sender, EventArgs e)
        {
            bool uygunmu = true;
            int id = Convert.ToInt32(Request.QueryString["ddid"]);
            Deneyim d = dm.DeneyimGetir(id);
            d.Baslik = tb_isim.Text;
            d.Onyazi = tb_onyazi.Text;
            d.Icerik = tb_icerik.Text;
            d.Sehir_ID = Convert.ToInt32(ddl_sehirler.SelectedValue);
            d.Durum = cb_paylas.Checked;
            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;
                string dosyaadi = Guid.NewGuid() + uzanti;
                if (uzanti == ".png" || uzanti == ".jpg" || uzanti == ".jpeg")
                {
                    fu_resim.SaveAs(Server.MapPath("~/DeneyimResimler/" + dosyaadi));
                    d.GeziResim = dosyaadi;
                }
                else
                {
                    uygunmu = false;
                }

            }
            if (uygunmu)
            {
                if (dm.DeneyimGuncelle(d))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;

                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Bir hata oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya uzantısı png, jpg veya jpeg olmalıdır";
            }
        }
    }
}