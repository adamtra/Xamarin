using System;
using Xamarin.Forms;

namespace _27BindingCode
{
    public class BindingCodePage : ContentPage
    {
        public BindingCodePage()
        {
            Label label = new Label
            {
                Text = "Opacity Binding Demo",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            Slider slider = new Slider
            {
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            #region noBindingObject
            //// Set the binding context: target is Label; source is Slider.
            //label.BindingContext = slider;

            //// Bind the properties: target is Opacity; source is Value.
            //label.SetBinding(Label.OpacityProperty, "Value");
            #endregion
            #region bindingObject
            //// Define Binding object with source object and property.
            //Binding binding = new Binding
            //{
            //    Source = slider,
            //    Path = "Value"
            //};
            //// Bind the Opacity property of the Label to the source.
            //label.SetBinding(Label.OpacityProperty, binding);
            #endregion

            #region createVersion
            Binding binding = Binding.Create<Slider>(src => src.Value);
            binding.Source = slider;
            label.SetBinding(Label.OpacityProperty, binding);
            #endregion

            // Construct the page.
            Padding = new Thickness(10, 0);
            Content = new StackLayout
            {
                Children = { label, slider }
            };
        }
    }
}
