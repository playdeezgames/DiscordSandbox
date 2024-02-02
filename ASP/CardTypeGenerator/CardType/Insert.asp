<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    InsertRecord Conn, _
        TABLE_CARD_TYPE_GENERATOR_CARD_TYPES, _
        Array(COLUMN_CARD_TYPE_GENERATOR_ID,COLUMN_CARD_TYPE_ID,COLUMN_GENERATOR_WEIGHT), _
        Array(Request.form(COLUMN_CARD_TYPE_GENERATOR_ID),Request.form(COLUMN_CARD_TYPE_ID),Request.form(COLUMN_GENERATOR_WEIGHT))
    RedirectToEdit "CardTypeGenerator", COLUMN_CARD_TYPE_GENERATOR_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
