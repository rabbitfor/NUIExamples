using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class Selector0 : TestUnit
{
    public override void OnCreate(View root)
    {
        // button0 : Test overwriting selector by non-selector
        var button = new Button(new ButtonStyle
        {
            Size = new Size(200, 60),
            Text = new TextLabelStyle
            {
                TextColor = new Selector<Color>
                {
                    Normal = Color.Black,
                    Pressed = Color.Yellow,
                },
                Text = "Button0",
                PixelSize = 12,
            },
            BackgroundColor = Color.Yellow,
        });
        button.TextColor = Color.Black;
        root.Add(button);

        // button1 : Test opacity selector
        var button1 = new Button(new ButtonStyle
        {
            Size = new Size(200, 60),
            Position = new Position(0, 60),
            Text = new TextLabelStyle
            {
                Text = "Button1",
                PixelSize = 12,
            },
            BackgroundColor = Color.Blue,
            Opacity = null
        });
        root.Add(button1);

        // button2 : Test opacity selector
        var button2 = new Button(new ButtonStyle
        {
            Size = new Size(200, 60),
            Position = new Position(0, 120),
            Text = new TextLabelStyle
            {
                Text = "Button2",
                PixelSize = 12,
            },
            BackgroundColor = Color.Red,
        });
        button2.TextLabel.Opacity = 0.2f;
        root.Add(button2);

        // button3 : Test null item of opacity selector
        var button3 = new Button(new ButtonStyle
        {
            Size = new Size(200, 60),
            Position = new Position(0, 180),
            Text = new TextLabelStyle
            {
                Text = "Button3",
                PixelSize = 12,
            },
            BackgroundColor = Color.Green,
            Opacity = new Selector<float?>
            {
                Pressed = 0.5f,
            }
        });
        root.Add(button3);

        var expected = new View
        {
            BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Selector0/expected.png",
            PositionUsesPivotPoint = true,
            ParentOrigin = ParentOrigin.TopRight,
            PivotPoint = PivotPoint.TopRight,
        };
        root.Add(expected);
    }

    public override string TestDescription => "This tests funtonality of selectors in styles using button.";

    public override string RunningDescription => "Click buttons on the left side";

    public override string PassCondition => "1. The buttons on the left and right should look same.\n2. All button are still when click.";
}
