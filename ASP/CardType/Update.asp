<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    UpdateRecord Conn, _
        TABLE_CARD_TYPES, _
        Array( _
            COLUMN_CARD_TYPE_NAME, _
            COLUMN_SELF_DESTRUCT), _
        Array(COLUMN_CARD_TYPE_ID), _
        Array( _
            Request.form(COLUMN_CARD_TYPE_NAME), _
            EmptyStringIsFalse(COLUMN_SELF_DESTRUCT,Request.Form), _
            Request.form(COLUMN_CARD_TYPE_ID))
    RedirectToEdit "CardType", COLUMN_CARD_TYPE_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
