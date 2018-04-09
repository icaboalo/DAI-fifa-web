using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Player
/// </summary>
public class Player
{
    private int id;
    public int number { get; set; }
    public String name { get; set; }
    public String position { get; set; }
    public Team team { get; set; }

    public Player()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public List<Player> getPlayers(int teamId, OdbcConnection con)
    {
        List<Player> list = new List<Player>();
        OdbcCommand cmd = new OdbcCommand(String.Format(""), con);



        return list;
    }

    public override string ToString()
    {
        return this.name;
    }
}