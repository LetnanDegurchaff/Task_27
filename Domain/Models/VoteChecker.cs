using WinFormsApp1.Domain.Contracts;

namespace WinFormsApp1.Domain.Models;

public class VoteChecker
{
    private readonly ICitizenRepository _citizenRepository;

    public VoteChecker(ICitizenRepository citizenRepository)
    {
        _citizenRepository = citizenRepository ?? throw new ArgumentNullException();
    }
    
    public Citizen GetVoteAccess(Passport passport)
    {
        if (passport == null)
            throw new ArgumentNullException();
        
        return _citizenRepository.FindCitizen(passport) ?? throw new ArgumentNullException();
    }
}