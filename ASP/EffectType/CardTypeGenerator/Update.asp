<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    UpdateRecord Conn, _
        TABLE_EFFECT_TYPE_CARD_TYPE_GENERATORS, _
        Array( _
            COLUMN_CARD_COUNT), _
        Array(COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID), _
        Array( _
            Request.Form(COLUMN_CARD_COUNT), _
            Request.form(COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID))
    RedirectToEdit "EffectType/CardTypeGenerator", COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
