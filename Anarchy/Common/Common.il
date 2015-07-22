.class public sealed Anarchy.Common
{
	.method public static native uint Size<valuetype T>(!!T Host) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 1

		sizeof !!T
		ret
	}
	.method public static native uint Size<T>() cil managed aggressiveinlining
	{
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

	.method public static native uint NativeLength<T>(!!T[] Host) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 1

		ldarg.0
		ldlen
		ret
	}

	.method public static valuetype Anarchy.RefPointer`1<!!T> NativeIndex<T>(!!T[] Host, native int Index) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1
		ldelema !!T
		ret
	}

	.method public static native int Token<T>() cil managed aggressiveinlining
	{
		.maxstack 1
		ldtoken !!T
		ret
	}

	/*
	.method public static valuetype Anarchy.Pointer Rift(uint8 Size) cil managed aggressiveinlining
	{
		.maxstack 1
		ldarg.0
		localloc
		ret
	}
	*/
}

.class public sealed Anarchy.Indirect
{
	.method public static valuetype Anarchy.RefPointer`1<!!T> ByRef<T>(!!T& Input) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 1

		ldarg.0
		ret
	}
	/*.method public static valuetype Anarchy.Pointer`1<!!T> ByStruct<valuetype T>(!!T& Input) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 1

		ldarg.0
		ret
	}*/
	.method public static valuetype Anarchy.Pointer`1<!!T> ByVal<class T>(!!T Input) cil managed aggressiveinlining
	{
		//.custom instance void [System]System.ComponentModel.EditorBrowsableAttribute::.ctor(valuetype [System]System.ComponentModel.EditorBrowsableState) = ( 01 00 01 00 00 00 00 00 ) 
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

	.method public static !!T As<class T>(valuetype Anarchy.Pointer Input) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 1

		ldarg.0
		ret
	}

	.method public static !!T To<valuetype T>(valuetype Anarchy.Pointer Input) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		//ldobj !!T
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
	
	.method public static void CopyTo(valuetype Anarchy.Pointer Input, valuetype Anarchy.Pointer Output, native uint Length) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 3

		ldarg.1
		ldarg.0
		ldarg.2
		cpblk
		ret
	}

	/*.method public static void DisguiseAs<class T, class V>(!!T From, !!V To) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 3

		.locals init ([0] native int)
		
		ldloca.s 0
		ldarg.1
		sizeof native int
		cpblk

		ldarg.0
		ldloca.s 0
		sizeof native int
		cpblk

		ret
	}*/

	.method public static !!V  CClass<class T,class V>(!!T& From, !!V Sample) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 3

		.locals init ([0] native int)
		
		ldarg.0
		ldind.ref
		ldarg.1
		sizeof native int
		cpblk

		ldarg.0
		ldind.ref

		ldarg.0
		ldnull
		stind.ref

		ret
	}

	.method public static !!V[] CArray<T, V>(!!T[]& From) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 3

		.locals init ([0] native int, [1] !!T[])

		ldarg.0
		ldind.ref
		stloc.1
		
		ldloc.1
		ldc.i4.0
		newarr !!V
		sizeof native int
		cpblk

		//{-----------------------
		ldloc.1
		sizeof native int
		add

		sizeof !!T
		conv.r4
		sizeof !!V
		conv.r4
		div
		ldloc.1
		ldlen
		conv.r4
		mul
		conv.i
		stloc.0

		ldloca.s 0
		
		sizeof native int
		cpblk
		//-----------------------}

		ldarg.0
		ldnull
		stind.ref

		ldloc.1
		ret
	}
}


/*
.class public sequential ansi sealed beforefieldinit Anarchy.Pointer`1<T>
       extends [mscorlib]System.ValueType
{
	.method public specialname static valuetype Anarchy.Pointer 
        op_Implicit(valuetype Anarchy.Pointer`1<!T> Input) cil managed aggressiveinlining
	{
		ldarg.0
		ret
	}
}
*/

.class public sequential ansi sealed Anarchy.RefPointer`1<T>
       extends [mscorlib]System.ValueType
{
	.method public specialname instance !T  get_Value() cil managed aggressiveinlining
	{
		.maxstack 1
		ldarg.0
		ldfld      native int valuetype Anarchy.RefPointer`1<!T>::Address
		ldobj	!T
		ret
	}
	.method public specialname instance void set_Value(!T 'value') cil managed aggressiveinlining
	{
		ldarg.0
		ldfld      native int valuetype Anarchy.RefPointer`1<!T>::Address
		ldarg.1
		stobj !T
		ret
	}

}