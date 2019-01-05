**Randomize.Net**

Randomize.Net provides an easy and lightweight solution for creating instances of any type, with generated random value. 

For Example,

```csharp
var randomString = Randomize.GenerateInstance<string>(); 
var randomInt32 = Randomize.GenerateInstance<int32>();
```

Randmize.Net works with User Defined Types as well, including nested User Defined Types.

```csharp
public class SampleClass
{
    public string StringProperty{get;set;}
    public int Int32Property {get;set;}
    public char CharProperty {get;set;}
}

public class AnotherSampleClass
{
    public SampleClass SampleClassProperty{get;set;}
    public string StringProperty{get;set;}
}

var sampleClass = Randomize.GenerateInstance<SampleClass>();
var anotherSampleClass = Randomize.GenerateInstance<AnotherSampleClass>();
```


