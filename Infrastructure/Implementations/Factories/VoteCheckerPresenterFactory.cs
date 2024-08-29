using WinFormsApp1.Domain.Models;
using WinFormsApp1.UI.Presenters.VoteCheckers;
using WinFormsApp1.UI.Views.Forms.VoteCheckers;

namespace WinFormsApp1.Infrastructure.Implementations.Factories;

public class VoteCheckerPresenterFactory : IVoteCheckerPresenterFactory
{
    private readonly VoteChecker _voteChecker;

    public VoteCheckerPresenterFactory(VoteChecker voteChecker) => 
        _voteChecker = voteChecker ?? throw new ArgumentNullException();

    public VoteCheckerPresenter Create(VoteCheckerForm voteCheckerView) => 
        new VoteCheckerPresenter(voteCheckerView, _voteChecker);
}