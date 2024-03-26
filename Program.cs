public class Item
{
    public string name
    {
        get;
    }
    private int quantity;
    private DateTime createdDate;


    public int Quantity
    {
        get { return quantity; }
        set
        {
            try
            {
                if (value >= 0)
                    quantity = value;
                else
                    throw new ArgumentException("Quantity cannot be negative.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }

    public DateTime CreatedDate
    {
        get { return createdDate; }
        set { createdDate = value; }
    }

    public Item(string name, int quantity, DateTime createdDate = default)
    {


        if (quantity < 0)
        {
            throw new ArgumentException("Quantity cannot be negative.");
        }
        this.name = name;
        this.quantity = quantity;
        this.createdDate = createdDate == default ? DateTime.Now : createdDate;


    }

    public override string ToString()
    {
        return $"{name} - {quantity} - {createdDate}";
    }
}

public class Store
{
    private List<Item> items = new List<Item>();
    private int MaximumCapacity;


    public Store(int MaximumCapacity)
    {
        this.MaximumCapacity = MaximumCapacity;
        items = new List<Item>();
    }



    public void AddItem(Item item)
    {
        bool isItemExist = items.Any((i) => i.name == item.name);
        if (isItemExist)
        {
            throw new ArgumentException($"Item {item.name} already exists.");

        }
        if (GetCurrentVolume() > MaximumCapacity)
        {
            throw new InvalidOperationException("Maximum Capcity");

        }

        items.Add(item);


    }

    public void PrintItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine($"{item}");
        }

    }

    public void RemoveItemByName(string itemName)
    {
        Item itemToRemove = items.FirstOrDefault(i => i.name == itemName);
        if (itemToRemove != null)
        {
            items.Remove(itemToRemove);
            throw new ArgumentException($"Item {itemName} removed successfully");


        }
        else
        {
            throw new ArgumentException($"Item '{itemName}' not found.");


        }
    }

    public int GetCurrentVolume()
    {

        return items.Sum(item => item.Quantity);
    }

    public Item FindItemByName(string itemName)
    {
        // find the item 
        Item itemFound = items.FirstOrDefault(i => i.name == itemName);
        return itemFound;


    }

    public List<Item> SortByNameAsc()
    {
        return items.OrderBy(i => i.name).ToList();
    }




}


public class MyClass
{
    public static void Main(string[] args)
    {

        try
        {
            var waterBottle1 = new Item("Water Bottle 1", 10, new DateTime(2023, 1, 1));
            var waterBottle2 = new Item("Water Bottle 2", 5, new DateTime(2023, 1, 1));
            var coffee = new Item("Coffee", 20);
            var sandwich = new Item("Sandwich", 15);
            var batteries = new Item("Batteries", 10);
            var umbrella = new Item("Umbrella", 5);
            var sunscreen = new Item("Sunscreen", 8);

            var store = new Store(100);


            store.AddItem(waterBottle1);
            store.AddItem(waterBottle2);
            store.AddItem(coffee);
            store.AddItem(sandwich);
            store.AddItem(batteries);
            store.AddItem(umbrella);
            store.AddItem(sunscreen);




            // store.PrintItems();
            // Console.WriteLine("--------------------------");
            //  store.RemoveItemByName("Coffee");


            Console.WriteLine($"{store.GetCurrentVolume()}");

            Console.WriteLine(store.FindItemByName("Coffee"));


            var collections = store.SortByNameAsc();
            foreach (var item in collections)
            {
                Console.WriteLine($"{item}");

            }

        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }








    }
}