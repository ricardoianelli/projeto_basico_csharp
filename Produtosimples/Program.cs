using System;
using System.Globalization;
using Produtosimples.Entities;
using Produtosimples.Enums;

namespace Produtosimples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Client Data");
            Console.Write("Name: ");
            string client_name = Console.ReadLine();
            Console.Write("Email: ");
            string client_email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime client_birthdate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(client_name, client_email, client_birthdate);

            Console.WriteLine("\nEnter Order Data");
            Console.Write("Status: ");
            OrderStatus order_status;
            Enum.TryParse<OrderStatus>(Console.ReadLine(), out order_status);
            Order order = new Order(order_status, client);

            Console.Write("How many items to this order? ");
            int order_quantity = int.Parse(Console.ReadLine());

            for(int i = 1; i<= order_quantity; i++)
            {
                Console.WriteLine("-> Enter #" + i + " item data");
                Console.Write("Product name: ");
                string product_name = Console.ReadLine();
                Console.Write("Product price: ");
                double product_price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Product product = new Product(product_name, product_price);

                Console.Write("Quantity: ");
                int product_quantity = int.Parse(Console.ReadLine());
                order.AddItem(new OrderItem(product_quantity, product_price, product));    
            }

            Console.Write(order.ToString());
            Console.ReadLine();
        }
    }
}
