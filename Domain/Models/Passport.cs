namespace WinFormsApp1.Domain.Models;

public class Passport
{
    private const int MinSerialNumberLength = 10;
    
    public Passport(string serialNumber)
    {
        if (string.IsNullOrEmpty(serialNumber))
            throw new ArgumentNullException();

        SerialNumber = serialNumber.Trim().Replace(" ", string.Empty);
        
        if (SerialNumber.Length < MinSerialNumberLength)
            throw new ArgumentOutOfRangeException();
    }
    
    public string SerialNumber { get; }
}