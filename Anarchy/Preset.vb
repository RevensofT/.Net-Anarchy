Imports Extension = System.Runtime.CompilerServices.ExtensionAttribute
Imports Method = System.Runtime.CompilerServices.MethodImplAttribute

Namespace Anarchy
    Public Module Preset
        Public Const Inline As System.Runtime.CompilerServices.MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining
        Public Const External As System.Runtime.CompilerServices.MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions.ForwardRef

        <Extension, Method(Inline)>
        Public Function This(Of T)(Input As T) As T
            Return Input
        End Function
    End Module
End Namespace
