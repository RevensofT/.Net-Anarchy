Imports Method = System.Runtime.CompilerServices.MethodImplAttribute
Imports Extension = System.Runtime.CompilerServices.ExtensionAttribute

Imports Anarchy
Imports Anarchy.Assist

Module Module1
    Sub Main()
        '-----------------------------------------------
        'Anarchy.Assist.Stream 
        '-----------------------------------------------
        'For Each Item In {"Z:\Test.txt", "Z:\Test2.txt", "Z:\Test3.txt", "Z:\Test4.txt"}
        '    With Item.OpenRead
        '        Call "File Name : ".Write()
        '        Item.WriteLine()

        '        Dim Size As UInteger = .Size
        '        Call "File Size : ".Write()
        '        Size.WriteLine()

        '        Dim Tmp = Size.Array(Of Byte)()

        '        Call "File Read : ".Write()
        '        .ReadTo(Tmp.ByArray, Size).WriteLine()

        '        Call "File Data : ".Write()
        '        String.Join(",", Tmp).WriteLine()

        '        Call "".WriteLine()
        '        .Dispose()
        '    End With
        'Next

        '-----------------------------------------------
        ' Native example
        '-----------------------------------------------
        'Dim Address = "Z:\Test.txt"
        'Dim File = Native.File.Open(Address, IO.FileAccess.ReadWrite, IO.FileShare.None,
        '                                               New Native.File.SECURITY_ATTRIBUTES,
        '                                               IO.FileMode.OpenOrCreate, IO.FileOptions.None, Nothing)
        'Native.File.Read(File, Buff.ByArray, 2, Counter, 0)

        Dim Box(1) As Byte
        Call (258).RawCopyTo(Box(0), 2)
        String.Format("Raw bytes of 258 is [{0}]", String.Join(",", Box)).WriteLine()
        Call "".WriteLine()

        Call " Test get ref type size and convert between them.".ExampleFrom(AddressOf SizeAndConvert)
        Call " Test litegate".ExampleFrom(AddressOf Litegate)
        Call " Mutable string".ExampleFrom(AddressOf MutableString)

        Call " Let convert our object to other type.".ExampleFrom(AddressOf ConvertClass)
        Call " Let convert our array to other type.".ExampleFrom(AddressOf ConvertArray)

        Call " Reference pointer performance (don't run on Visual studio !)".ExampleFrom(AddressOf Reference_Pointer)

        Call SubLine.WriteLine()
        Call "Testing method from Anarchy.Assist namespace".WriteLine()
        Call SubLine.WriteLine()
        Call " Testing a Jinx box".ExampleFrom(AddressOf JinxBox)

        Console.ReadLine()
    End Sub

#Region "Testing method"
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

    Sub ConvertClass()
        Dim Math As New Add With {.X = 3, .Y = 5}

        Call ("Add 3 and 5 = " & Math.Process).WriteLine()
        Call ("Try to cast as mul type = " & Math.As(Of Mul).Process).WriteLine()
        Call ("Well, then convert as mul = " & Math.CClass(New Mul).Process).WriteLine()
        Call "But the variant that containt previous class will become nothing.".WriteLine()
        Call "So, variant is nothing = ".Write()
        Call (Math Is Nothing).WriteLine()
    End Sub

    Sub ConvertArray()
        Dim Base() As Byte = {0, 1, 0, 2}

        Call "Base array is type of ".Write()
        Base.ToString.WriteLine()
        Call "Member of base array is ".Write()
        String.Join(",", Base).WriteLine()

        Call "".WriteLine()

        Dim BeShort = Base.CArray(Of UShort)()
        Call "Convert to type ".Write()
        BeShort.ToString.WriteLine()
        Call "Member of convert array is ".Write()
        String.Join(",", BeShort).WriteLine()

        Call "".WriteLine()

        Call "Is base array variant become nothing ? ".Write()
        Call (Base Is Nothing).WriteLine()
    End Sub

    Sub JinxBox()
        Dim Jx As New Jinx(32)

        Call "Push value of int16, 256 into jinx box.".WriteLine()
        Jx.Push(256S)

        Call "Push value of int32, -1 into jinx box.".WriteLine()
        Jx.Push(-1)

        Call "Make a reference pointer of string for next item.".WriteLine()
        Dim JxR = Jx.Ref(Of String)()

        Call "Push string, 'Hello' into jinx box.".WriteLine()
        Jx.Push("Hello")

        Call "".WriteLine()

        Call "Load value from refence pointer of string".WriteLine()
        JxR.Value.WriteLine()

        Call "".WriteLine()

        Call "Let's pop all value from jinx box.".WriteLine()

        Jx.Pop(Of String).WriteLine()
        Jx.Pop(Of Integer).WriteLine()
        Jx.Pop(Of UShort).WriteLine()
    End Sub

    Sub Reference_Pointer()
        Dim CA As New Calculus
        Dim CAA = CA.A.ByRef

        Call "Method : Class.Member + = 1".WriteLine()
        Dim Time = Date.Now
        For i = 1 To 1000000000
            CA.A += 1
        Next
        Call (Date.Now - Time).WriteLine()

        Call "Loop count = ".Write()
        CA.A.WriteLine()

        Call "".WriteLine()

        Call "Method : ReferencePointer + = 1".WriteLine()
        CA.A = 0
        Time = Date.Now
        For i = 1 To 1000000000
            CAA.Value += 1
        Next

        Call (Date.Now - Time).WriteLine()
        Call "Loop count = ".Write()
        CAA.Value.WriteLine()
    End Sub
#End Region

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
End Module

#Region "Testing type"
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

#End Region