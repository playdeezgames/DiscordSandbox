<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
Dim cmd
Set cmd = MakeSelectCommand(conn,TABLE_CHARACTERS,Array(COLUMN_CHARACTER_ID,COLUMN_CHARACTER_NAME,COLUMN_CHARACTER_TYPE_ID,COLUMN_LOCATION_ID),Array(COLUMN_CHARACTER_ID),Array(Request.QueryString(COLUMN_CHARACTER_ID)))
Dim rs
Set rs = cmd.Execute()
rs.movefirst
%>
<p><a href="/Character/CharacterList.asp">Back To Character List</a></p>
<form action="/Character/UpdateCharacter.asp" method="POST">
<table border="1">
    <tr>
        <td>
            <label for="<%=COLUMN_CHARACTER_ID%>">Id:</label>
        </td>
        <td>
            <input name="<%=COLUMN_CHARACTER_ID%>" value="<%=rs(COLUMN_CHARACTER_ID)%>" type="text" readonly="readonly"/>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_CHARACTER_NAME%>">Name: </label>
        </td>
        <td>
            <input name="<%=COLUMN_CHARACTER_NAME%>" type="text" maxlength="100" value="<%=rs(COLUMN_CHARACTER_NAME)%>"/>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_CHARACTER_TYPE_ID%>">Character Type:</label>
        </td>
        <td>
            <%=MakeEditComboBox(Conn, TABLE_CHARACTER_TYPES, COLUMN_CHARACTER_TYPE_ID, COLUMN_CHARACTER_TYPE_NAME, rs(COLUMN_CHARACTER_TYPE_ID))%>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_LOCATION_ID%>">Location:</label>
        </td>
        <td>
            <%=MakeEditComboBox(Conn, TABLE_LOCATIONS, COLUMN_LOCATION_ID, COLUMN_LOCATION_NAME, rs(COLUMN_LOCATION_ID))%>
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
<form action="/Character/DeleteCharacter.asp" method="post">
    <input type="hidden" name="<%=COLUMN_CHARACTER_ID%>" value="<%=request.querystring(COLUMN_CHARACTER_ID) %>" />
    <table border="1">
        <tr><td>Delete Record</td><td><input type="checkbox" name="ConfirmDelete" value="1" /></td></tr>
        <tr><td colspan="2"><input type="submit" /></td></tr>
    </table>
</form>
<%
Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
