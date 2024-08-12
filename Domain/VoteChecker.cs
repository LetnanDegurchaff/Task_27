using WinFormsApp1.Data;

namespace WinFormsApp1.Domain;

public class VoteChecker
{
    private readonly IDataBaseProvider _dataBaseProvider;

    public VoteChecker(IDataBaseProvider dataBaseProvider)
    {
        _dataBaseProvider = dataBaseProvider ?? throw new ArgumentNullException();
    }
    
    public Citizen GetVoteAccess(Passport passport)
    {
        if (passport == null)
            throw new ArgumentNullException();
        
        return _dataBaseProvider.FindCitizen(passport);
    }
}