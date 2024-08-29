using WinFormsApp1.Domain;
using WinFormsApp1.Domain.Exceptions;
using WinFormsApp1.Domain.Models;
using FileNotFoundException = WinFormsApp1.Data.Exceptions.FileNotFoundException;

namespace WinFormsApp1.UI.Presenters.VoteCheckers;

public class VoteCheckerPresenter
{
    private readonly IVoteCheckerView _voteCheckerView;
    private readonly VoteChecker _voteChecker;

    public VoteCheckerPresenter(IVoteCheckerView voteCheckerView, VoteChecker voteChecker)
    {
        _voteChecker = voteChecker ?? throw new ArgumentNullException();
        _voteCheckerView = voteCheckerView ?? throw new ArgumentNullException();
    }

    public void ShowVoteInfo(string passportSerialNumber)
    {
        try
        {
            Citizen citizen = _voteChecker.GetVoteAccess(new Passport(passportSerialNumber));
            _voteCheckerView.ShowVoteAccess(passportSerialNumber, citizen.IsAccessAvailable ? "ПРЕДОСТАВЛЕН" : "НЕ ПРЕДОСТАВЛЯЛСЯ");
        }
        catch (PassportNotFoundException passportNotFoundException)
        {
            _voteCheckerView.ShowPassportNotFoundError(passportSerialNumber);
        }
        catch (FileNotFoundException fileNotFoundException)
        {
            _voteCheckerView.ShowFileNotFoundError(fileNotFoundException.FilePath);
        }
        catch (ArgumentNullException argumentNullException)
        {
            _voteCheckerView.ShowNullInputError();
        }
        catch (ArgumentOutOfRangeException argumentOutOfRangeException)
        {
            _voteCheckerView.ShowIncorrectInputError();
        }
    }
}