<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    DeleteRecordIfConfirmed Conn, _
        TABLE_EFFECT_TYPES, _
        Array(COLUMN_EFFECT_TYPE_ID), _
        Array(Request.form(COLUMN_EFFECT_TYPE_ID))
    RedirectToList "EffectType"
%>
<!--#include virtual="inc/closeconn.inc"-->
