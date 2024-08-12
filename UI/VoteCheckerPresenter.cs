using WinFormsApp1.Domain;
using WinFormsApp1.Exceptions;
using WinFormsApp1.UI.Interfaces;
using FileNotFoundException = WinFormsApp1.Exceptions.FileNotFoundException;

namespace WinFormsApp1.UI;

public class VoteCheckerPresenter : IVoteCheckerPresenter
{
    private readonly IVoteCheckerView _voteCheckerView;
    private readonly VoteChecker _voteChecker;

    public VoteCheckerPresenter(IVoteCheckerView voteCheckerView, VoteChecker voteChecker)
    {
        _voteChecker = voteChecker ?? throw new ArgumentNullException();
        _voteCheckerView = voteCheckerView ?? throw new ArgumentNullException();
        voteCheckerView.InitPresenter(this);
    }

    public void ShowVoteInfo(string passportId)
    {
        if (string.IsNullOrEmpty(passportId))
            throw new ArgumentNullException();

        if (passportId.Length != 10)
        {
            _voteCheckerView.ShowIncorrectInputError();
            return;
        }

        Citizen citizen = null!;
        
        try
        {
            citizen = _voteChecker.GetVoteAccess(new Passport(passportId));
        }
        catch (PassportNotFoundException passportNotFoundException)
        {
            _voteCheckerView.ShowPassportNotFoundError(passportId);
        }
        catch (FileNotFoundException fileNotFoundException)
        {
            _voteCheckerView.ShowFileNotFoundError(fileNotFoundException.FilePath);
        }
        
        _voteCheckerView.ShowVoteAccess(passportId, citizen);
    }
}