Imports Extension = System.Runtime.CompilerServices.ExtensionAttribute
Imports Method = System.Runtime.CompilerServices.MethodImplAttribute

Imports Int = System.IntPtr
Imports UInt = System.UIntPtr

Namespace Anarchy.Assist
    Public Module Array
        <Extension, Method(Inline)>
        Public Function Managed(Of T)(Input() As T) As Objects(Of T)
            Return New Objects(Of T)(Input)
        End Function

        '''<summary>Double size of array's capacity.</summary>
        <Extension, Method(Inline)>
        Public Function Extension(Of T)(Input() As T) As T()
            With Input.NativeLength
                Dim Tmp = .Mul(2.As(Of UInt)).Array(Of T)()
                Input(0).RawCopyTo(Tmp(0), .Mul(Size(Of T)))

                Return Tmp
            End With
        End Function

#Region "Create"
        <Extension, Method(External)>
        Public Function Members(Of T)(Capacity As Integer) As Objects(Of T)
            Return New Objects(Of T)(Capacity)
        End Function
        <Extension, Method(External)>
        Public Function Members(Of T)(Capacity As UInteger) As Objects(Of T)
            Return New Objects(Of T)(Capacity)
        End Function
        '''<summary>For 64bit ONLY.</summary>
        <Extension, Method(External)>
        Public Function Members(Of T)(Capacity As Long) As Objects(Of T)
            Return New Objects(Of T)(Capacity)
        End Function
        '''<summary>For 64bit ONLY.</summary>
        <Extension, Method(External)>
        Public Function Members(Of T)(Capacity As ULong) As Objects(Of T)
            Return New Objects(Of T)(Capacity)
        End Function

        <Extension, Method(External)>
        Public Function Array(Of T)(Capacity As Integer) As T()
            Return New T(Capacity) {}
        End Function
        <Extension, Method(External)>
        Public Function Array(Of T)(Capacity As UInteger) As T()
            Return New T(Capacity) {}
        End Function
        '''<summary>For 64bit ONLY.</summary>
        <Extension, Method(External)>
        Public Function Array(Of T)(Capacity As Long) As T()
            Return New T(Capacity) {}
        End Function
        '''<summary>For 64bit ONLY.</summary>
        <Extension, Method(External)>
        Public Function Array(Of T)(Capacity As ULong) As T()
            Return New T(Capacity) {}
        End Function
        <Extension, Method(External)>
        Public Function Array(Of T)(Capacity As Int) As T()
            Return New T(Capacity) {}
        End Function
        <Extension, Method(External)>
        Public Function Array(Of T)(Capacity As UInt) As T()
            Return New T(Capacity) {}
        End Function
#End Region

#Region "Get"
        '''<summary>Selece element of array from postion (first element is 1 not 0).</summary>
        <Extension, Method(Inline)>
        Public Function [Of](Of T)(MemberNo As Integer, Input() As T) As T
            Return Input(MemberNo - 1)
        End Function
        '''<summary>Selece element of array from postion (first element is 1 not 0).</summary>
        <Extension, Method(Inline)>
        Public Function [Of](Of T)(MemberNo As Long, Input() As T) As T
            Return Input(MemberNo - 1)
        End Function
        '''<summary>Selece element of array from postion (first element is 1 not 0).</summary>
        <Extension, Method(Inline)>
        Public Function [Of](Of T)(MemberNo As Integer, Input As Objects(Of T)) As T
            Return Input(MemberNo - 1)
        End Function
        '''<summary>Selece element of array from postion (first element is 1 not 0).</summary>
        <Extension, Method(Inline)>
        Public Function [Of](Of T)(MemberNo As Long, Input As Objects(Of T)) As T
            Return Input(MemberNo - 1)
        End Function

        '''<summary>Selece element of array fron index.</summary>
        <Extension, Method(Inline)>
        Public Function [In](Of T)(Index As Integer, Input() As T) As T
            Return Input(Index)
        End Function
        '''<summary>Selece element of array fron index.</summary>
        <Extension, Method(Inline)>
        Public Function [In](Of T)(Index As Long, Input() As T) As T
            Return Input(Index)
        End Function
        '''<summary>Selece element of array fron index.</summary>
        <Extension, Method(Inline)>
        Public Function [In](Of T)(Index As Integer, Input As Objects(Of T)) As T
            Return Input(Index)
        End Function
        '''<summary>Selece element of array fron index.</summary>
        <Extension, Method(Inline)>
        Public Function [In](Of T)(Index As Long, Input As Objects(Of T)) As T
            Return Input(Index)
        End Function
#End Region

        ' '''<summary>Copy elements of array to other array.</summary>
        ' ''' <param name="Input">Start copy from this array's element.</param>
        ' ''' <param name="Output">Start paste from this array's element.</param>
        ' ''' <param name="Length">Number of element you want to copy.</param>
        '<Extension, Method(Inline)>
        'Public Sub CopyArray(Of T)(ByRef Input As T, ByRef Output As T, Length As UInt)
        '    Input.RawCopyTo(Output, Common.Size(Of T).Mul(Length))
        'End Sub

        '''<summary>Copy part of array to new array.</summary>
        ''' <param name="Input">Start copy from this array's element.</param>
        ''' <param name="Length">Number of element you want to copy.</param>
        <Extension, Method(Inline)>
        Public Function CopyArray(Of T)(ByRef Input As T, Length As UInt) As T()
            Dim Output = Length.Array(Of T)()  '(Length) As T
            Input.RawCopyTo(Output(0), Common.Size(Of T).Mul(Length))
            Return Output
        End Function

#Region "Crop"
        <Extension, Method(Inline)>
        Public Function [From](Of T)(Index As Integer, Input() As T) As T()
            From = Input(Index).CopyArray((Input.Length - Index).As(Of UInt))
        End Function
        <Extension, Method(Inline)>
        Public Function [From](Of T)(Index As Long, Input() As T) As T()
            From = Input(Index).CopyArray((Input.LongLength - Index).As(Of UInt))
        End Function
        '''<summary>Selecet elements from index 0.</summary>
        ''' <param name="Length">Number of element you want from this array.</param>
        <Extension, Method(Inline)>
        Public Function Onwards(Of T)(Input As T(), Length As Integer) As T()
            Onwards = Input(0).CopyArray(Length.As(Of UInt))
        End Function
        '''<summary>Selecet elements from index 0.</summary>
        ''' <param name="Length">Number of element you want from this array.</param>
        <Extension, Method(Inline)>
        Public Function Onwards(Of T)(Input As T(), Length As Long) As T()
            Onwards = Input(0).CopyArray(Length.As(Of UInt))
        End Function

        <Extension, Method(Inline)>
        Public Function [From](Of T)(Index As Integer, Input As Objects(Of T)) As T()
            From = Input.Base(Index).CopyArray(Index.As(Of UInt).Sub(Input.Length))
        End Function
        <Extension, Method(Inline)>
        Public Function [From](Of T)(Index As Long, Input As Objects(Of T)) As T()
            From = Input.Base(Index).CopyArray(Index.As(Of UInt).Sub(Input.Length))
        End Function
        '''<summary>Selecet elements from index 0.</summary>
        ''' <param name="Length">Number of element you want from this collection.</param>
        <Extension, Method(Inline)>
        Public Function Onwards(Of T)(Input As Objects(Of T), Length As Integer) As T()
            Onwards = Input.Base(0).CopyArray(Length.As(Of UInt))
        End Function
        '''<summary>Selecet elements from index 0.</summary>
        ''' <param name="Length">Number of element you want from this collection.</param>
        <Extension, Method(Inline)>
        Public Function Onwards(Of T)(Input As Objects(Of T), Length As Long) As T()
            Onwards = Input.Base(0).CopyArray(Length.As(Of UInt))
        End Function

        <Extension, Method(Inline)>
        Public Function Rid(Of T)(Input() As T, Target As T) As T()
            Dim Tmp = Input.Length.Members(Of T)()
            For Each Item In Input
                If Not Item.Equals(Target) Then Tmp.Push = Item
            Next
            Return Tmp.Array
        End Function
#End Region

        <Extension, Method(External)>
        Public Function [IsIn](Of T)(Input As T, Store() As T) As System.IntPtr
            For Index = 0 To Store.LongLength - 1
                If Input.Equals(Index.In(Store)) Then Return Index
            Next
            Return -1
        End Function
        <Extension, Method(External)>
        Public Function [IsIn](Of T)(Input As T, Store As Objects(Of T)) As System.IntPtr
            For Index = 0 To CLng(Store.Length) - 1
                If Input.Equals(Index.In(Store)) Then Return Index
            Next
            Return -1
        End Function

        <Extension, Method(External)>
        Public Function DefinitelyIn(Of T As Class)(Input As T, Store() As T) As System.IntPtr
            For Index = 0 To Store.LongLength - 1
                If Object.ReferenceEquals(Input, Store(Index)) Then Return Index
            Next
        End Function
        <Extension, Method(Inline)>
        Public Function DefinitelyIn(Of T As Class)(Input As T, Store As Objects(Of T)) As System.IntPtr
            Return Input.DefinitelyIn(Store.Base)
        End Function
    End Module

End Namespace