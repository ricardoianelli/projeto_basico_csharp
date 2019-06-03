using System;
using System.Text;
using System.Collections.Generic;
using Produtosimples.Enums;


namespace Produtosimples.Entities
{
    class Order
    {
        public DateTime moment { get; set; }
        public OrderStatus status { get; set; }
        public List<OrderItem> items { get; set; } = new List<OrderItem>();
        public Client client { get; set; }

        public Order()
        { }

        public Order(OrderStatus status, Client client)
        {
            moment = DateTime.Now;
            this.status = status;
            this.client = client;
        }

        public void AddItem(OrderItem item)
        {
            items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            items.Remove(item);
        }

        public double Total()
        {
            double total = 0;
            foreach(OrderItem item in items)
            {
                total += item.SubTotal();
            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nORDER SUMMARY");
            sb.Append("Order moment: ");
            sb.AppendLine(moment.ToString());
            sb.Append("Order status: ");
            sb.AppendLine(status.ToString());
            sb.AppendLine(client.ToString());
            sb.AppendLine("Order items: ");

            foreach(OrderItem item in items)
            {
                sb.AppendLine(item.ToString());
            }

            sb.Append("Total price: $");
            sb.Append(Total().ToString("F2"));
            return sb.ToString();
        }
    }
}
