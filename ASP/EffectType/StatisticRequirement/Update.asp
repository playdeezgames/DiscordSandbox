<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    UpdateRecord Conn, _
        TABLE_EFFECT_TYPE_STATISTIC_REQUIREMENTS, _
        Array( _
            COLUMN_MINIMUM_VALUE, _
            COLUMN_MAXIMUM_VALUE), _
        Array(COLUMN_EFFECT_TYPE_STATISTIC_REQUIREMENT_ID), _
        Array( _
            EmptyStringIsNull(COLUMN_MINIMUM_VALUE, Request.Form), _
            EmptyStringIsNull(COLUMN_MAXIMUM_VALUE, Request.Form), _
            Request.form(COLUMN_EFFECT_TYPE_STATISTIC_REQUIREMENT_ID))
    RedirectToEdit "EffectType/StatisticRequirement", COLUMN_EFFECT_TYPE_STATISTIC_REQUIREMENT_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
