﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Players.aspx.cs" Inherits="Players" %>

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
        #map {
            height: 180px;
            background-color: lightgrey;
        }
        html, body {
            height: 100%;
            margin:0;
            padding:0;
        }
        form {
            width: 100%;
        }
        #container {height: 100%; width:100%; font-size:0;}
        #spStadium {
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
        ul {
            list-style-type: none;
            margin: 0;
            overflow: hidden;
            font-size: 20px;
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
            background-color: white;
            color: dodgerblue;
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
        #ddPlayer {
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
        #gvPlayer{ padding-left:5%;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <br />
        <nav style="height:80px; background-color:dodgerblue; padding-left:20px; padding-right:20px;">
            <p style="color:white; font-size: 46px; display: inline-block; margin-top:0; margin-bottom:0;">Russia 2018</p>
            <ul style="height:50px; display: inline-block;">
              <li><a class="active" href="Index.aspx">Inicio</a></li>
              <li><a href="Players.aspx">Jugadores</a></li>
              <li><a href="Games.aspx">Partidos</a></li>
              <li><a href="Stadiums.aspx">Estadios</a></li>
            </ul>
            <img src="Rusia.jpg" id="icon" align="right" style="display:inline-block" />
        </nav>
        <br />
        <div>
            
            <h3 style="margin-left: 40px">Tabla de goleo por jugador</h3>
            <br />
            <div style="padding-left:45px">
                <asp:GridView ID="gvPlayer" runat="server" AllowPaging="true" OnPageIndexChanging="gvPlayer_PageIndexChanging" PageSize="15" >
                <PagerSettings Mode="NextPreviousFirstLast" NextPageText="Siguiente" PreviousPageText="Anterior" />
                </asp:GridView>
            </div>

        </div>
    </form>
</body>
</html>
