<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
%>
<p><a href="/CardTypeGenerator/Edit.asp?<%=COLUMN_CARD_TYPE_GENERATOR_ID%>=<%=Request.QueryString(COLUMN_CARD_TYPE_GENERATOR_ID)%>">Back To Card Type Generator</a></p>
<%
    StartInsertForm "CardTypeGenerator/CardType"
%>
    <input type="hidden" name="<%=COLUMN_CARD_TYPE_GENERATOR_ID%>" value="<%=Request.QueryString(COLUMN_CARD_TYPE_GENERATOR_ID)%>" />
<%StartTable %>
    <tr>
        <td>
            <label for="<%=COLUMN_CARD_TYPE_ID%>">Card Type: </label>
        </td>
        <td>
            <%=MakeFilteredEditComboBox(conn,VIEW_CARD_TYPE_GENERATOR_AVAILABLE_CARD_TYPES,COLUMN_CARD_TYPE_ID,COLUMN_CARD_TYPE_NAME,Array(COLUMN_CARD_TYPE_GENERATOR_ID),Array(Request.QueryString(COLUMN_CARD_TYPE_GENERATOR_ID)))%>
        </td>
    </tr>
    <tr>
        <td>
            <label for="<%=COLUMN_GENERATOR_WEIGHT%>">Generator Weight: </label>
        </td>
        <td>
            <input name="<%=COLUMN_GENERATOR_WEIGHT%>" type="text" value="1"/>
        </td>
    </tr>
<%SubmitButton %>
<%EndTable %>
<%EndForm%>
<%
Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
