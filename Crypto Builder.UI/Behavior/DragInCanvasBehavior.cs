using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;
using CryptoBuilder.UI.Helper;
using CryptoBuilder.UI.Model;
using System.Windows.Input;

namespace CryptoBuilder.UI.Behavior
{
    public class DragInCanvasBehavior : Behavior<FrameworkElement>
    {
        private Canvas canvas = null;

        private ListBoxItem lbi = null;

        private bool IsDragging = false;

        private Point mouseOffset;

        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;

            this.AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLeftButtonUp;

            this.AssociatedObject.MouseMove += AssociatedObject_MouseMove;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            this.AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;

            this.AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLeftButtonUp;

            this.AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
        }

        private void AssociatedObject_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (IsDragging)
            {
                IAlgorithmElement element = AssociatedObject as IAlgorithmElement;

                var point = e.GetPosition(canvas) - mouseOffset;

                //if (0 < point.X && point.X < (canvas.ActualWidth - lbi.ActualWidth))
                //    element.X = point.X;

                //if (0 < point.Y && point.Y < (canvas.ActualHeight - lbi.ActualHeight))
                //    element.Y = point.Y;

                if(0 < point.X)
                    element.X = point.X;

                if(0 < point.Y)
                    element.Y = point.Y;

                canvas.Resize();

                AssociatedObject.BringIntoView();

                e.Handled = true;
            }
        }

        private void AssociatedObject_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (IsDragging)
            {
                AssociatedObject.ReleaseMouseCapture();

                IsDragging = false;

                e.Handled = true;
            }
        }

        private void AssociatedObject_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        { 
            if (canvas == null)
                canvas = FrameworkElementExtension.FindParent<Canvas>(AssociatedObject);

            if (lbi == null)
                lbi = FrameworkElementExtension.FindParent<ListBoxItem>(AssociatedObject);

            lbi.IsSelected = true;

            IsDragging = true;

            mouseOffset = e.GetPosition(AssociatedObject);

            AssociatedObject.CaptureMouse();

            e.Handled = true;
        }
    }
}
