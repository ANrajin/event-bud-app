namespace EventBud.Domain.Event.ValueObjects;

public sealed class EventLocation
{
    public string Location { get; } = string.Empty;

    public string Street { get; } = string.Empty;

    public string City { get; } = string.Empty;

    public string State { get; } = string.Empty;
    
    public string Zip { get; } = string.Empty;

    public string Country { get; } = string.Empty;
    
    public EventLocation() { }

    public EventLocation(
        string location, 
        string street, 
        string city, 
        string state, 
        string zip, 
        string country)
    {
        Location = location;
        Street = street;
        City = city;
        State = state;
        Country = country;
        Zip = zip;
    }
}
