<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    DeleteRecordIfConfirmed Conn, _
        TABLE_EFFECT_TYPE_STATISTIC_REQUIREMENTS, _
        Array(COLUMN_EFFECT_TYPE_STATISTIC_REQUIREMENT_ID), _
        Array(Request.form(COLUMN_EFFECT_TYPE_STATISTIC_REQUIREMENT_ID))
    RedirectToEdit "EffectType", COLUMN_EFFECT_TYPE_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
