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
        Console.WriteLine($"Your {DrinkName} {CalculatedPrice():C2}");
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
         Console.WriteLine($"Adding {_sugarGrams}g sugar for the {DrinkName}.");

    }

    public void SteamMilk()
    {
        Console.WriteLine($"Steaming {_milkType} for the {DrinkName}.");
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
        Console.WriteLine($"Steeping exactly {_steepTime} minutes for the {DrinkName}.");
    }

    public void RemoveBag()
    {
        Console.WriteLine($"Remove tea bag for the {DrinkName}.");
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
    }
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"\n{EmployeeName} processing payment of {amount:C2}...");
        Console.WriteLine("Payment accepted. Thank You!");
    }
}
public class Customer
{
    public string CustomerName;
    private double _walletbalance;
    protected int LoyaltyPoints;
    public List<Drink> PurcahsedItems = new List<Drink>();

    public Customer(string name, double balance, int points)
    {
        CustomerName = name;
        _walletbalance = balance;
        LoyaltyPoints = points;
    }

    public OrderDrink(Drink purchase, Employee barista)
    {
        double cost = item.CalculatedPrice();

        if (cost <= _walletbalance)
        {
            _walletbalance -= cost;
            LoyaltyPoints += 25;
            PurcahsedItems.Add(item);
            Console.WriteLine($"Sucess! Wallet: {_walletbalance:C2} | Points: {LoyaltyPoints}");
        }
        else
            Console.WriteLine($"{CustomerName}, you need {cost:C2} to purchase but you only have {_walletbalance}.");
    }

    public void ViewBag()
    {
        Console.WriteLine($"\n{CustomerName} views the bag:");
        foreach (Drink item in PurcahsedItems)
        {
            item.ShowReciept();
        }
    }

    public double CalcualteGrandTotal()
    {
        double total = 0.0;
        foreach (Drink item in PurcahsedItems)
        {
          total += item.CalculatedPrice();
        }
        return total;
    }
}

class Program
{
    static void Main()
    {
        //build our menu
        Coffee MorningJoe = new Coffee("House Blend", 2.50, 0, "None");
        Tea EarlGrey = new Tea("London Fog", 3.50, 3, "Earl Grey / Bergamot");

        Employee Alice = new Employee("Alice Smith", 101);

        //Customer visits
        Customer JohnDoe = new Customer("John Doe", 25.00, 150);

        // Scenario 1
        Console.WriteLine($"SCENE 1 - Customer {JohnDoe.CustomerName} orders two drinks from {Alice.EmployeeName}.");
        JohnDoe.OrderDrink(MorningJoe, Alice);
        JohnDoe.OrderDrink(EarlGrey, Alice);

        Console.WriteLine($"\nBarista {Alice.EmployeeName} prepares the drinks:");
        Console.WriteLine("\nPreparing MorningJoe");
        MorningJoe.AddSugar();
        MorningJoe.SteamMilk();

        Console.WriteLine("\nPreparing EarlGrey");
        EarlGrey.Steep();
        EarlGrey.RemoveBag();

        // Console.WriteLine($"Customer {JohnDoe.CustomerName}views the bag:");
        JohnDoe.ViewBag();
        Console.WriteLine($"Grand Total: {JohnDoe.CalcualteGrandTotal():C2}");

        Console.WriteLine("Item Details:");
        MorningJoe.ShowReciept();
        EarlGrey.ShowReciept();

        Alice.ProcessPayment(JohnDoe.CalcualteGrandTotal());
    }
}
