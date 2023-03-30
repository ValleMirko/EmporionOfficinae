<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modificaAccount.aspx.cs" Inherits="EmporiumOfficine.modificaAccount" EnableEventValidation="false" EnableViewState="true" %>

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
    <title>Modifica account</title>
    <style>
        .account {
            height: 50px;
            width: 50px;
            display: flex;
            justify-content: center;
            align-items: center;
            border: 1px solid #eee;
            border-radius: 50%;
            margin-right: 10px;
            cursor: pointer
        }

        body {
            font-family: "Poppins", sans-serif;
            font-weight: 300;
            background: url(./IMG/gradientVerde.jpeg) no-repeat center fixed;
            background-size: cover;
        }

        .titolo {
            font-size: 25px;
            font-weight: bold;
            align-self: center;
        }

        .account:hover {
            border-color: #0d6efd;
            text-decoration: none;
        }


        .account:active {
            border-color: #021232;
            text-decoration: none;
        }

        .btnSel {
            border-color: #9238e0;
            border-style: solid;
            border-width: 3px;
        }

        .height {
            height: 100vh
        }

        .card {
            border: none;
            padding: 20px;
            background-color: #1c1e21;
            color: #fff;
            border-radius: 10px;
        }

        .form-input {
            position: relative;
            margin-bottom: 10px;
            margin-top: 10px
        }

            .form-input i {
                position: absolute;
                font-size: 18px;
                top: 15px;
                left: 10px
            }

        .form-control {
            height: 50px;
            background-color: #1c1e21;
            text-indent: 24px;
            font-size: 15px
        }

            .form-control:focus {
                background-color: #25272a;
                box-shadow: none;
                color: #fff;
                border-color: #4f63e7
            }

        .form-check-label {
            margin-top: 2px;
            font-size: 14px
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Panel runat="server" ID="divRegistrazione">
                <asp:Panel runat="server" class="container mt-5 mb-5" ID="Panel2">
                    <asp:Panel runat="server" class="row d-flex align-items-center justify-content-center">
                        <asp:Panel runat="server" class="col-md-6">
                            <asp:Panel runat="server" class="card px-5 py-5">
                                <!--<span class="circle"><i class="fa fa-check"></i></span>-->
                                <asp:Label ID="lblTitolo" runat="server" CssClass="mt-3 titolo" Text="Registrazione"></asp:Label>
                                <br />
                                <asp:Label runat="server">Indirizzo Email:</asp:Label>
                                <asp:Panel runat="server" class="form-input">
                                    <i class="fa fa-envelope"></i>
                                    <asp:TextBox runat="server" type="email" ID="txtEmail" class="form-control" placeholder="Indirizzo Email"></asp:TextBox>
                                </asp:Panel>
                                <div class="row mb-4">
                                    <div class="col">
                                        <div class="form-outline">
                                            <asp:Label runat="server">Nome:</asp:Label>
                                            <asp:Panel runat="server" class="form-input">
                                                <i class="fa fa-user"></i>
                                                <asp:TextBox runat="server" type="text" ID="txtNome" CssClass="form-control" placeholder="Nome"></asp:TextBox>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="form-outline">
                                            <asp:Label runat="server">Cognome:</asp:Label>
                                            <asp:Panel runat="server" class="form-input">
                                                <i class="fa fa-address-card"></i>
                                                <asp:TextBox runat="server" type="text" ID="txtCognome" CssClass="form-control" placeholder="Cognome"></asp:TextBox>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mb-4">
                                    <div class="col">
                                        <div class="form-outline">
                                            <asp:Label runat="server">Indirizzo:</asp:Label>
                                            <asp:Panel runat="server" class="form-input">
                                                <i class="fa fa-map-marker-alt"></i>
                                                <asp:TextBox runat="server" type="text" ID="txtIndirizzo" CssClass="form-control" placeholder="Indirizzo"></asp:TextBox>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="form-outline">
                                            <asp:Label runat="server">Città:</asp:Label>
                                            <asp:Panel runat="server" class="form-input">
                                                <i class="fa fa-city"></i>
                                                <asp:TextBox runat="server" type="text" ID="txtCitta" CssClass="form-control" placeholder="Città"></asp:TextBox>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mb-4">
                                    <div class="col">
                                        <asp:Button Style="width: 100%;" ID="btnModifica" runat="server" Text="Modifica" OnClick="btnModifica_Click" CssClass="btn btn-primary mt-4 signup" />
                                    </div>
                                    <div class="col">
                                        <asp:Button Style="width: 100%;" ID="btnIndietro" runat="server" Text="Indietro" OnClick="btnIndietro_Click" CssClass="btn btn-danger mt-4 signup" />
                                    </div>
                                </div>
                                <asp:Panel runat="server" class="text-center mt-3">
                                    <asp:Label ID="lblErrore" runat="server"></asp:Label>
                                </asp:Panel>
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
