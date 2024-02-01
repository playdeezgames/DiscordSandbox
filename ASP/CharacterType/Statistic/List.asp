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
<%StartTable 
ShowTableHeaders(Array("Character Type Statistic Id","Statistic Type Name","Statistic Value","Minimum Value","Maximum Value"))
    %>
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
<%EndTable %>
<%
rs.close
set rs = nothing
Set cmd = nothing
%>
<p><a href="/CharacterType/Statistic/Add.asp?<%=COLUMN_CHARACTER_TYPE_ID%>=<%=Request.QueryString(COLUMN_CHARACTER_TYPE_ID)%>">(new statistic)</a></p>
<!--#include virtual="inc/closeconn.inc"-->
