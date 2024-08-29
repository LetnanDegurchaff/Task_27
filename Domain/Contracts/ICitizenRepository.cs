using WinFormsApp1.Domain.Models;

namespace WinFormsApp1.Domain.Contracts;

public interface ICitizenRepository
{
    Citizen? FindCitizen(Passport passport);
}