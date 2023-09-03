using Microsoft.AspNetCore.Mvc;

namespace BlacksmithAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    [HttpPost(Name = "Request Order")]
    public Order RequestOrder([FromBody] OrderRequest request)
    {
        // Check client
        CustomerRepository customerRepository = new CustomerRepository();
        Customer customer = customerRepository.GetById(request.CustomerId);

        // Check inventory
        InventoryRepository inventoryRepository = new InventoryRepository();
        float materialModifier = inventoryRepository.GetMaterialPriceModifier(request.Material);
        
        // Calculate price
        int p = 0;
        if (request.ItemType == "Sword")
        {
            p = 5 * (int)materialModifier;
        }
        else if (request.ItemType == "Spear")
        {
            p = 15 * (int)materialModifier;
        }
        else if (request.ItemType == "Shield")
        {
            p = 25 * (int)materialModifier;
        }
        else
        {
            throw new Exception();
        }

        // Calculate delivery date
        DateTime deliveryDate = DateTime.Now.AddDays(2);
        if (request.ItemType == "Sword")
        {
            deliveryDate = deliveryDate.AddDays(1);
        }
        else if (request.ItemType == "Spear")
        {
            deliveryDate = deliveryDate.AddDays(2);
        }
        else if (request.ItemType == "Shield")
        {
            deliveryDate = deliveryDate.AddDays(3);
        }
        
        // Express customers have quicker delivery
        if (customer.Category == "Express")
        {
            deliveryDate = deliveryDate.AddDays(-2);
        }


        // Premium customers have quicker delivery and an 10% discount
        if(customer.Category == "Premium")
        {
            deliveryDate = deliveryDate.AddDays(-2);
            p = (int)(p * 0.9);
        }

        return new Order()
        {
            Id = 1,
            Price = p,
            DeliveryDate = deliveryDate
        };
    }
}
