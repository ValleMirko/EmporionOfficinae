<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="EmporiumOfficine.login" EnableEventValidation="false" EnableViewState="true" %>

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
    <title>Accesso</title>
    <style>
        @import url("https://fonts.googleapis.com/css2?family=Poppins:wght@100;200;300;400;500;600;700;800&display=swap");

        * {
            margin: 0;
            padding: 0;
        }

        body {
            font-family: "Poppins", sans-serif;
            font-weight: 300;
            background: url(./IMG/gradientLog.png) no-repeat center fixed;
            background-size: cover;
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

        .signup {
            height: 50px;
            font-size: 14px
        }

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
    </style>
</head>
<body>
    <asp:Panel runat="server" class="container" ID="divContainer">
        <form id="form1" runat="server">
            <asp:Panel runat="server" ID="divLog">
                <asp:Panel runat="server" class="container mt-5 mb-5" ID="divUser">
                    <asp:Panel runat="server" class="row d-flex align-items-center justify-content-center">
                        <asp:Panel runat="server" class="col-md-6">
                            <asp:Panel runat="server" class="card px-5 py-5">
                                <!--<span class="circle"><i class="fa fa-check"></i></span>-->
                                <asp:Label ID="lblTipo" runat="server" CssClass="mt-3 titolo" Text="Login"></asp:Label>
                                <br />
                                <asp:Label runat="server">Indirizzo Email:</asp:Label>
                                <asp:Panel runat="server" class="form-input">
                                    <i class="fa fa-envelope"></i>
                                    <asp:TextBox runat="server" type="email" ID="txtEmailLog" class="form-control" placeholder="Indirizzo Email"></asp:TextBox>
                                </asp:Panel>
                                <asp:Label runat="server">Password:</asp:Label>
                                <asp:Panel runat="server" class="form-input">
                                    <i class="fa fa-key"></i>
                                    <asp:TextBox runat="server" type="password" CssClass="form-control" ID="txtPasswordLog" placeholder="Password"></asp:TextBox>
                                </asp:Panel>
                                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary mt-4 signup" />
                                
                                <asp:Panel runat="server" class="text-center mt-4" ID="divReg">
                                    <asp:Label ID="lblAcc" runat="server" Text="Non hai un account?"></asp:Label>
                                    <asp:LinkButton ID="btnReg" runat="server" OnClick="btnReg_Click">Registrati</asp:LinkButton>
                                </asp:Panel>
                                <asp:Panel runat="server" class="text-center mt-3" Style="color: red;">
                                    <asp:Label ID="lblErroreLog" runat="server"></asp:Label>
                                </asp:Panel>
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>



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
                                    <asp:TextBox runat="server" type="email" ID="txtEmailReg" class="form-control" placeholder="Indirizzo Email"></asp:TextBox>
                                </asp:Panel>
                                <asp:Label runat="server">Password:</asp:Label>
                                <asp:Panel runat="server" class="form-input">
                                    <i class="fa fa-key"></i>
                                    <asp:TextBox runat="server" type="password" ID="txtPasswordReg" CssClass="form-control" placeholder="Password"></asp:TextBox>
                                </asp:Panel>
                                <div class="row mb-4">
                                    <div class="col">
                                        <div class="form-outline">
                                            <asp:Label runat="server">Nome:</asp:Label>
                                            <asp:Panel runat="server" class="form-input">
                                                <i class="fa fa-user"></i>
                                                <asp:TextBox runat="server" type="text" ID="txtNomeReg" CssClass="form-control" placeholder="Nome"></asp:TextBox>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="form-outline">
                                            <asp:Label runat="server">Cognome:</asp:Label>
                                            <asp:Panel runat="server" class="form-input">
                                                <i class="fa fa-address-card"></i>
                                                <asp:TextBox runat="server" type="text" ID="txtCognomeReg" CssClass="form-control" placeholder="Cognome"></asp:TextBox>
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
                                                <asp:TextBox runat="server" type="text" ID="txtIndirizzoReg" CssClass="form-control" placeholder="Indirizzo"></asp:TextBox>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="form-outline">
                                            <asp:Label runat="server">Città:</asp:Label>
                                            <asp:Panel runat="server" class="form-input">
                                                <i class="fa fa-city"></i>
                                                <asp:TextBox runat="server" type="text" ID="txtCittaReg" CssClass="form-control" placeholder="Città"></asp:TextBox>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mb-4">
                                    <div class="col">
                                        <div class="form-outline">
                                            <asp:Label runat="server">Sei un fornitore?</asp:Label>
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="form-outline">
                                            <asp:CheckBox runat="server" ID="chkTipoReg"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mb-4">
                                    <div class="col">
                                        <asp:Button style="width:100%;" ID="btnRegistrati" runat="server" Text="Registrati" OnClick="btnRegistrati_Click" CssClass="btn btn-primary mt-4 signup" />
                                    </div>
                                    <div class="col">
                                        <asp:Button style="width:100%;" ID="btnIndietro" runat="server" Text="Indietro" OnClick="btnIndietro_Click" CssClass="btn btn-danger mt-4 signup" />
                                    </div>
                                </div>
                                <asp:Panel runat="server" class="text-center mt-3">
                                    <asp:Label ID="lblErroreReg" runat="server"></asp:Label>
                                </asp:Panel>
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
        </form>
    </asp:Panel>
</body>
</html>
