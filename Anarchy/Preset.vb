Imports Extension = System.Runtime.CompilerServices.ExtensionAttribute
Imports Method = System.Runtime.CompilerServices.MethodImplAttribute

Namespace Anarchy
    Friend Module Preset
        Friend Const Inline As System.Runtime.CompilerServices.MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining
        Friend Const External As System.Runtime.CompilerServices.MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions.ForwardRef

        <Extension, Method(Inline)>
        Friend Sub WriteLine(Of T)(Input As T)
            System.Console.WriteLine(Input)
        End Sub
    End Module
End Namespace
