<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="tpc_webform_grupo_R.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .error-box {
            background-color: #141417;
            border: 1px solid #b91c1c;
            border-radius: 12px;
            padding: 32px;
            max-width: 540px;
            width: 100%;
            margin: 40px auto;
            box-shadow: 0 12px 32px rgba(0, 0, 0, 0.75);
        }
        .error-titulo {
            color: #ef4444;
            font-weight: 700;
            margin-bottom: 14px;
        }
        .error-detalle {
            color: #f5f5f5;
            margin-bottom: 24px;
            word-break: break-word;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="error-box text-center">
        <h2 class="error-titulo">¡Ups! Ocurrió un error</h2>
        <p class="error-detalle">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </p>
        <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-danger fw-semibold px-4" OnClick="btnVolver_Click" />
    </div>


</asp:Content>
