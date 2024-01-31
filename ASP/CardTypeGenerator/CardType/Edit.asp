<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
Dim cmd
Set cmd = MakeSelectCommand(conn, _
    VIEW_CARD_TYPE_GENERATOR_CARD_TYPE_DETAILS, _
    Array(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID,COLUMN_CARD_TYPE_GENERATOR_ID,COLUMN_CARD_TYPE_NAME,COLUMN_CARD_TYPE_GENERATOR_NAME,COLUMN_GENERATOR_WEIGHT), _
    Array(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID), _
    Array(Request.QueryString(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID)))
Dim rs
Set rs = cmd.Execute()
rs.movefirst
Dim CardTypeGeneratorId
CardTypeGeneratorId = rs(COLUMN_CARD_TYPE_GENERATOR_ID)
%>
<p><a href="/CardTypeGenerator/Edit.asp?<%=COLUMN_CARD_TYPE_GENERATOR_ID%>=<%=CardTypeGeneratorId%>">Back To Card Type Generator</a></p>
<form action="/CardTypeGenerator/CardType/Update.asp" method="POST">
<table border="1">
    <tr>
        <td>
            <label for="<%=COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID%>">Id:</label>
        </td>
        <td>
            <input name="<%=COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID%>" value="<%=rs(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID)%>" type="text" readonly="readonly"/>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_CARD_TYPE_GENERATOR_NAME%>">Card Type Generator: </label>
        </td>
        <td>
            <%=rs(COLUMN_CARD_TYPE_GENERATOR_NAME)%>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_CARD_TYPE_NAME%>">Card Type: </label>
        </td>
        <td>
            <%=rs(COLUMN_CARD_TYPE_NAME)%>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_GENERATOR_WEIGHT%>">Generator Weight: </label>
        </td>
        <td>
            <input name="<%=COLUMN_GENERATOR_WEIGHT%>" type="text" value="<%=rs(COLUMN_GENERATOR_WEIGHT)%>"/>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <input type="submit"/>
        </td>
    </tr>
</table>
<%EndForm%>
<%
rs.close
set rs = nothing
Set cmd = nothing
%>
<form action="/CardTypeGenerator/CardType/Delete.asp" method="post">
    <input type="hidden" name="<%=COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID%>" value="<%=Request.QueryString(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID)%>" />
    <input type="hidden" name="<%=COLUMN_CARD_TYPE_GENERATOR_ID%>" value="<%=CardTypeGeneratorId%>" />
    <table border="1">
        <tr><td>Delete Record</td><td><input type="checkbox" name="ConfirmDelete" value="1" /></td></tr>
        <tr><td colspan="2"><input type="submit" /></td></tr>
    </table>
<%EndForm%>
<%
Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
