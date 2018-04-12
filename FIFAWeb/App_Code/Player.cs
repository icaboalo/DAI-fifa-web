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
    private int teamId;
    public int goals { get; set; }

    public Player(int id, int number, String name, String position, int teamId)
    {
        this.id = id;
        this.number = number;
        this.name = name;
        this.position = position;
        this.teamId = teamId;
        this.goals = 0;
    }

    public static List<Player> getPlayers(OdbcConnection con)
    {
        List<Player> list = new List<Player>();
        OdbcCommand cmd = new OdbcCommand(String.Format("SELECT * FROM jugador;"), con);
        OdbcDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Player(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));
        }

        foreach (Player player in list)
        {
            player.parsePlayer(con);
        }

        con.Close();
        return list;
    }

    public static List<Player> getPlayers(int teamId, OdbcConnection con)
    {
        List<Player> list = new List<Player>();
        OdbcCommand cmd = new OdbcCommand(String.Format("SELECT * FROM jugador WHERE idEquipo = {0}", teamId), con);
        OdbcDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Player(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));
        }

        foreach (Player player in list)
        {
            player.parsePlayer(con);
        }

        con.Close();
        return list;
    }

    public static Player getPlayerById(int playerId, OdbcConnection con, Boolean closeCon)
    {
        Player player = null;
        OdbcCommand cmd = new OdbcCommand(String.Format("SELECT * FROM jugador WHERE id = {0}", playerId), con);
        OdbcDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            player = new Player(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
        }

        if (closeCon)
        {
            con.Close();
        }
        return player;
    }

    public int getTeamId()
    {
        return this.teamId;
    }

    private void parsePlayer(OdbcConnection con)
    {
        this.team = Team.getTeamById(this.teamId, con, false);
        this.goals = getGoals(this.id, con);
    }

    private int getGoals(int id, OdbcConnection con)
    {
        int goals = 0;
        OdbcCommand cmd = new OdbcCommand(String.Format("SELECT COUNT(*) FROM gol WHERE idJugador = {0} GROUP BY idJugador", id), con);
        OdbcDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            goals = reader.GetInt32(0);
        }
        return goals;
    }

    public override string ToString()
    {
        return this.name;
    }
}