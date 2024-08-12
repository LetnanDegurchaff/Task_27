using System.Data;
using System.Data.SQLite;
using System.Reflection;
using WindowsFormsApp1;
using WinFormsApp1.Domain;
using WinFormsApp1.Exceptions;
using FileNotFoundException = WinFormsApp1.Exceptions.FileNotFoundException;

namespace WinFormsApp1.Data;

public class DataBaseProvider : IDataBaseProvider
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

    public Citizen FindCitizen(Passport passport)
    {
        try
        {
            string commandText = string.Format
                ("select * from passports where num='{0}' limit 1;", _hashSystem.ComputeHash(passport.Id));

            string connectionString = string.Format(
                $"Data Source={Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{_dataBasePath}");

            using SQLiteConnection connection = new SQLiteConnection(connectionString);

            connection.Open();

            SQLiteDataAdapter sqLiteDataAdapter =
                new SQLiteDataAdapter(new SQLiteCommand(commandText, connection));

            DataTable dataTable = new DataTable();
            sqLiteDataAdapter.Fill(dataTable);

            bool isAccessAvailable = Convert.ToBoolean(dataTable.Rows[0].ItemArray[1]);

            if (isAccessAvailable)
                throw new PassportNotFoundException();

            return new Citizen(isAccessAvailable ? "ПРЕДОСТАВЛЕН" : "НЕ ПРЕДОСТАВЛЯЛСЯ");
        }
        catch (SQLiteException sqLiteException)
        {
            throw new FileNotFoundException(_dataBasePath);
        }
    }
}