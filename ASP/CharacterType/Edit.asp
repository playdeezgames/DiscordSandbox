<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
StartPage
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
<%
    BackToListLink "CharacterType", "Character Type"
%>
<%
    StartUpdateForm "CharacterType"
%>
<%StartTable 
        ReadonlyInput COLUMN_CHARACTER_TYPE_ID, "Id", rs
    
    %>
    <tr>
        <td>
            <label for="<%=COLUMN_CHARACTER_TYPE_NAME%>">Name: </label>
        </td>
        <td>
            <input name="<%=COLUMN_CHARACTER_TYPE_NAME%>" type="text" maxlength="100" value="<%=rs(COLUMN_CHARACTER_TYPE_NAME)%>"/>
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
<form action="/CharacterType/Delete.asp" method="post">
    <input type="hidden" name="<%=COLUMN_CHARACTER_TYPE_ID%>" value="<%=request.querystring(COLUMN_CHARACTER_TYPE_ID) %>" />
    <%StartTable %>
        <tr><td>Delete Record</td><td><input type="checkbox" name="ConfirmDelete" value="1" /></td></tr>
<%SubmitButton %>
    <%EndTable %>
<%EndForm%>
<hr />
<%
    Server.Execute("/CharacterType/Statistic/List.asp")
%>
<%
EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
