using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("155 Elm St", "Iowa City", "IA", "USA");
        Address address2 = new Address("348 Deez Ave", "Toronto", "Ontario", "Canada");

        Customer customer1 = new Customer("Dylan Wheeler", address1);
        Customer customer2 = new Customer("Jared Barney", address2);

        Product product1 = new Product("Halo Top Icecream", "HT", 800.00, 1);
        Product product2 = new Product("Creatine", "C4", 25.00, 2);
        Product product3 = new Product("America's Sweethearts Magazine", "ASM", 50.00, 1);
        Product product4 = new Product("Cars Monthly", "CM", 300.00, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product1);
        order2.AddProduct(product4);

        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order1.GetTotalCost());
        Console.WriteLine("---------------------");

        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order2.GetTotalCost());
    }
}

class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        SetPrice(price);
        SetQuantity(quantity);
    }

    public double GetTotalPrice()
    {
        return _price * _quantity;
    }

    public string GetProductInfo()
    {
        return $"Product: {_name}, ID: {_productId}";
    }

    public void SetPrice(double price)
    {
        if (price < 0)
        {
            throw new ArgumentException("Price cannot be negative.");
        }
        _price = price;
    }

    public void SetQuantity(int quantity)
    {
        if (quantity < 0)
        {
            throw new ArgumentException("Quantity cannot be negative.");
        }
        _quantity = quantity;
    }
}

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetCustomerInfo()
    {
        return $"Name: {_name}, Address: {_address.GetFullAddress()}";
    }
}

class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalPrice();
        }
        total += _customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (Product product in _products)
        {
            label += product.GetProductInfo() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return _customer.GetCustomerInfo();
    }
}
