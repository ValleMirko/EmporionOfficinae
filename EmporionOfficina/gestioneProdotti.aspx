<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestioneProdotti.aspx.cs" Inherits="EmporionOfficina.gestioneProdotti" EnableEventValidation="false" EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous" />
    <title>Gestione Prodotti</title>
    <link rel="icon" href="./IMG/icons8-negozio-40.png" type="image/ico" />
    <style>
        body {
            font-family: "Poppins", sans-serif;
            font-weight: 300;
            background: url(./IMG/sfondo3.jpg) no-repeat center fixed;
            background-size: cover;
        }

        .titolo {
            font-size: 25px;
            font-weight: bold;
            align-self: center;
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
            /*border-color: #0d6efd;*/
            border-color: #ffc107;
            text-decoration: none;
            align-self: center;
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

        .signup {
            height: 50px;
            font-size: 14px
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
        <div>
            <nav class="navbar navbar-expand-md navbar-dark fixed-top" style="background-color: rgb(81,7,64);">
                <div class="navbar-collapse collapse w-100 order-1 order-md-0 dual-collapse2">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item active">
                            <asp:LinkButton ID="btnProdotti" CssClass="btn btn-sm btn-warning" OnClick="btnProdotti_Click" runat="server">Gestisci i tuoi prodotti</asp:LinkButton>
                        </li>
                        <li class="nav-item" style="margin-left: 10px; margin-right: 10px;">
                            <asp:LinkButton runat="server" ID="btnAndamento" OnClick="btnAndamento_Click" class="btn btn-sm btn-warning">Andamento prodotti</asp:LinkButton>
                        </li>
                        <li class="nav-item" style="margin-right: 10px;">
                            <asp:LinkButton runat="server" ID="btnNuovoProdotto" class="btn btn-sm btn-warning" OnClick="btnNuovoProdotto_Click">Inserisci nuovo Prodotto</asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div class="mx-auto order-0">
                    <asp:Label ID="Label2" runat="server" class="navbar-brand mx-auto" Text="Gestione Prodotti"></asp:Label>
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
                            <asp:LinkButton ID="btnAccount" class="btn btn-sm btn-warning " OnClick="btnAccount_Click" runat="server">Modifica Account</asp:LinkButton>
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
        </div>
        <div class="container" style="text-align: center; padding-top: 50px; padding-bottom: 100px;">
            <br />
            <asp:PlaceHolder ID="tab" runat="server">
                <table id="tabProdotti" style="text-align: center; vertical-align: central; background-color: rgb(51,71,184); color: white; border: 2px solid white;" class="table">
                    <thead>
                        <tr>
                            <th>Gestione</th>
                            <th>Nome</th>
                            <th>Descrizione</th>
                            <th>Immagine</th>
                            <th>Prezzo</th>
                            <th>Categoria</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="contenutoTab" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </asp:PlaceHolder>
            <br />
            <asp:Label ID="lblErrore" runat="server" Text="" Font-Bold="True"></asp:Label>
            <asp:Panel ID="divNewProd" runat="server">
                <asp:Panel runat="server" class="container mt-5 mb-5" ID="Panel2">
                    <asp:Panel runat="server" class="row d-flex align-items-center justify-content-center">
                        <asp:Panel runat="server" class="col-md-6">
                            <asp:Panel runat="server" class="card px-5 py-5">
                                <asp:Label ID="lblTitolo" runat="server" CssClass="mt-3 titolo" Text="Inserimento Nuovo Prodotto"></asp:Label>
                                <br />
                                <asp:Label runat="server">Nome:</asp:Label>
                                <asp:Panel runat="server" class="form-input">
                                    <i class="fa fa-comment"></i>
                                    <asp:TextBox runat="server" type="text" ID="txtNomeProd" class="form-control" placeholder="Nome"></asp:TextBox>
                                </asp:Panel>
                                <asp:Label runat="server">Descrizione:</asp:Label>
                                <asp:Panel runat="server" class="form-input">
                                    <i class="fa fa-receipt"></i>
                                    <asp:TextBox runat="server" type="text" ID="txtDescrProd" CssClass="form-control" placeholder="Descrizione"></asp:TextBox>
                                </asp:Panel>
                                <asp:Label runat="server">Immagine:</asp:Label>
                                <asp:Panel runat="server" class="form-input">
                                    <asp:FileUpload ID="fileUp" runat="server" />
                                </asp:Panel>
                                <asp:Label runat="server">Prezzo:</asp:Label>
                                <asp:Panel runat="server" class="form-input">
                                    <i class="fa fa-cash-register"></i>
                                    <asp:TextBox runat="server" type="text" ID="txtPrezzoProd" CssClass="form-control" placeholder="Prezzo"></asp:TextBox>
                                </asp:Panel>
                                <asp:Label runat="server">Validità:</asp:Label>
                                <asp:Panel runat="server" class="form-input">
                                    <asp:CheckBox ID="chkValidita" CssClass="form-check-input" runat="server" Style="margin-top: -15px; margin-left: -10px;" />
                                </asp:Panel>
                                <asp:Label runat="server">Categoria:</asp:Label>
                                <asp:Panel runat="server" class="form-input">
                                    <asp:DropDownList ID="cmbCategorie" runat="server" CssClass="btn btn-sm btn-successfull dropdown-navbar-toggler text-center" AutoPostBack="true" AppendDataBoundItems="True">
                                    </asp:DropDownList>
                                </asp:Panel>
                                <div class="row mb-4">
                                    <div class="col">
                                        <asp:Button Style="width: 100%;" ID="btnAggiungi" runat="server" Text="Aggiungi" OnClick="btnAggiungi_Click" CssClass="btn btn-primary mt-4 signup" />
                                    </div>
                                    <div class="col">
                                        <asp:Button Style="width: 100%;" ID="btnIndietro" runat="server" Text="Indietro" OnClick="btnIndietro_Click" CssClass="btn btn-danger mt-4 signup" />
                                    </div>
                                </div>
                                <asp:Panel runat="server" class="text-center mt-3">
                                    <asp:Label ID="lblErroreInserimento" runat="server"></asp:Label>
                                    <asp:RegularExpressionValidator ControlToValidate="txtPrezzoProd" ErrorMessage="Prezzo non valido" ID="txtValid"
                                        ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" runat="server" ValidationGroup="Numbers" Visible="False">
                                    </asp:RegularExpressionValidator>
                                </asp:Panel>
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>


            <asp:Panel ID="divModifica" runat="server" Visible="False">
                <asp:Panel runat="server" class="container mt-5 mb-5" ID="Panel3">
                    <asp:Panel runat="server" class="row d-flex align-items-center justify-content-center">
                        <asp:Panel runat="server" class="col-md-6">
                            <asp:Panel runat="server" class="card px-5 py-5">
                                <asp:Label ID="lblTitoloMod" runat="server" CssClass="mt-3 titolo" Text="Modifica Prodotto"></asp:Label>
                                <br />
                                <asp:Label runat="server">Nome:</asp:Label>
                                <asp:Panel runat="server" class="form-input">
                                    <i class="fa fa-comment"></i>
                                    <asp:TextBox runat="server" type="text" ID="txtNomeMod" class="form-control" placeholder="Nome"></asp:TextBox>
                                </asp:Panel>
                                <asp:Label runat="server">Descrizione:</asp:Label>
                                <asp:Panel runat="server" class="form-input">
                                    <i class="fa fa-receipt"></i>
                                    <asp:TextBox runat="server" type="text" ID="txtDescrMod" CssClass="form-control" placeholder="Descrizione"></asp:TextBox>
                                </asp:Panel>
                                <div style="display: inline-block;">
                                    <asp:Label runat="server">Modifica l'immagine:</asp:Label>
                                    <asp:CheckBox Style="margin-left: 10px; margin-top: 2px" ID="chkFileMod" CssClass="form-check-input" runat="server" />
                                </div>
                                <asp:Panel runat="server" class="form-input">
                                    <asp:FileUpload ID="fileUpMod" runat="server" />
                                </asp:Panel>
                                <asp:Label runat="server">Prezzo:</asp:Label>
                                <asp:Panel runat="server" class="form-input">
                                    <i class="fa fa-cash-register"></i>
                                    <asp:TextBox runat="server" type="text" ID="txtPrezzoMod" CssClass="form-control" placeholder="Prezzo"></asp:TextBox>
                                </asp:Panel>
                                <asp:Label runat="server">Validità:</asp:Label>
                                <asp:Panel runat="server" class="form-input">
                                    <asp:CheckBox ID="chkValiditaMod" style="margin-left:30px;margin-top:-40px;" CssClass="form-check-input" runat="server" />
                                </asp:Panel>
                                <asp:Label runat="server">Categoria:</asp:Label>
                                <asp:Panel runat="server" class="form-input">
                                    <asp:DropDownList ID="cmbCategoriaMod" runat="server" CssClass="btn btn-sm btn-successfull dropdown-navbar-toggler text-center" AutoPostBack="true" AppendDataBoundItems="True">
                                    </asp:DropDownList>
                                </asp:Panel>
                                <div class="row mb-4">
                                    <div class="col">
                                        <asp:Button Style="width: 100%;" ID="btnModificaProd" runat="server" OnClick="btnModificaProd_Click" Text="Modifica" CssClass="btn btn-primary mt-4 signup" />
                                    </div>
                                    <div class="col">
                                        <asp:Button Style="width: 100%;" ID="btnIndietroMod" runat="server" OnClick="btnIndietroMod_Click" Text="Indietro" CssClass="btn btn-danger mt-4 signup" />
                                    </div>
                                </div>
                                <asp:Panel runat="server" class="text-center mt-3">
                                    <asp:Label ID="lblErroreModifica" runat="server"></asp:Label>
                                    <asp:RegularExpressionValidator ControlToValidate="txtPrezzoMod" ErrorMessage="Prezzo non valido" ID="txtValidMod"
                                        ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" runat="server" ValidationGroup="Numbers" Visible="False">
                                    </asp:RegularExpressionValidator>
                                    <asp:Label ID="lblIdProd" runat="server" Visible="False"></asp:Label>
                                </asp:Panel>
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>
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
