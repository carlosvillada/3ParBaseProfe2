<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="_3ParBaseProfe.Views.AgregarProducto" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agregar Producto</title>
    <style>
        /* General */
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
            margin: 0;
            padding: 0;
        }

        h1 {
            color: #333;
            text-align: center;
            margin-top: 20px;
        }

        h3 {
            color: #555;
            margin: 10px 0;
            text-align: center;
        }

        /* Formulario */
        form {
            width: 100%;
            max-width: 500px;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        form div {
            margin: 10px 0;
        }

        label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
            color: #333;
        }

        input[type="text"], input[type="number"] {
            width: 100%;
            padding: 8px;
            margin: 5px 0 15px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        input[type="submit"], button, .aspNetButton {
            width: 100%;
            padding: 10px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        input[type="submit"]:hover, button:hover, .aspNetButton:hover {
            background-color: #45a049;
        }

        /* GridView */
        #GridDatos {
            width: 100%;
            margin-top: 20px;
            border-collapse: collapse;
        }

        #GridDatos th, #GridDatos td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: center;
        }

        #GridDatos th {
            background-color: #f2f2f2;
            color: #333;
        }

        #GridDatos img {
            max-width: 50px;
            height: auto;
            border-radius: 4px;
        }

        /* Botón Mostrar Productos */
        #BtnMostrar {
            margin-top: 15px;
            background-color: #007BFF;
        }

        #BtnMostrar:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Carrito de Compras</h1>
        <h3>Agregar Producto</h3>

        <asp:Label runat="server" for="txtNombre">Nombre:</asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />

        <asp:Label runat="server" for="txtCantidad">Cantidad:</asp:Label>
        <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" ></asp:TextBox>
        <br />

        <asp:Label runat="server" for="txtCosto">Costo:</asp:Label>
        <asp:TextBox ID="txtCosto" runat="server" TextMode="Number" ></asp:TextBox>
        <br />
               
        <asp:Label runat="server" for="txtUrlImagen">Imagen:</asp:Label>
        <asp:FileUpload ID="fileUploadImagen" runat="server" />
        <br />

        <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar Producto" OnClick="btnAgregarProducto_Click" />
        
        <!-- Label para mostrar mensajes -->
        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>

        <h3>Mostrar Productos</h3>
        <asp:GridView runat="server" ID="GridDatos" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:TemplateField HeaderText="Imagen">
                    <ItemTemplate>
                        <img src='<%# ResolveUrl(Eval("UrlImagen").ToString()) %>' alt="Imagen del producto" style="width:50px; height:50px;" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>



        <asp:Button runat="server" ID="BtnMostrar" OnClick="BtnMostrar_Click" Text="Mostrar Productos" />
    </div>
</form>

</body>
</html>

