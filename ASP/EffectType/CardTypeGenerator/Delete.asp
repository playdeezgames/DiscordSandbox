<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    DeleteRecordIfConfirmed Conn, _
        TABLE_EFFECT_TYPE_CARD_TYPE_GENERATORS, _
        Array(COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID), _
        Array(Request.form(COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID))
    RedirectToEdit "EffectType", COLUMN_EFFECT_TYPE_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
