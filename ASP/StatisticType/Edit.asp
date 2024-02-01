<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
StartPage
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
<%StartTable 
        ReadonlyTextInput COLUMN_STATISTIC_TYPE_ID, "Id", rs
    %>
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
        StartDeleteForm "StatisticType"
%>
    <input type="hidden" name="<%=COLUMN_STATISTIC_TYPE_ID%>" value="<%=request.querystring(COLUMN_STATISTIC_TYPE_ID) %>" />
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
