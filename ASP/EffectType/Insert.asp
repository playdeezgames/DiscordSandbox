<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
InsertRecord Conn, _
    TABLE_EFFECT_TYPES, _
    Array(COLUMN_EFFECT_TYPE_NAME), _
    Array(Request.form(COLUMN_EFFECT_TYPE_NAME))
Response.Redirect("/EffectType/List.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
