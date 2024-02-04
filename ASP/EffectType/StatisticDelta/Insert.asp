<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    InsertRecord Conn, _
        TABLE_EFFECT_TYPE_STATISTIC_DELTAS, _
        Array(COLUMN_EFFECT_TYPE_ID, _
            COLUMN_STATISTIC_TYPE_ID, _
            COLUMN_STATISTIC_VALUE), _
        Array(Request.form(COLUMN_EFFECT_TYPE_ID), _
            Request.form(COLUMN_STATISTIC_TYPE_ID), _
            Request.Form(COLUMN_STATISTIC_VALUE))
    RedirectToEdit "EffectType", COLUMN_EFFECT_TYPE_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
