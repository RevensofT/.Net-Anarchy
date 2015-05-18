Imports Anarchy

Module Module1

    Sub Main()
        Dim Ex = New Byte() {1, 1, 2, 2}
        Call (256).CopyTo(Ex)
        SizeAndConvert()
        Litegate()

        Console.ReadLine()
    End Sub

    Sub SizeAndConvert()
        Dim Format = " R:{0}, G:{1}, B:{2}"

        MainLine.WriteLine()
        Call "' Test get ref type size and convert between them.".WriteLine()
        SubLine.WriteLine()
        Call "".WriteLine()

        With New RefColor With {.R = 200, .G = 100, .B = 50}
            'Get size of reference type.
            Console.WriteLine("Size of ref color type::" & .Size(.B).ToString)

            'Copy all value from reference type into value type by size of value type.
            Dim VColor As New ValColor
            .CopyTo(VColor)

            'Change value of ref type, prevent confusion.
            .R = 255
            .B = 125

            'View data of reference type.
            String.Format("Ref type Color =" & Format, .R, .G, .B).WriteLine()

            With VColor
                'View data of value type.
                String.Format("Val type Color =" & Format, .R, .G, .B).WriteLine()
            End With

            'Create new ref type and copy value from value type.
            Dim NColor As New RefColor
            VColor.CopyTo(NColor)
            With NColor
                'View data of reference type
                String.Format("New ref Color =" & Format, .R, .G, .B).WriteLine()
            End With
        End With

        MainLine.WriteLine()
        Call "".WriteLine()
    End Sub

    Sub Litegate()
        MainLine.WriteLine()
        Call "' Test litegate".WriteLine()
        SubLine.WriteLine()

        Dim Base As New Calculus With {.A = 12, .B = 4}

        Dim Methods = {New System.Func(Of Integer)(AddressOf Base.Add).Address,
                       New System.Func(Of Integer)(AddressOf Base.Sub).Address,
                       New System.Func(Of Integer)(AddressOf Base.Mul).Address,
                       New System.Func(Of Integer)(AddressOf Base.Div).Address}

        Dim Operators = {"+", "-", "*", "\"}
        Dim Report = New System.Action(Of String)(AddressOf Base.Report).Address

        For Each Item In {Base,
                          New Point3D With {.X = 9, .Y = 8, .Z = 7},
                          New Dimenstion With {.Height = 60, .Width = 40}}
            For i = 0 To 3
                'Auto set generic type for no return method.
                Report.Invoke(Item, Operators(i))

                'For function, request to specify type of this object and argumets.
                Methods(i).Invoke(Of Object, Integer)(Item).WriteLine()
            Next
            Call "".WriteLine()
        Next
        MainLine.WriteLine()
        Call "".WriteLine()
    End Sub

End Module


Public Class RefColor
    Public R, G, B As Byte
End Class

Public Structure ValColor
    Public R, G, B As Byte
End Structure

Public Class Calculus
    Public A, B As Integer

    Public Function Add() As Integer
        Return A + B
    End Function

    Public Function [Sub]() As Integer
        Return A + B
    End Function

    Public Function Mul() As Integer
        Return A * B
    End Function

    Public Function Div() As Integer
        Return A \ B
    End Function

    Public Sub Report([Operator] As String)
        Call String.Format("Result of {0} {2} {1} = ", A, B, [Operator]).Write()
    End Sub
End Class

Public Class Point3D
    Public X, Y, Z As Integer
End Class

Public Class Dimenstion
    Public Height, Width As Integer
End Class
