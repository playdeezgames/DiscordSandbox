<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
StartPage
%>
<%
    BackToListLink "EffectType", "Effect Type"
%>
<%
    StartInsertForm "EffectType"
%>
<%StartTable %>
    <tr>
        <td>
            <label for="<%=COLUMN_EFFECT_TYPE_NAME%>">Name: </label>
        </td>
        <td>
            <input name="<%=COLUMN_EFFECT_TYPE_NAME%>" type="text" maxlength="100"/>
        </td>
    </tr>
<%SubmitButton %>
<%EndTable %>
<%EndForm%>
<%
EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
