.class public sealed Anarchy.Calculate
{
	//====================================
	// Native Int
	//====================================
	.method public static native int Add(native int A, native int B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1

		add
		ret
	}
	
	.method public static native int Sub(native int A, native int B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1

		sub
		ret
	}

	.method public static native int Mul(native int A, native int B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1

		mul
		ret
	}

	.method public static native int Div(native int A, native int B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1

		div
		ret
	}

	.method public static native int Rem(native int A, native int B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1

		rem
		ret
	}

	//---------------------------------------

	.method public static native int Add(native int A, native uint B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1
		conv.i

		add
		ret
	}
	
	.method public static native int Sub(native int A, native uint B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1
		conv.i

		sub
		ret
	}

	.method public static native int Mul(native int A, native uint B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1
		conv.i

		mul
		ret
	}

	.method public static native int Div(native int A, native uint B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1
		conv.i

		div
		ret
	}

	.method public static native int Rem(native int A, native uint B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1
		conv.i

		rem
		ret
	}
		
	//====================================
	// Native UInt
	//====================================
	.method public static native uint Add(native uint A, native uint B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1

		add.ovf.un
		ret
	}
	
	.method public static native uint Sub(native uint A, native uint B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1

		sub.ovf.un
		ret
	}

	.method public static native uint Mul(native uint A, native uint B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1

		mul.ovf.un
		ret
	}

	.method public static native uint Div(native uint A, native uint B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1

		div.un
		ret
	}

	.method public static native uint Rem(native uint A, native uint B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1

		rem.un
		ret
	}

	//---------------------------------------
	.method public static native uint Add(native uint A, native int B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1
		conv.u

		add.ovf.un
		ret
	}
	
	.method public static native uint Sub(native uint A, native int B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1
		conv.u

		sub.ovf.un
		ret
	}

	.method public static native uint Mul(native uint A, native int B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1
		conv.u

		mul.ovf.un
		ret
	}

	.method public static native uint Div(native uint A, native int B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1
		conv.u

		div.un
		ret
	}

	.method public static native uint Rem(native uint A, native int B) cil managed aggressiveinlining
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack 2

		ldarg.0
		ldarg.1
		conv.u

		rem.un
		ret
	}
}