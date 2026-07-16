namespace ShopMaster;

public static class ProductService
{
    /*
          Task 01 : Smart Product Search
    
          Manager: "Customers search in all kinds of ways - by category, by price, by name, by stock... and the list keeps growing. I need ONE search method that works for any filter, now and in the future, without being modified".
    
          What You Need To Do: Write a single method called SearchProducts that accepts two parameters:
          1. The product list (List<Product>)
          2. A delegate representing the filter condition Func<Product, bool>
    
          The method should return a List containing only the products that satisfy the condition.
        */
    // Add brief comments in your code explaining which delegate type you used and why. 
    // because Func references a method that has a return type and I want to reference a method that returns bool.
    public static List<Product> SearchProducts(List<Product> products, Func<Product, bool> predicate)
    {
        List<Product> returnedProducts = [];

        foreach (var product in products)
        {
            if(predicate(product))
                returnedProducts.Add(product);
        }

        return returnedProducts;
    }
    
    /*
     3.1  Print Reports 
     Write a method called PrintReport that accepts the product list and an Action. The method loops through all 
     products and calls the action on each one. The caller decides what to print by passing a lambda. 
     */
    // Add brief comments in your code explaining which delegate type you used and why. 
    /*
      Action, because Action references a method that has no return type and here we are doing an operation that
      doesn't require to have a return type instead it takes the object that it will work on and the action
      that will be done.
    */
    public static void PrintReport(List<Product> products, Action<Product> PrintReportAction)
    {
        foreach(var product in products)
            PrintReportAction(product);
    }
    
    /*
     3.2. Transform Products 
     Write a method called TransformProducts that accepts the product list and a Func. 
     The method returns a List by applying the function to each product. 
     */
    // Add brief comments in your code explaining which delegate type you used and why. 
    // because Func references a method that has a return type and I want to reference a method which takes a 
    //  product object and returns a string based on it.
    public static List<string> TransformProducts(List<Product> products, Func<Product, string> Transform)
    {
        List<string> returnedProducts = [];

        foreach (var product in products)
            returnedProducts.Add(Transform(product));

        return returnedProducts;
    }
    
    /*
     3.3. Filter Products 
     Write a method called FilterProducts that accepts the product list and a Predicate. The method returns a 
     List of products that match the condition. 
     */
    public static List<Product> FilterProducts(List<Product> products, Predicate<Product> Filter)
    {
        List<Product> filteredProducts = [];
       
        foreach(var product in products)
            if (Filter(product))
                filteredProducts.Add(product);

        return filteredProducts;
    }
}