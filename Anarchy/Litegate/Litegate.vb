Imports Extension = System.Runtime.CompilerServices.ExtensionAttribute
Imports Method = System.Runtime.CompilerServices.MethodImplAttribute

Imports Op = System.Reflection.Emit.OpCodes

Namespace Anarchy
    Public Module LitegateExtensions

        <Extension, Method(Inline)>
        Public Function Address(Method As System.Delegate) As Litegate
            Dim N2 = System.IntPtr.Size * 2
            Dim MethodAddress(1) As System.IntPtr
            Method.ByClass(N2).Copy(MethodAddress.ByArray, N2)

            Return If(MethodAddress(1) = Nothing, MethodAddress(0), MethodAddress(1)).As(Of Litegate)()
        End Function

        'Preset invoker
#Region "Function"
        <Extension, Method(External)>
        Public Function Invoke(Of R)(MethodPtr As Litegate) As R
            Return Nothing
        End Function
        <Extension, Method(External)>
        Public Function Invoke(Of T, R)(MethodPtr As Litegate, This As T) As R
            Return Nothing
        End Function
        <Extension, Method(External)>
        Public Function Invoke(Of T, T2, R)(MethodPtr As Litegate, This As T, Arg2 As T2) As R
            Return Nothing
        End Function
        <Extension, Method(External)>
        Public Function Invoke(Of T, T2, T3, R)(MethodPtr As Litegate, This As T, Arg2 As T2, Arg3 As T3) As R
            Return Nothing
        End Function
        <Extension, Method(External)>
        Public Function Invoke(Of T, T2, T3, T4, R)(MethodPtr As Litegate, This As T, Arg2 As T2, Arg3 As T3, Arg4 As T4) As R
            Return Nothing
        End Function
        <Extension, Method(External)>
        Public Function Invoke(Of T, T2, T3, T4, T5, R)(MethodPtr As Litegate, This As T, Arg2 As T2, Arg3 As T3, Arg4 As T4, Arg5 As T5) As R
            Return Nothing
        End Function
        <Extension, Method(External)>
        Public Function Invoke(Of T, T2, T3, T4, T5, T6, R)(MethodPtr As Litegate, This As T, Arg2 As T2, Arg3 As T3, Arg4 As T4, Arg5 As T5, Arg6 As T6) As R
            Return Nothing
        End Function
        <Extension, Method(External)>
        Public Function Invoke(Of T, T2, T3, T4, T5, T6, T7, R)(MethodPtr As Litegate, This As T, Arg2 As T2, Arg3 As T3, Arg4 As T4, Arg5 As T5, Arg6 As T6, Arg7 As T7) As R
            Return Nothing
        End Function
        <Extension, Method(External)>
        Public Function Invoke(Of T, T2, T3, T4, T5, T6, T7, T8, R)(MethodPtr As Litegate, This As T, Arg2 As T2, Arg3 As T3, Arg4 As T4, Arg5 As T5, Arg6 As T6, Arg7 As T7, Arg8 As T8) As R
            Return Nothing
        End Function
#End Region

#Region "Sub"
        <Extension, Method(External)>
        Public Sub Invoke(MethodPtr As Litegate)
        End Sub
        <Extension, Method(External)>
        Public Sub Invoke(Of T)(MethodPtr As Litegate, This As T)
        End Sub
        <Extension, Method(External)>
        Public Sub Invoke(Of T, T2)(MethodPtr As Litegate, This As T, Arg2 As T2)
        End Sub
        <Extension, Method(External)>
        Public Sub Invoke(Of T, T2, T3)(MethodPtr As Litegate, This As T, Arg2 As T2, Arg3 As T3)
        End Sub
        <Extension, Method(External)>
        Public Sub Invoke(Of T, T2, T3, T4)(MethodPtr As Litegate, This As T, Arg2 As T2, Arg3 As T3, Arg4 As T4)
        End Sub
        <Extension, Method(External)>
        Public Sub Invoke(Of T, T2, T3, T4, T5)(MethodPtr As Litegate, This As T, Arg2 As T2, Arg3 As T3, Arg4 As T4, Arg5 As T5)
        End Sub
        <Extension, Method(External)>
        Public Sub Invoke(Of T, T2, T3, T4, T5, T6)(MethodPtr As Litegate, This As T, Arg2 As T2, Arg3 As T3, Arg4 As T4, Arg5 As T5, Arg6 As T6)
        End Sub
        <Extension, Method(External)>
        Public Sub Invoke(Of T, T2, T3, T4, T5, T6, T7)(MethodPtr As Litegate, This As T, Arg2 As T2, Arg3 As T3, Arg4 As T4, Arg5 As T5, Arg6 As T6, Arg7 As T7)
        End Sub
        <Extension, Method(External)>
        Public Sub Invoke(Of T, T2, T3, T4, T5, T6, T7, T8)(MethodPtr As Litegate, This As T, Arg2 As T2, Arg3 As T3, Arg4 As T4, Arg5 As T5, Arg6 As T6, Arg7 As T7, Arg8 As T8)
        End Sub
#End Region

    End Module

    'Prevent anyone confuse between number and 
    Public Structure Litegate
        <System.Security.SecurityCritical>
        Friend ReadOnly Address As System.IntPtr
    End Structure
End Namespace