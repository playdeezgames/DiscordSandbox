<!--#include virtual="inc/Grimoire.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/openconn.inc"-->
<%
Set cmd = Server.CreateObject("ADODB.Command")
Set cmd.activeconnection=conn
cmd.CommandType=adCmdText
cmd.CommandText="INSERT " & TABLE_CARD_TYPES & "(" & COLUMN_CARD_TYPE_NAME & "," & COLUMN_DELETE_ON_PLAY & ") VALUES(?,?);"
cmd.Parameters.Refresh
cmd.Parameters(0).Value=Request.Form(COLUMN_CARD_TYPE_NAME)
if Request.Form(COLUMN_DELETE_ON_PLAY)=1 then
    cmd.Parameters(1).Value=True
else
    cmd.Parameters(1).Value=False
end if
cmd.Execute()
Response.Redirect "/CardType/CardTypeList.asp"
Set cmd=nothing
%>
<!--#include virtual="inc/closeconn.inc"-->
