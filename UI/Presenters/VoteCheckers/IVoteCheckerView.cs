namespace WinFormsApp1.UI.Presenters.VoteCheckers;

public interface IVoteCheckerView
{
    void ShowIncorrectInputError();
    void ShowPassportNotFoundError(string passportId);
    void ShowVoteAccess(string passportId, string voteAccess);
    void ShowFileNotFoundError(string filePath);
    void ShowNullInputError();
}