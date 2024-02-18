<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    InsertRecord Conn, _
        TABLE_CARD_TYPES, _
        Array( _
            COLUMN_CARD_TYPE_NAME, _
            COLUMN_SELF_DESTRUCT, _
            COLUMN_CARD_LIMIT, _
            COLUMN_ALWAYS_AVAILABLE), _
        Array( _
            Request.form(COLUMN_CARD_TYPE_NAME), _
            EmptyStringIsFalse(COLUMN_SELF_DESTRUCT,Request.Form), _
            EmptyStringIsNull(COLUMN_CARD_LIMIT,Request.Form), _
            EmptyStringIsFalse(COLUMN_ALWAYS_AVAILABLE,Request.Form))
    RedirectToList "CardType"
%>
<!--#include virtual="inc/closeconn.inc"-->
