.class public auto ansi sealed beforefieldinit Anarchy.LitegateExtensions
{
	.method public static valuetype Anarchy.Litegate 
        Address(class [mscorlib]System.Delegate Method) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack  2
		
		ldarg.0
		ldsfld     native int Anarchy.LitegateExtensions::_AddressOf
		calli	   native int(class [mscorlib]System.Delegate)
		ret
	}
	
	//===============================
	// Function
	//===============================
	.method public static !!R Invoke<R>(valuetype Anarchy.Litegate MethodPtr) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 1

		ldarg.0
		calli !!R()
		ret
	}
	.method public static !!R Invoke<T, R>(valuetype Anarchy.Litegate MethodPtr, !!T This) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.1
		ldarg.0
		calli !!R(!!T)
		ret
	}

	.method public static !!R Invoke<T, T2, R>(valuetype Anarchy.Litegate MethodPtr, !!T This, !!T2 Arg2) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 3

		ldarg.1
		ldarg.2
		ldarg.0
		calli !!R(!!T, !!T2)
		ret
	}
	.method public static !!R Invoke<T, T2, T3, R>(valuetype Anarchy.Litegate MethodPtr, !!T This, !!T2 Arg2, !!T3 Arg3) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 4

		ldarg.1
		ldarg.2
		ldarg.3
		ldarg.0
		calli !!R(!!T, !!T2, !!T3)
		ret
	}
	.method public static !!R Invoke<T, T2, T3, T4, R>(valuetype Anarchy.Litegate MethodPtr, !!T This, !!T2 Arg2, !!T3 Arg3, !!T4 Arg4) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 5

		ldarg.1
		ldarg.2
		ldarg.3
		ldarg.s 4
		ldarg.0
		calli !!R(!!T, !!T2, !!T3, !!T4)
		ret
	}
	.method public static !!R Invoke<T, T2, T3, T4, T5, R>(valuetype Anarchy.Litegate MethodPtr, !!T This, !!T2 Arg2, !!T3 Arg3, !!T4 Arg4, !!T5 Arg5) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 6

		ldarg.1
		ldarg.2
		ldarg.3
		ldarg.s 4
		ldarg.s 5
		ldarg.0
		calli !!R(!!T, !!T2, !!T3, !!T4, !!T5)
		ret
	}
	.method public static !!R Invoke<T, T2, T3, T4, T5, T6, R>(valuetype Anarchy.Litegate MethodPtr, !!T This, !!T2 Arg2, !!T3 Arg3, !!T4 Arg4, !!T5 Arg5, !!T6 Arg6) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 7

		ldarg.1
		ldarg.2
		ldarg.3
		ldarg.s 4
		ldarg.s 5
		ldarg.s 6
		ldarg.0
		calli !!R(!!T, !!T2, !!T3, !!T4, !!T5, !!T6)
		ret
	}
	.method public static !!R Invoke<T, T2, T3, T4, T5, T6, T7, R>(valuetype Anarchy.Litegate MethodPtr, !!T This, !!T2 Arg2, !!T3 Arg3, !!T4 Arg4, !!T5 Arg5, !!T6 Arg6, !!T7 Arg7) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 8

		ldarg.1
		ldarg.2
		ldarg.3
		ldarg.s 4
		ldarg.s 5
		ldarg.s 6
		ldarg.s 7
		ldarg.0
		calli !!R(!!T, !!T2, !!T3, !!T4, !!T5, !!T6, !!T7)
		ret
	}
	.method public static !!R Invoke<T, T2, T3, T4, T5, T6, T7, T8, R>(valuetype Anarchy.Litegate MethodPtr, !!T This, !!T2 Arg2, !!T3 Arg3, !!T4 Arg4, !!T5 Arg5, !!T6 Arg6, !!T7 Arg7, !!T8 Arg8) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 9

		ldarg.1
		ldarg.2
		ldarg.3
		ldarg.s 4
		ldarg.s 5
		ldarg.s 6
		ldarg.s 7
		ldarg.s 8
		ldarg.0
		calli !!R(!!T, !!T2, !!T3, !!T4, !!T5, !!T6, !!T7, !!T8)
		ret
	}


	//===============================
	// Sub
	//===============================
	.method public static void Invoke(valuetype Anarchy.Litegate MethodPtr) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 1

		ldarg.0
		calli void()
		ret
	}
	.method public static void Invoke<T>(valuetype Anarchy.Litegate MethodPtr, !!T This) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.1
		ldarg.0
		calli void(!!T)
		ret
	}
	.method public static void Invoke<T, T2>(valuetype Anarchy.Litegate MethodPtr, !!T This, !!T2 Arg2) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 3

		ldarg.1
		ldarg.2
		ldarg.0
		calli void(!!T, !!T2)
		ret
	}
	.method public static void Invoke<T, T2, T3>(valuetype Anarchy.Litegate MethodPtr, !!T This, !!T2 Arg2, !!T3 Arg3) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 4

		ldarg.1
		ldarg.2
		ldarg.3
		ldarg.0
		calli void(!!T, !!T2, !!T3)
		ret
	}
	.method public static void Invoke<T, T2, T3, T4>(valuetype Anarchy.Litegate MethodPtr, !!T This, !!T2 Arg2, !!T3 Arg3, !!T4 Arg4) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 5

		ldarg.1
		ldarg.2
		ldarg.3
		ldarg.s 4
		ldarg.0
		calli void(!!T, !!T2, !!T3, !!T4)
		ret
	}
	.method public static void Invoke<T, T2, T3, T4, T5>(valuetype Anarchy.Litegate MethodPtr, !!T This, !!T2 Arg2, !!T3 Arg3, !!T4 Arg4, !!T5 Arg5) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 6

		ldarg.1
		ldarg.2
		ldarg.3
		ldarg.s 4
		ldarg.s 5
		ldarg.0
		calli void(!!T, !!T2, !!T3, !!T4, !!T5)
		ret
	}
	.method public static void Invoke<T, T2, T3, T4, T5, T6>(valuetype Anarchy.Litegate MethodPtr, !!T This, !!T2 Arg2, !!T3 Arg3, !!T4 Arg4, !!T5 Arg5, !!T6 Arg6) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 7

		ldarg.1
		ldarg.2
		ldarg.3
		ldarg.s 4
		ldarg.s 5
		ldarg.s 6
		ldarg.0
		calli void(!!T, !!T2, !!T3, !!T4, !!T5, !!T6)
		ret
	}
	.method public static void Invoke<T, T2, T3, T4, T5, T6, T7>(valuetype Anarchy.Litegate MethodPtr, !!T This, !!T2 Arg2, !!T3 Arg3, !!T4 Arg4, !!T5 Arg5, !!T6 Arg6, !!T7 Arg7) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 8

		ldarg.1
		ldarg.2
		ldarg.3
		ldarg.s 4
		ldarg.s 5
		ldarg.s 6
		ldarg.s 7
		ldarg.0
		calli void(!!T, !!T2, !!T3, !!T4, !!T5, !!T6, !!T7)
		ret
	}
	.method public static void Invoke<T, T2, T3, T4, T5, T6, T7, T8>(valuetype Anarchy.Litegate MethodPtr, !!T This, !!T2 Arg2, !!T3 Arg3, !!T4 Arg4, !!T5 Arg5, !!T6 Arg6, !!T7 Arg7, !!T8 Arg8) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 9

		ldarg.1
		ldarg.2
		ldarg.3
		ldarg.s 4
		ldarg.s 5
		ldarg.s 6
		ldarg.s 7
		ldarg.s 8
		ldarg.0
		calli void(!!T, !!T2, !!T3, !!T4, !!T5, !!T6, !!T7, !!T8)
		ret
	}
}