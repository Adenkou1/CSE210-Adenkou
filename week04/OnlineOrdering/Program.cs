using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        
        Product product1 = new Product("Laptop", 101, 800.00, 1);
        Product product2 = new Product("Mouse", 102, 25.00, 2);
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        
        Product product3 = new Product("Phone", 103, 500.00, 1);
        Product product4 = new Product("Charger", 104, 20.00, 3);
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        /
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.CalculateTotalCost());

        Console.WriteLine("\nOrder 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.CalculateTotalCost());
    }
}/
m 
class Product
{
    private string name;
    private int productId;
    private double price;
    private int quantity;

    public Product(string name, int productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetProductDetails()
    {
        return $"{name} (ID: {productId})";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }

    public string GetCustomerInfo()
    {
        return name + "\n" + address.GetFullAddress();
    }
}

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;
        foreach (Product product in products)
        {
            total += product.GetTotalCost();
        }
        total += customer.LivesInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in products)
        {
            label += product.GetProductDetails() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return "Shipping Label:\n" + customer.GetCustomerInfo();
    }
}
