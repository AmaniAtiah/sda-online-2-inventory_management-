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
        bool isItemExist = items.Any((i) => i.Name == item.Name);
        try
        { 
            if (isItemExist)
            {
                throw new ArgumentException($"Item {item.Name} already exists.");

            }
            if (GetCurrentVolume() + item.Quantity > MaximumCapacity)
            {
                throw new InvalidOperationException("Cannot add item. Store has reached its maximum capacity");

            }

            items.Add(item);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);

        } catch(InvalidOperationException e){
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
            Item itemToRemove = items.FirstOrDefault(i => i.Name == itemName);
            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);
                Console.WriteLine($"Item {itemName} removed");

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
        Item? itemFound = items.FirstOrDefault(i => i.Name == itemName);
        return itemFound;
    }

    public List<Item> SortByNameAsc()
    {
        return items.OrderBy(i => i.Name).ToList();
    }


    public List<Item> SortByDate(SortOrder sortOrder)
    {
        switch (sortOrder){
            case SortOrder.ASC:
                return items.OrderBy(i => i.CreatedDate).ToList();
            case SortOrder.DESC:
                return items.OrderByDescending(i => i.CreatedDate).ToList();
            default:
                return items.OrderBy(i => i.CreatedDate).ToList();
        }
    }

    public Dictionary<string, List<Item>> GroupByDate()
    {
        DateTime threeMonthsAgo = DateTime.Now.AddMonths(-3);

        Dictionary<string, List<Item>> groups = new Dictionary<string, List<Item>>();
        List<Item> newArrival = new List<Item>();
        List<Item> old = new List<Item>();

        foreach (var item in items)
        {
            if (item.CreatedDate >= threeMonthsAgo)
            {
                newArrival.Add(item);
            }
            else
            {
                old.Add(item);
            }


        }
        groups.Add("New Arrival", newArrival);
        groups.Add("Old", old);

        return groups;
    }

}

