<!--#include virtual="inc/Grimoire.asp"-->
<html>
    <head>
        <title>SPLORR!!</title>
    </head>
    <body>
        <p><a href="/CardType/CardTypeEdit.asp?<%=COLUMN_CARD_TYPE_ID%>=<%=Request.QueryString(COLUMN_CARD_TYPE_ID)%>">Back to Card Type</a></p>
        <form action="/CardType/DeleteCardType.asp" method="POST">
            <input type="hidden" name="<%=COLUMN_CARD_TYPE_ID%>" value="<%=Request.QueryString(COLUMN_CARD_TYPE_ID)%>"/>
            <p>Confirm Delete? <input name="ConfirmDelete" type="checkbox" value="1"/></p>
            <input type="submit"/>
        </form>
    </body>
</html>
