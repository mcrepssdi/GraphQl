namespace GraphQLTest;

public class Carrier
{
    public string Name { get; set; }
    public string Account { get; set; }
    public string Address1 { get; set; }

    
    public override string ToString()
    {
        return $"Name: {Name}, Account: {Account}, Address: {Address1}";
    }
}