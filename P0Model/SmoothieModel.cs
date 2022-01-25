namespace P0Model;
public class SmoothieModel
{

public string Name { get; set; }

public int ComboNumb { get; set; }

private List<string> _ingredients;
public List<string> Ingredients
{   
    get { return _ingredients; }
    set { _ingredients = value; }
}

private int _price;
public int Price
{
    get { return _price; }
    set { _price = value; }
}

public SmoothieModel(int ComboNumb)
{
    this.ComboNumb = ComboNumb;
    _ingredients = new List<string>();
switch (ComboNumb)
{
    case 1 : 
    Name = "CoconutFusion";
    Price = 6;
    
     _ingredients.Add("Coconut");
     _ingredients.Add("Banana");
     _ingredients.Add("Spinach");
     _ingredients.Add("Pinapple");
     _ingredients.Add("Coconut Water");
    break;
    case 2 : 
    Name = "VeryBerry";
    Price = 5;
    
     _ingredients.Add("Strawberry");
     _ingredients.Add("Blueberry");
     _ingredients.Add("Spinach");
     _ingredients.Add("Raspberry");
     _ingredients.Add("Almondmilk");
    break;
    case 3 : 
    Name = "TropicalBreeze";
    Price = 6;
    
     _ingredients.Add("Mango");
     _ingredients.Add("Passion Fruit");
     _ingredients.Add("Spinach");
     _ingredients.Add("Pinapple");
     _ingredients.Add("Coconut Water");
    break;
    case 4 : 
    Name = "ProtienShake";
    Price = 7;
    
     _ingredients.Add("Chocolate Powder");
     _ingredients.Add("Banana");
     _ingredients.Add("Spinach");
     _ingredients.Add("Protien Powder");
     _ingredients.Add("Almond Milk");
    break;
    default:
    throw new Exception("Choose combo number from 1 - 4.");
    break;
}
}

}
