<%
Const COLUMN_CARD_COUNT = "CardCount"
Const COLUMN_CARD_ID = "CardId"
Const COLUMN_CARD_TYPE_ID = "CardTypeId"
Const COLUMN_CARD_TYPE_NAME = "CardTypeName"
Const COLUMN_CHARACTER_ID = "CharacterId"
Const COLUMN_CHARACTER_NAME = "CharacterName"
Const COLUMN_CHARACTER_TYPE_ID = "CharacterTypeId"
Const COLUMN_CHARACTER_TYPE_NAME = "CharacterTypeName"
Const COLUMN_DELETE_ON_PLAY ="DeleteOnPlay"
Const COLUMN_DRAW_ORDER = "DrawOrder"
Const COLUMN_IN_DISCARD_PILE = "InDiscardPile"
Const COLUMN_IN_DRAW_PILE = "InDrawPile"
Const COLUMN_IN_HAND = "InHand"
Const COLUMN_LOCATION_ID = "LocationId"
Const COLUMN_LOCATION_NAME = "LocationName"
Const COLUMN_LOCATION_TYPE_ID = "LocationTypeId"
Const COLUMN_LOCATION_TYPE_NAME = "LocationTypeName"
Const COLUMN_CARD_TYPE_GENERATOR_ID = "CardTypeGeneratorId"
Const COLUMN_CARD_TYPE_GENERATOR_NAME = "CardTypeGeneratorName"
Const COLUMN_EFFECT_TYPE_ID = "EffectTypeId"
Const COLUMN_EFFECT_TYPE_NAME = "EffectTypeName"
Const COLUMN_STATISTIC_TYPE_ID = "StatisticTypeId"
Const COLUMN_STATISTIC_TYPE_NAME = "StatisticTypeName"
Const COLUMN_CHARACTER_TYPE_STATISTIC_ID = "CharacterTypeStatisticId"
Const COLUMN_STATISTIC_VALUE = "StatisticValue"
Const COLUMN_MAXIMUM_VALUE = "MaximumValue"
Const COLUMN_MINIMUM_VALUE = "MinimumValue"
Const COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID = "CardTypeGeneratorCardTypeId"
Const COLUMN_GENERATOR_WEIGHT = "GeneratorWeight"

Const TABLE_CARD_TYPES = "CardTypes"
Const TABLE_CARDS = "Cards"
Const TABLE_CHARACTERS = "Characters"
Const TABLE_CHARACTER_TYPES = "CharacterTypes"
Const TABLE_LOCATIONS = "Locations"
Const TABLE_LOCATION_TYPES = "LocationTypes"
Const TABLE_EFFECT_TYPES = "EffectTypes"
Const TABLE_STATISTIC_TYPES = "StatisticTypes"
Const TABLE_CARD_TYPE_GENERATORS = "CardTypeGenerators"
Const TABLE_CHARACTER_TYPE_STATISTICS = "CharacterTypeStatistics"
Const TABLE_CARD_TYPE_GENERATOR_CARD_TYPES = "CardTypeGeneratorCardTypes"

Const VIEW_CARD_DETAILS = "CardDetails"
Const VIEW_CARD_TYPE_DETAILS = "CardTypeDetails"
Const VIEW_CHARACTER_DETAILS = "CharacterDetails"
Const VIEW_CHARACTER_TYPE_DETAILS = "CharacterTypeDetails"
Const VIEW_LOCATION_TYPE_DETAILS = "LocationTypeDetails"
Const VIEW_EFFECT_TYPE_DETAILS = "EffectTypeDetails"
Const VIEW_STATISTIC_TYPE_DETAILS = "StatisticTypeDetails"
Const VIEW_CARD_TYPE_GENERATOR_DETAILS = "CardTypeGeneratorDetails"
Const VIEW_CHARACTER_TYPE_STATISTIC_DETAILS = "CharacterTypeStatisticDetails"
Const VIEW_CHARACTER_TYPE_AVAILABLE_STATISTIC_TYPES = "CharacterTypeAvailableStatisticTypes"
Const VIEW_CARD_TYPE_GENERATOR_CARD_TYPE_DETAILS = "CardTypeGeneratorCardTypeDetails"
Const VIEW_CARD_TYPE_GENERATOR_AVAILABLE_CARD_TYPES = "CardTypeGeneratorAvailableCardTypes"

Function MakeSelectCommandText(TableName, ShowColumns, FilterColumns)
    Dim result
    result = "SELECT " & Join(ShowColumns,", ") & " FROM " & TableName
    if not isnull(FilterColumns) then
        result = result & " WHERE " & Join(FilterColumns," = ? AND ") & " = ?"
    end if
    MakeSelectCommandText=result
End Function

Function MakeSelectCommand(Conn, TableName, ShowColumns, FilterColumns, FilterValues)
    Set MakeSelectCommand = Server.CreateObject("ADODB.Command")
    Set MakeSelectCommand.activeconnection=Conn
    MakeSelectCommand.CommandType=adCmdText
    MakeSelectCommand.CommandText=MakeSelectCommandText(TableName,ShowColumns,FilterColumns)
    if not isnull(FilterValues) then
        MakeSelectCommand.Parameters.Refresh
        Dim index
        for index=0 to ubound(FilterValues)
            MakeSelectCommand.Parameters(index)=FilterValues(index)
        next
    end if
End Function


Function MakeFilteredEditComboBox(Conn, TableName, KeyColumnName, DisplayColumnName, FilterColumns, FilterValues)
    Dim result
    result="<select name=""" & KeyColumnName &  """>"
    Dim cmd
    Set cmd = MakeSelectCommand(conn, TableName,Array(KeyColumnName,DisplayColumnName),FilterColumns,FilterValues)
    Dim rs
    set rs = cmd.Execute
    do until rs.eof
        result = result & "<option value="""
        result = result & rs(KeyColumnName) 
        result = result & """>"
        result = result & rs(DisplayColumnName)
        result = result & "</option>"
        rs.movenext
    loop
    rs.close
    set rs=nothing
    Set cmd = nothing
    result=result & "</select>"
    MakeFilteredEditComboBox = result
End Function


Function MakeEditComboBox(Conn, TableName, KeyColumnName, DisplayColumnName, KeyValue)
    Dim result
    result="<select name=""" & KeyColumnName &  """>"
    Dim cmd
    Set cmd = MakeSelectCommand(conn, TableName,Array(KeyColumnName,DisplayColumnName),Null,Null)
    Dim rs
    set rs = cmd.Execute
    do until rs.eof
        result = result & "<option value="""
        result = result & rs(KeyColumnName) 
        result = result & """"
        if rs(KeyColumnName)=KeyValue then
            result = result & " selected=""selected"""
        end if
        result = result & ">"
        result = result & rs(DisplayColumnName)
        result = result & "</option>"
        rs.movenext
    loop
    rs.close
    set rs=nothing
    Set cmd = nothing
    result=result & "</select>"
    MakeEditComboBox=result
End Function

Function UpdateRecord(Conn, TableName, ColumnNames, FilterColumns, ColumnValues)
    Dim result
    result="UPDATE " & TableName & " SET " & Join(ColumnNames," = ?," ) & " = ? WHERE " & Join(FilterColumns," = ? AND ") & " = ?;"
    Dim cmd
    Set cmd = Server.CreateObject("ADODB.Command")
    cmd.activeconnection=Conn
    cmd.CommandType=adCmdText
    cmd.CommandText= result
    cmd.Parameters.Refresh
    Dim index
    for index=0 to ubound(ColumnValues)
        cmd.Parameters(index)=ColumnValues(index)
    next
    cmd.Execute()
    Set cmd = nothing
End Function

Function InsertRecord(Conn, TableName, ColumnNames, ColumnValues)
    Dim result
    result = "INSERT INTO " & TableName & " (" & Join(ColumnNames,"," ) & ") VALUES("
    dim index
    for index=0 to ubound(columnnames)
        if index>0 then
        result = result & ","
        end if
        result = result & "?"
    next    
    result = result & ");"
    Dim cmd
    Set cmd = Server.CreateObject("ADODB.Command")
    cmd.activeconnection=Conn
    cmd.CommandType=adCmdText
    cmd.CommandText= result
    cmd.Parameters.Refresh
    for index=0 to ubound(ColumnValues)
        cmd.Parameters(index)=ColumnValues(index)
    next
    cmd.Execute()
    Set cmd = nothing
End Function

Sub DeleteRecord(Conn, TableName, FilterColumns, ColumnValues)
    Dim result
    result="DELETE FROM " & TableName & " WHERE " & Join(FilterColumns," = ? AND ") & " = ?;"
    Dim cmd
    Set cmd = Server.CreateObject("ADODB.Command")
    cmd.activeconnection=Conn
    cmd.CommandType=adCmdText
    cmd.CommandText= result
    cmd.Parameters.Refresh
    Dim index
    for index=0 to ubound(ColumnValues)
        cmd.Parameters(index)=ColumnValues(index)
    next
    cmd.Execute()
    Set cmd = nothing
End Sub

Sub DeleteRecordIfConfirmed(Conn, TableName, FilterColumns, ColumnValues)
    if request.form("ConfirmDelete")="1" then
        DeleteRecord Conn, TableName, FilterColumns, ColumnValues
    end if
End Sub

Sub BackToListLink(SubPath,Title)
    Response.Write("<p><a href=""/" & SubPath & "/List.asp"">Back To " & Title & " List</a></p>")
End Sub

Sub StartInsertForm(SubPath)
    response.write("<form action=""/" & SubPath & "/Insert.asp"" method=""POST"">")
End Sub

Sub StartDeleteForm(SubPath)
    response.write("<form action=""/" & SubPath & "/Delete.asp"" method=""POST"">")
End Sub

Sub StartUpdateForm(SubPath)
    response.write("<form action=""/" & SubPath & "/Update.asp"" method=""POST"">")
End Sub

Sub EndForm()
    Response.Write("</form>")
End Sub

Sub SubmitButton()
    Response.Write("<tr><td colspan=""2""><input type=""submit""/></td></tr>")
End Sub

Sub StartTable()
    Response.Write("<table border=""1"">")
End Sub

Sub EndTable()
    Response.Write("</table>")
End Sub

Sub StartTable()
    Response.Write("<table border=""1"">")
End Sub

Sub NameInput(InputName, DisplayName)
    Response.Write("<tr><td>" & DisplayName & ":</td><td><input name=""" & InputName & """ type=""text"" maxlength=""100""/></td></tr>")
End Sub
%>