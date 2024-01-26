<html>
    <head>
        <title>SPLORR!!</title>
    </head>
    <body>
        <p><a href="CardTypeEdit.asp?CardTypeId=<%=Request.QueryString("CardTypeId")%>">Back to Card Type</a></p>
        <form action="DeleteCardType.asp" method="POST">
            <input type="hidden" name="CardTypeId" value="<%=Request.QueryString("CardTypeId")%>"/>
            <p>Confirm Delete? <input name="ConfirmDelete" type="checkbox" value="1"/></p>
            <input type="submit"/>
        </form>
    </body>
</html>
