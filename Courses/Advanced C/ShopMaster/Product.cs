namespace ShopMaster;

/*
 Starter Code: Data Models & Product Catalog 
 Before building any features, you need to set up the data models. Copy the following Product class and product
  catalog into your project. This is shared starter code — all subsequent tasks will use this data.

 1. Product Model 
 */
public class Product
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Category { get; set; } // "Electronics", "Clothing", "Food", "Books"
    public double Price {get; set;}
    public int Stock { get; set; }
}