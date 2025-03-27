using System;

public class PricingDataModel
{
    public DateTime date { get; set; } = DateTime.UtcNow;
    public string terminalState { get; set; }
    public object content { get; set; }
}
