using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - USA customer
        Address addr1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Smith", addr1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "A101", 29.99, 1));
        order1.AddProduct(new Product("USB Hub", "B204", 15.50, 2));
        order1.AddProduct(new Product("Keyboard", "C305", 49.99, 1));

        // Order 2 - International customer
        Address addr2 = new Address("45 Queen St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Maria Garcia", addr2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Laptop Stand", "D410", 35.00, 1));
        order2.AddProduct(new Product("Webcam", "E512", 59.99, 1));

        List<Order> orders = new List<Order> { order1, order2 };
        foreach (Order o in orders)
            o.DisplayOrderSummary();
    }
}
