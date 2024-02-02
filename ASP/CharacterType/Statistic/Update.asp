<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    UpdateRecord Conn, _
        TABLE_CHARACTER_TYPE_STATISTICS, _
        Array(COLUMN_STATISTIC_VALUE,COLUMN_MINIMUM_VALUE,COLUMN_MAXIMUM_VALUE), _
        Array(COLUMN_CHARACTER_TYPE_STATISTIC_ID), _
        Array(Request.form(COLUMN_STATISTIC_VALUE),EmptyStringIsNull(COLUMN_MINIMUM_VALUE, Request.Form),EmptyStringIsNull(COLUMN_MAXIMUM_VALUE, Request.Form),Request.form(COLUMN_CHARACTER_TYPE_STATISTIC_ID))
    RedirectToEdit "CharacterType/Statistic", COLUMN_CHARACTER_TYPE_STATISTIC_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
