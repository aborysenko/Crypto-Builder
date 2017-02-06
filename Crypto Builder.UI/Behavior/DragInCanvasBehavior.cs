﻿using System;
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

        private ListBox listBox = null;

        private bool IsDragging = false;

        private bool IsMouseDown = false;

        private bool IsMouseAndControlDown = false;

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
            //if (IsDragging)
            //{
            //    IAlgorithmElement element = AssociatedObject as IAlgorithmElement;

            //    var point = e.GetPosition(canvas) - mouseOffset;

            //    if (0 < point.X && point.X < (canvas.ActualWidth - lbi.ActualWidth))
            //        element.X = point.X;

            //    if (0 < point.Y && point.Y < (canvas.ActualHeight - lbi.ActualHeight))
            //        element.Y = point.Y;

            //    canvas.Resize();

            //    AssociatedObject.BringIntoView();

            //    e.Handled = true;
            //}

            if (IsDragging)
            {
                var currentMouse = e.GetPosition(canvas);

                var point = currentMouse - mouseOffset;

                mouseOffset = currentMouse;

                foreach (IAlgorithmElement element in listBox.SelectedItems)
                {
                    element.X += point.X;

                    element.Y += point.Y;
                }

                //canvas.Resize();

                //AssociatedObject.BringIntoView();

               
            }
            else if (IsMouseDown)
            {
                IsDragging = true;

                e.Handled = true;
            }
        }

        private void AssociatedObject_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (IsMouseDown)
            {
                if (!IsDragging)
                {
                    if (IsMouseAndControlDown)
                    {
                        if (listBox.SelectedItems.Contains(AssociatedObject))
                        {
                            listBox.SelectedItems.Remove(AssociatedObject);
                        }
                        else
                        {
                            listBox.SelectedItems.Add(AssociatedObject);
                        }
                    }
                    else
                    {
                        if (!(listBox.SelectedItems.Count == 1 && listBox.SelectedItem == AssociatedObject))
                        {
                            listBox.SelectedItems.Clear();

                            listBox.SelectedItems.Add(AssociatedObject);
                        }
                    }
                }

                AssociatedObject.ReleaseMouseCapture();

                IsMouseAndControlDown = false;

                IsMouseDown = false;

                e.Handled = true;
            }

            IsDragging = false;
        }

        private void AssociatedObject_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(listBox == null)
                listBox = FrameworkElementExtension.FindParent<ListBox>(AssociatedObject);

            if (canvas == null)
                canvas = FrameworkElementExtension.FindParent<Canvas>(AssociatedObject);

            if (lbi == null)
                lbi = FrameworkElementExtension.FindParent<ListBoxItem>(AssociatedObject);

            IsMouseDown = true;

            IsMouseAndControlDown = (Keyboard.Modifiers & ModifierKeys.Control) != 0;

            if (!IsMouseAndControlDown)
            {
                if (listBox.SelectedItems.Count == 0)
                {
                    listBox.SelectedItems.Add(AssociatedObject);
                }
                else if (listBox.SelectedItems.Contains(AssociatedObject))
                {
                    
                }
                else
                {
                    listBox.SelectedItems.Clear();

                    listBox.SelectedItems.Add(AssociatedObject);
                }
            }
            else
            {
                if (!listBox.SelectedItems.Contains(AssociatedObject))
                {
                    listBox.SelectedItems.Add(AssociatedObject);
                }
            }

            mouseOffset = e.GetPosition(canvas);

            AssociatedObject.CaptureMouse();

            e.Handled = true;
        }
    }
}
