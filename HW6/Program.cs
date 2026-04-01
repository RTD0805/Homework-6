public class Drink
{
    protected string DrinkName;
    protected double BasePrice;
    private static double _taxRate = 0.085;

    public Drink(string name, double price)
    {
        DrinkName = name;
        BasePrice = price;
    }

    public double CalculatedPrice()
    {
        return BasePrice * (1 + _taxRate);
    }

    public void ShowReciept()
    {
        
    }

}

public class Coffee : Drink
{
    private int _sugarGrams;
    private string _milkType;

    public Coffee(string name, double price, int sugar, string milk):base(name, price)
    {
        _sugarGrams = sugar;
        _milkType = milk;
    }

    public void AddSugar()
    {
        
    }

    public void SteamMilk()
    {
        
    }
}

public class Tea : Drink
{
    private int _steepTime;
    private string _teaLeafType;

    public Tea(string name, double price, int steepTime, string teaLeafType):base(name, price)
    {
        _steepTime = steepTime;
        _teaLeafType = teaLeafType;
    }

    public void Steep()
    {
        
    }

    public void RemoveBag()
    {
        
    }
}

public class Juice : Drink
{
    private int _pulpLevel;
    protected bool IsFreshPressed;

    public Juice(string name, double price, int pulpLevel, bool Isfreshpressed):base(name, price)
    {
        _pulpLevel = pulpLevel;
        IsFreshPressed = Isfreshpressed;
    }

    public void PressFruit()
    {
        
    }

    public void Strain()
    {
        
    }
}

public class Smoothie : Drink
{
    public string FruitType;
    private string _baseLiquid;

    public Smoothie(string name, double price, string fruitType, string baseLiquid):base(name, price)
    {
        FruitType = fruitType;
        _baseLiquid = baseLiquid;
    }

    public void Blend()
    {
        
    }

    public void AddProtein()
    {
        
    }
}

public class SeasonalSpecial : Drink
{
    private static int _limitedQuantity;
    private string _expirationDate;

    public SeasonalSpecial(string name, double price, string expirationDate):base(name, price)
    {
        _expirationDate = expirationDate;
        _limitedQuantity--;
    }

    public void CheckAvailability()
    {
        
    }

    public void ApplySeasonalDiscount()
    {
        
    }
}

public class Employee
{
    public string EmployeeName;
    private int _employeeID;
    private static int _totalStaff;

    public Employee(string name, int id)
    {
        EmployeeName = name;
        _employeeID = id;
        _totalStaff++;
    }
}
public class Customer
{
    public string CustomerName;
    private double _walletbalance = 25.00;
    protected int LoyaltyPoints = 150;
    public List<Drink> PurcahsedItems = new List<Drink>();

    public Customer(string name)
    {
        CustomerName = name;
    }

    public OrderDrink(Drink purchase, Employee barista)
    {
        
    }

    public void ViewBag()
    {
        
    }

    public double CalcualteGrandTotal()
    {
        
    }
}
