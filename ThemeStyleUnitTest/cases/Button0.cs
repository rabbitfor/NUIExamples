using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

// Test reuse of button style
public class Button0 : TestUnit
{
    public override void OnCreate(View root)
    {
        var container = new View ()
        {
            WidthResizePolicy = ResizePolicyType.FitToChildren,
            HeightResizePolicy = ResizePolicyType.FitToChildren,
            PositionUsesPivotPoint = true,
            ParentOrigin = ParentOrigin.Center,
            PivotPoint = PivotPoint.Center,
        };

        var button0 = new Button();
        button0.Text = "Button0";
        container.Add(button0);

        var style = button0.Style;
        style.Position = new Position(0, 100);
        style.BackgroundColor = new Selector<Color>
        {
            Normal = Color.Blue,
            Pressed = Color.Red,
        };
        style.Text.Text = "Button1";
        var button1 = new Button(style);
        container.Add(button1);

        style = button1.Style;
        style.Position = new Position(0, 200);
        style.BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image.jpg";
        style.Text.Text = "Button2";
        style.CornerRadius = 0;
        var button2 = new Button(style);
        container.Add(button2);

        root.Add(container);
    }

    public override string TestDescription => "This tests creating a button with a style from other button.";

    public override string RunningDescription => "* Button0: Navy background.\n" +
                                                 "* Button1: Blue background.\n" +
                                                 "* Button2: Image background and non-rounded rectangle shape.";

    public override string PassCondition => "* Button0: Be brighten when click." + Environment.NewLine +
                                            "* Button1: Be red when click." + Environment.NewLine +
                                            "* Button2: No background change when click.";
}
