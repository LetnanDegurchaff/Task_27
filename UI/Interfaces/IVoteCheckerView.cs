using WinFormsApp1.Domain;

namespace WinFormsApp1.UI.Interfaces;

public interface IVoteCheckerView
{
    void ShowIncorrectInputError();
    void InitPresenter(IVoteCheckerPresenter voteCheckerPresenter);
    void ShowPassportNotFoundError(string passportId);
    void ShowVoteAccess(string passportId, Citizen citizen);
    void ShowFileNotFoundError(string filePath);
}