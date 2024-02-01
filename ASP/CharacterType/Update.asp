<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    UpdateRecord Conn, _
        TABLE_CHARACTER_TYPES, _
        Array(COLUMN_CHARACTER_TYPE_NAME), _
        Array(COLUMN_CHARACTER_TYPE_ID), _
        Array(Request.form(COLUMN_CHARACTER_TYPE_NAME),Request.form(COLUMN_CHARACTER_TYPE_ID))
    RedirectToEdit "CharacterType", COLUMN_CHARACTER_TYPE_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
