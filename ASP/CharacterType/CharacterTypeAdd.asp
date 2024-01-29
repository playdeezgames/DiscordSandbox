<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
%>
<p><a href="/CharacterType/CharacterTypeList.asp">Back To Character Type List</a></p>
<form action="/CharacterType/InsertCharacterType.asp" method="POST">
<table border="1">
    <tr>
        <td>
            <label for="<%=COLUMN_CHARACTER_TYPE_NAME%>">Name: </label>
        </td>
        <td>
            <input name="<%=COLUMN_CHARACTER_TYPE_NAME%>" type="text" maxlength="100"/>
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
