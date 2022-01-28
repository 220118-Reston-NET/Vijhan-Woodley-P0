namespace P0Model;
public class SmoothieModel
{

public string Name { get; set; }

private int _comboNumb;
public int ComboNumb
{
    get { return _comboNumb; }
    set { _comboNumb = value; }
}


private string _cupSize;
public string CupSize
{
    get { return _cupSize; }
    set { _cupSize = value; }
}


private List<string> _ingredients;
public List<string> Ingredients
{   
    get { return _ingredients; }
    set { _ingredients = value; }
}

private double _price;
public double Price
{
    get { return _price; }
    set { _price = value; }
}
public SmoothieModel()
{

}

public SmoothieModel(int ComboNumb)
{
    
    this._comboNumb = ComboNumb;
    _ingredients = new List<string>();
switch (ComboNumb)
{
    case 1 : 
    Name = "CoconutFusion";
    
    
     _ingredients.Add("Coconut");
     _ingredients.Add("Banana");
     _ingredients.Add("Spinach");
     _ingredients.Add("Pinapple");
     _ingredients.Add("Coconut Water");
    break;
    case 2 : 
    Name = "VeryBerry";
    
    
     _ingredients.Add("Strawberry");
     _ingredients.Add("Blueberry");
     _ingredients.Add("Spinach");
     _ingredients.Add("Raspberry");
     _ingredients.Add("Almondmilk");
    break;
    case 3 : 
    Name = "TropicalBreeze";
    
    
     _ingredients.Add("Mango");
     _ingredients.Add("Passion Fruit");
     _ingredients.Add("Spinach");
     _ingredients.Add("Pinapple");
     _ingredients.Add("Coconut Water");
    break;
    case 4 : 
    Name = "ProtienShake";
    
    
     _ingredients.Add("Chocolate Powder");
     _ingredients.Add("Banana");
     _ingredients.Add("Spinach");
     _ingredients.Add("Protien Powder");
     _ingredients.Add("Almond Milk");
    break;
    default:
    throw new Exception("Choose combo number from 1 - 4.");
    //break;
}
/*if(string.Equals(CupSize, "small", StringComparison.CurrentCultureIgnoreCase))
{
    Price = 5.00;
} else if (string.Equals(CupSize, "medium", StringComparison.CurrentCultureIgnoreCase))
{
    Price = 6.50;
} else if (string.Equals(CupSize, "large", StringComparison.CurrentCultureIgnoreCase))
{
    Price = 7.00;
} else 
{
    throw new Exception("Cupsize can be small, medium or large");
}*/
}

public SmoothieModel(int ComboNumb, string Cupsize)
{
    this.CupSize = Cupsize;
    this.ComboNumb = ComboNumb;
    _ingredients = new List<string>();
switch (ComboNumb)
{
    case 1 : 
    Name = "CoconutFusion";
    
    
     _ingredients.Add("Coconut");
     _ingredients.Add("Banana");
     _ingredients.Add("Spinach");
     _ingredients.Add("Pinapple");
     _ingredients.Add("Coconut Water");
    break;
    case 2 : 
    Name = "VeryBerry";
    
    
     _ingredients.Add("Strawberry");
     _ingredients.Add("Blueberry");
     _ingredients.Add("Spinach");
     _ingredients.Add("Raspberry");
     _ingredients.Add("Almondmilk");
    break;
    case 3 : 
    Name = "TropicalBreeze";
    
    
     _ingredients.Add("Mango");
     _ingredients.Add("Passion Fruit");
     _ingredients.Add("Spinach");
     _ingredients.Add("Pinapple");
     _ingredients.Add("Coconut Water");
    break;
    case 4 : 
    Name = "ProtienShake";
    
    
     _ingredients.Add("Chocolate Powder");
     _ingredients.Add("Banana");
     _ingredients.Add("Spinach");
     _ingredients.Add("Protien Powder");
     _ingredients.Add("Almond Milk");
    break;
    default:
    throw new Exception("Choose combo number from 1 - 4.");
    //break;
}
if(string.Equals(CupSize, "small", StringComparison.CurrentCultureIgnoreCase))
{
    Price = 5.00;
} else if (string.Equals(CupSize, "medium", StringComparison.CurrentCultureIgnoreCase))
{
    Price = 6.50;
} else if (string.Equals(CupSize, "large", StringComparison.CurrentCultureIgnoreCase))
{
    Price = 7.00;
} else 
{
    throw new Exception("Cupsize can be small, medium or large");
}
}

public SmoothieModel(string Cupsize)
{
    this.CupSize = Cupsize;
    if(string.Equals(CupSize, "small", StringComparison.CurrentCultureIgnoreCase))
{
    Price = 5.00;
} else if (string.Equals(CupSize, "medium", StringComparison.CurrentCultureIgnoreCase))
{
    Price = 6.50;
} else if (string.Equals(CupSize, "large", StringComparison.CurrentCultureIgnoreCase))
{
    Price = 7.00;
} else 
{
    throw new Exception("Cupsize can be small, medium or large");
}
}

public override string ToString()
{
    return $"Name : {Name}\nCup size : {CupSize}\nPrice : ${Price}";
}

}
