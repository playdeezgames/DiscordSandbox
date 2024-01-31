<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
Dim cmd
Set cmd = MakeSelectCommand(conn, _
    VIEW_EFFECT_TYPE_DETAILS,_
    Array(COLUMN_EFFECT_TYPE_ID,COLUMN_EFFECT_TYPE_NAME),_
    Null,_
    Null)
Dim rs
Set rs = cmd.Execute()
%>
<p><a href="/default.asp">Back to Main Menu</a></p>
<%StartTable %>
    <tr>
        <th>Effect Type Id</th>
        <th>Effect Type Name</th>
    </tr>
<%
do until rs.eof
%>
    <tr>
        <td>
            <a href="/EffectType/Edit.asp?<%=COLUMN_EFFECT_TYPE_ID%>=<%=rs(COLUMN_EFFECT_TYPE_ID)%>"><%=rs(COLUMN_EFFECT_TYPE_ID)%></a>
        </td>
        <td>
            <%=rs(COLUMN_EFFECT_TYPE_NAME)%>
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
<p><a href="/EffectType/Add.asp">(new)</a></p>
<%
Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
