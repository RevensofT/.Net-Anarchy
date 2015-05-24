.class public sealed Anarchy.Common
{
	.method public static native uint Size<valuetype T>(!!T Host) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 1

		sizeof !!T
		ret
	}

    .method public static native uint Size<class T,  V>(!!T Host, !!V& LastField) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.1
		ldarg.0
		sub
		sizeof native int
		sub
		sizeof !!V
		add
		ret
	}
}

.class public sealed Anarchy.Indirect
{
	.method public static valuetype Anarchy.Pointer ByRef<T>(!!T& Input) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 1

		ldarg.0
		ret
	}
	.method public static valuetype Anarchy.Pointer ByVal<class T>(!!T Input) cil managed aggressiveinlining
	{
		.custom instance void [System]System.ComponentModel.EditorBrowsableAttribute::.ctor(valuetype [System]System.ComponentModel.EditorBrowsableState) = ( 01 00 01 00 00 00 00 00 ) 
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 1

		ldarg.0
		ret
	}
		.method public static valuetype Anarchy.Pointer ByRef<T>(!!T& Input, native int ShiftPointerTo) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1
		add
		ret
	}
	.method public static valuetype Anarchy.Pointer ByVal<class T>(!!T Input, native int ShiftPointerTo) cil managed aggressiveinlining
	{
		.custom instance void [System]System.ComponentModel.EditorBrowsableAttribute::.ctor(valuetype [System]System.ComponentModel.EditorBrowsableState) = ( 01 00 01 00 00 00 00 00 ) 
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1
		add
		ret
	}
	.method public static valuetype Anarchy.Pointer Shift(valuetype Anarchy.Pointer Pointer, native int ShiftPointerTo) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1
		add
		ret
	}
}

.class public sealed Anarchy.Convert
{
	
	.method public static !!V As<class T, class V>(!!T Input) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 1

		ldarg.0
		ret
	}

	.method public static !!T As<valuetype T, valuetype V>(!!V Input) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 1

		ldarg.0
		ret
	}
	
	.method public static void CopyTo<class T, valuetype V>(!!T Input, !!V& Output) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 3

		ldarg.1

		ldarg.0
		sizeof native int
		add

		sizeof !!V

		volatile.
		cpblk
		ret
	}

	.method public static void CopyTo<class T, valuetype V>(!!V& Input, !!T Output) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 3

		ldarg.1
		sizeof native int
		add

		ldarg.0

		sizeof !!V

		volatile.
		cpblk
		ret
	}

	.method public static void RawCopyTo<T, V>(!!T& InputField, !!V& OutputField, uint32 Length) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 3

		ldarg.1
		ldarg.0
		ldarg.2
		cpblk
		ret
	}
	
	.method public static void Copy(valuetype Anarchy.Pointer Input, valuetype Anarchy.Pointer Output, native uint Length) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 3

		ldarg.1
		ldarg.0
		ldarg.2
		cpblk
		ret
	}
}