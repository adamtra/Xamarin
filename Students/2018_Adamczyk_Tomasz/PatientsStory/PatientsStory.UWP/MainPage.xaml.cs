namespace PatientsStory.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new PatientsStory.App());
        }
    }
}