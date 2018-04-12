using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Match
/// </summary>
public class Match
{
    private int id, localId, visitId, stadiumId;
    public String localTeam { get; set; }
    public String visitTeam { get; set; }
    public DateTime date { get; set; }
    public Team local { get; set; }
    public Team visit { get; set; }
    public Stadium stadium { get; set; }
    public String scoreboard { get; set; }

    public Match(int id, DateTime date, int localId, int visitId, int stadiumId)
    {
        this.id = id;
        this.date = date;
        this.localId = localId;
        this.visitId = visitId;
        this.stadiumId = stadiumId;
    }

    public static Match getNextMatch(OdbcConnection con)
    {
        Match match = null;
        OdbcCommand cmd = new OdbcCommand("SELECT TOP 1 * FROM partido ORDER BY fecha ASC;", con);
        OdbcDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            match = new Match(reader.GetInt32(0), reader.GetDate(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4));
        }
        match.parseMatch(con);
        con.Close();
        return match;
    }

    public static List<Match> getMatches(OdbcConnection con)
    {
        List<Match> list = new List<Match>();
        OdbcCommand cmd = new OdbcCommand("SELECT * FROM partido;", con);
        OdbcDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Match(reader.GetInt32(0), reader.GetDate(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4)));
        }
        reader.Close();

        foreach (Match match in list)
        {
            match.parseMatch(con);
        }
        con.Close();
        return list;
    }

    public static List<Match> getMatchesByDate(String date, OdbcConnection con) {
        List<Match> list = new List<Match>();
        OdbcCommand cmd = new OdbcCommand(String.Format("SELECT * FROM partido WHERE fecha LIKE '%{0}%'", date), con);
        OdbcDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Match(reader.GetInt32(0), reader.GetDate(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4)));
        }
        reader.Close();

        foreach (Match match in list)
        {
            match.parseMatch(con);
        }
        con.Close();
        return list;
    }

    public static List<Match> getMatchesByTeam(String team, OdbcConnection con)
    {
        List<Match> list = new List<Match>();


        OdbcCommand cmd = new OdbcCommand(String.Format("SELECT * FROM partido WHERE fecha LIKE '%{0}%'", team), con);
        OdbcDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Match(reader.GetInt32(0), reader.GetDate(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4)));
        }
        reader.Close();

        foreach (Match match in list)
        {
            match.parseMatch(con);
        }
        con.Close();

        return list;
    }

    private Match parseMatch(OdbcConnection con)
    {
        this.local = Team.getTeamById(this.localId, con, false);
        this.localTeam = this.local.ToString();
        this.visit = Team.getTeamById(this.visitId, con, false);
        this.visitTeam = this.visit.ToString();
        this.stadium = Stadium.getStadiumById(this.stadiumId, con);
        this.scoreboard = Goal.getScoreboard(this.id, this.local.id, this.visit.id, con);
        return this;
    }

    public static List<Match> getNextMatches(String teamName, OdbcConnection con)
    {
        List<Match> list = new List<Match>();
        Team team = Team.getTeamByName(teamName, con, false);
        OdbcCommand cmd = new OdbcCommand(String.Format("SELECT * FROM partido WHERE fecha >= GETDATE() AND (idLocal = {0} OR idVisitante = {0})", team.id), con);
        OdbcDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new Match(reader.GetInt32(0), reader.GetDate(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4)));
        }

        reader.Close();

        foreach (Match match in list)
        {
            Console.Out.WriteLine(match.ToString());
            match.parseMatch(con);
        }
        con.Close();
        return list;
    }

    public static List<Match> getPreviousMatches(String teamName, OdbcConnection con)
    {
        List<Match> list = new List<Match>();
        Team team = Team.getTeamByName(teamName, con, false);
        OdbcCommand cmd = new OdbcCommand(String.Format("SELECT * FROM partido WHERE fecha < GETDATE() AND (idLocal = {0} OR idVisitante = {0})", team.id), con);
        OdbcDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new Match(reader.GetInt32(0), reader.GetDate(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4)));
        }

        reader.Close();

        foreach (Match match in list)
        {
            Console.Out.WriteLine(match.ToString());
            match.parseMatch(con);
        }
        con.Close();
        return list;
    }

    public override string ToString()
    {
        return this.local + " v.s " + this.visit;
    }
}