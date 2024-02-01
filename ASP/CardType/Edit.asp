<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    StartPage
    Dim rs
    Set rs = ExecuteSelectCommand(conn, _
        TABLE_CARD_TYPES, _
        Array(COLUMN_CARD_TYPE_ID,COLUMN_CARD_TYPE_NAME), _
        Array(COLUMN_CARD_TYPE_ID), _
        Array(Request.QueryString(COLUMN_CARD_TYPE_ID)))
    BackToListLink "CardType", "Card Type"
    StartUpdateForm "CardType"
    StartTable 
    ReadonlyInput COLUMN_CARD_TYPE_ID, "Id", rs
%>
    <tr>
        <td>
            <label for="<%=COLUMN_CARD_TYPE_NAME%>">Name: </label>
        </td>
        <td>
            <input name="<%=COLUMN_CARD_TYPE_NAME%>" type="text" maxlength="100" value="<%=rs(COLUMN_CARD_TYPE_NAME)%>"/>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <input type="submit"/>
        </td>
    </tr>
<%
    EndTable 
    EndForm
    rs.close
    set rs = nothing
%>
<form action="/CardType/Delete.asp" method="post">
    <input type="hidden" name="<%=COLUMN_CARD_TYPE_ID%>" value="<%=request.querystring(COLUMN_CARD_TYPE_ID) %>" />
<%
    StartTable 
    ConfirmDeleteCheckbox
    SubmitButton
    EndTable 
    EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
