

using Microsoft.Maui.Controls.Shapes;
using Windows.Services.Maps;

namespace Twister_Maui;

public partial class CircleColor : ContentView
{

    #region Dependency Properties

    public bool Selected
    {
        get { return (bool)GetValue(SelectedProperty); }
        set { SetValue(SelectedProperty, value); }
    }

    public static readonly BindableProperty SelectedProperty =
        BindableProperty.CreateAttached("Selected", typeof(bool), typeof(CircleColor), false);

    public SolidColorBrush CircleBackground
    {
        get { return (SolidColorBrush)GetValue(CircleBackgroundProperty); }
        set { SetValue(CircleBackgroundProperty, value); }
    }

    public static readonly BindableProperty CircleBackgroundProperty =
        BindableProperty.CreateAttached("CircleBackground", typeof(SolidColorBrush), typeof(CircleColor), new SolidColorBrush(Colors.Black));

    public SolidColorBrush CircleFill
    {
        get { return (SolidColorBrush)GetValue(CircleFillProperty); }
        set { SetValue(CircleFillProperty, value); }
    }

    public static readonly BindableProperty CircleFillProperty =
        BindableProperty.CreateAttached("CircleFill", typeof(SolidColorBrush), typeof(CircleColor), new SolidColorBrush(Colors.LightGreen));


    public SolidColorBrush CircleStroke
    {
        get { return (SolidColorBrush)GetValue(CircleStrokeProperty); }
        set { SetValue(CircleStrokeProperty, value); }
    }

    public static readonly BindableProperty CircleStrokeProperty =
        BindableProperty.CreateAttached("CircleStroke", typeof(SolidColorBrush), typeof(CircleColor), new SolidColorBrush(Colors.Lime));

    #endregion

    #region Events

    //public static readonly RoutedEvent OnClickedEvent = EventManager.RegisterRoutedEvent(
    //    "OnClicked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CircleColor));

    //public event RoutedEventHandler OnClicked
    //{
    //    add { AddHandler(OnClickedEvent, value); }
    //    remove { RemoveHandler(OnClickedEvent, value); }
    //}

    #endregion

    public CircleColor()
	{
		InitializeComponent();
        BindingContext = this;

        

    }

    private void AnimateEllipseMargin()
    {
        var ellipse = InnerCircle;
        var animation = new Animation(v => ellipse.HeightRequest = v, 100, 200, Easing.Linear);

        // Optionally, you can loop the animation
        var parentAnimation = new Animation();
        parentAnimation.Add(0, 1, animation);
        parentAnimation.Commit(this, "HeightAnimation", length: 1000, repeat: () => false);
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Console.WriteLine("Tapped");
        AnimateEllipseMargin();
    }
}