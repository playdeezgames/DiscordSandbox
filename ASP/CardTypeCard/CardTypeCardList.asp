<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/openconn.inc"-->
<html>
    <head>
        <title>SPLORR!!</title>
    </head>
    <body>
        <p><a href="/CardType/CardTypeList.asp">Back To Card Type List</a></p>
        <table border="border">
            <tr>
                <th>Card Id</th>
                <th>Card Type</th>
                <th>Character</th>
            </tr>
        <%
        Set cmd = Server.CreateObject("ADODB.command")
        Set cmd.activeconnection=conn
        cmd.CommandType=adCmdText
        cmd.CommandText="SELECT CardId, CardTypeId, CharacterId, InDiscardPile, InDrawPile, InHand, DrawOrder, CardTypeName, CharacterName FROM CardDetails WHERE CardTypeId=?;"
        cmd.Parameters.Refresh
        cmd.Parameters(0).Value=Request.QueryString("CardTypeId")
        Set rs = cmd.execute
        rs.movefirst
        do until rs.eof
        %>
            <tr>
                <td><%=rs("CardId")%></td>
                <td><%=rs("CardTypeName")%></td>
                <td><%=rs("CharacterName")%></td>
            </tr>
        <%
            rs.movenext
        loop
        rs.close
        set rs=nothing
        set cmd=nothing
        %>
        </table>
        <p><a href="/CardTypeCard/CardTypeCardAdd.asp">(new)</a></p>
    </body>
</html>
<!--#include virtual="inc/closeconn.inc"-->
