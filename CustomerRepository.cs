namespace BlacksmithAPI;

public class CustomerRepository
{
    public Customer GetById(int id)
    {
        var categories = new string[]{"Regular", "Express", "Premium"};
        return new Customer()
        {
            Id = id,
            Category = categories[id%3]
        };
    }
}
