<!--#include virtual="inc/Grimoire.asp"-->
<!--#include virtual="inc/openconn.inc"-->
<html>
    <head>
        <title>SPLORR!!</title>
    </head>
    <body>
        <p><a href="/default.asp">Main Menu</a></p>
        <table border="border">
            <tr>
                <th>Card Type Id</th>
                <th>Card Type Name</th>
                <th>Delete On Play?</th>
                <th>Card Count</th>
                <th>Delete?</th>
            </tr>
        <%
        Set rs = Server.CreateObject("ADODB.RecordSet")
        rs.Open "SELECT " & COLUMN_CARD_TYPE_ID & ", " & COLUMN_CARD_TYPE_NAME & ", " & COLUMN_CARD_COUNT & ", " & COLUMN_DELETE_ON_PLAY & " FROM " & VIEW_CARD_TYPE_DETAILS & " ORDER BY " & COLUMN_CARD_TYPE_NAME & ";", conn
        rs.movefirst
        do until rs.eof
        %>
            <tr>
                <td><a href="/CardType/CardTypeEdit.asp?<%=COLUMN_CARD_TYPE_ID%>=<%=rs(COLUMN_CARD_TYPE_ID)%>"><%=rs(COLUMN_CARD_TYPE_ID)%></a></td>
                <td><%=rs(COLUMN_CARD_TYPE_NAME)%></td>
                <td><%=rs(COLUMN_DELETE_ON_PLAY)%></td>
                <td><a href="/CardTypeCard/CardTypeCardList.asp?<%=COLUMN_CARD_TYPE_ID%>=<%=rs(COLUMN_CARD_TYPE_ID)%>"><%=rs(COLUMN_CARD_COUNT)%></a></td>
                <td>
                    <% if rs(COLUMN_CARD_COUNT)=0 then %>
                        <a href="/CardType/CardTypeDelete.asp?<%=COLUMN_CARD_TYPE_ID%>=<%=rs(COLUMN_CARD_TYPE_ID)%>">(delete)</a>
                    <% end if %>
                </td>
            </tr>
        <%
            rs.movenext
        loop
        rs.close
        set rs=nothing
        %>
        </table>
        <p><a href="/CardType/CardTypeAdd.asp">(new)</a></p>
    </body>
</html>
<!--#include virtual="inc/closeconn.inc"-->
