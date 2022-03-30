using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace GezginimBlog
{
    public partial class DeneyimDevam : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["did"]);
                Deneyim d = dm.DeneyimGetir(id);
                ltrl_baslik.Text = d.Baslik;
                ltrl_icerik.Text = d.Icerik;
                ltrl_sehir.Text = d.Sehir;
                ltrl_yazar.Text = d.Yazar;
                img_resim.ImageUrl = "DeneyimResimler/" + d.GeziResim;

                if (Session["uye"] != null)
                {
                    pnl_GirisVar.Visible = true;
                    pnl_GirisYok.Visible = false;
                }
                else
                {
                    pnl_GirisVar.Visible = false;
                    pnl_GirisYok.Visible = true;
                }
                rp_yorumlar.DataSource = dm.YorumListele(id);
                rp_yorumlar.DataBind();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void lbtn_yorumyap_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["did"]);
            Yorum y = new Yorum();
            y.DeneyimID = id;
            y.UyeID = ((Uye)Session["uye"]).ID;
            y.Icerik = tb_yorum.Text;
            y.Tarih = DateTime.Now;
            y.Durum = false;
            if (dm.YorumEkle(y))
            {
                if (dm.YorumEkle(y))
                {
                    Response.Write("<script>alert('Yorum Alındı. Onay verilince yayınlanacaktır')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Başarısız')</script>");
                }
            }
            
        }
    }
}