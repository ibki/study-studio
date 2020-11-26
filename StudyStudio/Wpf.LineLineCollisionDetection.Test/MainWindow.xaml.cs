using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Wpf.LineLineCollisionDetection.Test
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// http://www.jeffreythompson.org/collision-detection/line-line.php
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="x4"></param>
        /// <param name="y4"></param>
        /// <returns></returns>
        private (bool isCollision, double intersectionX, double intersectionY) IsCollision(
            double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            // calculate the distance to intersection point
            double uA = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));
            double uB = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));

            // if uA and uB are between 0-1, lines are colliding
            if (uA >= 0 && uA <= 1 && uB >= 0 && uB <= 1)
            {
                // optionally, draw a circle where the lines meet
                double intersectionX = x1 + (uA * (x2 - x1));
                double intersectionY = y1 + (uA * (y2 - y1));

                return (true, intersectionX, intersectionY);
            }

            return (false, 0, 0);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            var canvas = sender as Canvas;

            canvas.Children.RemoveRange(1, canvas.Children.Count - 1);

            Line centerLine = new Line
            {
                X1 = 80,
                Y1 = canvas.ActualHeight / 2,
                X2 = canvas.ActualWidth - 80,
                Y2 = canvas.ActualHeight / 2,
                StrokeThickness = 1,
                Stroke = Brushes.Black
            };
            canvas.Children.Add(centerLine);

            var cursorPosition = e.GetPosition(canvas);
            Line cursorLine = new Line
            {
                X2 = cursorPosition.X,
                Y2 = cursorPosition.Y,
                StrokeThickness = 1,
                Stroke = Brushes.DarkGray
            };

            var startPosition = (StartPosition)((FrameworkElement)((FrameworkElement)canvas.TemplatedParent).TemplatedParent).Tag;
            switch (startPosition)
            {
                case StartPosition.LeftTop: cursorLine.X1 = 5; cursorLine.Y1 = 5; break;
                case StartPosition.CenterTop: cursorLine.X1 = canvas.ActualWidth / 2; cursorLine.Y1 = 5; break;
                case StartPosition.RightTop: cursorLine.X1 = canvas.ActualWidth - 5; cursorLine.Y1 = 5; break;

                case StartPosition.LeftCenter: cursorLine.X1 = 5; cursorLine.Y1 = centerLine.Y1; break;
                case StartPosition.CenterCenter: cursorLine.X1 = canvas.ActualWidth / 2; cursorLine.Y1 = centerLine.Y1; break;
                case StartPosition.RightCenter: cursorLine.X1 = canvas.ActualWidth - 5; cursorLine.Y1 = centerLine.Y1; break;

                case StartPosition.LeftBottom: cursorLine.X1 = 5; cursorLine.Y1 = canvas.ActualHeight - 5; break;
                case StartPosition.CenterBottom: cursorLine.X1 = canvas.ActualWidth / 2; cursorLine.Y1 = canvas.ActualHeight - 5; break;
                case StartPosition.RightBottom: cursorLine.X1 = canvas.ActualWidth - 5; cursorLine.Y1 = canvas.ActualHeight - 5; break;
            }

            canvas.Children.Add(cursorLine);
            
            (bool isCollision, double intersectionX, double intersectionY) = IsCollision(
                cursorLine.X1, cursorLine.Y1, cursorLine.X2, cursorLine.Y2, 
                centerLine.X1, centerLine.Y1, centerLine.X2, centerLine.Y2);

            if (isCollision)
            {
                var ellipse = new Ellipse { Width = 10, Height = 10, Stroke = Brushes.Red, StrokeThickness = 10 };
                ellipse.SetValue(Canvas.LeftProperty, intersectionX - 5);
                ellipse.SetValue(Canvas.TopProperty, intersectionY - 5);
                canvas.Children.Add(ellipse);
            }
        }
    }

    public enum StartPosition
    {
        LeftTop,
        CenterTop,
        RightTop,
        LeftCenter,
        CenterCenter,
        RightCenter,
        LeftBottom,
        CenterBottom,
        RightBottom,
    }
}
