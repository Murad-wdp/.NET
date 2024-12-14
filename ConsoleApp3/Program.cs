using System;
using System.Collections.Generic;

public enum ArticleType
{
    Electronics,
    Clothing,
    Food,
    Furniture,
    Others
}

public enum ClientType
{
    Regular,
    VIP
}

public enum PayType
{
    Cash,
    CreditCard,
    OnlinePayment
}

public struct Article
{
    public int ProductCode { get; set; }       
    public string ProductName { get; set; }    
    public decimal Price { get; set; }         
    public ArticleType Type { get; set; }      
}

public struct Client
{
    public int ClientCode { get; set; }             
    public string FullName { get; set; }          
    public string Address { get; set; }            
    public string Telephone { get; set; }          
    public int NumberOfOrders { get; set; }         
    public decimal TotalOrderAmount { get; set; }   
    public ClientType Type { get; set; }            
}


public struct RequestItem
{
    public Article Commodity { get; set; }         
    public int NumberOfUnits { get; set; }          
}

public struct Request
{
    public int OrderCode { get; set; }              
    public Client Client { get; set; }              
    public DateTime OrderDate { get; set; }        
    public List<RequestItem> OrderedProducts { get; set; } 
    public PayType PaymentType { get; set; }       

  
    public decimal OrderPrice
    {
        get
        {
            decimal total = 0;
            foreach (var item in OrderedProducts)
            {
                total += item.Commodity.Price * item.NumberOfUnits;
            }
            return total;
        }
    }
}
class Program
{
    static void Main()
    {
      
        Article laptop = new Article { ProductCode = 1, ProductName = "Laptop", Price = 1500, Type = ArticleType.Electronics };
        Article chair = new Article { ProductCode = 2, ProductName = "Chair", Price = 75, Type = ArticleType.Furniture };

     
        Client client = new Client
        {
            ClientCode = 101,
            FullName = "Murad Veliyev",
            Address = "Bakı, Mkr",
            Telephone = "+994553047571",
            NumberOfOrders = 5,
            TotalOrderAmount = 5000,
            Type = ClientType.VIP
        };

        
        RequestItem item1 = new RequestItem { Commodity = laptop, NumberOfUnits = 1 };
        RequestItem item2 = new RequestItem { Commodity = chair, NumberOfUnits = 4 };

      
        Request order = new Request
        {
            OrderCode = 1001,
            Client = client,
            OrderDate = DateTime.Now,
            OrderedProducts = new List<RequestItem> { item1, item2 },
            PaymentType = PayType.CreditCard
        };

     
        Console.WriteLine($"Sifariş kodu: {order.OrderCode}");
        Console.WriteLine($"Müşteri: {order.Client.FullName}");
        Console.WriteLine($"Sifariş tarixi: {order.OrderDate}");
        Console.WriteLine("Mehsullar:");
        foreach (var item in order.OrderedProducts)
        {
            Console.WriteLine($"- {item.Commodity.ProductName}: {item.NumberOfUnits} vahid, Qiymet: {item.Commodity.Price} AZN");
        }
        Console.WriteLine($"Ümumi mebleğ: {order.OrderPrice} AZN");
        Console.WriteLine($"Ödeniş növü: {order.PaymentType}");
    }
}
