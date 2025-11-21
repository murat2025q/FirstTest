# C# Expression - Koşul Örnekleri

Bu dosya C# dilinde sık kullanılan koşul/ifade (expression) örneklerini içerir. Kısa ve doğrudan örnekler, farklı C# sürümlerinde kullanabileceğiniz ifadeleri gösterir.

## 1. if - else
```csharp
int x = 10;
if (x > 5)
{
    Console.WriteLine("x 5'ten büyük");
}
else
{
    Console.WriteLine("x 5 veya daha küçük");
}
```

## 2. Ternary (?:)
```csharp
int a = 7;
string result = a % 2 == 0 ? "çift" : "tek";
Console.WriteLine(result);
```

## 3. Switch Expression (C# 8+)
```csharp
int day = 3;
string name = day switch
{
    1 => "Pazartesi",
    2 => "Salı",
    3 => "Çarşamba",
    4 => "Perşembe",
    5 => "Cuma",
    6 => "Cumartesi",
    7 => "Pazar",
    _ => "Bilinmiyor"
};
Console.WriteLine(name);
```

## 4. Pattern Matching (is)
```csharp
object obj = "merhaba";
if (obj is string s)
{
    Console.WriteLine($"Uzunluk: {s.Length}");
}
```

## 5. Switch ile Pattern Matching ve when
```csharp
object value = 15;
string desc = value switch
{
    int n when n < 0 => "negatif",
    int n when n == 0 => "sıfır",
    int n when n > 0 => "pozitif",
    _ => "bilinmiyor"
};
Console.WriteLine(desc);
```

## 6. Null-coalescing (??) ve Null-coalescing assignment (C# 8+)
```csharp
string? maybe = null;
string text = maybe ?? "varsayılan"; // "varsayılan"

List<int>? list = null;
list ??= new List<int>(); // list artık boş bir liste olur
```

## 7. Mantıksal Operatörler
```csharp
bool a = true, b = false;
if (a && !b)
    Console.WriteLine("a doğru ve b yanlış");
```

## 8. Expression-bodied members
```csharp
public class Calculator
{
    public int Add(int x, int y) => x + y; // ifade gövdeli metod
    public int Square(int x) => x * x;
}
```

## 9. LINQ içinde koşullar
```csharp
var nums = new[] {1,2,3,4,5};
var even = nums.Where(n => n % 2 == 0).ToList();
```

## 10. Koşula bağlı atama örneği
```csharp
int stock = 0;
string status = stock > 0 ? "Stokta" : "Tükendi";
```

## Notlar
- Modern C# sürümleriyle (8, 9, 10 ve sonrası) switch expression ve pattern matching gibi güçlü ifade tarzları kullanabilirsiniz.
- Kod örnekleri konsol uygulaması bağlamında çalıştırılmak üzere basitçe yazıldı; gerçek projede null kontrolleri ve hata yönetimini unutmayın.