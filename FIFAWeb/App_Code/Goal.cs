using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Goal
/// </summary>
public class Goal
{
    private int id;
    public int minute { get; set; }
    public Player player { get; set; }
    public Team team { get; set; }

    public Goal()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public static String getScoreboard(int matchId, int localId, int visitId, OdbcConnection con)
    {
        String scoreboard = "NA";
        OdbcCommand cmd = new OdbcCommand(String.Format("SELECT COUNT(*) FROM gol WHERE idPartido = {0} AND "), con);


        return scoreboard;
    }
}