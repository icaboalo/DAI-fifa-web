using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected double lat = 0.0;
    protected double lng = 0.0;
    protected OdbcConnection addConnection()
    {
        try
        {
            OdbcConnection con = new OdbcConnection("Driver={SQL Server Native Client 11.0}");
            con.Open();
            return con;
        } catch (Exception e)
        {
            return null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lat = 26.329490;
        lng = -97.503571;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String filter = spFilter.SelectedValue;
        String filterText = tbFilter.Text;
        switch (filter)
        {
            case "Partido":
                break;
            case "Jugador":
                break;
            case "Equipo":
                break;
        }
    }

    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");
            l.Attributes.Add("onclick", "javascript:return " +
            "confirm('Are you sure you want to delete this record? " + "')");
        }
    }
}