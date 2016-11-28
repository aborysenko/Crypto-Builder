using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CryptoBuilder.UI.Model;

namespace CryptoBuilder.UI.Behavior
{
    public static class DropBehavior
    {
        private static readonly DependencyProperty PreviewDropCommandProperty =
                    DependencyProperty.RegisterAttached
                    (
                        "PreviewDropCommand",
                        typeof(ICommand),
                        typeof(DropBehavior),
                        new PropertyMetadata(PreviewDropCommandPropertyChangedCallBack)
                    );

        public static void SetPreviewDropCommand(this UIElement inUIElement, ICommand inCommand)
        {
            inUIElement.SetValue(PreviewDropCommandProperty, inCommand);
        }

        private static ICommand GetPreviewDropCommand(UIElement inUIElement)
        {
            return (ICommand)inUIElement.GetValue(PreviewDropCommandProperty);
        }

      
        private static void PreviewDropCommandPropertyChangedCallBack(
            DependencyObject inDependencyObject, DependencyPropertyChangedEventArgs inEventArgs)
        {
            UIElement uiElement = inDependencyObject as UIElement;
            if (null == uiElement) return;

            uiElement.Drop += (sender, args) =>
            {
                DropData data = new DropData 
                {
                    Data = args.Data, Position = args.GetPosition(uiElement)
                };

                GetPreviewDropCommand(uiElement).Execute(data);
                
                args.Handled = true;
            };
        }
    }
}
