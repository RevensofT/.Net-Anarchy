Imports Extension = System.Runtime.CompilerServices.ExtensionAttribute
Imports Method = System.Runtime.CompilerServices.MethodImplAttribute
Imports Browns = System.ComponentModel.EditorBrowsableAttribute

Imports Int = System.IntPtr
Imports Uint = System.UIntPtr

Imports mws = Microsoft.Win32.SafeHandles

Namespace Anarchy.Assist
    Public Module NativeSteam
        <Extension, Method(Inline)>
        Public Function OpenFile(Address As String,
                            FileAccess As System.IO.FileAccess,
                             ShareMode As System.IO.FileShare,
                             FileMode As System.IO.FileMode,
                             FileOption As System.IO.FileOptions) As mws.SafeFileHandle

            Return Native.File.Open(Address, FileAccess, ShareMode, New Native.SECURITY_ATTRIBUTES, FileMode, FileOption, Nothing)
        End Function

        <Extension, Method(Inline)>
        Public Function OpenRead(Address As String) As mws.SafeFileHandle
            Return Native.File.Open(Address, System.IO.FileAccess.Read, System.IO.FileShare.None, New Native.SECURITY_ATTRIBUTES, System.IO.FileMode.Open, System.IO.FileOptions.None, Nothing)
        End Function

        <Extension, Method(Inline)>
        Public Function OpenWrite(Address As String, Mode As System.IO.FileMode) As mws.SafeFileHandle
            Return Native.File.Open(Address, System.IO.FileAccess.Write, System.IO.FileShare.None, New Native.SECURITY_ATTRIBUTES, Mode, System.IO.FileOptions.None, Nothing)
        End Function

        '''<param name="MoveValue">Positeve for move forward and negative for move backward.</param>
        <Extension, Method(Inline)>
        Public Function Seek(Steam As mws.SafeFileHandle, MoveValue As Long, origin As System.IO.SeekOrigin) As Long
            Native.File.Seek(Steam, MoveValue, Seek, origin)
        End Function

        <Extension, Method(Inline)>
        Public Function Position(Steam As mws.SafeFileHandle) As Long
            Native.File.Seek(Steam, 0, Position, System.IO.SeekOrigin.Current)
        End Function

        <Extension, Method(Inline)>
        Public Function ReadTo(Steam As mws.SafeFileHandle, Container As Pointer, Length As UInteger) As UInteger
            Native.File.Read(Steam, Container, Length, ReadTo, Nothing)
        End Function

        <Extension, Method(Inline)>
        Public Function WriteFrom(Steam As mws.SafeFileHandle, Container As Pointer, Length As UInteger) As UInteger
            Native.File.Write(Steam, Container, Length, WriteFrom, Nothing)
        End Function

        <Extension, Method(Inline)>
        Public Function Size(Steam As mws.SafeFileHandle) As ULong
            Native.File.Size(Steam, Size)
        End Function

    End Module

    Public Module Stream
        <Extension, Method(Inline)>
        Public Sub WriteTo(Of T As Structure)(Input As T, Target As System.IO.Stream)
            Dim Size = Anarchy.Size(Of T)()
            Dim Tmp(Size - 1) As Byte
            Input.RawCopyTo(Tmp(0), Size)

            Target.Write(Tmp, 0, Size)
        End Sub

        '''<summary>Directly write data from an array, [an array length x structure size must lower then max integer]</summary>
        <Extension, Method(Inline)>
        Public Sub WriteTo(Of T As Structure)(Input As T(), Target As System.IO.Stream)
            Dim Size As Integer = CInt(Anarchy.Size(Of T)()) * (Input.Length - 1)
            Dim Tmp(Size - 1) As Byte

            Target.Write(Tmp, 0, Size)
        End Sub

        <Extension, Method(Inline)>
        Public Function ReadTo(Of T As Structure)(Target As System.IO.Stream) As T
            Dim Size = Anarchy.Size(Of T)()
            Dim Tmp(Size - 1) As Byte

            Target.Read(Tmp, 0, Size)
            ReadTo = New T
            Tmp(0).RawCopyTo(ReadTo, Size)
        End Function

        '''<summary>Directly read data to an array, [an array length x structure size must lower then max integer]</summary>
        <Extension, Method(Inline)>
        Public Function ReadTo(Of T As Structure)(Target As System.IO.Stream, Length As Integer) As T()
            Dim Size = CInt(Anarchy.Size(Of T)()) * Length
            Dim Tmp = Size.Array(Of Byte)()
            Target.Read(Tmp, 0, Size)

            Return Tmp.CArray(Of T)()
        End Function

        '''<summary>Directly read data to an array, [an array lenght x structure size must lower then max integer]</summary>
        <Extension, Method(Inline)>
        Public Sub ReadTo(Of T As Structure)(Target As System.IO.Stream, Output As T(), Optional Index As Integer = 0)
            Dim Size = CInt(Anarchy.Size(Of T)()) * Output.Length

            Dim Ori = Output
            Dim Tmp = Ori.CArray(Of Byte)()

            Target.Read(Tmp, Index, Size)
            Tmp.CArray(Of T)()
        End Sub
    End Module
End Namespace