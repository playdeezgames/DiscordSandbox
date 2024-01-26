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
                <th>Card Count</th>
                <th>Edit?</th>
                <th>Delete?</th>
            </tr>
        <%
        Set rs = Server.CreateObject("ADODB.RecordSet")
        rs.Open "SELECT CardTypeId, CardTypeName, CardCount FROM CardTypeDetails ORDER BY CardTypeName;", conn
        rs.movefirst
        do until rs.eof
        %>
            <tr>
                <td><%=rs("CardTypeId")%></td>
                <td><%=rs("CardTypeName")%></td>
                <td><%=rs("CardCount")%></td>
                <td><a href="CardTypeEdit.asp?CardTypeId=<%=rs("CardTypeId")%>">(edit)</a></td>
                <td><%
                    if rs("CardCount")=0 then
                    %>
                        <a href="CardTypeDelete.asp?CardTypeId=<%=rs("CardTypeId")%>">(delete)</a>
                    <%
                    end if
                    %></td>
            </tr>
        <%
            rs.movenext
        loop
        rs.close
        set rs=nothing
        %>
        </table>
        <p><a href="CardTypeAdd.asp">(new)</a></p>
    </body>
</html>
<!--#include file="inc/closeconn.inc"-->
