<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    InsertRecord Conn, _
        TABLE_CARD_TYPE_EFFECTS, _
        Array( _
            COLUMN_CARD_TYPE_ID, _
            COLUMN_EFFECT_TYPE_ID), _
        Array( _
            Request.form(COLUMN_CARD_TYPE_ID), _
            Request.form(COLUMN_EFFECT_TYPE_ID))
%>
<!--#include virtual="inc/closeconn.inc"-->
