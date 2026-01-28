public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    
    public Feature[] Features {get; set;}
}

public class Feature
{
    public Property Properties {get; set;}
}

public class Property
{
    public decimal Mag {get; set;}
    public string Place {get; set;}
}