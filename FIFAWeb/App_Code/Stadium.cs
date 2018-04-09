using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Stadium
/// </summary>
public class Stadium
{
    private int id;
    public double lat { get; set; }
    public double lng { get; set; }
    public String name {get; set;}


    public Stadium(int id, String name, double lat, double lng)
    {
        this.id = id;
        this.name = name;
        this.lat = lat;
        this.lng = lng;
    }

    public static Stadium getStadiumById(int id, OdbcConnection con)
    {
        Stadium stadium = null;
        OdbcCommand cmd = new OdbcCommand(String.Format("SELECT * FROM estadio WHERE id = {0};", id), con);
        OdbcDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            stadium = new Stadium(reader.GetInt32(0), reader.getString(1), reader.GetDouble(2), reader.GetDouble(3));
        }
        return stadium;
    }
    
    override String toString() {
        return this.name;
    }
}
