namespace BlacksmithAPI;

public class CustomerRepository
{
    public Customer GetById(int id)
    {
        return BlacksmithDatabase.Get<Customer>("customers", x => x.Id == id);
    }
}
