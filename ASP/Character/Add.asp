<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
StartPage
%>
<%
    BackToListLink "Character", "Character"
%>
<%
    StartInsertForm "Character"
%>
<%StartTable %>
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
<%SubmitButton %>
<%EndTable %>
<%EndForm%>
<%
EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
