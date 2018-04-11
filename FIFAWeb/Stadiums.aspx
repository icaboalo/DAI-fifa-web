<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Stadiums.aspx.cs" Inherits="Stadiums" %>

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
    </style>
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
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
            <br />
        <br />
        <br />
        <div id="container" style="padding:10px;">
            <div style="width: 50%; display: inline-block; zoom: 1; vertical-align: top; font-size: 18px;">
                <p style="display:inline-block;">Estadio: </p>&nbsp;
                <asp:DropDownList ID="spStadium" runat="server" OnSelectedIndexChanged="spStadium_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <br />
                <br />
                Dirección:&nbsp;&nbsp;
                <asp:Label ID="lbDir" runat="server"></asp:Label>
                <br />
            </div>
            <div style="width: 48%; display: inline-block; zoom: 1; vertical-align: top; font-size: 18px; padding-right:10px;">
                
                <div id="map" style="height:180px"></div>
            </div>
        </div>
        
    </form>
    <script>
        map;
      function initMap() {
        var uluru = {lat: <%= lat %>, lng: <%= lng %>};
        var map = new google.maps.Map(document.getElementById('map'), {
          zoom: 9,
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
