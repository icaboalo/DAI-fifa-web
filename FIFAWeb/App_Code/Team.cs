using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Team
/// </summary>
public class Team
{
    private int id;
    public String name { get; set; }
    public Team()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public override string ToString()
    {
        return this.name;
    }
}