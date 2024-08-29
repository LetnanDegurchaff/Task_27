namespace WinFormsApp1.Domain.Models;

public class Citizen
{
    public Citizen(bool isAccessAvailable)
    {
        IsAccessAvailable = isAccessAvailable;
    }
    
    public bool IsAccessAvailable { get; }
}