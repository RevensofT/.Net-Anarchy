Imports Extension = System.Runtime.CompilerServices.ExtensionAttribute
Imports Method = System.Runtime.CompilerServices.MethodImplAttribute

Namespace Anarchy.Assist

    Public Structure Objects(Of T)
        Friend Base() As T
        Private _Length As System.UIntPtr
        Public Shared ReadOnly ElementSize As System.UIntPtr

        Shared Sub New()
            ElementSize = Common.Size(Of T)()
        End Sub

        <Method(Inline)>
        Public Sub New(Array() As T)
            Base = Array
        End Sub

        Public Sub New(Capacity As System.UIntPtr)
            Base = Capacity.Array(Of T)() 'New T(Capacity - 1) {}
        End Sub

        Public WriteOnly Property Push As T
            <Method(Inline)>
            Set(value As T)
                If _Length = Base.NativeLength Then Base = Base.Extension '.LongLength Then ReDim Preserve Base(_Length + _Length)
                Base(_Length) = value
                _Length += 1
            End Set
        End Property

        Public ReadOnly Property Pop As T
            <Method(Inline)>
            Get
                _Length -= 1
                Return Base(_Length)
            End Get
        End Property

        Default Public Property Items(Index As System.IntPtr) As T
            <Method(Inline)>
            Get
                Return Base(Index)
            End Get
            <Method(Inline)>
            Set(value As T)
                If Base.LongLength - CLng(Index) < 1 Then Base = Base.Extension
                Base(Index) = value
            End Set
        End Property

        Public ReadOnly Property Array As T()
            <Method(Inline)>
            Get
                Return Base(0).CopyArray(_Length)
            End Get
        End Property

        Public ReadOnly Property Length As System.UIntPtr
            <Method(Inline)>
            Get
                Return _Length
            End Get
        End Property

        Public ReadOnly Property Capital As System.UIntPtr
            'External)>
            <Method(Inline)>
            Get
                Return Base.NativeLength
            End Get
        End Property
    End Structure
End Namespace
