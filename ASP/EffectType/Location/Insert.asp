<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    InsertRecord Conn, _
        TABLE_EFFECT_TYPE_LOCATIONS, _
        Array(COLUMN_EFFECT_TYPE_ID, _
            COLUMN_LOCATION_ID), _
        Array(Request.form(COLUMN_EFFECT_TYPE_ID), _
            Request.form(COLUMN_LOCATION_ID))
    RedirectToEdit "EffectType", COLUMN_EFFECT_TYPE_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
