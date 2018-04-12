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
    private int id, playerId;
    public int minute { get; set; }
    public Player player { get; set; }
    public Team team { get; set; }

    public Goal(int id, int minute, int playerId)
    {
        this.id = id;
        this.minute = minute;
        this.playerId = playerId;
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public static String getScoreboard(int matchId, int localId, int visitId, OdbcConnection con)
    {
        String scoreboard = "NA";
        List<Goal> matchGoals = new List<Goal>();
        OdbcCommand cmd = new OdbcCommand(String.Format("SELECT * FROM gol WHERE idPartido = {0}", matchId), con);
        OdbcDataReader reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            matchGoals.Add(new Goal(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
        }
        reader.Close();
        int localGoal = 0, visitGoal = 0;
        foreach(Goal goal in matchGoals)
        {
            goal.parseGoal(con);
            if (goal.player.getTeamId() == localId)
            {
                localGoal += 1;
            } else
            {
                visitGoal += 1;
            }
        }

        scoreboard = localGoal + " - " + visitGoal;

        return scoreboard;
    }

    public void parseGoal(OdbcConnection con)
    {
        this.player = Player.getPlayerById(this.playerId, con, false);
    }
}