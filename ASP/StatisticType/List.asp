<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
Dim cmd
Set cmd = MakeSelectCommand(conn, _
    VIEW_STATISTIC_TYPE_DETAILS,_
    Array(COLUMN_STATISTIC_TYPE_ID,COLUMN_STATISTIC_TYPE_NAME),_
    Null,_
    Null)
Dim rs
Set rs = cmd.Execute()
%>
<p><a href="/default.asp">Back to Main Menu</a></p>
<table border="1">
    <tr>
        <th>Statistic Type Id</th>
        <th>Statistic Type Name</th>
    </tr>
<%
do until rs.eof
%>
    <tr>
        <td>
            <a href="/StatisticType/Edit.asp?<%=COLUMN_STATISTIC_TYPE_ID%>=<%=rs(COLUMN_STATISTIC_TYPE_ID)%>"><%=rs(COLUMN_STATISTIC_TYPE_ID)%></a>
        </td>
        <td>
            <%=rs(COLUMN_STATISTIC_TYPE_NAME)%>
        </td>
    </tr>
<%
    rs.movenext
loop
%>
</table>
<%
rs.close
set rs = nothing
Set cmd = nothing
%>
<p><a href="/StatisticType/Add.asp">(new)</a></p>
<%
Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
