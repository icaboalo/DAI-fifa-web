using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Games : System.Web.UI.Page
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

    }

    protected void ddTeam_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvPast.DataSource = Match.getPreviousMatches(ddTeam.SelectedValue, addConnection());
        gvPast.DataBind();

        gvNext.DataSource = Match.getNextMatches(ddTeam.SelectedValue, addConnection());
        gvNext.DataBind();
    }
}