<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QueueDodge.Web.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Queue Dodge</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="The description of my page" />
    <link href="styles/style.css" rel="stylesheet" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href='https://fonts.googleapis.com/css?family=Roboto+Condensed:400,300,700' rel='stylesheet' type='text/css'>
</head>

<body ng-app="app">

    <header>
        <h1>QUEUE DODGE</h1>
    </header>

    <div class="container-fluid">
        <nav>
            <ul>
                <li>Home</li>
                <li ui-sref="QueueDodge.Live">Live</li>
                <li>Ladder</li>
                <li>Title Calculator</li>
                <li>Conquest Calculator</li>
            </ul>
        </nav>
    </div>

    <div ui-view>
    </div>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundle/vendor/js") %>
        <%: Scripts.Render("~/bundle/app/js") %>
    </asp:PlaceHolder>
</body>
</html>

