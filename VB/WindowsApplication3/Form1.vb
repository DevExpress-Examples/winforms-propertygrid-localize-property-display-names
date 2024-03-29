Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading
Imports DevExpress.XtraEditors

Namespace DXSample

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            radioGroup1.SelectedIndex = 2
        End Sub

        Private Shared Function CreateProduct() As Product
            Dim pr As Product = New Product("123-12-23", "Orange", "Fruit", 12, 100)
            Return pr
        End Function

        Private Sub radioGroup1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim radioGroup As RadioGroup = TryCast(sender, RadioGroup)
            Dim cultureName As String = radioGroup.EditValue.ToString()
            SetCulture(cultureName)
            propertyGridControl1.SelectedObject = Nothing
            propertyGridControl1.Rows.Clear()
            propertyGridControl1.SelectedObject = CreateProduct()
        End Sub

        Private Shared Sub SetCulture(ByVal cultureName As String)
            Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo(cultureName)
            Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo(cultureName)
        End Sub
    End Class

    Public Class Product

        Private productCodeField, nameField, categoryField As String

        Private priceField As Decimal

        Private quantityField As Integer

        Public Sub New(ByVal code As String, ByVal name As String, ByVal category As String, ByVal price As Decimal, ByVal quantity As Integer)
            productCodeField = code
            nameField = name
            categoryField = category
            priceField = price
            quantityField = quantity
        End Sub

        <CustomDisplayNameAttribute("ProductCode")>
        Public Property ProductCode As String
            Get
                Return productCodeField
            End Get

            Set(ByVal value As String)
                productCodeField = value
            End Set
        End Property

        <CustomDisplayNameAttribute("Name")>
        Public Property Name As String
            Get
                Return nameField
            End Get

            Set(ByVal value As String)
                nameField = value
            End Set
        End Property

        <CustomDisplayNameAttribute("Category")>
        Public Property Category As String
            Get
                Return categoryField
            End Get

            Set(ByVal value As String)
                categoryField = value
            End Set
        End Property

        <CustomDisplayNameAttribute("Price")>
        Public Property Price As Decimal
            Get
                Return priceField
            End Get

            Set(ByVal value As Decimal)
                priceField = value
            End Set
        End Property

        <CustomDisplayNameAttribute("Quantity")>
        Public Property Quantity As Integer
            Get
                Return quantityField
            End Get

            Set(ByVal value As Integer)
                quantityField = value
            End Set
        End Property
    End Class

    Public Class CustomDisplayNameAttribute
        Inherits DisplayNameAttribute

        Public Sub New(ByVal displayName As String)
            MyBase.New(displayName)
        End Sub

        Public Overrides ReadOnly Property DisplayName As String
            Get
                Return GetLocalizedString(MyBase.DisplayName)
            End Get
        End Property
    End Class

    Public Module CustomLocalizer

        Public Function GetLocalizedString(ByVal name As String) As String
            If Equals(Thread.CurrentThread.CurrentCulture.Name, "fr-FR") Then
                If Equals(name, "ProductCode") Then Return "Produit Code"
                If Equals(name, "Name") Then Return "Nom"
                If Equals(name, "Category") Then Return "Catégorie"
                If Equals(name, "Price") Then Return "Prix"
                If Equals(name, "Quantity") Then Return "Quantité"
            ElseIf Equals(Thread.CurrentThread.CurrentCulture.Name, "de-DE") Then
                If Equals(name, "ProductCode") Then Return "Produkt Code"
                If Equals(name, "Name") Then Return "Name"
                If Equals(name, "Category") Then Return "Kategorie"
                If Equals(name, "Price") Then Return "Preis"
                If Equals(name, "Quantity") Then Return "Zahl"
            End If

            Return name
        End Function
    End Module
End Namespace
