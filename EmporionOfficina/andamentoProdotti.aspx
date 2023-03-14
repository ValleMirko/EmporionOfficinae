<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="andamentoProdotti.aspx.cs" Inherits="EmporionOfficina.andamentoProdotti" EnableEventValidation="false" EnableViewState="true" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous" />
    <link rel="icon" href="./IMG/icons8-negozio-40.png" type="image/ico" />
    <title>Statistiche</title>
    <style>
        .bottoniSocial {
            width: 2.5rem;
            height: 2.5rem;
            border-radius: 50%;
            position: relative;
            align-content: center;
            align-items: center;
            align-self: center;
            vertical-align: central;
        }

        .form-input {
            position: relative;
            margin-bottom: 10px;
            margin-top: 10px;
            background-color: white;
        }

        #icoFa:hover {
            background-color: #3b5998;
        }

        #icoTw:hover {
            background-color: #55acee;
        }

        #icoGo:hover {
            background-color: #dd4b39;
        }

        #icoIn:hover {
            background-color: #ac2bac;
        }

        #icoLi:hover {
            background-color: #0082ca;
        }

        #icoGi:hover {
            background-color: #333333;
        }

        .form-input i {
            position: absolute;
            font-size: 18px;
            top: 15px;
            left: 10px;
        }

        .form-control {
            height: 50px;
            /*background-color: #1c1e21;*/
            text-indent: 24px;
            font-size: 15px;
            background-color: white;
        }

        #footer {
            position: fixed;
            padding: 10px 10px 0px 10px;
            bottom: 0;
            width: 100%;
            /* Height of the footer*/
            height: 30px;
        }

        .card-footer small {
            letter-spacing: 7px !important;
            font-size: 12px
        }

        .border-line {
            border-right: 1px solid rgb(226, 206, 226)
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-md navbar-dark fixed-top" style="background-color: rgb(81,7,64);">
            <div class="navbar-collapse collapse w-100 order-1 order-md-0 dual-collapse2">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <asp:LinkButton ID="btnProdotti" CssClass="btn btn-sm btn-warning" OnClick="btnProdotti_Click" runat="server">Gestisci i tuoi prodotti</asp:LinkButton>
                    </li>
                </ul>
            </div>
            <div class="mx-auto order-0">
                <asp:Label ID="Label2" runat="server" class="navbar-brand mx-auto" Text="Statistiche"></asp:Label>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".dual-collapse2">
                    <span class="navbar-toggler-icon"></span>
                </button>
            </div>
            <div class="navbar-collapse collapse w-100 order-3 dual-collapse2">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item" style="color: white">
                        <asp:Label ID="Label1" runat="server" Style="display: inline-block; vertical-align: middle;" Text="Login effettuato:"></asp:Label>
                        <asp:Label ID="lblUtente" runat="server" Style="display: inline-block; vertical-align: middle; margin-right: 15px" Text=""></asp:Label>
                    </li>
                    <li class="nav-item" id="itemLogout">
                        <asp:LinkButton ID="btnLogout" class="btn btn-sm btn-danger " OnClick="btnLogout_Click" runat="server">Logout</asp:LinkButton>
                    </li>
                    <li class="nav-item" style="margin-left:10px;margin-right:10px;">
                        <asp:LinkButton ID="btnAccount" class="btn btn-sm btn-warning " OnClick="btnAccount_Click" runat="server">Modifica Account</asp:LinkButton>
                    </li>
                    <li class="nav-item" id="itemAdmin">
                        <asp:DropDownList ID="cmbAdmin" Visible="false" runat="server" CssClass="btn btn-sm btn-warning dropdown-navbar-toggler text-center" OnSelectedIndexChanged="cmbAdmin_SelectedIndexChanged"  AutoPostBack="true" AppendDataBoundItems="True">
                            <asp:ListItem Selected="True" Value="0">Privilegi Amministratore</asp:ListItem>
                            <asp:ListItem Value="Admin">Pagina Admin</asp:ListItem>
                            <asp:ListItem Value="Utente">Pagina Utente</asp:ListItem>
                            <asp:ListItem Value="Fornitore">Pagina Fornitore</asp:ListItem>
                            <asp:ListItem Value="Logout">Logout</asp:ListItem>
                        </asp:DropDownList>
                    </li>
                </ul>
            </div>
        </nav>
        <div class="container" style="padding-top: 70px; padding-bottom: 100px;">
            <asp:Panel runat="server" ID="divGrafico1" CssClass="container" Style="margin-left:20%;margin-right:20%;">
                <asp:Chart ID="chartProdotti" runat="server"  class="mx-auto">
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </asp:Panel>
            <asp:Panel runat="server" ID="divGrafico2" CssClass="container" Style="margin-left:20%;margin-right:20%;">
                <asp:Chart ID="chartCategorie" runat="server">
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </asp:Panel>
        </div>
        <footer class="bg-dark text-center text-white fixed-bottom">
            <!-- Grid container -->
            <div class="container p-1 pb-0">
                <!-- Section: Social media -->
                <section class="mb-1" style="margin-top: 8px;">
                        <!-- Facebook -->
                        <a class="btn btn-outline-light btn-floating m-1 bottoniSocial" id="icoFa" href="http://www.facebook.com" role="button"><i class="fab fa-facebook-f"></i></a>

                        <!-- Twitter -->
                        <a class="btn btn-outline-light btn-floating m-1 bottoniSocial" id="icoTw" href="http://www.twitter.com" role="button"><i class="fab fa-twitter"></i></a>

                        <!-- Google -->
                        <a class="btn btn-outline-light btn-floating m-1 bottoniSocial" id="icoGo" href="http://www.google.com" role="button"><i class="fab fa-google"></i></a>

                        <!-- Instagram -->
                        <a class="btn btn-outline-light btn-floating m-1 bottoniSocial" id="icoIn" href="http://www.instagram.com" role="button"><i class="fab fa-instagram"></i></a>

                        <!-- Linkedin -->
                        <a class="btn btn-outline-light btn-floating m-1 bottoniSocial" id="icoLi" href="http://www.linkedin.com" role="button"><i class="fab fa-linkedin-in"></i></a>

                        <!-- Github -->
                        <a class="btn btn-outline-light btn-floating m-1 bottoniSocial" id="icoGi" href="http://www.github.com" role="button"><i class="fab fa-github"></i></a>
                    </section>
                <!-- Section: Social media -->
            </div>
            <!-- Grid container -->

            <!-- Copyright -->
            <div class="text-center p-2" style="background-color: rgba(0, 0, 0, 0.2);">
                © 2022 Copyright 
            </div>
            <!-- Copyright -->
        </footer>
    </form>
</body>
</html>
