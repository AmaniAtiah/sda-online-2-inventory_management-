public class Item
{
    public string Name
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
     }

    public Item(string name, int quantity, DateTime createdDate = default)
    {
        try
        {
            if (quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative.");
            }

            Name = name;
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
        return $"Name: {Name},  Quantity:  {quantity},  Created date: {createdDate}";
    }
}