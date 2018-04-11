<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Games.aspx.cs" Inherits="Games" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
         #icon{
	        width:70px;
	        height:70px;
            padding:5px;
	        opacity: 1;
	        }
         #container {height: 100%; width:100%;}
         
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
        #ddTeam {
             position: relative; 
                width: 200px;
                padding: 10px;
                margin: 0 auto;

                background: #9bc7de;
                color: #fff;
                outline: none;
                cursor: pointer;

                font-weight: bold;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav style="height:80px; background-color:green;">
            <p style="color:white; font-size: 46px;">Russia 2018
                <img src="Rusia.jpg" id="icon" align="right" />
            </p>
            <ul style="height:50px;">
              <li><a class="active" href="Index.aspx">Inicio</a></li>
              <li><a href="Players.aspx">Jugadores</a></li>
              <li><a href="Games.aspx">Partidos</a></li>
              <li><a href="Stadiums.aspx">Estadios</a></li>
            </ul>
            
        </nav>
        <br />
            <br />
        <br />
        <br />
        <div id="container" style="padding:10px;">
            Equipo:&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddTeam" runat="server" OnSelectedIndexChanged="ddTeam_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <div style="width: 40%; display: inline-block; zoom: 1; vertical-align: top;">
            Partidos pasados:<br />
            &nbsp;<asp:GridView ID="gvPast" runat="server">
            </asp:GridView>

            </div>
            <br />
            <div style="width: 40%; display: inline-block; zoom: 1; vertical-align: top;">
            Partidos siguientes:<br />
            &nbsp;<asp:GridView ID="gvNext" runat="server">
            </asp:GridView>
             </div>
        </div>
    </form>
</body>
</html>
