Imports Extension = System.Runtime.CompilerServices.ExtensionAttribute
Imports Method = System.Runtime.CompilerServices.MethodImplAttribute
Imports Browns = System.ComponentModel.EditorBrowsableAttribute

Namespace Anarchy

    Public Module Common
        '''<summary>Get size of reference type, request an object for calculate.</summary>
        <Extension, Method(External)>
        Public Function Size(Of T As Class, V)(Host As T, ByRef LastField As V) As System.UIntPtr
            Return 0
        End Function

        '''<summary>Get size of value type.</summary>
        <Extension, Method(External)>
        Public Function Size(Of T As Structure)(Host As T) As System.UIntPtr
            Return 0
        End Function

        '''<summary>Get type token.</summary>
        <Method(External)>
        Public Function Token(Of T)() As System.IntPtr
        End Function
    End Module

    Public Module Indirect
        '''<summary>Get a reference pointer.</summary>
        <Extension, Method(External)>
        Public Function [ByRef](Of T)(ByRef Input As T) As Pointer
        End Function

        '''<summary>Get a pointer.</summary>
        <Extension, Method(External), Browns(1)>
        Public Function [ByVal](Of T As Class)(Input As T) As Pointer
        End Function

        '''<summary>Get a reference pointer.</summary>
        '''<param name="ShiftPointerTo">Move pointer from current position; value is byte type</param>
        <Extension, Method(External)>
        Public Function [ByRef](Of T)(ByRef Input As T, ShiftPointerTo As System.IntPtr) As Pointer
        End Function
        '''<summary>Get a pointer.</summary>
        '''<param name="ShiftPointerTo">Move pointer from current position; value is byte type</param>
        <Extension, Method(External), Browns(1)>
        Public Function [ByVal](Of T As Class)(Input As T, ShiftPointerTo As System.IntPtr) As Pointer
        End Function

        '''<summary>Get a pointer of first field of class.</summary>
        '''<param name="ShiftPointerTo">Move pointer from current position; value is byte type</param>
        <Extension, Method(Inline)>
        Public Function ByClass(Of T As Class)(Input As T, Optional ShiftPointerTo As System.IntPtr = Nothing) As Pointer
            Return Input.ByVal(System.IntPtr.Size + ShiftPointerTo)
        End Function
        '''<summary>Get a pointer of first index of any array alike type.</summary>
        '''<param name="ShiftPointerTo">Move pointer from current position; value is byte type</param>
        <Extension, Method(Inline)>
        Public Function ByArray(Of T As Class)(Input As T, Optional ShiftPointerTo As System.IntPtr = Nothing) As Pointer
            Return Input.ByVal(System.IntPtr.Size + System.IntPtr.Size + ShiftPointerTo)
        End Function

        '''<summary>Shift pointer from current position.</summary>
        <Extension, Method(External)>
        Public Function Shift(Pointer As Pointer, Postion As System.IntPtr) As Pointer
        End Function
    End Module

    Public Module Convert
        '''<summary>Unsafe direct cast type, use it only when you know what're you doing.</summary>
        <Extension, Method(External)>
        Public Function [As](Of T As Class, V As Class)(Input As T) As V
            Return Nothing
        End Function

        '''<summary>Unsafe direct cast type, use it only when you know what're you doing.</summary>
        <Extension, Method(External)>
        Public Function [As](Of T As Structure, V As Structure)(Input As V) As T
        End Function

        '''<summary>Unsafe direct cast type, use it only when you know what're you doing.</summary>
        <Extension, Method(External)>
        Public Function [As](Of T As Class)(Input As Pointer) As T
            Return Nothing
        End Function

        '''<summary>Unsafe direct cast type, use it only when you know what're you doing.</summary>
        <Extension, Method(External)>
        Public Function [To](Of T As Structure)(Input As Pointer) As T
        End Function
        '===================================
        'Unsupport, hard to design for user to use it without errors.
        '-----------------------------------
        <Extension, Method(Inline)>
        Public Function [As](Of T, V)(Input() As V) As T
            Throw New System.Exception("Unsupport.")
            Return Nothing
        End Function
        <Extension, Method(Inline)>
        Public Function [As](Of T)(Input As Object) As T()
            Throw New System.Exception("Unsupport.")
            Return Nothing
        End Function
        <Extension, Method(Inline)>
        Public Function [As](Of T, V)(Input() As T) As V()
            Throw New System.Exception("Unsupport.")
            Return Nothing
        End Function
        '===================================

        '''<summary>Unsafe copy data of object, size of input type and output type should be the same.</summary>
        <Extension, Method(External)>
        Public Sub CopyTo(Of T As Class, V As Structure)(Input As T, ByRef Output As V)
        End Sub

        '''<summary>Unsafe copy data of object, size of input type and output type should be the same.</summary>
        <Extension, Method(External)>
        Public Sub CopyTo(Of T As Class, V As Structure)(ByRef Input As V, Output As T)
        End Sub

        '''<summary>Unsafe copy byte data of object.</summary>
        ''' <param name="InputField">Put a field or an element of object into this, DONT use object itself directly.</param>
        ''' <param name="OutputField">Put a field or an element of object into this, DONT use object itself directly.</param>
        <Extension, Method(External)>
        Public Sub RawCopyTo(Of T, V)(ByRef InputField As T, ByRef OutputField As V, LengthByte As UInteger)
        End Sub

        '''<summary>Unsafe copy data from object to object</summary>
        ''' <param name="Length">Byte length you want to copy.</param>
        <Extension, Method(External)>
        Public Sub CopyTo(Input As Pointer, Output As Pointer, Optional Length As System.UIntPtr = Nothing)
        End Sub

        '''<summary>Disguising an object to other type.</summary>
        <Extension, Method(External)>
        Public Sub DisguiseAs(Of T As Class, V As Class)([From] As T, [To] As V)
        End Sub
    End Module

    Public Structure Pointer
        <System.Security.SecurityCritical>
        Friend ReadOnly Address As System.IntPtr
    End Structure
End Namespace