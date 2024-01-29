<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
Dim cmd
Set cmd = MakeSelectCommand(conn, _
    VIEW_CHARACTER_TYPE_DETAILS,_
    Array(COLUMN_CHARACTER_TYPE_ID,COLUMN_CHARACTER_TYPE_NAME),_
    Null,_
    Null)
Dim rs
Set rs = cmd.Execute()
%>
<p><a href="/default.asp">Back to Main Menu</a></p>
<table border="1">
    <tr>
        <th>Character Type Id</th>
        <th>Character Type Name</th>
    </tr>
<%
do until rs.eof
%>
    <tr>
        <td>
            <a href="/CharacterType/CharacterTypeEdit.asp?<%=COLUMN_CHARACTER_TYPE_ID%>=<%=rs(COLUMN_CHARACTER_TYPE_ID)%>"><%=rs(COLUMN_CHARACTER_TYPE_ID)%></a>
        </td>
        <td>
            <%=rs(COLUMN_CHARACTER_TYPE_NAME)%>
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
<p><a href="/CharacterType/CharacterTypeAdd.asp">(new)</a></p>
<%
Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
