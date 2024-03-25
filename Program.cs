public class Item
{
    private readonly string _name;
    private int quantity;
    private DateTime createdDate;

    public string Name
    {
        get
        {
            return _name;
        }

    }
    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public DateTime CreatedDate
    {
        get { return createdDate; }
        set { createdDate = value; }
    }

    public Item(string _name, int quantity, DateTime createdDate = default)
    {
        this._name = _name;
        this.quantity = quantity;
        this.createdDate = createdDate;
    }

    public override string ToString()
    {
        return $"{_name} - {quantity} - {createdDate}";
    }
}

public class Store
{
    private List<Item> items = new List<Item>();

 

    public void AddItem(Item item)
    {
        bool isItemExist = items.Any((i) => i.Name == item.Name);
        if (isItemExist)
        {
            Console.WriteLine($"Item {item.Name} already exist");
            return;
        }
        items.Add(item);
    }

    public void PrintItems(){
        foreach(var item in items){
            Console.WriteLine($"{item}");
        }

    }

    public bool RemoveItemByName(string itemName)
    {
         Item itemToRemove = items.FirstOrDefault(i => i.Name == itemName);
        if (itemToRemove != null)
        {
            items.Remove(itemToRemove);
            Console.WriteLine($"Item {itemName} removed successfully");
            return true;
        }
        else
        {
            Console.WriteLine($"Item {itemName} not found");
            return false;
        }
    }



}







public class MyClass
{
    public static void Main(string[] args)
    {



        var waterBottle1 = new Item("Water Bottle 1", 10, new DateTime(2023, 1, 1));
        var waterBottle2 = new Item("Water Bottle 2", 5, new DateTime(2023, 1, 1));
        var coffee = new Item("Coffee", 20);
        var sandwich = new Item("Sandwich", 15);
        var batteries = new Item("Batteries", 10);
        var umbrella = new Item("Umbrella", 5);
        var sunscreen = new Item("Sunscreen", 8);


        // Console.WriteLine($"{waterBottle1}");
        // Console.WriteLine($"{coffee}");



        var store = new Store();
        store.AddItem(waterBottle1);
        store.AddItem(waterBottle2);
        store.AddItem(coffee);
        store.AddItem(sandwich);
        store.AddItem(batteries);
        store.AddItem(umbrella);
        store.AddItem(sunscreen);

      

       store.PrintItems();
       Console.WriteLine("--------------------------");
       store.RemoveItemByName("Coffee");
       // print items after removing
       store.PrintItems();

        // store.DeleteItem("Water Bottle");

        // Console.WriteLine($"{store.GetCurrentVolume()}");

        // Console.WriteLine(store.FindItemByName("Coffee"));

        // Console.WriteLine("------------------------");

        // var collections = store.SortByNameAsc();
        // foreach (var item in collections)
        // {
        //     Console.WriteLine($"{item}");

        // }








        // List<int> numbers = new List<int>{1, 2, 3, 4, 5, 6, 7};

        // int firstGreaterThanFour = numbers.FirstOrDefault(num => num > 4);
        // Console.WriteLine($"{firstGreaterThanFour}");




    }
}