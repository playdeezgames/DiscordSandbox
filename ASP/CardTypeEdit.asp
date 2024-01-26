<!--#include file="inc/AdoVbs.inc"-->
<!--#include file="inc/openconn.inc"-->
<html>
    <head>
        <title>SPLORR!!</title>
    </head>
    <body>
        <p><a href="CardTypeList.asp">Back to Card Type List</a></p>
        <%
        Set cmd=server.CreateObject("adodb.command")
        Set cmd.activeconnection=conn
        cmd.CommandType=adCmdText
        cmd.CommandText="SELECT CardTypeId, CardTypeName FROM CardTypes WHERE CardTypeId=?;"
        cmd.Parameters.Refresh
        cmd.Parameters(0).Value=Request.QueryString("CardTypeId")
        set rs = cmd.Execute()
        rs.movefirst
        %>
        <form action="UpdateCardType.asp" method="POST">
            <p>Card Type Id: <%=rs("CardTypeId")%><input name="CardTypeId" type="hidden" value="<%=rs("CardTypeId")%>"/></p>
            <p>Card Type Name: <input name="CardTypeName" type="text" size="100" maxlength="100" value="<%=rs("CardTypeName")%>"/></p>
            <input type="submit"/>
        </form>
        <%
        set rs=nothing  
        %>
    </body>
</html>
<!--#include file="inc/closeconn.inc"-->