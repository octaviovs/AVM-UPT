﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AVM.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sesion</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <link href="/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/app.css" rel="stylesheet" />
    <link href="/Iconos/icon/font/css/open-iconic-bootstrap.css" rel="stylesheet" />


    <script src="/Scripts/jquery-3.3.1.min.js"></script>
    <script src="/Scripts/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
</head>
<body>
    <header id="header-container" class="fondoColor posicionFoter">
        <div class="container">
            <div class="row">

                <div class="col-1">
                    <asp:Image ID="ImagenLogo" runat="server" ImageUrl="~/Imagenes/Universidad/corazon.png" Height="65px" Width="76px" alt="Responsive image" />
                </div>
                <div class="col-10 text-center">
                    <h2>Universidad Politécnica de Tulancingo</h2>
                </div>
                <div class="col-1">
                </div>
            </div>
        </div>
    </header>
    <br />
    <br />
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-1 col-md-3 col-lg-3 col-xl-3 ">
                </div>
                <div class="col-sm10 col-md-6 col-lg-6 col-xl-6">
                    <div class="row justify-content-md-center ">
                        <div class="col align-content-center">
                            <div class="card bg-light ">
                                <div class="card-header fondoColor text-center">Sistema Médico UPT</div>
                                <div class="card-body">
                                    <div class="card-body">
                                        <h4 class="card-title">Inicio de Sesión</h4>
                                        <div class="form-group">
                                            <label for="TextBoxNumDeControl"><span class="oi oi-person"></span>   Matrícula:
                                            </label>
                                            <asp:TextBox PlaceHolder="Escriba su matrícula" ID="TextBoxNumeroDeControl" runat="server" required="Ingrese su matrícula" CssClass="form-control input-lg"   autofocus="" ></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="password"><span class="oi oi-key"></span>   Contraseña:</label>
                                            <asp:TextBox PlaceHolder="Escriba su contraseña" ID="TextBoxContrasena" runat="server" required="" CssClass="form-control input-lg " TextMode="Password"  ></asp:TextBox>

                                        </div>
                                        <div class="row center-align">

                                             
                                            <div class="col m10 s10">
                                           <label>        Usuario:</label>
                                                
                                                <asp:DropDownList ID="DropDownListRoles" runat="server" CssClass="form-control"></asp:DropDownList>
                                                <br />
                                            </div>

                                        </div>
                                        <div class="form-group my-2">
                                            <asp:Button ID="Button1" runat="server" Font-Size="Medium" Text="Entrar" class="btn  btn-block fondoColor" OnClick="Button1_Click" />
                                        </div>
                                        <div class="ocultar" id="PanelAviso">
                                            <div class="alert alert-danger" role="alert">
                                               Datos no correctos!
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="footer  text-center">
                                    Copyright &copy; Fábrica de Software <a href="#" class="alert-link"><%Response.Write(DateTime.Now.Year); %></a>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-sm-1 col-md-3 col-lg-3 col-xl-3">
                </div>
            </div>
        </div>
    </form>
    <script>
        z
    </script>
</body>
</html>
