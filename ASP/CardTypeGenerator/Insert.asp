<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    InsertRecord Conn, _
        TABLE_CARD_TYPE_GENERATORS, _
        Array(COLUMN_CARD_TYPE_GENERATOR_NAME), _
        Array(Request.form(COLUMN_CARD_TYPE_GENERATOR_NAME))
    RedirectToList "CardTypeGenerator"
%>
<!--#include virtual="inc/closeconn.inc"-->
