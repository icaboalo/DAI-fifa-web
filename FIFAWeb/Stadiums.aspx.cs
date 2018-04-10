using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Stadiums : System.Web.UI.Page
{
    public double lat = 0;
    public double lng = 0;
    protected double zoom = 7;

    protected OdbcConnection addConnection()
    {
        try
        {
            OdbcConnection con = new OdbcConnection("Driver={SQL Server Native Client 11.0};Server=CC102-28;Uid=sa;Pwd=sqladmin;Database=fifa;");
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
        if (!IsPostBack)
        {
            OdbcConnection con = addConnection();
            if (con != null)
            {               
                    //spStadium.Items.Add(lector.GetString(0));
                spStadium.DataSource = Stadium.getStadiums(con);
                spStadium.DataBind();
            }
        }
    }

    protected void spStadium_SelectedIndexChanged(object sender, EventArgs e)
    {
        OdbcConnection con = addConnection();
        if (con != null)
        {
            Stadium stadium = Stadium.getInfo(con, spStadium.SelectedValue.ToString());
            lat = stadium.lat;
            lng = stadium.lng;
            zoom = 11;
            tbDir.Text = stadium.address;
        }
    }
}