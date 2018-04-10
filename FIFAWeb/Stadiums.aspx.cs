using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Stadiums : System.Web.UI.Page
{
    protected double lat = 0.0;
    protected double lng = 0.0;
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

    }
}