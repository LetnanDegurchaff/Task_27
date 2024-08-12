using WinFormsApp1.Domain;
using WinFormsApp1.UI.Interfaces;

namespace WinFormsApp1.UI
{
    public partial class VoteCheckerView : Form, IVoteCheckerView
    {
        private IVoteCheckerPresenter _voteCheckerPresenter;

        public VoteCheckerView()
        {
            InitializeComponent();
        }

        public void InitPresenter(IVoteCheckerPresenter voteCheckerPresenter)
        {
            _voteCheckerPresenter = voteCheckerPresenter ?? throw new ArgumentNullException();
        }

        public void ShowPassportNotFoundError(string passportId)
        {
            if (string.IsNullOrEmpty(passportId))
                throw new ArgumentNullException();
            
            _textResult.Text =
                $"Паспорт «{passportId}» в списке участников дистанционного голосования НЕ НАЙДЕН";
        }

        public void ShowVoteAccess(string passportId, Citizen citizen)
        {
            _textResult.Text =
                $"По паспорту «{passportId}» {citizen.VoteAccessStatus}";
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
            try
            {
                _voteCheckerPresenter.ShowVoteInfo(_passportTextbox.Text
                    .Trim().Replace(" ", string.Empty));
            }
            catch (ArgumentNullException exception)
            {
                _textResult.Text = "Введите серию и номер паспорта";
            }
        }
    }
}