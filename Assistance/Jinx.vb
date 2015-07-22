Imports Extension = System.Runtime.CompilerServices.ExtensionAttribute
Imports Method = System.Runtime.CompilerServices.MethodImplAttribute
Imports Browns = System.ComponentModel.EditorBrowsableAttribute

Imports Int = System.IntPtr
Imports Uint = System.UIntPtr

Imports mws = Microsoft.Win32.SafeHandles

Namespace Anarchy.Assist
    '''<summary>Ultimate container that can containt multi type of data.</summary>
    Public Structure Jinx
        Private ReadOnly Data() As Byte
        Public Pos As Int

        '''<param name="Capacity">Size of Jinx in bytes.</param>
        <Method(Inline)>
        Public Sub New(Capacity As Int)
            Data = Capacity.Array(Of Byte)()
        End Sub

        <Method(Inline)>
        Public Sub Push(Of T)(Input As T)
            Dim Size = Anarchy.Size(Of T)()
            Input.RawCopyTo(Data(Pos), Size)
            Pos += Size
        End Sub

        <Method(Inline)>
        Public Sub Push(Input As Pointer, Length As Uint)
            Input.CopyTo(Data(Pos).ByRef, Length)
            Pos += Length
        End Sub

        <Method(Inline)>
        Public Sub Push(Of T)(Input As RefPointer(Of T))
            Dim Size = Anarchy.Size(Of T)()
            Input.As(Of Pointer).CopyTo(Data(Pos).ByRef, Size)
            Pos += Size
        End Sub

        '''<summary>move postion to backward and load object.</summary>
        <Method(Inline)>
        Public Function Pop(Of T)() As T
            Dim Size = Anarchy.Size(Of T)()
            Pos -= Size
            Data(Pos).RawCopyTo(Pop, Size)
        End Function
        '''<summary>Load object from current postion and move postion to forward.</summary>
        <Method(Inline)>
        Public Function [Next](Of T)() As T
            Dim Size = Anarchy.Size(Of T)()
            Data(Pos).RawCopyTo([Next], Size)
            Pos += Size
        End Function

        '''<summary>Create a reference pointer from current position.</summary>
        <Method(Inline)>
        Public Function Ref(Of T)() As Anarchy.RefPointer(Of T)
            Return Data(Pos).ByRef.As(Of Anarchy.RefPointer(Of T))()
        End Function

        '''<summary>Load object from current postion without change position.</summary>
        Public Function Peek(Of T)() As T
            Dim Size = Anarchy.Size(Of T)()
            Data(Pos - Size).RawCopyTo(Peek, Size)
        End Function

    End Structure

End Namespace