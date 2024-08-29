using WinFormsApp1.Data;
using WinFormsApp1.Domain.Models;
using WinFormsApp1.Infrastructure.Implementations.Factories;
using WinFormsApp1.Infrastructure.Implementations.Repositories;
using WinFormsApp1.Infrastructure.Implementations.Systems;
using WinFormsApp1.UI.Views.Forms.VoteCheckers;

namespace WinFormsApp1;

static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        DataBaseProvider dataBaseProvider = new DataBaseProvider("db.sqlite", new Sha256HashSystem());
        CitizenRepository citizenRepository = new CitizenRepository(dataBaseProvider);
        
        VoteChecker voteChecker = new VoteChecker(citizenRepository);
        VoteCheckerPresenterFactory voteCheckerPresenterFactory = new VoteCheckerPresenterFactory(voteChecker);
        
        VoteCheckerForm startForm = new VoteCheckerForm(voteCheckerPresenterFactory);

        Application.Run(startForm);
    }
}