using WinFormsApp1.UI.Presenters.VoteCheckers;

namespace WinFormsApp1.UI.Views.Forms.VoteCheckers;

public interface IVoteCheckerPresenterFactory
{
    VoteCheckerPresenter Create(VoteCheckerForm voteCheckerView);
}