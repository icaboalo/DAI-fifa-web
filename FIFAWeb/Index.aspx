<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
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
        #spFilter {
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
        #icon{
	        width:70px;
	        height:70px;
            padding:5px;
	        opacity: 1;
	        }
    </style>
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>


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
            <div style="width: 70%; display: inline-block; zoom: 1; vertical-align: top; font-size: 18px;">
                <asp:GridView ID="gvData" runat="server"></asp:GridView>
            </div>
            <div style="width: 28%; display: inline-block; zoom: 1; vertical-align: top; font-size: 18px; padding-right:10px;">
                <p>Proximo Partido:</p>
                <asp:Label ID="lbMatch" runat="server" Text="Alemania v.s México"></asp:Label>
                <br />
                Fecha: <asp:Label ID="lbDate" runat="server" Text="04/04/2018"></asp:Label>
                <br />
                Dirección: <asp:Label ID="lbAddress" runat="server" Text="Bla bla bla..."></asp:Label>
                <div id="map" style="height:180px"></div>
            </div>
        </div>
    </form>
    <script>
      var map;
      function initMap() {
        var uluru = {lat: <%= lat %>, lng: <%= lng %>};
        var map = new google.maps.Map(document.getElementById('map'), {
          zoom: <%= zoom %>,
          center: uluru
        });
        var marker = new google.maps.Marker({
          position: uluru,
          map: map
        });
    }
    google.maps.event.addDomListener(window, 'load', initMap);
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBQsUDdREYaW1kiQxxyFLV5qO9rHotNCDI"
    async defer></script>
</body>
</html>
