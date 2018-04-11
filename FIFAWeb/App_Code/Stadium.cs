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
    public String address { get; set; }


    public Stadium(int id, String name, double lat, double lng, String address)
    {
        this.id = id;
        this.name = name;
        this.lat = lat;
        this.lng = lng;
        this.address = address;
    }
    public Stadium( double lat, double lng, String address)
    {
        this.lat = lat;
        this.lng = lng;
        this.address = address;
    }
    public Stadium(String name)
    {
        this.name = name;
    }

    public static Stadium getStadiumById(int id, OdbcConnection con)
    {
        Stadium stadium = null;
        OdbcCommand cmd = new OdbcCommand(String.Format("SELECT * FROM estadio WHERE id = {0};", id), con);
        OdbcDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            stadium = new Stadium(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetString(4));
        }
        return stadium;
    }

    public static List<Stadium> getStadiums(OdbcConnection con)
    {
        List<Stadium> list = new List<Stadium>();
        OdbcCommand cmd = new OdbcCommand("SELECT distinct nombre FROM estadio;", con);
        OdbcDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Stadium(reader.GetString(0)));
        }
        reader.Close();
        con.Close();
        return list;
    }
    public static Stadium getInfo(OdbcConnection con, String nom)
    {
        Stadium stadium = null;
        OdbcCommand cmd = new OdbcCommand("SELECT * FROM estadio where nombre= '"+nom+"';", con);
        OdbcDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            stadium = new Stadium(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetString(4));
        }
        return stadium;
    }

    public override string ToString()
    {
        return this.name;
    }
}
