<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Stadiums.aspx.cs" Inherits="Stadiums" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-color: green;
        }

        li {
            float: left;
        }

        li a {
            display: block;
            color: white;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
        }

        li a:hover {
            background-color: #111;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav style="height:50px; background-color:green;">
            <p style="color:white;">Russia 2018</p>
            <ul style="height:50px;">
              <li><a class="active" href="#inicio">Inicio</a></li>
              <li><a href="Index.aspx">Índice</a></li>
              <li><a href="Players.aspx">Jugadores</a></li>
              <li><a href="Games.aspx">Partidos</a></li>
              <li><a href="Stadiums.aspx">Estadios</a></li>
            </ul>
            <br />
            <br />
            <br />
        </nav>
        <div>
        </div>
    </form>
</body>
</html>
