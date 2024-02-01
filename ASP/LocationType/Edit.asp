<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
StartPage
Dim cmd
Set cmd = MakeSelectCommand(conn, _
    TABLE_LOCATION_TYPES, _
    Array(COLUMN_LOCATION_TYPE_ID,COLUMN_LOCATION_TYPE_NAME), _
    Array(COLUMN_LOCATION_TYPE_ID), _
    Array(Request.QueryString(COLUMN_LOCATION_TYPE_ID)))
Dim rs
Set rs = cmd.Execute()
rs.movefirst
%>
<%
    BackToListLink "LocationType", "Location Type"
%>
<%
    StartUpdateForm "LocationType"
%>
<%StartTable 
        ReadonlyTextInput COLUMN_LOCATION_TYPE_ID, "Id", rs
    
    %>
    <tr>
        <td>
            <label for="<%=COLUMN_LOCATION_TYPE_NAME%>">Name: </label>
        </td>
        <td>
            <input name="<%=COLUMN_LOCATION_TYPE_NAME%>" type="text" maxlength="100" value="<%=rs(COLUMN_LOCATION_TYPE_NAME)%>"/>
        </td>
    </tr>
<%SubmitButton %>
<%EndTable %>
<%EndForm%>
<%
rs.close
set rs = nothing
Set cmd = nothing
    StartDeleteForm "LocationType"
%>
    <input type="hidden" name="<%=COLUMN_LOCATION_TYPE_ID%>" value="<%=request.querystring(COLUMN_LOCATION_TYPE_ID) %>" />
    <%StartTable 
                ConfirmDeleteCheckbox
%>
<%SubmitButton %>
    <%EndTable %>
<%EndForm%>
<%
EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
