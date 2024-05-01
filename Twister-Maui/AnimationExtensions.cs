using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twister_Maui
{
    public static class AnimationExtensions
    {
        #region Color Animation
        public static Task<bool> ColorTo(this Ellipse self, Color fromColor, Color toColor, Action<Color> callback, uint length = 250, Easing easing = null)
        {
            Func<double, Color> transform = (t) =>
                Color.FromRgba(fromColor.Red + t * (toColor.Red - fromColor.Red),
                               fromColor.Green + t * (toColor.Green - fromColor.Green),
                               fromColor.Blue + t * (toColor.Blue - fromColor.Blue),
                               fromColor.Alpha + t * (toColor.Alpha - fromColor.Alpha));
            return ColorAnimation(self, "ColorTo", transform, callback, length, easing);
        }

        public static void CancelColorAnimation(this Ellipse self)
        {
            self.AbortAnimation("ColorTo");
        }

        private static Task<bool> ColorAnimation(Ellipse element, string name, Func<double, Color> transform, Action<Color> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<Color>(name, transform, callback, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));
            return taskCompletionSource.Task;
        }

        #endregion

        #region Thickness Animation

        public static Task<bool> ThicknessTo(this Ellipse self, Thickness fromThickness, Thickness toThickness, Action<Thickness> callback, uint length = 250, Easing easing = null)
        {
            Func<double, Thickness> transform = (t) =>
                new Thickness(fromThickness.Left + t * (toThickness.Left - fromThickness.Left),
                               fromThickness.Top + t * (toThickness.Top - fromThickness.Top),
                               fromThickness.Right + t * (toThickness.Right - fromThickness.Right),
                               fromThickness.Bottom + t * (toThickness.Bottom - fromThickness.Bottom));
            return ThicknessAnimation(self, "ThicknessTo", transform, callback, length, easing);
        }

        public static void CancelThicknessAnimation(this Ellipse self)
        {
            self.AbortAnimation("ThicknessTo");
        }

        private static Task<bool> ThicknessAnimation(Ellipse element, string name, Func<double, Thickness> transform, Action<Thickness> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<Thickness>(name, transform, callback, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));
            return taskCompletionSource.Task;
        }

        #endregion
    }
}
