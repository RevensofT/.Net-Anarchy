# .Net-Anarchy
Throw rules of Vb.net and C# away, we on our own.
***

## What're we already anarchy ?
- Get size of reference type.
- Direct cast object without limited.
- Copy all field between structure and class.
- Raw byte copy directly between any object.
- Get and invoke from method address directly.
- Full access and modify any object. (2014/05/24)
- ~~Disguise object to other type, common parrent wanna be a child too.(2014/05/26)~~
- Convert class to other class. (2014/07/22)
- Convert array to other array's type. (2014/07/22)
- Reference pointer and generic pointer. (2014/07/22)
- Ultimate object collection. (2014/07/22)

# Something I create for make my life easier.
- Native integer calculate (2014/07/22)
- Manage WinAPI : file system and memory. (2014/07/22)

## Get size of reference type
```vb
Dim MyVar As New MyType
Dim Size = MyVar.Size(MyVar.LastField)
```
```c#
MyType MyVar = new MyType();
var Size = MyVar.Size(ref MyVar.LastField);
```
I alway wonder why I can't find any function that give me a size of my class, I find many reason that said why can't but you know what, I find a way to get a raw data size on memory.
It's much faster to get size of type by instance object then crawing on class structure, all you need to to do is mark start point and end point of it and measure it.

## Direct cast object without limited.
```vb
Dim VarA As New TypeA
Dim VarB As TypeB = VarA.As(Of TypeB)
```
```c#
TypeA VarA = new TypeA();
TypeB VarB = VarA.As<TypeB>();
```
Well, it's just a dance of illusions of IDE and compiler that make you believe in OOP illusions.
However, don't touch an array type, I warn you unless you have a holy water for cure a curse from it. xD

Oh, it still can cast between reference type to reference type and value type to value type but don't worry I already have other method to do that.

## Copy all field between structure and class
```vb
Dim FromBytes As Short
Call New With {.A = CByte(1), .B = CByte(1)}.CopyTo(FromBytes)

'FromBytes == 257
```
```c#
short FromBytes = 0;
new {A = (byte)1, B = (byte)1}.CopyTo(FromBtyes);

//Sadly C# can't use extension method when first argument call by ref.
//So you can't copy from class to structure request by extension method, need to do it normally.
```
Much easier for transfer a data from reference type to value type but this method is measure size of data it going to copy by structure size... what ? you still don't satisfied with this, well I still have a trick in my sleeve. ;)

## Raw byte copy directly between any object
```vb
Dim Box(1) As Byte
Call (258).RawCopyTo(Box(0), 2) ' Copy 2 bytes from 258 to Box since element index 0.

'Box == {2, 1}
```
```c#
byte[] Box = new byte[2];
short MyVal = 258;
Anarchy.Convert.RawCopyTo<short, byte>(ref MyVal, ref Box[0], (uint)2);

//Sadly C# can't use extension method when first argument call by ref.
```
Now you are become a wizard, you can copy any data of any object to other object just by reference to a field of an object you want to start copy and a field of an object you want to paste that data then push a number of byte of that data you want but beware you mighty spell might be not over come the mighty of authority.

***
Well, let's us get to a highlight feature that I pray for it long long time but well... make a devil contract is much faster than wait for a god. xD

# Get and invoke from method address directly
```vb
Module Module1

    Sub Main()
      MainLine.WriteLine()
        Dim Base As New Calculus With {.A = 12, .B = 4}

        Dim Methods = {New System.Func(Of Integer)(AddressOf Base.Add).Address,
                       New System.Func(Of Integer)(AddressOf Base.Sub).Address,
                       New System.Func(Of Integer)(AddressOf Base.Mul).Address,
                       New System.Func(Of Integer)(AddressOf Base.Div).Address}

        Dim Operators = {"+", "-", "*", "\"}
        Dim Report = New System.Action(Of String)(AddressOf Base.Report).Address

        For Each Item In {Base,
                          New Point3D With {.X = 9, .Y = 8, .Z = 7},
                          New Dimenstion With {.Height = 60, .Width = 40}}
            For i = 0 To 3
                'Auto set generic type for no return method.
                Report.Invoke(Item, Operators(i))

                'For function, request to specify type of this object and arguments.
                Methods(i).Invoke(Of Object, Integer)(Item).WriteLine()
            Next
        Next
    End Sub
```

```
'===================================================
' Test litegate
'---------------------------------------------------
Result of 12 + 4 = 16
Result of 12 - 4 = 8
Result of 12 * 4 = 48
Result of 12 \ 4 = 3

Result of 9 + 8 = 17
Result of 9 - 8 = 1
Result of 9 * 8 = 72
Result of 9 \ 8 = 1

Result of 60 + 40 = 100
Result of 60 - 40 = 20
Result of 60 * 40 = 2400
Result of 60 \ 40 = 1

'===================================================
```
Let's me talk about what's going on in code above like an evil genius talk about their plan to good guy.

1. I create an instance object that going to be a base for other.
2. I get all method address I want from create delegates of that instance object.
3. Set up for a pretty report.
4. Start pack all objcet I want to use; now, ALL OBJECT do an instance invoke from every method address I have collected.
5. What's going on here you will never able to do it by delegate... ok, you might be able do it by `Delegate.CreateDelegate` but you going to pay a huge price for it; anyway, what's going on there is each object start to invoke each method in loop; it's a lot save a time. 
  - You don't need to inherit those type to make it use the same instance method.
  - You don't need to call each method every time, just push it into array and sent it to anywhere by UPS. xD
  - You don't have to worry if you spam spawn too many litegate, it's really light weight, much more light weight then delegate.
  - BUT you need to be careful when invoke it, make sure all of your argument be in the right place, if you instance invoke FIRST OBJECT MUST BE `this` object of an instance that method is member of it; like example above, `Add()` doesn't has any argument on declare but when use as instance method, it real form is `Add(This As Calculus)` that mean when I invoke it I must sent a data that has farmilar structure with `Calculus` type as 1st argument like `Add(Base)` instead of `Add()`.
 
***
# Full access and modify any object

>Update 2015/05/26
>
>I change method name from `Copy` to `CopyTo`.

Why we still use inheritance when we can access all member of object already !!
even an immutable class doesn't escape from our hand !! let's see how we could do that.

1. You need to get pointer of object you want to mess abound, Anarchy has 3 methods to get them.
    - ByRef : for any value type object but you could use it on class's field or array's element for direct access into that postion(like you want to get pointer from array index 3)
    - ByArray : for an array type object, start with first element of that array, it has optional argument to shift byte if you don't want to start from first element.
    - ByClass : same as ByArray but use for any reference type, start with first field of object.
    - Shift : use for move pointer in byte you got from 3 methods above.
2. You need to know how much length you want to copy(of course in bytes unit).
3. You need a container of data, you might be access anything but you still need to push them somewhere in .net.

```VB
Dim Word = "My World"
Call "Our".ByArray.CopyTo(Word.ByArray, 2 * 3)

'Word = "OurWorld"
```
In this example I copy data from `"Our"` into `Word`, yep I just change data of immutable type. 
`2 * 3 '== Size of char * number of char in word`. 
Oh, if you don't get it why would I use `ByArray`, it's simple string is array of char.

***
##Disguise object in to other type.

>Update 2015/07/22
>
>I rename this method to CClass.

Are you tired about the rule that said parrent could not be child ? but many parrent want to be a child sometime why should we stop them, let's it go.

```VB
Public Class Add
    Public X, Y As Integer
    Public Overridable Function Process() As Integer
        Return X + Y
    End Function
End Class

Public Class Mul
    Inherits Add
    Public Overrides Function Process() As Integer
        Return X * Y
    End Function
End Class

    Sub Disguise()
        Dim Math As New Add With {.X = 3, .Y = 5}
        Dim Result As Integer
        
        'Add 3 and 5
        Result = Math.Process ' = 8
        
        'Try to cast as mul type
        Result = Math.As(Of Mul).Process ' = 8
        
        'Well, then disguise as mul
        Dim NewMath As Mul = Math.CClass(New Mul) 'rename from DisguiseAs to CClass.
        Result = NewMath.Process ' = 15
        
        '** Math will become nothing(null) after convert.**
    End Sub
```

Why's it request an instance object not just a type ? sadly I still not master of metadata of object so I have to copy it from somewhere since I can't create it on my own but on the bright side, you still can disguise any object to any reference type. :wink:

***
## Convert array.
Isn't it boring and waste of your time to copy each member of array to other array just because it's not the same type even you know it is the same thing like direct cast all child class array to parent class array or something like integer array to byte array; well you don't need to do that any more just grab a red pill !

```VB
        Dim Base() As Byte = {0, 1, 0, 2}

        Dim BeShort() As UShort = Base.CArray(Of UShort)()
        'BeShort = {256, 512}
        'Base = Nothing
```

It's very simple, isn't it; but one thing you must remember is after you convert array or class, those variant will become nothing to prevent any error from IDE.

## Reference pointer and generic pointer.
What's a bad day that Vb.net can't use any pointer because deverloper said you don't need it, even on C# you still have some limit to use it; what's a point to keep a powerful tool from you(maybe a weapon of mass destruction for someone xD) go and grab it !

```VB
        Dim Base() As Byte = {0, 1, 0, 2}
        
        'Read only pointer for reference type
        Dim PBase = Base.ByVal
        
        'Load reference object from pointer and load element index 3.
        Dim Element4 = PBase.Load(3) 'Element4 = 2
        
        'Reference pointer that you can get or set value of destination.
        Dim RElement2 = Base(1).ByRef
        
        'Reference pointer has Value property for easy get and set value.
        RElement2.Value = 3 ' Base = {0, 3, 0, 2}
```
You can adapt it to any member of class or structure you want to point to but make sure that object still alive while you point to it.

## Ultimate object collection.
You have 3 object and each of them have difference type, what's you can do is create an array(collection) of object or create a structure to hold it, isn' it ? well, what if you just want quickly pack everything up without wasting your time to create a structure or boxing value type ? let's get Jinx !

```VB
        'Create a collection size 32 bytes.
        Dim Jx As New Jinx(32)
        
        Jx.Push(256S) '(short)256 for C#
        Jx.Push(-1)
        
        'Make a reference pointer of string for next item.
        Dim JxR = Jx.Ref(Of String)()
        
        Jx.Push("Hello")
        
        'Load value from refence pointer of string.
        JxR.Value.WriteLine()
        
        'Let's pop all value from jinx box.
        Jx.Pop(Of String).WriteLine()
        Jx.Pop(Of Integer).WriteLine()
        Jx.Pop(Of UShort).WriteLine()
```
Very easily and simple but you must very carful when use this collection, I don't name it Jinx for no reason; other dev won't know what's you packing into this Jinx(I really want to name it Padora's box) and they never know how much is it large; so don't use it on API unless you want to make it as a black box.

## Native integer calculate.
Not much to show but lately I heavily use native integer and I have to use it on some calculate so I create some method to help me; now it has addition, subtraction, mulitply, division and remainder. 

## Manage WinAPI : file system and memory.
Not much to say but if you want to use WinAPI then grab it, I even make it read or write a structure to file.

```VB
        '-----------------------------------------------
        'Anarchy.Assist.Stream 
        '-----------------------------------------------
        For Each Item In {"Z:\Test.txt", "Z:\Test2.txt", "Z:\Test3.txt", "Z:\Test4.txt"}
            With Item.OpenRead
                Call "File Name : ".Write()
                Item.WriteLine()

                Dim Size As UInteger = .Size
                Call "File Size : ".Write()
                Size.WriteLine()
                
                'byte[] Tmp = new byte[Size]; 'I hate index initilaization of VB language.
                Dim Tmp = Size.Array(Of Byte)()

                Call "File Read : ".Write()
                .ReadTo(Tmp.ByArray, Size).WriteLine()

                Call "File Data : ".Write()
                String.Join(",", Tmp).WriteLine()

                Call "".WriteLine()
                .Dispose()
            End With
        Next

        '-----------------------------------------------
        ' Native example
        '-----------------------------------------------
        Dim Address = "Z:\Test.txt"
        Dim File = Native.File.Open(Address, IO.FileAccess.ReadWrite, IO.FileShare.None,
                                    New Native.File.SECURITY_ATTRIBUTES,
                                    IO.FileMode.OpenOrCreate, IO.FileOptions.None, Nothing)
        Native.File.Read(File, Buff.ByArray, 2, Counter, 0)
```

# It's not even my final form
Ok guys, I might be out of trick...for now but you guys can give me a request what's kind of feature you want, maybe me or someone else can pull that trick and if you have your own trick that you want to share just pull a request, I need it  more from everyone to ANARCHY us from rule that create by C# and VB.net.

## By the way
Github might be show you that my project wrote by `VB.net` 100% but it's a lie... well let's say Github misunderstand about my code language in this project; MOST of code in this is `MSIL`, I have some Vb.net code for markup to make this project easy to test and edit with example project. If you looking for code, open `*.il`, most of `*.vb` is just for show except in example project.
