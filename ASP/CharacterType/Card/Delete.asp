<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    DeleteRecordIfConfirmed Conn, _
        TABLE_CHARACTER_TYPE_CARDS, _
        Array(COLUMN_CHARACTER_TYPE_CARD_ID), _
        Array(Request.form(COLUMN_CHARACTER_TYPE_CARD_ID))
    RedirectToEdit "CharacterType", COLUMN_CHARACTER_TYPE_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
