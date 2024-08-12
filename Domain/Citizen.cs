namespace WinFormsApp1.Domain;

public class Citizen
{
    public Citizen(string isAccessAvailable)
    {
        if (string.IsNullOrWhiteSpace(isAccessAvailable))
            throw new ArgumentNullException();

        VoteAccessStatus = $"доступ к бюллетеню на дистанционном электронном голосовании {isAccessAvailable}";
    }
    
    public string VoteAccessStatus { get; }
}