using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Books.Behaviors
{
    public class BookNameValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += BindableOnTextChanged;
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.TextChanged -= BindableOnTextChanged;
        }
        private void BindableOnTextChanged(object sender, TextChangedEventArgs e)
        {
            var name = e.NewTextValue;
            var bookName = sender as Entry;

            if (!name.Trim().Equals(""))
            {
                bookName.BackgroundColor = Color.Transparent;
            }
            else
            {
                bookName.BackgroundColor = Color.Red;
            }
        }
    }
}
