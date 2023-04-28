<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisualizzazioneProdotti.aspx.cs" Inherits="EmporiumOfficine.VisualizzazioneProdotti" EnableEventValidation="false" EnableViewState="true" %>

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
    <title>Emporium Officinea</title>
    <style>
        body {
            background: url(./IMG/TevereEmporium.jpg) no-repeat center fixed;
            background-size: cover;
        }

        .container-fluid {
            margin-top: 200px
        }

        p {
            font-size: 14px;
            margin-bottom: 7px
        }

        .small {
            letter-spacing: 0.5px !important
        }

        .card-1 {
            box-shadow: 2px 2px 10px 0px rgb(10, 5, 115)
        }

        hr {
            background-color: rgba(10, 5, 115, 0.667)
        }

        .bold {
            font-weight: 500
        }

        .change-color {
            color: #0b0494 !important
        }

        .card-2 {
            box-shadow: 1px 1px 3px 0px rgb(10, 5, 115)
        }

        .fa-circle.active {
            font-size: 8px;
            color: #0b0494
        }

        .fa-circle {
            font-size: 8px;
            color: #aaa
        }

        .rounded {
            border-radius: 2.25rem !important
        }

        .progress-bar {
            background-color:  !important
        }

        .progress {
            height: 5px !important;
            margin-bottom: 0
        }

        .invoice {
            position: relative;
            top: -70px
        }

        .Glasses {
            position: relative;
            top: -12px !important
        }

        .card-footer {
            background-color: #75151e;
            color: #ebebe8
        }

        h2 {
            color: white;
            letter-spacing: 2px !important
        }

        .display-3 {
            font-weight: 500 !important
        }

        @media (max-width: 479px) {
            .invoice {
                position: relative;
                top: 7px
            }

            .border-line {
                border-right: 0px solid rgb(10, 5, 115) !important
            }
        }

        @media (max-width: 700px) {
            h2 {
                color: white;
                font-size: 17px
            }

            .display-3 {
                font-size: 28px;
                font-weight: 500 !important
            }
        }

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
            background-color: #3b5998; /* blu */
        }

        #icoTw:hover {
            background-color: #55acee; /*azzurro*/
        }

        #icoGo:hover {
            background-color: #dd4b39; /*rosso chiaro*/
        }

        #icoIn:hover {
            background-color: #eb87eb; /*Viola chiaro*/
        }

        #icoLi:hover {
            background-color: #0082ca; /*azzuro scuro*/
        }

        #icoGi:hover {
            background-color: #333333; /*nero*/
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

        .account {
            height: 50px;
            width: 50px;
            display: flex;
            justify-content: center;
            align-items: center;
            border: 3px solid #eee;
            border-radius: 50%;
            margin-right: 10px;
            cursor: pointer;
            border-color: #0d6efd;
            text-decoration: none;
            align-self: center;
        }

            .account:hover {
                text-decoration: none;
            }

            .account span {
                color: rgb(0, 76, 255);
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-md navbar-dark fixed-top" style="background-color: rgb(141, 0, 0);">
            <div class="navbar-collapse collapse w-100 order-1 order-md-0 dual-collapse2">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <asp:DropDownList ID="cmbCategorie" runat="server" CssClass="btn btn-sm btn-warning dropdown-navbar-toggler text-center" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="cmbCategorie_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="0">Tutte le categorie</asp:ListItem>
                        </asp:DropDownList>
                    </li>
                    <li class="nav-item" style="margin-left: 10px; margin-right: 10px;">
                        <asp:LinkButton ID="btnStorico" class="btn btn-sm btn-warning" runat="server" OnClick="btnStorico_Click">Storico Ordini</asp:LinkButton>
                    </li>
                    <li class="nav-item" style="margin-right: 10px;">
                        <asp:LinkButton ID="btnCarrello" class="btn btn-sm btn-warning" runat="server" OnClick="btnCarrello_Click">Gestisci Carrello</asp:LinkButton>
                    </li>
                </ul>
            </div>
            <div class="mx-auto order-0">
                <asp:Label ID="Label2" runat="server" class="navbar-brand mx-auto" Text="Prodotti"></asp:Label>
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
                    <li class="nav-item" style="margin-left: 10px; margin-right: 10px;">
                        <asp:LinkButton ID="btnAccount" class="btn btn-sm btn-warning " runat="server" OnClick="btnAccount_Click">Modifica Account</asp:LinkButton>
                    </li>
                    <li class="nav-item" id="itemAdmin">
                        <asp:DropDownList ID="cmbAdmin" Visible="false" runat="server" CssClass="btn btn-sm btn-warning dropdown-navbar-toggler text-center" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="cmbAdmin_SelectedIndexChanged">
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
        <div class="container" style="padding-top: 50px; padding-bottom: 100px;">
            <asp:Panel ID="divCarte" runat="server" CssClass=" mt-5">
            </asp:Panel>
            <asp:Panel runat="server" ID="divStorico1" Visible="false">
                <asp:Label runat="server" ID="lblStorico" Font-Bold="True"></asp:Label>
                <asp:Panel runat="server" ID="divStorico" Style="min-width:70%">
              
                    
                </asp:Panel>
            </asp:Panel>
        </div>
        <footer class="bg-dark text-center text-white fixed-bottom">
            <!-- Copyright -->
            <div class="text-center p-2" style="background-color: rgba(0, 0, 0, 0.2);">
                © 2023 Copyright
            </div>
            <!-- Copyright -->
        </footer>
    </form>
</body>
</html>
