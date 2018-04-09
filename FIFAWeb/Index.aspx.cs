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
            OdbcConnection con = new OdbcConnection("Driver={SQL Server Native Client 11.0};Server=CC102-28;Uid=sa;Pwd=sqladmin;Database=fifa;");
            con.Open();
            return con;
        } catch (Exception e)
        {
            return null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        spFilter.Items.Add("Partido");
        spFilter.Items.Add("Partido");
        spFilter.Items.Add("Equipo");

        gvData.DataSource = Match.getMatches(addConnection());
        gvData.DataBind();
        lbMatch.Text = (gvData.DataSource as List<Match>).Count + "";
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
                List<Match> list = gvData.DataSource as List<Match>;
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    Match match = list[i];
                    if (!match.local.ToString().Equals(tbFilter.Text) && !match.visit.ToString().Equals(tbFilter.Text))
                    {
                        list.RemoveAt(i);
                    }
                }
                gvData.DataSource = list;
                gvData.DataBind();
                lbMatch.Text = (gvData.DataSource as List<Match>).Count + "";

                break;
            case "Jugador":
                break;
            case "Equipo":
                break;
        }
    }

    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }
}