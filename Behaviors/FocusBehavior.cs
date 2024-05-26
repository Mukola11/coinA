using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace coinA.Behaviors
{
    public class FocusBehavior : Behavior<TextBox>
    {
        private bool _focusSet;

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.TextChanged += OnTextChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.TextChanged -= OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!_focusSet)
            {
                AssociatedObject.CaretIndex = AssociatedObject.Text.Length;
                AssociatedObject.Focus();
                _focusSet = true;
            }
        }
    }
}
