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
Const COLUMN_IS_PLAYER_SELECTABLE = "IsPlayerSelectable"
Const COLUMN_CARD_TYPE_EFFECT_ID = "CardTypeEffectId"
Const COLUMN_CARD_TYPE_STATISTIC_REQUIREMENT_ID = "CardTypeStatisticRequirementId"
Const COLUMN_EFFECT_TYPE_STATISTIC_DELTA_ID = "EffectTypeStatisticDeltaId"
Const COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID = "EffectTypeCardTypeGeneratorId"
Const COLUMN_CHARACTER_STATISTIC_ID = "CharacterStatisticId"
Const COLUMN_SELF_DESTRUCT = "SelfDestruct"
Const COLUMN_EFFECT_TYPE_LOCATION_ID = "EffectTypeLocationId"
Const COLUMN_EFFECT_TYPE_STATISTIC_REQUIREMENT_ID = "EffectTypeStatisticRequirementId"
Const COLUMN_CARD_LIMIT = "CardLimit"
Const COLUMN_CHARACTER_TYPE_CARD_ID = "CharacterTypeCardId"
Const COLUMN_CARD_QUANTITY = "CardQuantity"
Const COLUMN_ALWAYS_AVAILABLE = "AlwaysAvailable"
Const COLUMN_REFRESH_HAND = "RefreshHand"

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
Const TABLE_CARD_TYPE_EFFECTS = "CardTypeEffects"
Const TABLE_CARD_TYPE_STATISTIC_REQUIREMENTS = "CardTypeStatisticRequirements"
Const TABLE_EFFECT_TYPE_STATISTIC_DELTAS = "EffectTypeStatisticDeltas"
Const TABLE_EFFECT_TYPE_CARD_TYPE_GENERATORS = "EffectTypeCardTypeGenerators"
Const TABLE_CHARACTER_STATISTICS = "CharacterStatistics"
Const TABLE_EFFECT_TYPE_LOCATIONS = "EffectTypeLocations"
Const TABLE_EFFECT_TYPE_STATISTIC_REQUIREMENTS = "EffectTypeStatisticRequirements"
Const TABLE_CHARACTER_TYPE_CARDS = "CharacterTypeCards"

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
Const VIEW_CARD_TYPE_EFFECT_DETAILS = "CardTypeEffectDetails"
Const VIEW_CARD_TYPE_STATISTIC_REQUIREMENT_DETAILS = "CardTypeStatisticRequirementDetails"
Const VIEW_CARD_TYPE_AVAILABLE_REQUIREMENT_STATISTIC_TYPES = "CardTypeAvailableRequirementStatisticTypes"
Const VIEW_EFFECT_TYPE_STATISTIC_DELTA_DETAILS = "EffectTypeStatisticDeltaDetails"
Const VIEW_EFFECT_TYPE_AVAILABLE_DELTA_STATISTIC_TYPES = "EffectTypeAvailableDeltaStatisticTypes"
Const VIEW_EFFECT_TYPE_CARD_TYPE_GENERATOR_DETAILS = "EffectTypeCardTypeGeneratorDetails"
Const VIEW_EFFECT_TYPE_AVAILABLE_CARD_TYPE_GENERATORS = "EffectTypeAvailableCardTypeGenerators"
Const VIEW_CHARACTER_STATISTIC_DETAILS = "CharacterStatisticDetails"
Const VIEW_CHARACTER_AVAILABLE_STATISTIC_TYPES = "CharacterAvailableStatisticTypes"
Const VIEW_EFFECT_TYPE_LOCATION_DETAILS = "EffectTypeLocationDetails"
Const VIEW_EFFECT_TYPE_STATISTIC_REQUIREMENT_DETAILS = "EffectTypeStatisticRequirementDetails"
Const VIEW_EFFECT_TYPE_AVAILABLE_REQUIREMENT_STATISTIC_TYPES = "EffectTypeAvailableRequirementStatisticTypes"
Const VIEW_CHARACTER_TYPE_CARD_DETAILS = "CharacterTypeCardDetails"
Const VIEW_CHARACTER_TYPE_AVAILABLE_CARDS = "CharacterTypeAvailableCards"
Const VIEW_LOCATION_DETAILS = "LocationDetails"

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
            MakeSelectCommand.Parameters(index) = FilterValues(index)
        next
    end if
End Function

Function ExecuteSelectCommand(Conn, TableName, ShowColumns, FilterColumns, FilterValues)
    Dim cmd
    Set cmd = MakeSelectCommand(Conn, TableName, ShowColumns, FilterColumns, FilterValues)
    Set ExecuteSelectCommand = cmd.Execute()
    Set cmd = nothing
End Function

Function MakeFilteredEditComboBox(Conn, TableName, KeyColumnName, DisplayColumnName, FilterColumns, FilterValues, IsNullable)
    Dim result
    result="<select name=""" & KeyColumnName &  """>"
    If IsNullable Then
        result = result & "<option value="""">(none)</option>"
    End If
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


Function MakeEditComboBox(Conn, TableName, KeyColumnName, DisplayColumnName, KeyValue, IsNullable)
    Dim result
    result="<select name=""" & KeyColumnName &  """>"
    Dim cmd
    Set cmd = MakeSelectCommand(conn, TableName,Array(KeyColumnName,DisplayColumnName),Null,Null)
    If IsNullable Then
        result = result & "<option value="""""
        if isnull(keyvalue) then
            result = result & " selected=""selected"""
        end if
        result = result & ">(none)</option>"
    End If
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

Sub BackToEditLink(SubPath,Title,ColumnName,DataSource)
    Response.Write("<p><a href=""/" & SubPath & "/Edit.asp?" & ColumnName & "=" & DataSource(ColumnName) & """>Back To " & Title & "</a></p>")
End Sub

Sub BackToListLink(SubPath,Title)
    Response.Write("<p><a href=""/" & SubPath & "/List.asp"">Back To " & Title & " List</a></p>")
End Sub

Sub BackToMainMenuLink()
    Response.Write("<p><a href=""/default.asp"">Back to Main Menu</a></p>")
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

Sub StartTableRow()
    Response.Write("<tr>")
End Sub

Sub EndTableRow()
    Response.Write("</tr>")
End Sub

Sub StartTable()
    Response.Write("<table border=""1"">")
End Sub

Sub CheckboxInputAdd(InputName, DisplayName)
    Response.Write("<tr><td>" & DisplayName & ":</td><td><input name=""" & InputName & """ type=""checkbox"" value=""1""/></td></tr>")
End Sub

Sub CheckboxInputEdit(InputName, DisplayName, DataSource)
    Response.Write("<tr><td>" & DisplayName & ":</td><td><input name=""" & InputName & """ type=""checkbox"" value=""1""")
    Dim x
    x = DataSource(InputName)
    If DataSource(InputName) Then
        Response.Write(" checked=""checked""")
    End If
    Response.Write("/></td></tr>")
End Sub

Sub TextInputAdd(InputName, DisplayName)
    Response.Write("<tr><td>" & DisplayName & ":</td><td><input name=""" & InputName & """ type=""text"" maxlength=""100""/></td></tr>")
End Sub

Sub TextInputEdit(InputName, DisplayName, DataSource)
    Response.Write("<tr><td>" & DisplayName & ":</td><td><input name=""" & InputName & """ value=""" & DataSource(InputName) & """  type=""text"" maxlength=""100""/></td></tr>")
End Sub

Sub ReadonlyTextInput(InputName, DisplayName, DataSource)
    Response.Write("<tr><td>" & DisplayName & ":</td><td><input name=""" & InputName & """ value=""" & DataSource(InputName) & """ type=""text"" readonly=""readonly""/></td></tr>")
End Sub

Sub HiddenInput(InputName, DataSource)
    Response.Write("<input name=""" & InputName & """ value=""" & DataSource(InputName) & """ type=""hidden""/>")
End Sub

Sub StartPage()
    Server.Execute("/inc/Start.asp")
End Sub

Sub EndPage()
    Server.Execute("/inc/End.asp")
End Sub

Sub RedirectToList(SubPath)
    Response.Redirect("/" & SubPath & "/List.asp")
End Sub

Sub RedirectToEdit(SubPath,ColumnName,DataSource)
    Response.Redirect("/" & SubPath & "/Edit.asp?" & ColumnName & "=" & DataSource(ColumnName))
End Sub

Sub ConfirmDeleteCheckbox()
    Response.Write("<tr><td>Delete Record</td><td><input type=""checkbox"" name=""ConfirmDelete"" value=""1""/></td></tr>")
End Sub

Sub ShowTableHeaders(Headers)
    response.write("<tr>")
    Dim Header
    For Each Header in Headers
        response.write("<th>" & header & "</th>")
    Next
    response.write("</tr>")
End Sub

Sub TableCell(ColumnName,DataSource)
    Response.Write("<td>" & DataSource(ColumnName) & "</td>")
End Sub

Sub TableCellEditLink(SubPath, ColumnName, DataSource)
    Response.Write("<td><a href=""/" & SubPath & "/Edit.asp?" & ColumnName & "=" & DataSource(ColumnName) & """>" & DataSource(ColumnName) & "</a></td>")
End Sub

Sub AddLink(SubPath,LinkText)
    Response.Write("<p><a href=""/" & SubPath & "/Add.asp"">(" & LinkText & ")</a></p>")
End Sub

Sub FilterAddLink(SubPath,LinkText, FilterColumn, DataSource)
    Response.Write("<p><a href=""/" & SubPath & "/Add.asp?" & FilterColumn & "=" & DataSource(FilterColumn) & """>(" & LinkText & ")</a></p>")
End Sub

Sub ComboBoxAdd(InputName, DisplayName, Conn, TableName, OptionColumnName, IsNullable)
    Response.Write("<tr><td>" & DisplayName & ":</td><td>")
    Response.Write(MakeEditComboBox(Conn, TableName, InputName, OptionColumnName, Null, IsNullable))
    Response.Write("</td></tr>")
End Sub

Sub ComboBoxEdit(InputName, DisplayName, Conn, TableName, OptionColumnName, DataSource, IsNullable)
    Response.Write("<tr><td>" & DisplayName & ":</td><td>")
    Response.Write(MakeEditComboBox(Conn, TableName, InputName, OptionColumnName, DataSource(InputName),IsNullable))
    Response.Write("</td></tr>")
End Sub

Sub FilteredComboBoxAdd(InputName, DisplayName, Conn, TableName, OptionColumnName, FilterColumn, DataSource, IsNullable)
    Response.Write("<tr><td>" & DisplayName & ":</td><td>")
    Response.Write(MakeFilteredEditComboBox(Conn, TableName, InputName, OptionColumnName, Array(FilterColumn), Array(DataSource(FilterColumn)),IsNullable))
    Response.Write("</td></tr>")
End Sub

Function EmptyStringIsNull(ColumnName, DataSource)
    Dim result
    result = DataSource(ColumnName)
    if len(result)=0 then
        result = null
    end if
    EmptyStringIsNull = result
End Function

Function EmptyStringIsFalse(ColumnName, DataSource)
    Dim result
    result = DataSource(ColumnName)
    EmptyStringIsFalse = len(result)>0
End Function

Sub TableCellActionButton(axn)
    response.write("<td><input name=""axn"" type=""submit"" value=""" & axn & """/></td>")
End Sub
%>