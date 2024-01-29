<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
Dim cmd
Set cmd = MakeSelectCommand(conn,VIEW_CHARACTER_DETAILS,Array(COLUMN_CHARACTER_ID,COLUMN_CHARACTER_NAME,COLUMN_CHARACTER_TYPE_NAME,COLUMN_LOCATION_NAME),Null,Null)
Dim rs
Set rs = cmd.Execute()
%>
<p><a href="/default.asp">Back to Main Menu</a></p>
<table border="1">
    <tr>
        <th>Character Id</th>
        <th>Character Name</th>
        <th>Character Type</th>
        <th>Location</th>
    </tr>
<%
do until rs.eof
%>
    <tr>
        <td>
            <a href="/Character/CharacterEdit.asp?<%=COLUMN_CHARACTER_ID%>=<%=rs(COLUMN_CHARACTER_ID)%>"><%=rs(COLUMN_CHARACTER_ID)%></a>
        </td>
        <td>
            <%=rs(COLUMN_CHARACTER_NAME)%><br/>
        </td>
        <td>
            <%=rs(COLUMN_CHARACTER_TYPE_NAME)%>
        </td>
        <td>
            <%=rs(COLUMN_LOCATION_NAME)%>
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
<p><a href="/Character/CharacterAdd.asp">(new)</a></p>
<%
Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
