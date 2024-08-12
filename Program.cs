using WinFormsApp1.Data;
using WinFormsApp1.Domain;
using WinFormsApp1.Domain.Services;
using WinFormsApp1.UI;

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

        IDataBaseProvider dataBaseProvider = new DataBaseProvider("db.sqlite", new Sha256HashSystem());

        VoteChecker voteChecker = new VoteChecker(dataBaseProvider);
        VoteCheckerView startForm = new VoteCheckerView();
        new VoteCheckerPresenter(startForm, voteChecker);

        Application.Run(startForm);
    }
}