


public class MyClass
{
    public static void Main(string[] args)
    {


        var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
        var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
        var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
        var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
        var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
        var chipsBag = new Item("Chips Bag", 25, new DateTime(2023, 6, 1));
        var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 7, 1));
        var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
        var shampoo = new Item("Shampoo", 40, new DateTime(2023, 9, 1));
        var toothbrush = new Item("Toothbrush", 50, new DateTime(2023, 10, 1));
        var coffee = new Item("Coffee", 20);
        var sandwich = new Item("Sandwich", 15);
        var batteries = new Item("Batteries", 10);
        var umbrella = new Item("Umbrella", 5);
        var sunscreen = new Item("Sunscreen", 8);

        var store = new Store(250);

        // Add Item To Store
        store.AddItem(waterBottle);
        store.AddItem(chocolateBar);
        store.AddItem(notebook);
        store.AddItem(pen);
        store.AddItem(tissuePack);
        store.AddItem(chipsBag);
        store.AddItem(sodaCan);
        store.AddItem(soap);
        store.AddItem(shampoo);
        store.AddItem(toothbrush);
        store.AddItem(coffee);
        store.AddItem(sandwich);
        store.AddItem(batteries);
        store.AddItem(umbrella);
        store.AddItem(sunscreen);

        // Print Items
        store.PrintItems();
        Console.WriteLine("--------------------------");

        // Delete Selected Items By Name
        store.RemoveItemByName("Water Bottle");
        Console.WriteLine("--------------------------");

        Console.WriteLine($"{store.GetCurrentVolume()}");
        Console.WriteLine("--------------------------");

        // search item by name
        var itemName = "Chocolate Bar";
        Item foundItem = store.FindItemByName(itemName);
        if (foundItem != null)
        {
            Console.WriteLine($"Found item: {foundItem.Name}, Created Date: {foundItem.CreatedDate.ToShortDateString()}");
        }
        else
        {
            Console.WriteLine($"Item with name '{itemName}' not found.");
        }

        Console.WriteLine("--------------------------");


        // sort by name 
        Console.WriteLine("Sort By name Ascendeing");
        var collections = store.SortByNameAsc();
        foreach (var item in collections)
        {
            Console.WriteLine($"{item}");

        }
        Console.WriteLine("--------------------------");

        // print item after sorted asc
        Console.WriteLine("Items sorted in ascending order:");
        var sortedItemsAsc = store.SortByDate(Store.SortOrder.ASC);
        foreach (var item in sortedItemsAsc)
        {
            Console.WriteLine($"{item}");
        }

        Console.WriteLine("--------------------------");

        // print item after sorted desc
        Console.WriteLine("\nItems sorted in descending order:");
        var sortedItemsDesc = store.SortByDate(Store.SortOrder.DESC);
        foreach (var item in sortedItemsDesc)
        {
            Console.WriteLine($"{item}");
        }

        Console.WriteLine("--------------------------");

        // group items for last three month and add to  in new arrival  
        var groupByDate = store.GroupByDate();

        foreach (var group in groupByDate)
        {
            Console.WriteLine($"{group.Key} Items:");
            foreach (var item in group.Value)
            {
                Console.WriteLine($" - {item.Name}, Created: {item.CreatedDate.ToShortDateString()}");
            }
        }





    }




}
