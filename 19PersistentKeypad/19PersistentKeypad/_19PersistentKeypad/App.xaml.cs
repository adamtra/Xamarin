using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace _19PersistentKeypad {
    public partial class App : Application {
        const string displayLabelText = "displayLabelText";
        public App() {
            if (Properties.ContainsKey(displayLabelText)) {
                DisplayLabelText = (string)Properties[displayLabelText];
            }

            InitializeComponent();

            MainPage = new _19PersistentKeypad.PersistentKeypadPage();
        }
        public string DisplayLabelText { set; get; }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
            Properties[displayLabelText] = DisplayLabelText;
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
