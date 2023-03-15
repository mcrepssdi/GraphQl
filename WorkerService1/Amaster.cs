namespace WorkerService1;

public class Amaster
{
    public string Name { get; set; }
    public string Account { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string ApCarrier { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    

    
    public override string ToString()
    {
        return $"Name: {Name}, Account: {Account}, Address: {Address1}, ApCarrier: {ApCarrier}";
    }
}