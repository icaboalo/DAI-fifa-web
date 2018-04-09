using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Team
/// </summary>
public class Team
{
    private int id;
    public String name { get; set; }
    public Team(int id, String name)
    {
        this.id = id;
        this.name = name;
    }

    public static Team getTeamById(int teamId, OdbcConnection con, Boolean closeCon)
    {
        OdbcCommand cmd = new OdbcCommand(String.Format("SELECT * FROM equipo WHERE id = {0};", teamId), con);
        OdbcDataReader reader = cmd.ExecuteReader();
        Team team = null;
        while (reader.Read())
        {
            team = new Team(reader.GetInt32(0), reader.GetString(1));
        }

        if (closeCon)
        {
            con.Close();
        }

        return team;
    }

    public override string ToString()
    {
        return this.name;
    }
}