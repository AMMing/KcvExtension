using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AMing.KcvExtension.Core.Controls
{
    public class Settings : UserControl
    {
        public Settings()
        {
            this.Loaded += Settings_Loaded;
        }

        bool isinit = false;
        private void Settings_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (isinit) return;
            isinit = true;

            (this.Content as Grid)?.Children.Insert(0, this.CreateBackgroundImage());
        }
        #region prop

        public ImageSource BackgroundImage
        {
            get { return (ImageSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundImageProperty =
            DependencyProperty.Register("BackgroundImage", typeof(ImageSource), typeof(Settings), new PropertyMetadata(null));


        public Brush BackgroundImageColor
        {
            get { return (Brush)GetValue(BackgroundImageColorProperty); }
            set { SetValue(BackgroundImageColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundImageColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundImageColorProperty =
            DependencyProperty.Register("BackgroundImageColor", typeof(Brush), typeof(Settings), new PropertyMetadata(null));

        #endregion

        #region method
        protected virtual UIElement CreateBackgroundImage()
        {
            var rect = new Rectangle
            {
                Width = 400,
                Height = 400,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right,
                OpacityMask = new ImageBrush
                {
                    ImageSource = this.BackgroundImage
                },
                Fill = this.BackgroundImageColor ?? new SolidColorBrush(Colors.Black)
            };

            return rect;
        }

        #endregion
    }
}
