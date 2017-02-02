using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CryptoBuilder.UI.Model;

namespace CryptoBuilder.UI.Helper
{
    public static class FrameworkElementExtension
    {
        //public static void BringToFront(this FrameworkElement element)
        //{
        //    Panel parent = VisualTreeHelper.GetParent(element) as Panel;
            
        //    if (parent == null) return;

        //    var maxZIndex = parent.Children.OfType<UIElement>()
        //        .Where(x => x != element)
        //            .Select(x => Panel.GetZIndex(x))
        //                .Max();
            
        //    Panel.SetZIndex(element, maxZIndex + 1);
        //}

        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null) return null;

            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return FindParent<T>(parentObject);
        }

        public static void Resize(this Canvas canvas)
        {
            Size size = canvas.DesiredSize;

            if (canvas.Children.Count != 0)
            {
                var items = canvas.Children.OfType<UIElement>();

                size.Width = items.Max(i => i.DesiredSize.Width + (double)i.GetValue(Canvas.LeftProperty));

                size.Height = items.Max(i => i.DesiredSize.Height + (double)i.GetValue(Canvas.TopProperty));
            }

            canvas.Measure(size);
        }
    }
}
