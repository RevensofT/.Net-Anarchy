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

        '''<summary>Get size of value type.</summary>
        <Method(External)>
        Public Function Size(Of T)() As System.UIntPtr
            Return 0
        End Function

        '''<summary>Get native uint size of array.</summary>
        <Extension, Method(External)>
        Public Function NativeLength(Of T)(Input() As T) As System.UIntPtr
            Return 0
        End Function

        '''<summary>Get element of array by native int index.</summary>
        <Extension, Method(External)>
        Public Function NativeIndex(Of T)(Input() As T, Index As System.IntPtr) As RefPointer(Of T)
        End Function

        '''<summary>Get type token.</summary>
        <Method(External)>
        Public Function Token(Of T)() As System.IntPtr
        End Function

        'Result pointer can't be touch, any pointer access to section of reserve memory other then result pointer will cause data's crash.
        ' '''<summary>Allocate from local dynamic memory, auto free when end method but size very limit.</summary>
        '<Method(External)>
        'Public Function Rift(Size As Byte) As Pointer  'System.IntPtr
        'End Function
    End Module

    Public Module Indirect
        '''<summary>Get a reference pointer.</summary>
        <Extension, Method(External)>
        Public Function [ByRef](Of T)(ByRef Input As T) As RefPointer(Of T)
        End Function

        ' '''<summary>Get a reference pointer of structure.</summary>
        '<Extension, Method(External)>
        'Public Function ByStruct(Of T As Structure)(ByRef Input As T) As Pointer(Of T)
        'End Function

        ', Browns(1)
        '''<summary>Get a pointer.</summary>
        <Extension, Method(External)>
        Public Function [ByVal](Of T As Class)(Input As T) As Pointer(Of T)
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

        '===============================================
        ' Manage pointer is unsupport for shift address
        '===============================================
        '''<summary>Unsupport to shift pointer because it will unloadable.</summary>
        <Extension, Method(Inline)>
        Public Function Shift(Of T)(Pointer As Pointer(Of T), Postion As System.IntPtr) As Pointer(Of T)
            Throw New System.Exception("Unsupport shift position, generic pointer will unloadable.")
        End Function
        '''<summary>Unsupport to shift pointer because it will unloadable.</summary>
        <Extension, Method(Inline)>
        Public Function Shift(Of T)(Pointer As RefPointer(Of T), Postion As System.IntPtr) As Pointer(Of T)
            Throw New System.Exception("Unsupport shift position, generic pointer will unloadable.")
        End Function
        '===============================================

        <Extension, Method(Inline)>
        Public Function Load(Of T As Class)(Pointer As Pointer(Of T)) As T
            Return Pointer.As(Of Pointer).As(Of T)()
        End Function
        '<Extension, Method(External)>
        'Public Function Value(Of T As Structure)(Pointer As Pointer(Of T)) As T
        'End Function

        <Extension, Method(Inline)>
        Public Sub SetTo(Of T)(Pointer As RefPointer(Of T), Value As T)
            Pointer.Value = Value
        End Sub

    End Module

    Public Module Convert
        '''<summary>Unsafe direct cast between reference type, use it only when you know what're you doing.</summary>
        <Extension, Method(External)>
        Public Function [As](Of T As Class, V As Class)(Input As T) As V
            Return Nothing
        End Function

        '''<summary>Unsafe direct cast between value type, use it only when you know what're you doing.</summary>
        <Extension, Method(External)>
        Public Function [As](Of T As Structure, V As Structure)(Input As V) As T
        End Function

        '''<summary>Unsafe direct cast type from pointer, use it only when you know what're you doing.</summary>
        <Extension, Method(External)>
        Public Function [As](Of T As Class)(Input As Pointer) As T
            Return Nothing
        End Function

        '''<summary>Unsafe direct cast pointer to other value type, use it only when you know what're you doing.</summary>
        <Extension, Method(External)>
        Public Function [To](Of T As Structure)(Input As Pointer) As T
        End Function
        '===================================
        'Unsupport, hard to design for user to use it without errors.
        '-----------------------------------
        '''<summary>Unsupport to cast array to object.</summary>
        <Extension, Method(Inline)>
        Public Function [As](Of T, V)(Input() As V) As T
            Throw New System.Exception("Unsupport to cast array to object.")
            Return Nothing
        End Function
        '''<summary>Unsupport to cast object to array.</summary>
        <Extension, Method(Inline)>
        Public Function [As](Of T)(Input As Object) As T()
            Throw New System.Exception("Unsupport to cast object to array.")
            Return Nothing
        End Function
        '''<summary>Unsupport to cast array to other type of array.</summary>
        <Extension, Method(Inline)>
        Public Function [As](Of T, V)(Input() As T) As V()
            Throw New System.Exception("Unsupport to cast array to other type of array.")
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

        '''<summary>Change an array from type to other type, calculate array size by size of type; so beware missing data if size of those type can't be multiply to match each other.</summary>
        '''<param name="From">This variant WILL BE reference to null/nothing after used by this method.</param>
        <Extension, Method(External)>
        Public Function CArray(Of T, V)(ByRef [From] As T()) As V()
            Return Nothing
        End Function

        '''<summary>Change class type to other class type.</summary>
        '''<param name="From">This variant WILL BE reference to null/nothing after used by this method.</param>
        '''<param name="Sample">This object will be untouch, just want its meta header.</param>
        <Extension, Method(External)>
        Public Function CClass(Of T As Class, V As Class)(ByRef [From] As T, Sample As V) As V
            Return Nothing
        End Function

        ' '''<summary>Disguising an object to other type.</summary>
        '<Extension, Method(External)>
        'Public Sub DisguiseAs(Of T As Class, V As Class)([From] As T, [To] As V)
        'End Sub
    End Module

#Region "Pointer"
    Public Structure Pointer
        <System.Security.SecurityCritical>
        Friend ReadOnly Address As System.IntPtr

        <Method(Inline)>
        Public Shared Widening Operator CType(Input As Pointer) As System.IntPtr
            Return Input.Address
        End Operator
    End Structure

    Public Structure RefPointer(Of T)
        Public Shared ReadOnly Type As System.Type = GetType(T)

        <System.Security.SecurityCritical>
        Friend ReadOnly Address As System.IntPtr

        <Method(Inline)>
        Public Shared Widening Operator CType(Input As RefPointer(Of T)) As Pointer
            Return Input.As(Of Pointer)()
        End Operator
        '<Method(Inline)>
        'Public Shared Widening Operator CType(Input As Pointer) As RefPointer(Of T)
        '    Return Input.To(Of RefPointer(Of T))()
        'End Operator

        Public Property Value As T
            <Method(External)>
            Get
            End Get

            <Method(External)>
            Set(value As T)
            End Set
        End Property

    End Structure

    Public Structure Pointer(Of T)
        Public Shared ReadOnly Type As System.Type = GetType(T)

        <System.Security.SecurityCritical>
        Friend ReadOnly Address As System.IntPtr

        <Method(Inline)>
        Public Shared Widening Operator CType(Input As Pointer(Of T)) As Pointer
            Return Input.As(Of Pointer)()
        End Operator
        '<Method(Inline)>
        'Public Shared Widening Operator CType(Input As Pointer) As Pointer(Of T)
        '    Return Input.To(Of Pointer(Of T))()
        'End Operator
    End Structure
#End Region

End Namespace