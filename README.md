# .Net-Anarchy
Throw rules of Vb.net and C# away, we on our own.
***

##What're we already anarchy ?
- Get size of reference type.
- Direct cast object without limited.
- Copy all field between structure and class.
- Raw byte copy directly between any object.
- `Get and invoke from method address directly.`

## Get size of reference type
```vb
Dim MyVar As New MyType
Dim Size = MyVar.Size(MyVar.LastField)
```
I alway wonder why I can't find any function that give me a size of my class, I find many reason that said why can't but you know what, I find a way to get a raw data size on memory.
It's much faster to get size of type by instance object then crawing on class structure, all you need to to do is mark start point and end point of it and measure it.

## Direct cast object without limited.
```vb
Dim VarA As New TypeA
Dim VarB As Type B = VarA.As(Of TypeB)
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
Much easier for transfer a data from reference type to value type but this method is measure size of data it going to copy by structure size... what ? you still don't satisfied with this, well I still have a trick in my sleeve. ;)

## Raw byte copy directly between any object
```vb
Dim Box(1) As Byte
Call (258).RawCopyTo(Box(0), 2) ' Copy 2 bytes from 258 to Box since element index 0.

'Box == {2, 1}
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
# It's not even my final form
Ok guys, I might be out of trick...for now but you guys can give me a request what's kind of feature you want, maybe me or someone else can pull that trick and if you have your own trick that you want to share just pull a request, I need it  more from everyone to ANARCHY us from rule that create by C# and VB.net.

## By the way
Github might be show you that my project wrote by `VB.net` 100% but it's a lie... well let's say Github misunderstand about my code language in this project; MOST of code in this is `MSIL`, I have some Vb.net code for markup to make this project easy to test and edit with example project. If you looking for code, open `*.il`, most of `*.vb` is just for show except in example project.
