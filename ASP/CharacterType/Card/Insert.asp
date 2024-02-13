<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    InsertRecord Conn, _
        TABLE_CHARACTER_TYPE_CARDS, _
        Array(COLUMN_CHARACTER_TYPE_ID, _
            COLUMN_CARD_TYPE_ID, _
            COLUMN_CARD_QUANTITY), _
        Array(Request.form(COLUMN_CHARACTER_TYPE_ID), _
            Request.form(COLUMN_CARD_TYPE_ID), _
            Request.form(COLUMN_CARD_QUANTITY))
    RedirectToEdit "CharacterType", COLUMN_CHARACTER_TYPE_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
