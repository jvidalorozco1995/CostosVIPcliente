<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebLineasAgregadas.aspx.cs" Inherits="ArchivoCostosWeb.WebLineasAgregadas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
 <asp:LinkButton id="btnBack" runat="server" text="Atras"  ForeColor="#B700000" Font-Names="Calibri"
OnClientClick="JavaScript: window.history.back(1); return false;"></asp:LinkButton>
        &nbsp;<asp:LinkButton  ID="BtnExportar"  ForeColor="#B700000" Font-Names="Calibri" runat="server" OnClick="BtnExportar_Click" Text="Exportar a Excel" Width="116px" />
        <br />    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Font-Names="Calibri" Font-Size="12pt" EmptyDataText="No hay Lineas Agregadas de estas fechas">
            <Columns>
                <asp:BoundField DataField="referencia1" HeaderText="referencia1" SortExpression="referencia1" />
                <asp:BoundField DataField="referencia2" HeaderText="referencia2" SortExpression="referencia2" />
                <asp:BoundField DataField="referencia3" HeaderText="referencia3" SortExpression="referencia3" />
                <asp:BoundField DataField="presupuesto" HeaderText="presupuesto" SortExpression="presupuesto" />
                <asp:BoundField DataField="codcapi" HeaderText="codcapi" SortExpression="codcapi" />
                <asp:BoundField DataField="capitulo" HeaderText="capitulo" SortExpression="capitulo" />
                <asp:BoundField DataField="codunit" HeaderText="codunit" SortExpression="codunit" />
                <asp:BoundField DataField="unitario" HeaderText="unitario" SortExpression="unitario" />
                <asp:BoundField DataField="undunita" HeaderText="undunita" SortExpression="undunita" />
                <asp:BoundField DataField="cantxppto" HeaderText="cantxppto" SortExpression="cantxppto" />
                <asp:BoundField DataField="codinsu" HeaderText="codinsu" SortExpression="codinsu" />
                <asp:BoundField DataField="insutipo" HeaderText="insutipo" SortExpression="insutipo" />
                <asp:BoundField DataField="insumo" HeaderText="insumo" SortExpression="insumo" />
                <asp:BoundField DataField="unidinsu" HeaderText="unidinsu" SortExpression="unidinsu" />
                <asp:BoundField DataField="ctrlinven" HeaderText="ctrlinven" SortExpression="ctrlinven" />
                <asp:BoundField DataField="validación" HeaderText="validación" SortExpression="validación" />
                <asp:BoundField DataField="precioppto" HeaderText="precioppto" SortExpression="precioppto" />
                <asp:BoundField DataField="consumounitario" HeaderText="consumounitario" SortExpression="consumounitario" />
                <asp:BoundField DataField="consumototal" HeaderText="consumototal" SortExpression="consumototal" />
                <asp:BoundField DataField="adic" HeaderText="adic" SortExpression="adic" />
                <asp:BoundField DataField="precioaut" HeaderText="precioaut" SortExpression="precioaut" />
                <asp:BoundField DataField="PrecioCompra" HeaderText="PrecioCompra" SortExpression="PrecioCompra" />
                <asp:BoundField DataField="PrecioEntrado" HeaderText="PrecioEntrado" SortExpression="PrecioEntrado" />
                <asp:BoundField DataField="Ped" HeaderText="Ped" SortExpression="Ped" />
                <asp:BoundField DataField="aprob" HeaderText="aprob" SortExpression="aprob" />
                <asp:BoundField DataField="comp" HeaderText="comp" SortExpression="comp" />
                <asp:BoundField DataField="ent" HeaderText="ent" SortExpression="ent" />
                <asp:BoundField DataField="sali" HeaderText="sali" SortExpression="sali" />
                <asp:BoundField DataField="traslado" HeaderText="traslado" SortExpression="traslado" />
                <asp:BoundField DataField="xcomp" HeaderText="xcomp" SortExpression="xcomp" />
                <asp:BoundField DataField="xent" HeaderText="xent" SortExpression="xent" />
                <asp:BoundField DataField="saldoxunit" HeaderText="saldoxunit" SortExpression="saldoxunit" />
                <asp:BoundField DataField="SaldoXppto" HeaderText="SaldoXppto" SortExpression="SaldoXppto" />
                <asp:BoundField DataField="vlrEnt" HeaderText="vlrEnt" SortExpression="vlrEnt" />
                <asp:BoundField DataField="vlrEnttraslado" HeaderText="vlrEnttraslado" SortExpression="vlrEnttraslado" />
                <asp:BoundField DataField="VlrCompradoxent" HeaderText="VlrCompradoxent" SortExpression="VlrCompradoxent" />
                <asp:BoundField DataField="vlrxcomp" HeaderText="vlrxcomp" SortExpression="vlrxcomp" />
                <asp:BoundField DataField="VlrTraslado" HeaderText="VlrTraslado" SortExpression="VlrTraslado" />
                <asp:BoundField DataField="vlrproy" HeaderText="vlrproy" SortExpression="vlrproy" />
                <asp:BoundField DataField="Vlrini" HeaderText="Vlrini" SortExpression="Vlrini" />
                <asp:BoundField DataField="vlrejec" HeaderText="vlrejec" SortExpression="vlrejec" />
            </Columns>
            <HeaderStyle Font-Names="Calibri" Font-Size="12pt" ForeColor="#B70000" />
        </asp:GridView>
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:COSTOSVIPConnectionString %>" OnSelecting="SqlDataSource1_Selecting" SelectCommand="  SELECT        referencia1, referencia2, referencia3, presupuesto, codcapi, capitulo, codunit, unitario, undunita, cantxppto, codinsu, insutipo, insumo, unidinsu, ctrlinven, 
                         validación, precioppto, consumounitario, consumototal, adic, precioaut, PrecioCompra, PrecioEntrado, Ped, aprob, comp, ent, sali, traslado, xcomp, xent, 
                         saldoxunit, SaldoXppto, vlrEnt, vlrEnttraslado, VlrCompradoxent, vlrxcomp, VlrTraslado, vlrproy, Vlrini, vlrejec
FROM            dbo.CostosPptoProg as t1
where   IdFecha=@IdFecha1  and not exists

(
SELECT        1
FROM            dbo.CostosPptoProg  as t2
WHERE        (t2.referencia1 = t1.referencia1) and IdFecha=@IdFecha2)">
            <SelectParameters>
                 <asp:SessionParameter Name="IdFecha1" SessionField="FechaActual" Type="String"  />
                <asp:SessionParameter Name="IdFecha2" SessionField="FechaPasada" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
