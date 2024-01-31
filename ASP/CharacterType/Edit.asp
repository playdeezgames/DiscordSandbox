<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
Dim cmd
Set cmd = MakeSelectCommand(conn, _
    TABLE_CHARACTER_TYPES, _
    Array(COLUMN_CHARACTER_TYPE_ID,COLUMN_CHARACTER_TYPE_NAME), _
    Array(COLUMN_CHARACTER_TYPE_ID), _
    Array(Request.QueryString(COLUMN_CHARACTER_TYPE_ID)))
Dim rs
Set rs = cmd.Execute()
rs.movefirst
%>
<p><a href="/CharacterType/List.asp">Back To Character Type List</a></p>
<form action="/CharacterType/Update.asp" method="POST">
<table border="1">
    <tr>
        <td>
            <label for="<%=COLUMN_CHARACTER_TYPE_ID%>">Id:</label>
        </td>
        <td>
            <input name="<%=COLUMN_CHARACTER_TYPE_ID%>" value="<%=rs(COLUMN_CHARACTER_TYPE_ID)%>" type="text" readonly="readonly"/>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_CHARACTER_TYPE_NAME%>">Name: </label>
        </td>
        <td>
            <input name="<%=COLUMN_CHARACTER_TYPE_NAME%>" type="text" maxlength="100" value="<%=rs(COLUMN_CHARACTER_TYPE_NAME)%>"/>
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
<form action="/CharacterType/Delete.asp" method="post">
    <input type="hidden" name="<%=COLUMN_CHARACTER_TYPE_ID%>" value="<%=request.querystring(COLUMN_CHARACTER_TYPE_ID) %>" />
    <table border="1">
        <tr><td>Delete Record</td><td><input type="checkbox" name="ConfirmDelete" value="1" /></td></tr>
        <tr><td colspan="2"><input type="submit" /></td></tr>
    </table>
</form>
<hr />
<%
    Server.Execute("/CharacterType/Statistic/StatisticSublist.asp")
%>
<%
Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
