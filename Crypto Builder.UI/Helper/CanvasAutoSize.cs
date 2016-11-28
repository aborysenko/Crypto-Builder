using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CryptoBuilder.UI.Model;

namespace CryptoBuilder.UI.Helper
{
    public class CanvasAutoSize : Canvas
    {
        protected override System.Windows.Size MeasureOverride(System.Windows.Size constraint)
        {
            Size size = base.MeasureOverride(constraint);

            if (base.InternalChildren.Count != 0)
            {
                var items = base.InternalChildren.OfType<UIElement>();

                size.Width = items.Max(i => i.DesiredSize.Width + (double)i.GetValue(Canvas.LeftProperty));

                size.Height = items.Max(i => i.DesiredSize.Height + (double)i.GetValue(Canvas.TopProperty));
            }

            return size;
        }
    }
}
