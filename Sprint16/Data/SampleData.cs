using Sprint16.Models;

namespace Sprint16.Data
{
    public class SampleData
    {
        public static void Initialize(ShoppingContext context)
        {
            if (context.Products.Any())
            {
                return;
            }
            context.Products.AddRange(
                new Product
                {
                    Name = "Butter",
                    Price = 30.0f
                },
                new Product
                {
                    Name = "Banana",
                    Price = 20.50f
                },
                new Product
                {
                    Name = "Morshinska",
                    Price = 9.30f
                }
            );
            context.Customers.AddRange(
                new Customer
                {
                    Fname = "Volodya",
                    Lname ="Myk",
                    Address = "Ivano-Frankivsk",
                    Discount = 0.3
                },
                new Customer
                {
                    Fname = "Hlib",
                    Lname = "Bond",
                    Address = "Dnipro",
                    Discount = 0.5
                },
                new Customer
                {
                    Fname = "Maksym",
                    Lname = "Seer",
                    Address = "Kyiv",
                    Discount = 0.4
                }
            );
            context.Supermarkets.AddRange(
                new Supermarket
                {
                    Name = "Atb",
                    Address = "Mazepy str"
                },
                new Supermarket
                {
                    Name = "Silpo",
                    Address = "Shevchenka str"
                },
                new Supermarket
                {
                    Name = "Comfy",
                    Address = "Parkova str"
                }
            );
            context.Orders.AddRange(
            
                new Order
                {
                    Customer_Id = 1,
                    Supermarket_Id = 1,
                    Order_Date = new DateTime(2023,03,04),
                    OrderDetails= new List<OrderDetails>
                    {
                        new OrderDetails
                        {
                            Product_Id = 1, 
                            Quantity = 5
                        },
                    }
                },
                new Order
                {
                    Customer_Id = 2,
                    Supermarket_Id = 2,
                    Order_Date = new DateTime(2023,05,27),
                    OrderDetails= new List<OrderDetails>
                    {
                        new OrderDetails
                        {
                            Product_Id = 3, 
                            Quantity = 4
                        },
                    }
                },
                new Order
                {
                    Customer_Id = 3,
                    Supermarket_Id = 3,
                    Order_Date = new DateTime(2023,01,02),
                    OrderDetails= new List<OrderDetails>
                    {
                        new OrderDetails
                        {
                            Product_Id = 2, 
                            Quantity = 1
                        },
                    }
                }
            );
            context.SaveChanges();

        }
    }
}
