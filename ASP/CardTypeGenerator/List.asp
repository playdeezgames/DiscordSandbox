<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
StartPage
Dim cmd
Set cmd = MakeSelectCommand(conn, _
    VIEW_CARD_TYPE_GENERATOR_DETAILS,_
    Array(COLUMN_CARD_TYPE_GENERATOR_ID,COLUMN_CARD_TYPE_GENERATOR_NAME),_
    Null,_
    Null)
Dim rs
Set rs = cmd.Execute()
%>
<p><a href="/default.asp">Back to Main Menu</a></p>
<%StartTable %>
    <tr>
        <th>Card Type Generator Id</th>
        <th>Card Type Generator Name</th>
    </tr>
<%
do until rs.eof
%>
    <tr>
        <td>
            <a href="/CardTypeGenerator/Edit.asp?<%=COLUMN_CARD_TYPE_GENERATOR_ID%>=<%=rs(COLUMN_CARD_TYPE_GENERATOR_ID)%>"><%=rs(COLUMN_CARD_TYPE_GENERATOR_ID)%></a>
        </td>
        <td>
            <%=rs(COLUMN_CARD_TYPE_GENERATOR_NAME)%>
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
<p><a href="/CardTypeGenerator/Add.asp">(new)</a></p>
<%
EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
