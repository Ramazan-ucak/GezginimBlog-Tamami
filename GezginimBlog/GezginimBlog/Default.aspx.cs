using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
namespace GezginimBlog
{
    public partial class Default : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                lv_deneyimler.DataSource = dm.DeneyimListele();
                lv_deneyimler.DataBind();
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["sid"]);
                lv_deneyimler.DataSource = dm.DeneyimListele(id);
                lv_deneyimler.DataBind();
            }
        }
    }
}