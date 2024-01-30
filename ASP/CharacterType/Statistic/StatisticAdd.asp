<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
%>
<p><a href="/CharacterType/CharacterTypeEdit.asp?<%=COLUMN_CHARACTER_TYPE_ID%>=<%=Request.QueryString(COLUMN_CHARACTER_TYPE_ID)%>">Back To Character Type</a></p>
<form action="/CharacterType/Statistic/InsertStatistic.asp" method="POST">
    <input type="hidden" name="<%=COLUMN_CHARACTER_TYPE_ID%>" value="<%=Request.QueryString(COLUMN_CHARACTER_TYPE_ID)%>" />
<table border="1">
    <tr>
        <td>
            <label for="<%=COLUMN_STATISTIC_TYPE_ID%>">Statistic Type: </label>
        </td>
        <td>
            <%=MakeEditComboBox(conn,TABLE_STATISTIC_TYPES,COLUMN_STATISTIC_TYPE_ID,COLUMN_STATISTIC_TYPE_NAME,Null)%>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_STATISTIC_VALUE%>">Statistic Value: </label>
        </td>
        <td>
            <input name="<%=COLUMN_STATISTIC_VALUE%>" type="text"/>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_MINIMUM_VALUE%>">Minimum Value: </label>
        </td>
        <td>
            <input name="<%=COLUMN_MINIMUM_VALUE%>" type="text"/>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_MAXIMUM_VALUE%>">Maximum Value: </label>
        </td>
        <td>
            <input name="<%=COLUMN_MAXIMUM_VALUE%>" type="text"/>
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
