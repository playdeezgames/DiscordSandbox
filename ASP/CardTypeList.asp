<!--#include file="inc/openconn.inc"-->
<html>
    <head>
        <title>SPLORR!!</title>
    </head>
    <body>
        <p><a href="default.asp">Main Menu</a></p>
        <table>
            <tr>
                <th>Card Type Id</th>
                <th>Card Type Name</th>
                <th>Edit</th>
            </tr>
        <%
        Set rs = Server.CreateObject("ADODB.RecordSet")
        rs.Open "SELECT CardTypeId, CardTypeName FROM CardTypes ORDER BY CardTypeName;", conn
        rs.movefirst
        do until rs.eof
        %>
            <tr>
                <td><%=rs("CardTypeId")%></td>
                <td><%=rs("CardTypeName")%></td>
                <td><a href="CardTypeEdit.asp?CardTypeId=<%=rs("CardTypeId")%>">(edit)</a></td>
            </tr>
        <%
            rs.movenext
        loop
        %>
        </table>
    </body>
</html>
<!--#include file="inc/closeconn.inc"-->
