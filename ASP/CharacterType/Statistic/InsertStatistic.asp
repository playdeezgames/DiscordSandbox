<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Dim MaximumValue
MaximumValue = Request.form(COLUMN_MAXIMUM_VALUE)
if len(maximumvalue)=0 then
    maximumvalue = null
end if
Dim MinimumValue
MinimumValue = Request.form(COLUMN_MINIMUM_VALUE)
if len(minimumvalue)=0 then
    minimumvalue = null
end if
InsertRecord Conn, _
    TABLE_CHARACTER_TYPE_STATISTICS, _
    Array(COLUMN_CHARACTER_TYPE_ID,COLUMN_STATISTIC_TYPE_ID,COLUMN_STATISTIC_VALUE,COLUMN_MINIMUM_VALUE,COLUMN_MAXIMUM_VALUE), _
    Array(Request.form(COLUMN_CHARACTER_TYPE_ID),Request.form(COLUMN_STATISTIC_TYPE_ID),Request.form(COLUMN_STATISTIC_VALUE),MinimumValue,MaximumValue)
Response.Redirect("/CharacterType/CharacterTypeEdit.asp?" & COLUMN_CHARACTER_TYPE_ID & "=" & Request.form(COLUMN_CHARACTER_TYPE_ID))
%>
<!--#include virtual="inc/closeconn.inc"-->
