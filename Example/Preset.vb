Imports Extension = System.Runtime.CompilerServices.ExtensionAttribute
Imports Method = System.Runtime.CompilerServices.MethodImplAttribute

Friend Module Preset
    Friend Const Inline As System.Runtime.CompilerServices.MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining
    Friend Const External As System.Runtime.CompilerServices.MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions.ForwardRef


    Friend Const MainLine As String = "'==================================================="
    Friend Const SubLine As String = "'---------------------------------------------------"

    <Extension, Method(Inline)>
    Friend Sub WriteLine(Of T)(Input As T)
        System.Console.WriteLine(Input)
    End Sub

    <Extension, Method(Inline)>
    Friend Sub Write(Of T)(Input As T)
        System.Console.Write(Input)
    End Sub

    <Extension, Method(Inline)>
    Friend Function This(Of T)(Input As T) As T
        Return Input
    End Function
End Module
