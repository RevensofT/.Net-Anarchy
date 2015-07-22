Imports sri = System.Runtime.InteropServices
Imports srv = System.Runtime.Versioning
Imports src = System.Runtime.ConstrainedExecution

Imports Int = System.IntPtr
Imports Uint = System.UIntPtr

Imports mws = Microsoft.Win32.SafeHandles

Namespace Native
    Public Module DllInfo
        Public Const KERNEL32 = "kernel32.dll"
        Public Const USER32 = "user32.dll"
        Public Const ADVAPI32 = "advapi32.dll"
        Public Const OLE32 = "ole32.dll"
        Public Const OLEAUT32 = "oleaut32.dll"
        Public Const SHELL32 = "shell32.dll"
        Public Const SHIM = "mscoree.dll"
        Public Const CRYPT32 = "crypt32.dll"
        Public Const SECUR32 = "secur32.dll"
        Public Const NTDLL = "ntdll.dll"

        Public Const MSVCRT = "msvcrt.dll"
    End Module

    Public Module Common
        <sri.DllImport(KERNEL32, SetLastError:=True, EntryPoint:="GetLastError")>
        Public Function LastError() As Integer
        End Function
    End Module

    Public Module File

        Public Const DirectWrite As Integer = &H20000000 Or &H80000000

        <sri.StructLayout(sri.LayoutKind.Sequential)>
        Public Class SECURITY_ATTRIBUTES
            Public nLength As Integer = 8 + System.IntPtr.Size
            'don't remove null, or this field will disappear in bcl.small
            'internal unsafe byte * pSecurityDescriptor = null;
            Public pSecurityDescriptor As System.IntPtr = Nothing
            Public bInheritHandle As Integer = 0
        End Class

        ' SetLastError=true, CharSet=CharSet.Auto, BestFitMapping=false)>
        '<sri.DllImport(KERNEL32, SetLastError:=True, CharSet:=sri.CharSet.Auto, BestFitMapping:=False)>
        'Public Function CreateFile(lpFileName As String,
        '                dwDesiredAccess As System.IO.FileAccess, dwShareMode As System.IO.FileShare,
        '                securityAttrs As SECURITY_ATTRIBUTES, dwCreationDisposition As System.IO.FileMode,
        '                dwFlagsAndAttributes As System.IO.FileOptions, hTemplateFile As System.IntPtr) As mws.SafeFileHandle
        'End Function

        'Public Declare Function Open Lib "kernel32.dll" Alias "CreateFile" () As mws.SafeFileHandle

        <sri.DllImport(KERNEL32, SetLastError:=True, EntryPoint:="CreateFile", CharSet:=sri.CharSet.Auto, BestFitMapping:=False)>
        Public Function Open(FileName As String,
                             FileAccess As System.IO.FileAccess, ShareMode As System.IO.FileShare,
                             SecurityATB As SECURITY_ATTRIBUTES, FileMode As System.IO.FileMode,
                             FileOption As System.IO.FileOptions, hTemplateFile As System.IntPtr) As mws.SafeFileHandle
        End Function

        'Might be wrong but I think lo and hi == {int, int} == long
        ' (Long)FullLength = (Long)hi << 32 Or (Uint)lo
        <sri.DllImport(KERNEL32, SetLastError:=True, EntryPoint:="SetFilePointerEx"),
        srv.ResourceExposure(srv.ResourceScope.None)>
        Public Function Seek(handle As mws.SafeFileHandle, MoveValue As Long, ByRef PositionAfterSeek As Long, origin As System.IO.SeekOrigin) As Boolean
        End Function

        '''<param name="lpOverlapped">Contains information used in asynchronous (or overlapped) input and output (I/O)</param>
        <sri.DllImport(KERNEL32, SetLastError:=True, EntryPoint:="ReadFile"),
        srv.ResourceExposure(srv.ResourceScope.None)>
        Public Function Read(handle As mws.SafeFileHandle, Data As System.IntPtr, Length As UInteger, ByRef Count As UInteger, lpOverlapped As Int) As Boolean
        End Function

        '''<param name="lpOverlapped">Contains information used in asynchronous (or overlapped) input and output (I/O)</param>
        <sri.DllImport(KERNEL32, SetLastError:=True, EntryPoint:="WriteFile"),
        srv.ResourceExposure(srv.ResourceScope.None)>
        Public Function Write(handle As mws.SafeFileHandle, Data As System.IntPtr, Length As UInteger, ByRef Count As UInteger, lpOverlapped As Int) As Boolean
        End Function

        <sri.DllImport(KERNEL32, SetLastError:=True, EntryPoint:="GetFileSizeEx"),
         srv.ResourceExposure(srv.ResourceScope.None)>
        Public Function Size(hFile As mws.SafeFileHandle, ByRef highSize As ULong) As Boolean
        End Function

        <sri.DllImport(KERNEL32, SetLastError:=True, EntryPoint:="CancelIo"),
         srv.ResourceExposure(srv.ResourceScope.None)>
        Public Function Cancel(hFile As mws.SafeFileHandle) As Boolean
        End Function
    End Module

    Public Module Link
        '''<param name="lpSecurityAttributes">Must be Null.</param>
        <sri.DllImport(KERNEL32, EntryPoint:="CreateHardLink")>
        Public Function Hard(NewAddress As String, TargetAddress As String, lpSecurityAttributes As Object) As Boolean
        End Function

        <sri.DllImport(KERNEL32, EntryPoint:="CreateSymbolicLink")>
        Public Function Symbolic(NewAddress As String, TargetAddress As String, IsFolder As UInteger) As Boolean
        End Function
    End Module

    Public Module Memory
        <sri.DllImport(KERNEL32, EntryPoint:="LocalAlloc"),
         System.Runtime.Versioning.ResourceExposure(srv.ResourceScope.None),
         src.ReliabilityContract(src.Consistency.WillNotCorruptState, src.Cer.MayFail)>
        Public Function Alloc(uFlags As Integer, sizetdwBytes As System.IntPtr) As System.IntPtr
        End Function

        'Unuseable
        '<sri.DllImport(KERNEL32, EntryPoint:="LocalReAlloc"),
        'System.Runtime.Versioning.ResourceExposure(srv.ResourceScope.None),
        'src.ReliabilityContract(src.Consistency.WillNotCorruptState, src.Cer.MayFail)>
        'Public Function ReAlloc(Address As System.IntPtr, sizetdwBytes As System.IntPtr, uFlags As Integer) As System.IntPtr
        'End Function

        <sri.DllImport(KERNEL32, EntryPoint:="CopyMemory"),
         System.Runtime.Versioning.ResourceExposure(srv.ResourceScope.None)>
        Public Sub Copy(Target As System.IntPtr, Source As System.IntPtr, Size As Long)
        End Sub

        <sri.DllImport(KERNEL32, EntryPoint:="MoveMemory"),
         System.Runtime.Versioning.ResourceExposure(srv.ResourceScope.None)>
        Public Sub Move(Target As System.IntPtr, Source As System.IntPtr, Size As Long)
        End Sub

        <sri.DllImport(KERNEL32, EntryPoint:="FillMemory"),
         System.Runtime.Versioning.ResourceExposure(srv.ResourceScope.None)>
        Public Sub Fill([From] As System.IntPtr, Count As Long, Value As Byte)
        End Sub

        <sri.DllImport(KERNEL32, SetLastError:=True, EntryPoint:="LocalFree"),
         System.Runtime.Versioning.ResourceExposure(srv.ResourceScope.None),
         src.ReliabilityContract(src.Consistency.WillNotCorruptState, src.Cer.Success)>
        Public Function Free(Address As System.IntPtr) As System.IntPtr
        End Function

        <sri.DllImport(KERNEL32, SetLastError:=True, EntryPoint:="LocalSize"),
         System.Runtime.Versioning.ResourceExposure(srv.ResourceScope.None),
         src.ReliabilityContract(src.Consistency.WillNotCorruptState, src.Cer.Success)>
        Public Function Size(Address As System.IntPtr) As System.UIntPtr
        End Function

        <sri.DllImport(KERNEL32, EntryPoint:="RtlZeroMemory"),
         System.Runtime.Versioning.ResourceExposure(srv.ResourceScope.None),
         src.ReliabilityContract(src.Consistency.WillNotCorruptState, src.Cer.Success)>
        Public Sub Clear(Address As System.IntPtr, Length As System.IntPtr)
        End Sub

        <sri.DllImport(MSVCRT, EntryPoint:="memcmp", CallingConvention:=sri.CallingConvention.Cdecl)>
        Public Function Compare(A() As Byte, B() As Byte, Length As UInteger) As System.IntPtr
        End Function
        <sri.DllImport(MSVCRT, EntryPoint:="memcmp", CallingConvention:=sri.CallingConvention.Cdecl)>
        Public Function Compare(A As System.IntPtr, B As System.IntPtr, Length As UInteger) As System.IntPtr
        End Function
        '<sri.DllImport(MSVCRT, EntryPoint:="memcmp", CallingConvention:=sri.CallingConvention.Cdecl)>
        'Public Function Compare(A As Object, B As Object, Length As UInteger) As System.IntPtr
        'End Function
        'CallingConvention:=sri.CallingConvention.Cdecl
        '<sri.DllImport(MSVCRT, EntryPoint:="memcmp")>
        'Public Function Compare(A As Object, B As Object, Length As Long) As System.IntPtr
        'End Function
    End Module
End Namespace