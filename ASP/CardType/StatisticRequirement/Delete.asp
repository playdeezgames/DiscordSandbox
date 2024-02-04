<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    DeleteRecordIfConfirmed Conn, _
        TABLE_CARD_TYPE_STATISTIC_REQUIREMENTS, _
        Array(COLUMN_CARD_TYPE_STATISTIC_REQUIREMENT_ID), _
        Array(Request.form(COLUMN_CARD_TYPE_STATISTIC_REQUIREMENT_ID))
    RedirectToEdit "CardType", COLUMN_CARD_TYPE_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
