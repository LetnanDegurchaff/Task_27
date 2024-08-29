using WinFormsApp1.Domain;
using WinFormsApp1.UI.Presenters.VoteCheckers;

namespace WinFormsApp1.UI.Views.Forms.VoteCheckers
{
    public partial class VoteCheckerForm : Form, IVoteCheckerView
    {
        private VoteCheckerPresenter _voteCheckerPresenter;

        public VoteCheckerForm(IVoteCheckerPresenterFactory voteCheckerPresenterFactory)
        {
            _voteCheckerPresenter = voteCheckerPresenterFactory?.Create(this) ?? throw new ArgumentNullException();
            InitializeComponent();
        }

        public void ShowPassportNotFoundError(string passportId)
        {
            if (string.IsNullOrEmpty(passportId))
                throw new ArgumentNullException();
            
            _textResult.Text =
                $"Паспорт «{passportId}» в списке участников дистанционного голосования НЕ НАЙДЕН";
        }

        public void ShowVoteAccess(string passportId, string voteAccess)
        {
            _textResult.Text =
                $"По паспорту «{passportId}» {voteAccess}";
        }

        public void ShowFileNotFoundError(string filePath)
        {
            MessageBox.Show($"Файл {filePath} не найден. Положите файл в папку вместе с exe.");
        }

        public void ShowIncorrectInputError()
        {
            _textResult.Text = "Неверный формат серии или номера паспорта";
        }
        
        private void CheckButton_Click(object sender, EventArgs eventArgs)
        {
            _voteCheckerPresenter.ShowVoteInfo(_passportTextbox.Text);
        }
        
        public void ShowNullInputError()
        {
            MessageBox.Show("Введите серию и номер паспорта");
        }
    }
}