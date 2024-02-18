<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    UpdateRecord Conn, _
        TABLE_EFFECT_TYPES, _
        Array( _
            COLUMN_EFFECT_TYPE_NAME, _
            COLUMN_LOCATION_TYPE_ID, _
            COLUMN_REFRESH_HAND), _
        Array( _
            COLUMN_EFFECT_TYPE_ID), _
        Array( _
            Request.form(COLUMN_EFFECT_TYPE_NAME), _
            EmptyStringIsNull(COLUMN_LOCATION_TYPE_ID, Request.Form), _
            EmptyStringIsFalse(COLUMN_REFRESH_HAND, Request.Form), _
            Request.form(COLUMN_EFFECT_TYPE_ID))
    RedirectToEdit "EffectType", COLUMN_EFFECT_TYPE_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
