<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestioneCarrello.aspx.cs" Inherits="EmporionOfficina.visualizzaCarrello" EnableEventValidation="false" EnableViewState="true" %>

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
    <title>Gestione Carrello</title>
    <style>
        body {
            background: url(./IMG/3d-background-neon-ultraviolet-purple-3840x2160-2562.jpg) no-repeat center fixed;
            background-size: cover;
        }

        .titolo {
            font-size: 25px;
            font-weight: bold;
            align-self: center;
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
            box-shadow: 2px 2px 10px 0px rgb(190, 108, 170)
        }

        hr {
            background-color: rgba(248, 248, 248, 0.667)
        }

        .bold {
            font-weight: 500
        }

        .change-color {
            color: #AB47BC !important
        }

        .card-2 {
            box-shadow: 1px 1px 3px 0px rgb(112, 115, 139)
        }

        .fa-circle.active {
            font-size: 8px;
            color: #AB47BC
        }

        .fa-circle {
            font-size: 8px;
            color: #aaa
        }

        .rounded {
            border-radius: 2.25rem !important
        }

        .progress-bar {
            background-color: #AB47BC !important
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
            background-color: #AB47BC;
            color: #fff
        }

        h2 {
            color: rgb(78, 0, 92);
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
                border-right: 0px solid rgb(226, 206, 226) !important
            }
        }

        @media (max-width: 700px) {
            h2 {
                color: rgb(78, 0, 92);
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
        <nav class="navbar navbar-expand-md navbar-dark fixed-top" style="background-color: rgb(63,3,133);">
            <div class="navbar-collapse collapse w-100 order-1 order-md-0 dual-collapse2">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item" style="margin-left: 10px; margin-right: 10px;">
                        <asp:LinkButton ID="btnProdotti" class="btn btn-sm btn-warning" OnClick="btnProdotti_Click" runat="server">Visualizza Prodotti</asp:LinkButton>
                    </li>
                </ul>
            </div>
            <div class="mx-auto order-0">
                <asp:Label ID="Label2" runat="server" class="navbar-brand mx-auto" Text="Carrello"></asp:Label>
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
                        <asp:DropDownList ID="cmbAdmin" Visible="false" runat="server" CssClass="btn btn-sm btn-warning dropdown-navbar-toggler text-center" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="cmbAdmin_SelectedIndexChanged">
                            <asp:ListItem selected="True" Value="0">Privilegi Amministratore</asp:ListItem>
                            <asp:ListItem Value="Admin">Pagina Admin</asp:ListItem>
                            <asp:ListItem Value="Utente">Pagina Utente</asp:ListItem>
                            <asp:ListItem Value="Fornitore">Pagina Fornitore</asp:ListItem>
                            <asp:ListItem Value="Logout">Logout</asp:ListItem>
                        </asp:DropDownList>
                    </li>
                </ul>
            </div>
        </nav>
        <div class="container" style="padding-top:50px;padding-bottom: 100px;">
            <asp:PlaceHolder ID="divCarrello" runat="server">
                <asp:Panel runat="server" ID="containerFluid" class="container-fluid my-5 d-flex justify-content-center">
                    <asp:Panel ID="carta" runat="server" Style="min-width: 60%;" class="card card-1">
                        <div class="card-header bg-white">
                            <div class="media flex-sm-row flex-column-reverse justify-content-between ">
                                <div class="col my-auto">
                                    <asp:Label runat="server" Style="font-size: 25px" ID="lblCarrello" class="mb-0">Prodotti nel carrello:</asp:Label>
                                    <asp:Label runat="server" Style="font-size: 25px" ID="lblErrore" Visible="false" class="mb-0"></asp:Label>
                                </div>
                                <div class="col-auto text-center my-auto pl-0 pt-sm-4">
                                    <asp:Image runat="server" ID="imgCarrello" class="img-fluid my-auto align-items-center mb-0 pt-3" ImageUrl="" Width="115" Height="115" />
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="cardBody" runat="server" class="card-body">
                            <div class="row justify-content-between mb-3">
                                <div class="col-auto">
                                    <h6 class="color-1 mb-0 change-color">Carrello</h6>
                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel runat="server" ID="divTotale">
                            <div class="row" style="margin-left: 15px; margin-right: 15px; margin-bottom: 15px;">
                                <div class="col-auto">
                                    <p class="mb-1 text-dark"><b>Informazioni ordine:</b></p>
                                    <br />
                                    <p class="mb-1 text-dark">- IVA inclusa: 22%</p>
                                    <p class="mb-1 text-dark">- Spedizione: Gratuita</p>
                                    <!--<p class="mb-1 text-dark"><b>Order Details</b></p>-->
                                </div>
                            </div>
                            <div class="row justify-content-between" style="margin-left: 15px; margin-right: 15px; margin-bottom: 15px;">
                                <div class="col-auto my-auto ">
                                    <asp:Button runat="server" ID="btnSvuota" Class="btn btn-danger " OnClick="btnSvuota_Click" Text="Svuota Carrello" />
                                </div>
                                <div class="col-auto my-auto ml-auto">
                                    <asp:Button runat="server" Class="btn btn-success " ID="btnAcquista" OnClick="btnAcquista_Click" Text="Acquista" />
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="divFooter" Class="card-footer">
                            <div class="jumbotron-fluid">
                                <div class="row justify-content-between ">
                                    <div class="col-sm-auto col-auto my-auto">
                                        <img class="img-fluid my-auto align-self-center " src="IMG/icons8-scontrino-40.png" width="115" height="115" />
                                    </div>
                                    <div class="col-auto my-auto ">
                                        <h2 class="mb-0 font-weight-bold">TOTALE: </h2>
                                    </div>
                                    <div class="col-auto my-auto ml-auto">
                                        <asp:Label runat="server" ID="lblTotale" Style="font-size: 30px" class="display-3 ">e</asp:Label>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="divConferma" runat="server" Visible="False">
                <asp:Panel runat="server" class="container mt-5 mb-5" ID="divUser">
                    <asp:Panel runat="server" class="row d-flex align-items-center justify-content-center">
                        <asp:Panel runat="server" class="col-md-6">
                            <asp:Panel runat="server" class="card px-5 py-5">
                                <asp:Label ID="lblTitolo" runat="server" CssClass="mt-3 titolo" Text="Conferma svuotamento completo del carrello"></asp:Label>
                                <br />
                                <div class="row mb-4">
                                    <div class="col">
                                        <asp:Button Style="width: 100%;" ID="btnConferma" runat="server" Text="Conferma" OnClick="btnConferma_Click" CssClass="btn btn-success mt-4 " />
                                    </div>
                                    <div class="col">
                                        <asp:Button Style="width: 100%;" ID="btnIndietro" runat="server" Text="Indietro" OnClick="btnIndietro_Click" CssClass="btn btn-danger mt-4 " />
                                    </div>
                                </div>
                                <asp:Panel runat="server" class="text-center mt-3" Style="color: red;">
                                    <asp:Label ID="lbl" runat="server">Attenzione, i dati eliminati non potranno essere recuperati.</asp:Label>
                                    <asp:Label ID="lblErr" runat="server" Visible="false"></asp:Label>
                                </asp:Panel>
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="divAcquista" runat="server" Visible="False">
                <asp:Panel runat="server" class="container mt-5 mb-5" ID="Panel1">
                    <asp:Panel runat="server" class="row d-flex align-items-center justify-content-center">
                        <asp:Panel runat="server" class="col-md-6">
                            <asp:Panel runat="server" class="card px-5 py-5">
                                <asp:Label ID="lblTipo" runat="server" CssClass="mt-3 titolo" Text="Conferma Acquisto"></asp:Label>
                                <br />
                                <asp:Label runat="server">Numero di carta:</asp:Label>
                                <asp:Panel runat="server">
                                    <asp:TextBox runat="server" ID="txtNum" type="text" class="form-control" placeholder="Numero di carta"></asp:TextBox>
                                </asp:Panel>
                                <br />
                                <asp:Label runat="server">Nome proprietario:</asp:Label>
                                <asp:Panel runat="server">
                                    <asp:TextBox runat="server" ID="txtNome" type="text" class="form-control" placeholder="Nome proprietario"></asp:TextBox>
                                </asp:Panel>
                                <br />
                                <asp:Label runat="server">Data di scadenza della carta:</asp:Label>
                                <div class="row mb-4">
                                    <div class="col">
                                        <asp:TextBox ID="txtGiorno" Style="width: 100%;" runat="server" type="text" class="form-control" placeholder="Giorno"></asp:TextBox>
                                    </div>
                                    <div class="col">
                                        <asp:TextBox ID="txtMese" Style="width: 100%;" runat="server" type="text" class="form-control" placeholder="Mese"></asp:TextBox>
                                    </div>
                                    <div class="col">
                                        <asp:TextBox ID="txtAnno" Style="width: 100%;" runat="server" type="text" class="form-control" placeholder="Anno"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <asp:Label runat="server">Metodo di pagamento:</asp:Label>
                                <asp:Panel runat="server" class="form-input">
                                    <asp:DropDownList ID="cmbPagamento" runat="server" CssClass="btn btn-sm btn-successfull dropdown-navbar-toggler text-center">
                                        <asp:ListItem Selected="True">Carta di Credito</asp:ListItem>
                                        <asp:ListItem>Carta Prepagata</asp:ListItem>
                                        <asp:ListItem>Satispay</asp:ListItem>
                                        <asp:ListItem>MasterCard</asp:ListItem>
                                        <asp:ListItem>Altro</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:Panel>
                                <br />
                                <div class="row mb-4">
                                    <div class="col">
                                        <asp:Button ID="btnConfermaAcquisto" Style="width: 100%;" runat="server" Text="Conferma" OnClick="btnConfermaAcquisto_Click" CssClass="btn btn-success mt-4" />
                                    </div>
                                    <div class="col">
                                        <asp:Button ID="btnIndietroAcquisto" Style="width: 100%;" runat="server" Text="Indietro" OnClick="btnIndietroAcquisto_Click" CssClass="btn btn-danger mt-4" />
                                    </div>
                                </div>

                                <asp:Panel runat="server" class="text-center mt-3" Style="color: red;">
                                    <asp:Label ID="lblErroreAcquisto" runat="server" Font-Bold="True"></asp:Label>
                                </asp:Panel>
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>
            </asp:PlaceHolder>
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
