using System.Data;
using WinFormsApp1.Data;
using WinFormsApp1.Domain.Contracts;
using WinFormsApp1.Domain.Exceptions;
using WinFormsApp1.Domain.Models;

namespace WinFormsApp1.Infrastructure.Implementations.Repositories;

public class CitizenRepository : ICitizenRepository
{
    private readonly DataBaseProvider _baseProvider;

    public CitizenRepository(DataBaseProvider dataBaseProvider)
    {
        _baseProvider = dataBaseProvider ?? throw new ArgumentNullException();
    }
    
    public Citizen? FindCitizen(Passport passport)
    {
        DataTable dataTable = _baseProvider.FindCitizenData(passport);

        bool isAccessAvailable = Convert.ToBoolean(dataTable.Rows[0].ItemArray[1]);

        if (isAccessAvailable)
            throw new PassportNotFoundException();

        return new Citizen(isAccessAvailable);
    }
}