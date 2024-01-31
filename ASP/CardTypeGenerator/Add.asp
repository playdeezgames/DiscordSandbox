<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Server.Execute("/inc/Start.asp")
%>
<%
    BackToListLink "CardTypeGenerator", "Card Type Generator"
%>
<%
    StartInsertForm "CardTypeGenerator"
%>
<%StartTable %>
    <tr>
        <td>
            <label for="<%=COLUMN_CARD_TYPE_GENERATOR_NAME%>">Name: </label>
        </td>
        <td>
            <input name="<%=COLUMN_CARD_TYPE_GENERATOR_NAME%>" type="text" maxlength="100"/>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <input type="submit"/>
        </td>
    </tr>
<%EndTable %>
<%EndForm%>
<%
Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
