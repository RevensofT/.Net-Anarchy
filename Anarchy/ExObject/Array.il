.class public auto ansi sealed Anarchy.Assist.Array
{

  //===============================
  // Member
  //===============================
  .method public static valuetype Anarchy.Assist.Objects`1<!!T> 
          Members<T>(int32 Capacity) cil managed aggressiveinlining
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
    .maxstack  2
    .locals init ([0] valuetype Anarchy.Assist.Objects`1<!!T> Members)

    ldloca.s   0
    ldarg.0
    conv.u
    call       instance void valuetype Anarchy.Assist.Objects`1<!!T>::.ctor(native uint)
    ldloc.0
    ret
  } // end of method Array::Members

  .method public static valuetype Anarchy.Assist.Objects`1<!!T> 
          Members<T>(uint32 Capacity) cil managed aggressiveinlining
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
    .maxstack  2
    .locals init ([0] valuetype Anarchy.Assist.Objects`1<!!T> Members)

    ldloca.s   0
    ldarg.0
    call       instance void valuetype Anarchy.Assist.Objects`1<!!T>::.ctor(native uint)
    ldloc.0
    ret
  } // end of method Array::Members

  .method public static valuetype Anarchy.Assist.Objects`1<!!T> 
          Members<T>(int64 Capacity) cil managed aggressiveinlining
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
    .maxstack  2
    .locals init ([0] valuetype Anarchy.Assist.Objects`1<!!T> Members)

    ldloca.s   0
    ldarg.0
    conv.u
    call       instance void valuetype Anarchy.Assist.Objects`1<!!T>::.ctor(native uint)
    ldloc.0
    ret
  } // end of method Array::Members

  .method public static valuetype Anarchy.Assist.Objects`1<!!T> 
          Members<T>(uint64 Capacity) cil managed aggressiveinlining
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
    .maxstack  2
    .locals init ([0] valuetype Anarchy.Assist.Objects`1<!!T> Members)

    ldloca.s   0

    ldarg.0
    call       instance void valuetype Anarchy.Assist.Objects`1<!!T>::.ctor(native uint)
    ldloc.0
    ret
  } // end of method Array::Members

  //===============================
  // Array
  //===============================

  .method public static !!T[]  Array<T>(int32 Capacity) cil managed aggressiveinlining
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
    .maxstack  1

    ldarg.0
    newarr     !!T
    ret
  } // end of method Array::Array

  .method public static !!T[]  Array<T>(uint32 Capacity) cil managed aggressiveinlining
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
    .maxstack  1

    ldarg.0
    newarr     !!T
    ret
  } // end of method Array::Array

  .method public static !!T[]  Array<T>(int64 Capacity) cil managed aggressiveinlining
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
    .maxstack  1

    ldarg.0
    newarr     !!T
    ret
  } // end of method Array::Array

  .method public static !!T[]  Array<T>(uint64 Capacity) cil managed aggressiveinlining
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
    .maxstack  1

    ldarg.0
    newarr     !!T
    ret
  } // end of method Array::Array

  .method public static !!T[]  Array<T>(native int Capacity) cil managed aggressiveinlining
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
    .maxstack  1

    ldarg.0
    newarr     !!T
    ret
  }
  
  .method public static !!T[]  Array<T>(native uint Capacity) cil managed aggressiveinlining
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
    .maxstack  1

    ldarg.0
    newarr     !!T
    ret
  }
  //------------------------------------

  .method public static native int  IsIn<T>(!!T Input,
                                            !!T[] Store) cil managed aggressiveinlining
	{
	.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
	.maxstack  3
	.locals init ([0] native int IsIn,
						[1] native int Index,
						[2] native int VB$t_i$L0)
		ldc.i4.0
		ldarg.1
		ldlen
		ldc.i4.1
		sub
		stloc.2
		stloc.1
		br.s       IL_0033
  
  IL_000c:
		ldarga.s   Input
		ldarg.1
		ldloc.1
		ldelem !!T
		box        !!T
		constrained. !!T
		callvirt   instance bool [mscorlib]System.Object::Equals(object)
		brfalse.s  IL_002e

		ldloc.1
		ret

  IL_002e:
		ldloc.1
		ldc.i4.1
		add
		stloc.1

  IL_0033:
		ldloc.1
		ldloc.2
		ble.s      IL_000c

		ldc.i4.m1
		ret
	} // end of method Array::IsIn

	.method public static native int  IsIn<T>(!!T Input,
											  valuetype Anarchy.Assist.Objects`1<!!T> Store) cil managed aggressiveinlining
	{
	.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 )
	.maxstack  3
	.locals init ([0] native int IsIn,
				  [1] native int Index,
			      [2] native int VB$t_i$L0)
		
		ldarga.s   Store
		call       instance native uint valuetype Anarchy.Assist.Objects`1<!!T>::get_Length()
		conv.i
		stloc.2

		ldc.i4.0
		stloc.1
		br.s       IL_003d

  IL_0016:
		ldarga.s   Input
		ldarga.s   Store
		ldloc.1
		call       instance !0 valuetype Anarchy.Assist.Objects`1<!!T>::get_Items(native int)
		box        !!T
		constrained. !!T
		callvirt   instance bool [mscorlib]System.Object::Equals(object)
		brfalse.s  IL_0038

		ldloc.1
		ret

  IL_0038:
		ldloc.1
		ldc.i4.1
		add
		stloc.1

  IL_003d:
		ldloc.1
		ldloc.2
		ble.s      IL_0016

		ldc.i4.m1
		ret
	} // end of method Array::IsIn

	.method public static native int  DefinitelyIn<class T>(!!T Input, !!T[] Store) cil managed aggressiveinlining
	{
	.custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
	.maxstack  3
	.locals init ([0] native int IsIn,
				  [1] native int Index,
				  [2] native int VB$t_i$L0)
		ldc.i4.0
		ldarg.1
		ldlen
		ldc.i4.1
		sub
		stloc.2
		stloc.1
		br.s       IL_0033
  
  IL_000c:
		ldarg.1
		ldloc.1
		ldelem !!T
		ldarg.0
		bne.un.s  IL_002e

		ldloc.1
		ret

  IL_002e:
		ldloc.1
		ldc.i4.1
		add
		stloc.1

  IL_0033:
		ldloc.1
		ldloc.2
		ble.s      IL_000c

		ldc.i4.m1
		ret
	} // end of method Array::IsIn


} // end of class Anarchy.Assist.Array