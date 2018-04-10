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
    protected double zoom = 7;
    protected OdbcConnection addConnection()
    {
        try
        {
            OdbcConnection con = new OdbcConnection("Driver={SQL Server Native Client 11.0};Server=localhost;Database=fifa;Trusted_Connection={Yes};");
            con.Open();
            return con;
        } catch (Exception e)
        {
            lbAddress.Text = e.Message;
            return null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        gvData.DataSource = Match.getMatches(addConnection());
        gvData.DataBind();
        getNextMatch();
    }

    private void getNextMatch()
    {
        Match match = Match.getNextMatch(addConnection());
        lbMatch.Text = match.ToString();
        lbDate.Text = match.date.ToString();
        lbAddress.Text = match.stadium.address;
        lat = match.stadium.lat;
        lng = match.stadium.lng;
        zoom = 11;
    }
}