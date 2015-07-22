Imports Extension = System.Runtime.CompilerServices.ExtensionAttribute
Imports Method = System.Runtime.CompilerServices.MethodImplAttribute
Imports Browns = System.ComponentModel.EditorBrowsableAttribute

Imports Int = System.IntPtr
Imports UInt = System.UIntPtr

Namespace Anarchy
    Public Module Calculate
#Region "Natvie Int"
        <Extension, Method(External)>
        Public Function Add(A As Int, B As Int) As Int
        End Function

        <Extension, Method(External)>
        Public Function [Sub](A As Int, B As Int) As Int
        End Function

        <Extension, Method(External)>
        Public Function Mul(A As Int, B As Int) As Int
        End Function

        <Extension, Method(External)>
        Public Function Div(A As Int, B As Int) As Int
        End Function

        <Extension, Method(External)>
        Public Function [Rem](A As Int, B As Int) As Int
        End Function

        <Extension, Method(External)>
        Public Function Add(A As Int, B As UInt) As Int
        End Function

        <Extension, Method(External)>
        Public Function [Sub](A As Int, B As UInt) As Int
        End Function

        <Extension, Method(External)>
        Public Function Mul(A As Int, B As UInt) As Int
        End Function

        <Extension, Method(External)>
        Public Function Div(A As Int, B As UInt) As Int
        End Function

        <Extension, Method(External)>
        Public Function [Rem](A As Int, B As UInt) As Int
        End Function
#End Region

#Region "Natvie UInt"
        <Extension, Method(External)>
        Public Function Add(A As UInt, B As UInt) As UInt
        End Function

        <Extension, Method(External)>
        Public Function [Sub](A As UInt, B As UInt) As UInt
        End Function

        <Extension, Method(External)>
        Public Function Mul(A As UInt, B As UInt) As UInt
        End Function

        <Extension, Method(External)>
        Public Function Div(A As UInt, B As UInt) As UInt
        End Function

        <Extension, Method(External)>
        Public Function [Rem](A As UInt, B As UInt) As UInt
        End Function

        <Extension, Method(External)>
        Public Function Add(A As UInt, B As Int) As UInt
        End Function

        <Extension, Method(External)>
        Public Function [Sub](A As UInt, B As Int) As UInt
        End Function

        <Extension, Method(External)>
        Public Function Mul(A As UInt, B As Int) As UInt
        End Function

        <Extension, Method(External)>
        Public Function Div(A As UInt, B As Int) As UInt
        End Function

        <Extension, Method(External)>
        Public Function [Rem](A As UInt, B As Int) As UInt
        End Function
#End Region
    End Module
End Namespace