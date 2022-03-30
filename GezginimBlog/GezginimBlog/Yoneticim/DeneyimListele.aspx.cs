using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace GezginimBlog.Yoneticim
{
    public partial class DeneyimListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_deneyimler.DataSource = dm.DeneyimListele();
            lv_deneyimler.DataBind();
        }

        protected void lv_deneyimler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.DeneyimSil(id);

            }
            if (e.CommandName == "durum")
            {
                dm.DeneyimDurumDegistir(id);
            }
            lv_deneyimler.DataSource = dm.DeneyimListele();
            lv_deneyimler.DataBind();
        }
    }
}