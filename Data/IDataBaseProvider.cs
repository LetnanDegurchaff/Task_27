using WinFormsApp1.Domain;

namespace WinFormsApp1.Data;

public interface IDataBaseProvider
{
    Citizen FindCitizen(Passport passport);
}