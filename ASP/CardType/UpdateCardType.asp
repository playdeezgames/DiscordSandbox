<!--#include virtual="/inc/AdoVbs.inc"-->
<!--#include virtual="/inc/openconn.inc"-->
<%
Set cmd = Server.CreateObject("ADODB.Command")
Set cmd.activeconnection=conn
cmd.CommandType=adCmdText
cmd.CommandText="UPDATE CardTypes SET CardTypeName=?,DeleteOnPlay=? WHERE CardTypeId=?;"
cmd.Parameters.Refresh
cmd.Parameters(0).Value=Request.Form("CardTypeName")
if Request.Form("DeleteOnPlay")=1 Then
    cmd.Parameters(1).Value=True
else
    cmd.Parameters(1).Value=False
end if
cmd.Parameters(2).Value=Request.Form("CardTypeId")
cmd.Execute()
Response.Redirect "/CardType/CardTypeList.asp"
Set cmd=nothing
%>
<!--#include virtual="/inc/closeconn.inc"-->
