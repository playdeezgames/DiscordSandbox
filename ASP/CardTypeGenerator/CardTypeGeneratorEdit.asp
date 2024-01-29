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
<p><a href="/CardTypeGenerator/CardTypeGeneratorList.asp">Back To Card Type Generator List</a></p>
<form action="/CardTypeGenerator/UpdateCardTypeGenerator.asp" method="POST">
<table border="1">
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
    <tr>
        <td colspan="2">
            <input type="submit"/>
        </td>
    </tr>
</table>
</form>
<%
rs.close
set rs = nothing
Set cmd = nothing
%>
<form action="/CardTypeGenerator/DeleteCardTypeGenerator.asp" method="post">
    <input type="hidden" name="<%=COLUMN_CARD_TYPE_GENERATOR_ID%>" value="<%=request.querystring(COLUMN_CARD_TYPE_GENERATOR_ID) %>" />
    <table border="1">
        <tr><td>Delete Record</td><td><input type="checkbox" name="ConfirmDelete" value="1" /></td></tr>
        <tr><td colspan="2"><input type="submit" /></td></tr>
    </table>
</form>
<%
Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
