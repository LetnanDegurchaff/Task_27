namespace WinFormsApp1.Domain;

public class Passport
{
    public Passport(string id)
    {
        if (string.IsNullOrEmpty(id))
            throw new ArgumentNullException();

        Id = id;
    }
    
    public string Id { get; }
}