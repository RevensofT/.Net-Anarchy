Imports Extension = System.Runtime.CompilerServices.ExtensionAttribute
Imports Method = System.Runtime.CompilerServices.MethodImplAttribute

Namespace Anarchy

    Public Module Common
        '''<summary>Get size of reference type, request an object for calculate.</summary>
        <Extension, Method(External)>
        Public Function Size(Of T As Class, V)(Host As T, ByRef LastField As V) As System.UIntPtr
            Return 0
        End Function

        <Extension, Method(External)>
        Public Function Size(Of T As Structure)(Host As T) As System.UIntPtr
            Return 0
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

    End Module

End Namespace