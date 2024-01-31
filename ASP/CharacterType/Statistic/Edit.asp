<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
Dim cmd
Set cmd = MakeSelectCommand(conn, _
    VIEW_CHARACTER_TYPE_STATISTIC_DETAILS, _
    Array(COLUMN_CHARACTER_TYPE_STATISTIC_ID,COLUMN_CHARACTER_TYPE_ID,COLUMN_STATISTIC_VALUE,COLUMN_MAXIMUM_VALUE,COLUMN_MINIMUM_VALUE,COLUMN_CHARACTER_TYPE_NAME,COLUMN_STATISTIC_TYPE_NAME), _
    Array(COLUMN_CHARACTER_TYPE_STATISTIC_ID), _
    Array(Request.QueryString(COLUMN_CHARACTER_TYPE_STATISTIC_ID)))
Dim rs
Set rs = cmd.Execute()
rs.movefirst
Dim CharacterTypeId
CharacterTypeId = rs(COLUMN_CHARACTER_TYPE_ID)
%>
<p><a href="/CharacterType/Edit.asp?<%=COLUMN_CHARACTER_TYPE_ID%>=<%=CharacterTypeId%>">Back To Character Type</a></p>
<form action="/CharacterType/Statistic/Update.asp" method="POST">
<table border="1">
    <tr>
        <td>
            <label for="<%=COLUMN_CHARACTER_TYPE_STATISTIC_ID%>">Id:</label>
        </td>
        <td>
            <input name="<%=COLUMN_CHARACTER_TYPE_STATISTIC_ID%>" value="<%=rs(COLUMN_CHARACTER_TYPE_STATISTIC_ID)%>" type="text" readonly="readonly"/>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_CHARACTER_TYPE_NAME%>">Character Type: </label>
        </td>
        <td>
            <%=rs(COLUMN_CHARACTER_TYPE_NAME)%>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_STATISTIC_TYPE_NAME%>">Statistic Type: </label>
        </td>
        <td>
            <%=rs(COLUMN_STATISTIC_TYPE_NAME)%>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_STATISTIC_VALUE%>">Value: </label>
        </td>
        <td>
            <input name="<%=COLUMN_STATISTIC_VALUE%>" type="text" value="<%=rs(COLUMN_STATISTIC_VALUE)%>"/>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_MINIMUM_VALUE%>">Minimum: </label>
        </td>
        <td>
            <input name="<%=COLUMN_MINIMUM_VALUE%>" type="text" value="<%=rs(COLUMN_MINIMUM_VALUE)%>"/>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_MAXIMUM_VALUE%>">Maximum: </label>
        </td>
        <td>
            <input name="<%=COLUMN_MAXIMUM_VALUE%>" type="text" value="<%=rs(COLUMN_MAXIMUM_VALUE)%>"/>
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
rs.close
set rs = nothing
Set cmd = nothing
%>
<form action="/CharacterType/Statistic/Delete.asp" method="post">
    <input type="hidden" name="<%=COLUMN_CHARACTER_TYPE_STATISTIC_ID%>" value="<%=Request.QueryString(COLUMN_CHARACTER_TYPE_STATISTIC_ID)%>" />
    <input type="hidden" name="<%=COLUMN_CHARACTER_TYPE_ID%>" value="<%=CharacterTypeId%>" />
    <table border="1">
        <tr><td>Delete Record</td><td><input type="checkbox" name="ConfirmDelete" value="1" /></td></tr>
        <tr><td colspan="2"><input type="submit" /></td></tr>
    </table>
<%EndForm%>
<%
Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
