using System.Runtime.CompilerServices;

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
        Console.WriteLine($"Pressing fruit for the {DrinkName}.");
    }

    public void Strain()
    {
    Console.WriteLine($"{DrinkName} with pulp level {_pulpLevel}.");
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
        Console.WriteLine($"Blending {FruitType} with a {_baseLiquid} base for the {DrinkName}.");
    }

    public void AddProtein()
    {
        Console.WriteLine($"Add protein for the {DrinkName}.");
    }
}

public class SeasonalSpecial : Drink
{
    private static int _limitedQuantity = 50;
    private string _expirationDate;
   

    public SeasonalSpecial(string name, double price, string expirationDate):base(name, price)
    {
        _expirationDate = expirationDate;
    }

    public void CheckAvailability()
    {
            if (_limitedQuantity > 0)
            {
                Console.WriteLine($"{DrinkName} is available. Limited quantity: {_limitedQuantity}");
            }
            else
            {
                Console.WriteLine($"{DrinkName} is sold out.");
            }
    }

    public void ApplySeasonalDiscount()
    {
        if (_limitedQuantity > 0)
        {
            _limitedQuantity--;
            double discountPrice = BasePrice * 0.9; // 10% discount
            Console.WriteLine($"Applying seasonal discount for {DrinkName}. New price: {discountPrice:C2}");
        }
        else
        {
            Console.WriteLine($"Cannot apply discount. {DrinkName} is sold out.");
        }
    }
}

public class Employee
{
    public string EmployeeName;
    private int _employeeID;

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

    public void OrderDrink(Drink item, Employee barista)
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
        Coffee FancyLatte = new Coffee("Vanilla Oat Latte", 4.75, 4, "Oat Milk");
        Tea EarlGrey = new Tea("London Fog", 3.50, 3, "Earl Grey / Bergamot");
        Tea GreenTea = new Tea("Zen Matcha", 4.00, 2, "Ceremonial Matcha");
        Juice ClassicJuice = new Juice("Classic Orange", 3.00, 2, false);
        Juice GreenPower = new Juice("Emerald Squeeze", 6.50, 1, true);
        Smoothie BerryBlast = new Smoothie("Wild Berry", 5.50, "Mixed Berries", "Coconut Water");
        Smoothie BulkUp = new Smoothie("Protein Power", 7.00, "Banana", "Almond Milk");
        SeasonalSpecial CherryBlossom = new SeasonalSpecial("Cherry Blossom Latte", 5.50, "2026-05-01");
        SeasonalSpecial PeachSummer = new SeasonalSpecial ("Peach Summer Special", 5.95, "2026-08-31");

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

    // Scenario 2
    Customer JaneSmith = new Customer("Jane Smith", 50.00, 500);
    Employee Bob = new Employee("Bob Jones", 202);

    Console.WriteLine($"\nSCENE 2 - Customer {JaneSmith.CustomerName} orders three drinks from {Bob.EmployeeName}");

    JaneSmith.OrderDrink(GreenPower, Bob);
    JaneSmith.OrderDrink(BerryBlast, Bob);
    JaneSmith.OrderDrink(CherryBlossom, Bob);

    Console.WriteLine($"\nBarista {Bob.EmployeeName} Prepares the Drinks:\n");

    Console.WriteLine("Preparing GreenPower:");
    GreenPower.PressFruit();
    GreenPower.Strain();

    Console.WriteLine("\nPreparing BerryBlast:");
    BerryBlast.Blend();
    BerryBlast.AddProtein();

    Console.WriteLine("\nPreparing CherryBlossom:");
    CherryBlossom.CheckAvailability();
    CherryBlossom.ApplySeasonalDiscount();

    JaneSmith.ViewBag();
    Console.WriteLine($"\nGrand Total: {JaneSmith.CalcualteGrandTotal():C2}");

    Console.WriteLine("\nItem Details:");
    GreenPower.ShowReciept();
    BerryBlast.ShowReciept();
    CherryBlossom.ShowReciept();

    Bob.ProcessPayment(JaneSmith.CalcualteGrandTotal());
    }
}
