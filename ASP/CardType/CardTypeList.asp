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
        rs.Open "SELECT CardTypeId, CardTypeName, CardCount, DeleteOnPlay FROM CardTypeDetails ORDER BY CardTypeName;", conn
        rs.movefirst
        do until rs.eof
        %>
            <tr>
                <td><a href="/CardType/CardTypeDelete.asp?CardTypeId=<%=rs("CardTypeId")%>"><%=rs("CardTypeId")%></a></td>
                <td><%=rs("CardTypeName")%></td>
                <td><%=rs("DeleteOnPlay")%></td>
                <td><a href="/CardTypeCard/CardTypeCardList.asp?CardTypeId=<%=rs("CardTypeId")%>"><%=rs("CardCount")%></a></td>
                <td>
                    <% if rs("CardCount")=0 then %>
                        <a href="/CardType/CardTypeDelete.asp?CardTypeId=<%=rs("CardTypeId")%>">(delete)</a>
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
