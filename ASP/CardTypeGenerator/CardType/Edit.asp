<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
StartPage
Dim cmd
Set cmd = MakeSelectCommand(conn, _
    VIEW_CARD_TYPE_GENERATOR_CARD_TYPE_DETAILS, _
    Array(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID,COLUMN_CARD_TYPE_GENERATOR_ID,COLUMN_CARD_TYPE_NAME,COLUMN_CARD_TYPE_GENERATOR_NAME,COLUMN_GENERATOR_WEIGHT), _
    Array(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID), _
    Array(Request.QueryString(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID)))
Dim rs
Set rs = cmd.Execute()
rs.movefirst
Dim CardTypeGeneratorId
CardTypeGeneratorId = rs(COLUMN_CARD_TYPE_GENERATOR_ID)
%>
<p><a href="/CardTypeGenerator/Edit.asp?<%=COLUMN_CARD_TYPE_GENERATOR_ID%>=<%=CardTypeGeneratorId%>">Back To Card Type Generator</a></p>
<%
    StartUpdateForm "CardTypeGenerator/CardType"
%>
<%
    StartTable 
    ReadonlyTextInput COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID, "Id", rs

%>
    <tr>
        <td>
            <label for="<%=COLUMN_CARD_TYPE_GENERATOR_NAME%>">Card Type Generator: </label>
        </td>
        <td>
            <%=rs(COLUMN_CARD_TYPE_GENERATOR_NAME)%>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_CARD_TYPE_NAME%>">Card Type: </label>
        </td>
        <td>
            <%=rs(COLUMN_CARD_TYPE_NAME)%>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_GENERATOR_WEIGHT%>">Generator Weight: </label>
        </td>
        <td>
            <input name="<%=COLUMN_GENERATOR_WEIGHT%>" type="text" value="<%=rs(COLUMN_GENERATOR_WEIGHT)%>"/>
        </td>
    </tr>
<%SubmitButton %>
<%EndTable %>
<%EndForm%>
<%
rs.close
set rs = nothing
Set cmd = nothing
        StartDeleteForm "CardTypeGenerator/CardType"

%>
    <input type="hidden" name="<%=COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID%>" value="<%=Request.QueryString(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID)%>" />
    <input type="hidden" name="<%=COLUMN_CARD_TYPE_GENERATOR_ID%>" value="<%=CardTypeGeneratorId%>" />
    <%StartTable %>
        <tr><td>Delete Record</td><td><input type="checkbox" name="ConfirmDelete" value="1" /></td></tr>
<%SubmitButton %>
    <%EndTable %>
<%EndForm%>
<%
EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
