<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
%>
<%
    BackToListLink "LocationType", "Location Type"
%>
<%
    StartInsertForm "LocationType"
%>
<table border="1">
    <tr>
        <td>
            <label for="<%=COLUMN_LOCATION_TYPE_NAME%>">Name: </label>
        </td>
        <td>
            <input name="<%=COLUMN_LOCATION_TYPE_NAME%>" type="text" maxlength="100"/>
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
Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
