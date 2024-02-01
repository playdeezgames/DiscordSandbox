<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    UpdateRecord Conn, _
        TABLE_CARD_TYPE_GENERATORS, _
        Array(COLUMN_CARD_TYPE_GENERATOR_NAME), _
        Array(COLUMN_CARD_TYPE_GENERATOR_ID), _
        Array(Request.form(COLUMN_CARD_TYPE_GENERATOR_NAME),Request.form(COLUMN_CARD_TYPE_GENERATOR_ID))
    RedirectToEdit "CardTypeGenerator", COLUMN_CARD_TYPE_GENERATOR_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
