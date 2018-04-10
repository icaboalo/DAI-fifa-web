using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Players : System.Web.UI.Page
{
    protected OdbcConnection addConnection()
    {
        try
        {
            OdbcConnection con = new OdbcConnection("Driver={SQL Server Native Client 11.0};Server=localhost;Database=fifa;Trusted_Connection={Yes};");
            con.Open();
            return con;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        List<Player> list = Player.getPlayers(addConnection());
        list.Sort(delegate (Player p1, Player p2) { return p2.goals.CompareTo(p1.goals); });
        gvPlayer.DataSource = list;
        gvPlayer.DataBind();
    }

    protected void gvPlayer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPlayer.PageIndex = e.NewPageIndex;
    }
}