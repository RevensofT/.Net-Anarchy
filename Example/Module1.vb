Imports Extension = System.Runtime.CompilerServices.ExtensionAttribute

Imports Anarchy


Public Structure Exteract
    Public Base, Target, Prt, Aux As IntPtr
End Structure

Module Module1

    Sub Main()
        Dim Box(1) As Byte
        Call (258).RawCopyTo(Box(0), 2)
        String.Format("Raw bytes of 258 is [{0}]", String.Join(",", Box)).WriteLine()
        Call "".WriteLine()

        Call "' Test get ref type size and convert between them.".ExampleFrom(AddressOf SizeAndConvert)
        Call "' Test litegate".ExampleFrom(AddressOf Litegate)
        Call "' Mutable string".ExampleFrom(AddressOf MutableString)

        Call "' Let disguise our object to other type.".ExampleFrom(AddressOf Disguise)

        Console.ReadLine()
    End Sub

    Sub MutableString()
        Dim Word = "My World"
        Word.WriteLine()

        '2 == char(uint16) type size
        Call "Our".ByArray.CopyTo(Word.ByArray, 2 * 3)
        Word.WriteLine()
    End Sub

    Sub SizeAndConvert()
        Dim Format = " R:{0}, G:{1}, B:{2}"

        With New RefColor With {.R = 200, .G = 100, .B = 50}
            'Get size of reference type.
            Console.WriteLine("Size of ref color type::" & .Size(.B).ToString)

            'Copy all value from reference type into value type by size of value type.
            Dim VColor As New ValColor
            .CopyTo(VColor)
            '.ByValClass.Copy(VColor.ByRef)

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
            'VColor.ByRef.Copy(NColor.ByValClass)

            With NColor
                'View data of reference type
                String.Format("New ref Color =" & Format, .R, .G, .B).WriteLine()
            End With
        End With

    End Sub

    Sub Litegate()
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
    End Sub

    <Extension>
    Sub ExampleFrom(Title As String, Method As Action)
        MainLine.WriteLine()
        Title.WriteLine()
        SubLine.WriteLine()

        Call "".WriteLine()
        Method()
        Call "".WriteLine()

        MainLine.WriteLine()
        Call "".WriteLine()
    End Sub

    Sub Disguise()
        Dim Math As New Add With {.X = 3, .Y = 5}

        Call ("Add 3 and 5 = " & Math.Process).WriteLine()
        Call ("Try to cast as mul type = " & Math.As(Of Mul).Process).WriteLine()
        Math.DisguiseAs(New Mul)
        Call ("Well, then disguise as mul = " & Math.Process).WriteLine()
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
        Return A - B
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


Public Class Add
    Public X, Y As Integer
    Public Overridable Function Process() As Integer
        Return X + Y
    End Function
End Class

Public Class Mul
    Inherits Add
    Public Overrides Function Process() As Integer
        Return X * Y
    End Function
End Class