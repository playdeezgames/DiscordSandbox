<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    DeleteRecord Conn, _
        TABLE_CARD_TYPE_EFFECTS, _
        Array(COLUMN_CARD_TYPE_EFFECT_ID), _
        Array(Request.form(COLUMN_CARD_TYPE_EFFECT_ID))
%>
<!--#include virtual="inc/closeconn.inc"-->
