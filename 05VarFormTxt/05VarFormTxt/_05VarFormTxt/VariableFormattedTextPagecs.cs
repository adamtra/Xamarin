using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace _05VarFormTxt {
    public class VariableFormattedTextPagecs : ContentPage {
        public VariableFormattedTextPagecs() {
            Content = new Label {
                FormattedText = new FormattedString {
                    Spans =
                    {
                        new Span
                        {
                            Text = "I ",
                            FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                            FontAttributes = FontAttributes.Italic
                        },
                        new Span
                        {
                            Text = "love",
                            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                            FontAttributes = FontAttributes.Bold
                        },
                        new Span
                        {
                            Text = " Xamarin.Forms!",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                            FontAttributes = FontAttributes.None
                        }
                    }
                },

                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
        }
    }
}