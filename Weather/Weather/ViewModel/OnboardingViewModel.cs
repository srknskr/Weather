using System.Collections.ObjectModel;
using System.Windows.Input;
using Weather.Model;
using Xamarin.Forms;

namespace Weather.ViewModel
{
    public class OnboardingViewModel : MvvmHelpers.BaseViewModel
    {
        private ObservableCollection<Onboarding> items;
        private int position;
        private string nextButtonText;
        private string skipButtonText;

        public OnboardingViewModel()
        {
            SetNextButtonText("NEXT");
            SetSkipButtonText("SKIP");
            OnBoarding();
            LaunchNextCommand();
            LaunchSkipCommand();
        }

        private void SetNextButtonText(string nextButtonText) => NextButtonText = nextButtonText;
        private void SetSkipButtonText(string skipButtonText) => SkipButtonText = skipButtonText;

        private void OnBoarding()
        {
            Items = new ObservableCollection<Onboarding>
            {
                new Onboarding
                {
                    Title = "Welcome",
                    Content = "Welcome to Weather. Let's start.",
                    ImageUrl = "welcome.svg"
                },
                new Onboarding
                {
                    Title = "Latest Data",
                    Content = "Weather shows you the data from \n the API.",
                    ImageUrl = "show.svg"
                },
                new Onboarding
                {
                    Title = "Instant notifications",
                    Content = "Get notified according to the changes \n you want.",
                    ImageUrl = "notification.svg"
                }
            };
        }

        private void LaunchNextCommand()
        {

            NextCommand = new Command(() =>
            {
                if (LastPositionReached())
                {
                    ExitOnBoarding();
                }
                else
                {
                    MoveToNextPosition();
                }
            });
        }
        private void LaunchSkipCommand()
        {
            SkipCommand = new Command(() =>
            {
                ExitOnBoarding();

            });
        }

        private static void ExitOnBoarding()
            => Application.Current.MainPage.Navigation.PopModalAsync();

        private void MoveToNextPosition()
        {
            var nextPosition = ++Position;
            Position = nextPosition;
        }

        private bool LastPositionReached()
            => Position == Items.Count - 1;

        public ObservableCollection<Onboarding> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        public string NextButtonText
        {
            get => nextButtonText;
            set => SetProperty(ref nextButtonText, value);
        }
        public string SkipButtonText
        {
            get => skipButtonText;
            set => SetProperty(ref skipButtonText, value);
        }

        public int Position
        {
            get => position;
            set
            {
                if (SetProperty(ref position, value))
                {
                    UpdateNextButtonText();
                }
            }
        }

        private void UpdateNextButtonText()
        {
            if (LastPositionReached())
            {
                SetNextButtonText("GOT IT");
            }
            else
            {
                SetNextButtonText("NEXT");
            }
        }

        public ICommand NextCommand { get; private set; }
        public ICommand SkipCommand { get; private set; }
    }
}
