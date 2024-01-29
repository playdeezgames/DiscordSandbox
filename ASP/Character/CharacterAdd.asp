<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
%>
<p><a href="/Character/CharacterList.asp">Back To Character List</a></p>
<form action="/Character/InsertCharacter.asp" method="POST">
<table border="1">
    <tr>
        <td>
            <label for="<%=COLUMN_CHARACTER_NAME%>">Name: </label>
        </td>
        <td>
            <input name="<%=COLUMN_CHARACTER_NAME%>" type="text" maxlength="100"/>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_CHARACTER_TYPE_ID%>">Character Type:</label>
        </td>
        <td>
            <%=MakeEditComboBox(Conn, TABLE_CHARACTER_TYPES, COLUMN_CHARACTER_TYPE_ID, COLUMN_CHARACTER_TYPE_NAME, Null)%>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_LOCATION_ID%>">Location:</label>
        </td>
        <td>
            <%=MakeEditComboBox(Conn, TABLE_LOCATIONS, COLUMN_LOCATION_ID, COLUMN_LOCATION_NAME, Null)%>
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
Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
