<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Dim cmd
Set cmd = MakeSelectCommand(conn, _
    VIEW_CARD_TYPE_GENERATOR_CARD_TYPE_DETAILS,_
    Array(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID,_
        COLUMN_CARD_TYPE_GENERATOR_ID,_
        COLUMN_CARD_TYPE_ID,_
        COLUMN_GENERATOR_WEIGHT,_
        COLUMN_CARD_TYPE_GENERATOR_NAME,_
        COLUMN_CARD_TYPE_NAME),_
    Array(COLUMN_CARD_TYPE_GENERATOR_ID),_
    Array(Request.QueryString(COLUMN_CARD_TYPE_GENERATOR_ID)))
Dim rs
Set rs = cmd.Execute()
%>
<table border="1">
    <tr>
        <th>Card Type Generator Card Type Id</th>
        <th>Card Type</th>
        <th>Generator Weight</th>
    </tr>
<%
do until rs.eof
%>
    <tr>
        <td>
            <a href="/CardTypeGenerator/CardType/Edit.asp?<%=COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID%>=<%=rs(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID)%>"><%=rs(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID)%></a>
        </td>
        <td>
            <%=rs(COLUMN_CARD_TYPE_NAME)%>
        </td>
        <td>
            <%=rs(COLUMN_GENERATOR_WEIGHT)%>
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
<p><a href="/CardTypeGenerator/CardType/Add.asp?<%=COLUMN_CARD_TYPE_GENERATOR_ID%>=<%=Request.QueryString(COLUMN_CARD_TYPE_GENERATOR_ID)%>">(new card type)</a></p>
<!--#include virtual="inc/closeconn.inc"-->
