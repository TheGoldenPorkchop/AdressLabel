'Angel Nava
'Spring 2025
'RCET2265
'Address Label
'https://github.com/TheGoldenPorkchop/AdressLabel/tree/main
Option Strict On
Option Explicit On


Public Class AdressLabelForm
    Sub SetDefaults()
        FirstNameTextBox.Text = ""
        LastNameTextBox.Text = ""
        StreetAddressTextBox.Text = ""
        CityTextBox.Text = ""
        StateTextBox.Text = ""
        ZipTextBox.Text = ""

        FirstNameTextBox.Focus()
    End Sub

    Function FullName() As String
        Dim _fullName As String
        _fullName = FirstNameTextBox.Text & "" & LastNameTextBox.Text
        Return _fullName
    End Function

    Sub AddToLabel(thisString As String)
        DisplayLabel.Text = thisString
    End Sub

    Function UserInputIsValid() As Boolean
        Dim valid As Boolean = True
        Dim message As String = ""

        If ZipTextBox.Text = "" Then
            valid = False
            message &= "Zip Code is required" & vbNewLine
            ZipTextBox.Focus()
        End If

        If StateTextBox.Text = "" Then
            valid = False
            message &= "State is required" & vbNewLine
            StateTextBox.Focus()
        End If

        If CityTextBox.Text = "" Then
            valid = False
            message &= "City is required" & vbNewLine
            CityTextBox.Focus()
        End If
        If StreetAddressTextBox.Text = "" Then
            valid = False
            message &= "Street Address is required" & vbNewLine
            StreetAddressTextBox.Focus()
        End If

        If LastNameTextBox.Text = "" Then
            valid = False
            message &= "Last Name is required" & vbNewLine
            LastNameTextBox.Focus()
        End If
        If FirstNameTextBox.Text = "" Then
            valid = False
            message &= "First Name is required" & vbNewLine
            FirstNameTextBox.Focus()
        End If

        If valid = False Then
            MsgBox(message, MsgBoxStyle.Critical, "Empty Fields")
        End If
        Return valid
    End Function

    Private Sub DisplayButton_Click(sender As Object, e As EventArgs) Handles DisplayButton.Click
        Dim coolLabel As String
        Dim completeName As String

        completeName = FullName()
        If UserInputIsValid() Then
            coolLabel = completeName & vbNewLine _
            & StreetAddressTextBox.Text & vbNewLine _
            & CityTextBox.Text & ", " & StateTextBox.Text & " " & ZipTextBox.Text
            AddToLabel(coolLabel)
        End If

        SetDefaults()

    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        SetDefaults()
        AddToLabel("")
    End Sub
End Class
