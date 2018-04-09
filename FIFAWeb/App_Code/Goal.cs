using System;
using System.Collections.Generic;
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
}