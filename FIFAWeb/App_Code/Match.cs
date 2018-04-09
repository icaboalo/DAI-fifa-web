using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Match
/// </summary>
public class Match
{
    private int id;
    public DateTime date { get; set; }
    public Team local { get; set; }
    public Team visit { get; set; }

    public Match()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public override string ToString()
    {
        return this.local + " v.s " + this.visit;
    }
}