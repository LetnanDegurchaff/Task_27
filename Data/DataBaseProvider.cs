using System.Data;
using System.Data.SQLite;
using System.Reflection;
using WinFormsApp1.Domain.Models;
using WinFormsApp1.Infrastructure.Interfaces.Systems;
using FileNotFoundException = WinFormsApp1.Data.Exceptions.FileNotFoundException;

namespace WinFormsApp1.Data;

public class DataBaseProvider
{
    private readonly IHashSystem _hashSystem;
    private readonly string _dataBasePath;

    public DataBaseProvider(string dataBasePath, IHashSystem hashSystem)
    {
        if (string.IsNullOrEmpty(dataBasePath))
            throw new ArgumentNullException();

        _hashSystem = hashSystem ?? throw new ArgumentNullException();
        _dataBasePath = dataBasePath;
    }

    public DataTable FindCitizenData(Passport passport)
    {
        try
        {
            string commandText = string.Format
                ("select * from passports where num='{0}' limit 1;", _hashSystem.ComputeHash(passport.SerialNumber));

            string connectionString = string.Format(
                $"Data Source={Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{_dataBasePath}");

            using SQLiteConnection connection = new SQLiteConnection(connectionString);

            connection.Open();

            SQLiteDataAdapter sqLiteDataAdapter =
                new SQLiteDataAdapter(new SQLiteCommand(commandText, connection));

            DataTable citizenDataTable = new DataTable();
            sqLiteDataAdapter.Fill(citizenDataTable);
            
            return citizenDataTable;
        }
        catch (SQLiteException sqLiteException)
        {
            throw new FileNotFoundException(_dataBasePath);
        }
    }
}