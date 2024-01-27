<!--#include virtual="inc/Grimoire.inc"-->
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
                <th>In Draw Pile</th>
                <th>Draw Order</th>
                <th>In Hand</th>
                <th>In Discard Pile</th>
            </tr>
        <%
        Set cmd = Server.CreateObject("ADODB.command")
        Set cmd.activeconnection=conn
        cmd.CommandType=adCmdText
        cmd.CommandText="SELECT " & COLUMN_CARD_ID & ", " & COLUMN_CARD_TYPE_ID & ", " & COLUMN_CHARACTER_ID & ", " & COLUMN_IN_DISCARD_PILE & ", " & COLUMN_IN_DRAW_PILE & ", " & COLUMN_IN_HAND & ", " & COLUMN_DRAW_ORDER & ", " & COLUMN_CARD_TYPE_NAME & ", " & COLUMN_CHARACTER_NAME & " FROM " & VIEW_CARD_DETAILS & " WHERE " & COLUMN_CARD_TYPE_ID & "=?;"
        cmd.Parameters.Refresh
        cmd.Parameters(0).Value=Request.QueryString(COLUMN_CARD_TYPE_ID)
        Set rs = cmd.execute
        rs.movefirst
        do until rs.eof
        %>
            <tr>
                <td><a href="/Card/CardEdit.asp?<%=COLUMN_CARD_ID%>=<%=rs(COLUMN_CARD_ID)%>"><%=rs(COLUMN_CARD_ID)%></a></td>
                <td><a href="/CardType/CardTypeEdit.asp?<%=COLUMN_CARD_TYPE_ID%>=<%=rs(COLUMN_CARD_TYPE_ID)%>"><%=rs(COLUMN_CARD_TYPE_NAME)%></a></td>
                <td><a href="/Character/CharacterEdit.asp?<%=COLUMN_CHARACTER_ID%>=<%=rs(COLUMN_CHARACTER_ID)%>"><%=rs(COLUMN_CHARACTER_NAME)%></a></td>
                <td><%=rs(COLUMN_IN_DRAW_PILE)%></td>
                <td><%=rs(COLUMN_DRAW_ORDER)%></td>
                <td><%=rs(COLUMN_IN_HAND)%></td>
                <td><%=rs(COLUMN_IN_DISCARD_PILE)%></td>
            </tr>
        <%
            rs.movenext
        loop
        rs.close
        set rs=nothing
        set cmd=nothing
        %>
        </table>
        <p><a href="/CardTypeCard/CardTypeCardAdd.asp?<%=COLUMN_CARD_TYPE_ID%>=<%=Request.QueryString(COLUMN_CARD_TYPE_ID)%>">(new)</a></p>
    </body>
</html>
<!--#include virtual="inc/closeconn.inc"-->
