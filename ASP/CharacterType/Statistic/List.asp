<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Dim cmd
Set cmd = MakeSelectCommand(conn, _
    VIEW_CHARACTER_TYPE_STATISTIC_DETAILS,_
    Array(COLUMN_CHARACTER_TYPE_STATISTIC_ID,_
        COLUMN_STATISTIC_TYPE_NAME,_
        COLUMN_STATISTIC_VALUE,_
        COLUMN_MAXIMUM_VALUE,_
        COLUMN_MINIMUM_VALUE),_
    Array(COLUMN_CHARACTER_TYPE_ID),_
    Array(Request.QueryString(COLUMN_CHARACTER_TYPE_ID)))
Dim rs
Set rs = cmd.Execute()
%>
<table border="1">
    <tr>
        <th>Character Type Statistic Id</th>
        <th>Statistic Type Name</th>
        <th>Statistic Value</th>
        <th>Minimum Value</th>
        <th>Maximum Value</th>
    </tr>
<%
do until rs.eof
%>
    <tr>
        <td>
            <a href="/CharacterType/Statistic/Edit.asp?<%=COLUMN_CHARACTER_TYPE_STATISTIC_ID%>=<%=rs(COLUMN_CHARACTER_TYPE_STATISTIC_ID)%>"><%=rs(COLUMN_CHARACTER_TYPE_STATISTIC_ID)%></a>
        </td>
        <td>
            <%=rs(COLUMN_STATISTIC_TYPE_NAME)%>
        </td>
        <td>
            <%=rs(COLUMN_STATISTIC_VALUE)%>
        </td>
        <td>
            <%=rs(COLUMN_MINIMUM_VALUE)%>
        </td>
        <td>
            <%=rs(COLUMN_MAXIMUM_VALUE)%>
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
<p><a href="/CharacterType/Statistic/Add.asp?<%=COLUMN_CHARACTER_TYPE_ID%>=<%=Request.QueryString(COLUMN_CHARACTER_TYPE_ID)%>">(new statistic)</a></p>
<!--#include virtual="inc/closeconn.inc"-->
