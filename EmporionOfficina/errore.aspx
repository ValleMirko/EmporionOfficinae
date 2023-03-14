<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="errore.aspx.cs" Inherits="EmporionOfficina.errore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous" />
    <link rel="icon" href="./IMG/icons8-negozio-40.png" type="image/ico" />
    <title>Errore</title>
    <style>
        *{
            margin: 0 auto;
            padding: 0;
        }
        
        .card {
            border: none;
            padding: 10px;
            background-color: #1c1e21;
            color: #fff;
            border-radius: 10px;
            font-weight: 300;
            margin-top: 30%;
            margin-bottom: 30%;
        }

        body {
            font-family: "Poppins", sans-serif;
            font-weight: 300;
            background: url(./IMG/gradientErr.png) no-repeat center fixed;
            background-size: cover;
        }

        .titolo {
            font-size: 25px;
            font-weight: bold;
            align-self: center;
        }
    </style>
</head>
<body>
    <div>
        <form id="form1" runat="server">
            <asp:Panel runat="server" ID="divErrore">
                <asp:Panel runat="server" class="container mt-5 mb-5" ID="divUser">
                    <asp:Panel runat="server" class="row d-flex align-items-center justify-content-center">
                        <asp:Panel runat="server" class="col-md-5">
                            <asp:Panel runat="server" class="card px-5 py-5">
                                <asp:Label ID="label" runat="server" CssClass="mt-3 titolo" Text="Errore"></asp:Label>
                                <br />
                                <asp:Label runat="server" ID="lblErrore"></asp:Label>
                                <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Torna al Login" CssClass="btn btn-danger mt-4 " />
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
        </form>
    </div>
</body>
</html>
