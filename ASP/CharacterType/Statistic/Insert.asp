<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    InsertRecord Conn, _
        TABLE_CHARACTER_TYPE_STATISTICS, _
        Array(COLUMN_CHARACTER_TYPE_ID, _
            COLUMN_STATISTIC_TYPE_ID, _
            COLUMN_STATISTIC_VALUE, _
            COLUMN_MINIMUM_VALUE, _
            COLUMN_MAXIMUM_VALUE), _
        Array(Request.form(COLUMN_CHARACTER_TYPE_ID), _
            Request.form(COLUMN_STATISTIC_TYPE_ID), _
            Request.form(COLUMN_STATISTIC_VALUE), _
            EmptyStringIsNull(COLUMN_MINIMUM_VALUE, Request.Form), _
            EmptyStringIsNull(COLUMN_MAXIMUM_VALUE, Request.Form))
    RedirectToEdit "CharacterType", COLUMN_CHARACTER_TYPE_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
