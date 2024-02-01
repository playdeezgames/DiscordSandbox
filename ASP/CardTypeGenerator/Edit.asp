<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
StartPage
Dim cmd
Set cmd = MakeSelectCommand(conn, _
    TABLE_CARD_TYPE_GENERATORS, _
    Array(COLUMN_CARD_TYPE_GENERATOR_ID,COLUMN_CARD_TYPE_GENERATOR_NAME), _
    Array(COLUMN_CARD_TYPE_GENERATOR_ID), _
    Array(Request.QueryString(COLUMN_CARD_TYPE_GENERATOR_ID)))
Dim rs
Set rs = cmd.Execute()
rs.movefirst
%>
<%
    BackToListLink "CardTypeGenerataor", "Card Type Generator"
%>
<%
    StartUpdateForm "CardTypeGenerator"
%>
<%
    StartTable 
        ReadonlyInput COLUMN_CARD_TYPE_GENERATOR_ID, "Id", rs
    %>
    <tr>
        <td>
            <label for="<%=COLUMN_CARD_TYPE_GENERATOR_NAME%>">Name: </label>
        </td>
        <td>
            <input name="<%=COLUMN_CARD_TYPE_GENERATOR_NAME%>" type="text" maxlength="100" value="<%=rs(COLUMN_CARD_TYPE_GENERATOR_NAME)%>"/>
        </td>
    </tr>
<%EndTable %>
<%EndForm%>
<%
rs.close
set rs = nothing
Set cmd = nothing
%>
<form action="/CardTypeGenerator/Delete.asp" method="post">
    <input type="hidden" name="<%=COLUMN_CARD_TYPE_GENERATOR_ID%>" value="<%=request.querystring(COLUMN_CARD_TYPE_GENERATOR_ID) %>" />
    <%StartTable %>
        <tr><td>Delete Record</td><td><input type="checkbox" name="ConfirmDelete" value="1" /></td></tr>
<%SubmitButton %>
    <%EndTable %>
<%EndForm%>
<hr />
<%
    Server.Execute("/CardTypeGenerator/CardType/List.asp")
%>
<%
EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
