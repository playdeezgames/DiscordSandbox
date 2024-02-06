<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    UpdateRecord Conn, _
        TABLE_CHARACTER_STATISTICS, _
        Array( _
            COLUMN_STATISTIC_VALUE, _
            COLUMN_MINIMUM_VALUE, _
            COLUMN_MAXIMUM_VALUE), _
        Array(COLUMN_CHARACTER_STATISTIC_ID), _
        Array( _
            Request.form(COLUMN_STATISTIC_VALUE), _
            EmptyStringIsNull(COLUMN_MINIMUM_VALUE, Request.Form), _
            EmptyStringIsNull(COLUMN_MAXIMUM_VALUE, Request.Form), _
            Request.form(COLUMN_CHARACTER_STATISTIC_ID))
    RedirectToEdit "Character/Statistic", COLUMN_CHARACTER_STATISTIC_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
