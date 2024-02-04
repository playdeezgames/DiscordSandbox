<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    UpdateRecord Conn, _
        TABLE_EFFECT_TYPE_STATISTIC_DELTAS, _
        Array( _
            COLUMN_STATISTIC_VALUE), _
        Array(COLUMN_EFFECT_TYPE_STATISTIC_DELTA_ID), _
        Array( _
            Request.Form(COLUMN_STATISTIC_VALUE), _
            Request.form(COLUMN_EFFECT_TYPE_STATISTIC_DELTA_ID))
    RedirectToEdit "EffectType/StatisticDelta", COLUMN_EFFECT_TYPE_STATISTIC_DELTA_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
