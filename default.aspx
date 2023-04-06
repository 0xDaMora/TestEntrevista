<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TestTrabajo.Addtosql"  %>

<%@ Import Namespace="TestTrabajo.Controllers" %>




<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADD DATA</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@3.4.1/dist/css/bootstrap.min.css" >
    <link href="Recursos/CSS/StyleTest.css" rel="stylesheet" />
</head>

<body class="bg-light">
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="panel panel-primary">
                    <div class="panel-heading text-center">
                        <h3><asp:Label ID="bienvenida" runat="server" Text="Bienvenido al Test"></asp:Label></h3>
                    </div>

                    <div class="panel-body">
                        
                        <form id="form1" runat="server">

                            <div class="form-group">


                                <asp:Label ID="lbNombre" runat="server" Text="Nombre:"></asp:Label>
                                <asp:TextBox ID="TxNombre" runat="server" placeholder="Nombre" CssClass="form-control" required></asp:TextBox>
                                
                            </div>
                            <div class="form-group">

                                <asp:Label ID="lbIdioma" runat="server" Text="Idioma:"></asp:Label>
                        <asp:DropDownList ID="DdlIdioma" runat="server" CssClass="form-control" required>
                                    <asp:ListItem Value="Español">Español</asp:ListItem>
                                    <asp:ListItem Value="Inglés">Inglés</asp:ListItem>
                                    <asp:ListItem Value="Francés">Francés</asp:ListItem>
                                    <asp:ListItem Value="Alemán">Alemán</asp:ListItem>
                                    <asp:ListItem Value="Italiano">Italiano</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                            <div class="form-group">

                                <asp:Label ID="lbDescripcion" runat="server" Text="Descripción:"></asp:Label>
                                <asp:TextBox ID="TxDescripcion" runat="server" placeholder="Descripción" CssClass="form-control" TextMode="MultiLine" Rows="3" required></asp:TextBox>

                            </div>

                            <asp:Button ID="BtnGuardar" runat="server" Text="Enviar" CssClass="btn btn-primary btn-block" OnClick="BtnGuardar_Click" />

                           
                            <div class="row">



                <div class="col-md-8 col-md-offset-2">
                    <asp:GridView ID="GridRegistros" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="ID" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Idioma" HeaderText="Idioma" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        </Columns>
                    </asp:GridView>
                </div>


            </div>
        

                        </form>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@3.4.1/dist/js/bootstrap.min.js"></script>
</body>
</html>

