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

            quantity = value;



        }
    }

    public DateTime CreatedDate
    {
        get { return createdDate; }
        set { createdDate = value; }
    }

    public Item(string name, int quantity, DateTime createdDate = default)
    {
        try
        {
            if (quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative.");
            }

            this.name = name;
            this.quantity = quantity;
            this.createdDate = createdDate == default ? DateTime.Now : createdDate;

        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }


    }

    public override string ToString()
    {
        return $"{name} - {quantity} - {createdDate}";
    }
}

public class Store
{
    public enum SortOrder
    {
        ASC,
        DESC
    }

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
        try
        {
            if (isItemExist)
            {
                throw new ArgumentException($"Item {item.name} already exists.");

            }
            if (GetCurrentVolume() + item.Quantity > MaximumCapacity)
            {
                throw new InvalidOperationException("Maximum Capcity");

            }

            items.Add(item);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);

        }


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
        try
        {
            Item itemToRemove = items.FirstOrDefault(i => i.name == itemName);
            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);
                Console.WriteLine($"Item {itemName} removed.");


            }
            else
            {
                throw new ArgumentException($"Item {itemName}  not found.");

            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

    }


    public int GetCurrentVolume()
    {

        return items.Sum(item => item.Quantity);
    }

    public Item FindItemByName(string itemName)
    {
        Item itemFound = items.FirstOrDefault(i => i.name == itemName);
        return itemFound;

    }

    public List<Item> SortByNameAsc()
    {
        return items.OrderBy(i => i.name).ToList();
    }

    public List<Item> SortByDate(SortOrder sortOrder)
    {
        switch (sortOrder)
        {
            case SortOrder.ASC:
                return items.OrderBy(i => i.CreatedDate).ToList();
            case SortOrder.DESC:
                return items.OrderByDescending(i => i.CreatedDate).ToList();

            default:
                return items.OrderBy(i => i.CreatedDate).ToList();
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
        var sandwich = new Item("Sandwich", -15);
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

        Console.WriteLine("--------------------------");

       


        var collectionSortedByDateAsc = store.SortByDate(Store.SortOrder.ASC);
       

        foreach (var item in collectionSortedByDateAsc)
        {
            Console.WriteLine($"{item}");
        }

                Console.WriteLine("--------------------------");


         var collectionSortedByDateDesc = store.SortByDate(Store.SortOrder.DESC);
      

        foreach (var item in collectionSortedByDateDesc)
        {
            Console.WriteLine($"{item}");
        }




      







    }




}
