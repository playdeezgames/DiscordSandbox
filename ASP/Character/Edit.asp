<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
StartPage
Dim cmd
Set cmd = MakeSelectCommand(conn,TABLE_CHARACTERS,Array(COLUMN_CHARACTER_ID,COLUMN_CHARACTER_NAME,COLUMN_CHARACTER_TYPE_ID,COLUMN_LOCATION_ID),Array(COLUMN_CHARACTER_ID),Array(Request.QueryString(COLUMN_CHARACTER_ID)))
Dim rs
Set rs = cmd.Execute()
rs.movefirst
%>
<%
    BackToListLink "Character", "Character"
%>
<%
    StartUpdateForm "Character"
%>
<%StartTable 
        ReadonlyInput COLUMN_CHARACTER_ID, "Id", rs
    
    %>
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
<%SubmitButton %>
<%EndTable %>
<%EndForm%>
<%
rs.close
set rs = nothing
Set cmd = nothing
%>
<form action="/Character/Delete.asp" method="post">
    <input type="hidden" name="<%=COLUMN_CHARACTER_ID%>" value="<%=request.querystring(COLUMN_CHARACTER_ID) %>" />
    <%StartTable %>
        <tr><td>Delete Record</td><td><input type="checkbox" name="ConfirmDelete" value="1" /></td></tr>
<%SubmitButton %>
    <%EndTable %>
<%EndForm%>
<%
EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
