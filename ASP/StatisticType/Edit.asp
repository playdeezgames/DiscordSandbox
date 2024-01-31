<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
Dim cmd
Set cmd = MakeSelectCommand(conn, _
    TABLE_STATISTIC_TYPES, _
    Array(COLUMN_STATISTIC_TYPE_ID,COLUMN_STATISTIC_TYPE_NAME), _
    Array(COLUMN_STATISTIC_TYPE_ID), _
    Array(Request.QueryString(COLUMN_STATISTIC_TYPE_ID)))
Dim rs
Set rs = cmd.Execute()
rs.movefirst
%>
<%
    BackToListLink "StatisticType", "Statistic Type"
%>
<%
    StartUpdateForm "StatisticType"
%>
<%StartTable %>
    <tr>
        <td>
            <label for="<%=COLUMN_STATISTIC_TYPE_ID%>">Id:</label>
        </td>
        <td>
            <input name="<%=COLUMN_STATISTIC_TYPE_ID%>" value="<%=rs(COLUMN_STATISTIC_TYPE_ID)%>" type="text" readonly="readonly"/>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_STATISTIC_TYPE_NAME%>">Name: </label>
        </td>
        <td>
            <input name="<%=COLUMN_STATISTIC_TYPE_NAME%>" type="text" maxlength="100" value="<%=rs(COLUMN_STATISTIC_TYPE_NAME)%>"/>
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
<form action="/StatisticType/Delete.asp" method="post">
    <input type="hidden" name="<%=COLUMN_STATISTIC_TYPE_ID%>" value="<%=request.querystring(COLUMN_STATISTIC_TYPE_ID) %>" />
    <%StartTable %>
        <tr><td>Delete Record</td><td><input type="checkbox" name="ConfirmDelete" value="1" /></td></tr>
<%SubmitButton %>
    <%EndTable %>
<%EndForm%>
<%
Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
