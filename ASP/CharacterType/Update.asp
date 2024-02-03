<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    UpdateRecord Conn, _
        TABLE_CHARACTER_TYPES, _
        Array( _
            COLUMN_CHARACTER_TYPE_NAME, _
            COLUMN_IS_PLAYER_SELECTABLE, _
            COLUMN_GENERATOR_WEIGHT), _
        Array( _
            COLUMN_CHARACTER_TYPE_ID), _
        Array( _
            Request.Form(COLUMN_CHARACTER_TYPE_NAME), _
            EmptyStringIsFalse(COLUMN_IS_PLAYER_SELECTABLE, Request.Form), _
            Request.Form(COLUMN_GENERATOR_WEIGHT), _
            Request.Form(COLUMN_CHARACTER_TYPE_ID))
    RedirectToEdit "CharacterType", COLUMN_CHARACTER_TYPE_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
