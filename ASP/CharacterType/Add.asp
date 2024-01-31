<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
%>
<%
    BackToListLink "CharacterType", "Character Type"
%>
<%
    StartInsertForm "CharacterType"
%>
<%StartTable %>
    <tr>
        <td>
            <label for="<%=COLUMN_CHARACTER_TYPE_NAME%>">Name: </label>
        </td>
        <td>
            <input name="<%=COLUMN_CHARACTER_TYPE_NAME%>" type="text" maxlength="100"/>
        </td>
    </tr>
<%SubmitButton %>
<%EndTable %>
<%EndForm%>
<%
Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
