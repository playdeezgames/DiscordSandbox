<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
StartPage
Dim cmd
Set cmd = MakeSelectCommand(conn, _
    VIEW_STATISTIC_TYPE_DETAILS,_
    Array(COLUMN_STATISTIC_TYPE_ID,COLUMN_STATISTIC_TYPE_NAME),_
    Null,_
    Null)
Dim rs
Set rs = cmd.Execute()
            BackToMainMenuLink

%>
<%StartTable 
    ShowTableHeaders(Array("Statistic Type Id","Statistic Type Name"))
    %>
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
<%EndTable %>
<%
rs.close
set rs = nothing
Set cmd = nothing
%>
<p><a href="/StatisticType/Add.asp">(new)</a></p>
<%
EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
