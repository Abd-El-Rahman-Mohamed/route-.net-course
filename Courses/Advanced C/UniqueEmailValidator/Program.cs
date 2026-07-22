// Exercise 4: Unique Email Validator
namespace UniqueEmailValidator;

class Program
{
    // Use Collection to manage unique email addresses.
    static void Main(string[] args)
    {
        // 1. Create a HashSet<string> with a case-insensitive comparer:
        //  new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        
        // 2. Add these emails: "ahmed@test.com", "AHMED@test.com", "sara@test.com", "Sara@Test.Com"
        emails.Add("ahmed@test.com");
        emails.Add("AHMED@test.com");
        emails.Add("sara@test.com");
        emails.Add("Sara@Test.Com");
        
        // 3. Print Count — how many are actually stored? Explain why.
        Console.WriteLine($"How many emails are actually stored?  {emails.Count}");
        // It will print only 2 because we ignored the case of strings so:
        //  - "ahmed@test.com" and "AHMED@test.com" are considered the same, so they are counted as only 1 
        //  - "sara@test.com" and "Sara@Test.Com" are considered the same, so they are counted as only 1
        
        // 4. Create two sets: Set A = {1,2,3,4,5} and Set B = {4,5,6,7,8}
        HashSet<int> a = new() { 1, 2, 3, 4, 5 };
        HashSet<int> b = new() { 4, 5, 6, 7, 8 };
        
        // 5. Print the result of: UnionWith, IntersectWith, ExceptWith
        // UnionWith
        Console.WriteLine();
        Console.WriteLine("--- UnionWith ---");
        a.UnionWith(b);
        foreach (var setItem in a)
            Console.Write($"{setItem} ");
        
        // IntersectWith
        Console.WriteLine("\n");
        Console.WriteLine("--- IntersectWith ---");
        a.IntersectWith(b);
        foreach (var setItem in a)
            Console.Write($"{setItem} ");
        
        // ExceptWith
        // We can reset the values of HashSet a because the previous two operations has changed its value,
        //  so we can reset its value to the initialization values to test the `ExceptWith` operation
        a.Clear();
        a.Add(1); a.Add(2); a.Add(3); a.Add(4); a.Add(5);
        Console.WriteLine("\n");
        Console.WriteLine("--- ExceptWith ---");
        a.ExceptWith(b);
        foreach (var setItem in a)
            Console.Write($"{setItem} ");
        
        // 6. Use IsSubsetOf to check if {1,2} is a subset of Set A
        
        // Also reseting Set A
        a.Clear();
        a.Add(1); a.Add(2); a.Add(3); a.Add(4); a.Add(5);
        
        HashSet<int> setToCheck = new() { 1, 2 };
        Console.WriteLine("\n");
        Console.WriteLine($"Is {{ 1, 2 }} is a subset of Set A? {(setToCheck.IsSubsetOf(a) ? "Yes" : "No")}");
    }
}