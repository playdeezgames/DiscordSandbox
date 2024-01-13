﻿Imports SPLORR.Data

Friend Class CharacterModel
    Implements ICharacterModel

    Private ReadOnly store As ICharacterStore
    Sub New(characterStore As ICharacterStore)
        store = characterStore
    End Sub
    Public Property Name As String Implements ICharacterModel.Name
        Get
            Return store.Name
        End Get
        Set(value As String)
            store.Name = value
        End Set
    End Property
    Public Property Location As ILocationModel Implements ICharacterModel.Location
        Get
            Return New LocationModel(store.Location)
        End Get
        Set(value As ILocationModel)
            store.SetLocation(value.LocationStore, DateTimeOffset.Now)
        End Set
    End Property

    Public ReadOnly Property HasOtherCharacters As Boolean Implements ICharacterModel.HasOtherCharacters
        Get
            Return store.HasOtherCharacters
        End Get
    End Property

    Public ReadOnly Property OtherCharacters As IEnumerable(Of ICharacterModel) Implements ICharacterModel.OtherCharacters
        Get
            Return store.OtherCharacters.Select(Function(x) New CharacterModel(x))
        End Get
    End Property

    Public ReadOnly Property Inventory As IInventoryModel Implements ICharacterModel.Inventory
        Get
            Return New InventoryModel(store)
        End Get
    End Property

    Public Function UseRoute(route As IRouteModel) As (Result As Boolean, Messages As String()) Implements ICharacterModel.UseRoute
        If route Is Nothing Then
            Return (False, {"The route does not exist!"})
        End If
        If Not route.FromLocation.IsSameAs(Location) Then
            Return (False, {"The route is not available!"})
        End If
        Location = route.ToLocation
        Return (True, Array.Empty(Of String))
    End Function

    Public Function FindRecipeByName(recipeName As String) As IRecipeModel Implements ICharacterModel.FindRecipeByName
        Dim recipe = store.Store.Recipes.Filter(recipeName).FirstOrDefault
        If recipe Is Nothing Then
            Return Nothing
        End If
        Return New RecipeModel(recipe)
    End Function

    Public Function CanCraft(recipe As IRecipeModel) As Boolean Implements ICharacterModel.CanCraft
        Dim inputs As IEnumerable(Of (Quantity As Integer, ItemType As IItemTypeStore)) = recipe.Store.Inputs
        Return inputs.All(Function(x) store.Inventory.ItemTypeCount(x.ItemType) >= x.Quantity)
    End Function

    Public Function Craft(recipe As IRecipeModel) As IEnumerable(Of (Quantity As Integer, ItemType As IItemTypeModel)) Implements ICharacterModel.Craft
        If Not CanCraft(recipe) Then
            Return Array.Empty(Of (Quantity As Integer, Item As IItemTypeModel))
        End If
        Dim inputs As IEnumerable(Of (Quantity As Integer, ItemType As IItemTypeStore)) = recipe.Store.Inputs
        Dim outputs As IEnumerable(Of (Quantity As Integer, ItemType As IItemTypeStore)) = recipe.Store.Outputs
        Dim deltas As New Dictionary(Of IItemTypeStore, Integer)
        For Each itemOut In outputs
            deltas(itemOut.ItemType) = itemOut.Quantity
        Next
        For Each itemIn In inputs
            Dim itemType = itemIn.ItemType
            If Not deltas.ContainsKey(itemType) Then
                deltas(itemType) = 0
            End If
            deltas(itemType) -= itemIn.Quantity
        Next
        For Each entry In deltas
            Dim removeCount = -Math.Min(entry.Value, 0)
            Dim createCount = Math.Max(entry.Value, 0)
            For Each dummy In Enumerable.Range(1, createCount)
                entry.Key.CreateItem(store.Inventory)
            Next
            Dim items As IEnumerable(Of IItemStore) = store.Inventory.ItemsByType(entry.Key).Take(removeCount)
            For Each item In items
                item.Delete()
            Next
        Next
        Return deltas.Select(Function(x)
                                 Dim result As (Quantity As Integer, ItemType As IItemTypeModel) = (x.Value, New ItemTypeModel(x.Key))
                                 Return result
                             End Function)
    End Function
End Class
