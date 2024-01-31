<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
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
<%StartTable %>
    <tr>
        <td>
            <label for="<%=COLUMN_CARD_TYPE_GENERATOR_ID%>">Id:</label>
        </td>
        <td>
            <input name="<%=COLUMN_CARD_TYPE_GENERATOR_ID%>" value="<%=rs(COLUMN_CARD_TYPE_GENERATOR_ID)%>" type="text" readonly="readonly"/>
        </td>
    </tr>
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
Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
