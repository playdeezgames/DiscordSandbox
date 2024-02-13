<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    UpdateRecord Conn, _
        TABLE_CHARACTER_TYPE_CARDS, _
        Array( _
            COLUMN_CARD_QUANTITY), _
        Array(COLUMN_CHARACTER_TYPE_CARD_ID), _
        Array( _
            Request.form(COLUMN_CARD_QUANTITY), _
            Request.form(COLUMN_CHARACTER_TYPE_CARD_ID))
    RedirectToEdit "CharacterType/Card", COLUMN_CHARACTER_TYPE_CARD_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
