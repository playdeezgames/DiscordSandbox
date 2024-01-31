<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
StartPage
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
<%StartTable %>
    <tr>
        <th>Character Type Id</th>
        <th>Character Type Name</th>
    </tr>
<%
do until rs.eof
%>
    <tr>
        <td>
            <a href="/CharacterType/Edit.asp?<%=COLUMN_CHARACTER_TYPE_ID%>=<%=rs(COLUMN_CHARACTER_TYPE_ID)%>"><%=rs(COLUMN_CHARACTER_TYPE_ID)%></a>
        </td>
        <td>
            <%=rs(COLUMN_CHARACTER_TYPE_NAME)%>
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
<p><a href="/CharacterType/Add.asp">(new)</a></p>
<%
EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
