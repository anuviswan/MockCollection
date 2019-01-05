**Randomize.Net**

Randomize.Net provides an easy and lightweight extensions for **System.Random** for creating random instances of any type, with generated random value. 

For Example,

```csharp
var _random = new Random();_
var randomString = _random.GenerateInstance<string>(); 
var randomInt32 = _random.GenerateInstance<int32>();
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

var sampleClass = _random.GenerateInstance<SampleClass>();
var anotherSampleClass = _random.GenerateInstance<AnotherSampleClass>();
```


