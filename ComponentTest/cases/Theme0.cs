using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;


// Test reuse of button style
public class Theme0 : TestUnit
{
    public class Button1 : Tizen.NUI.Components.StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            return new ButtonStyle()
            {
                Size = new Size(160, 100),
                BackgroundColor = Color.Blue,
                Text = new TextLabelStyle
                {
                    TextColor = Color.Black,
                    PointSize = 16,
                },
                Icon = new ImageViewStyle
                {
                    ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image.jpg",
                    Size = new Size(30, 30)
                }
            };
        }
    }

    public class Button2 : Tizen.NUI.Components.StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            return new ButtonStyle()
            {
                Size = new Size(120, 120),
                BackgroundColor = Color.Red,
                Text = new TextLabelStyle
                {
                    TextColor = Color.White,
                    PointSize = 18,
                },
                Icon = new ImageViewStyle
                {
                    ResourceUrl = "",
                    Size = new Size(0, 0)
                }
            };
        }
    }

    public class Button3 : Button2
    {
        protected override ViewStyle GetViewStyle()
        {
            var result = (ButtonStyle)base.GetViewStyle();
            result.BackgroundColor = Color.Yellow;
            result.Text.TextColor = Color.Black;
            return result;
        }
    }

    int clickCount = 0;

    public override void OnCreate(View root)
    {       
        Tizen.NUI.Components.StyleManager.Instance.Theme = "Theme1";

        Tizen.NUI.Components.StyleManager.Instance.RegisterStyle("Button1", "Theme1", typeof(Button1));
        Tizen.NUI.Components.StyleManager.Instance.RegisterStyle("Button2", "Theme1", typeof(Button2));
        Tizen.NUI.Components.StyleManager.Instance.RegisterStyle("Button1", "Theme2", typeof(Button2));
        Tizen.NUI.Components.StyleManager.Instance.RegisterStyle("Button2", "Theme2", typeof(Button1));
        Tizen.NUI.Components.StyleManager.Instance.RegisterStyle("Button1", null, typeof(Button3));

        var button = new Button("Button1")
        {
            Text = "A"
        };
        root.Add(button);

        var button1 = new Button("Button2")
        {
            Position = new Position(170, 0),
            Text = "B"
        };
        root.Add(button1);

        var button2 = new Button("Button1")
        {
            Position = new Position(0, 130),
            Text = "C"
        };
        root.Add(button2);

        var button3 = new Button("Button2")
        {
            Position = new Position(170, 130),
            Text = "D"
        };
        root.Add(button3);

        var button4 = new Button("Button1")
        {
            Position = new Position(0, 260),
            ThemeChangeSensitive = false,
            Text = "E"
        };
        root.Add(button4);

        button.Clicked += OnClicked;
    }

    public void OnClicked(object target, ClickedEventArgs args)
    {
        Tizen.Log.Info("JYJY", "OnClicked\n");
        clickCount = (clickCount + 1) % 3;
        if (clickCount == 0)
        {
            Tizen.NUI.Components.StyleManager.Instance.Theme = "Theme1";
        }
        else if (clickCount == 1)
        {
            Tizen.NUI.Components.StyleManager.Instance.Theme = "Theme2";
        }
        else
        {
            Tizen.NUI.Components.StyleManager.Instance.Theme = "Default";
        }
    }

    public override string RunningDescription => "There are 3 blue boxes in left side with a small icon.\n"
                                               + "There are 2 red boxes in the right with no image.";

    public override string PassCondition => "Click A!\n"
                                          + "* A, C will be red boxes. And B, D will be blue boxes with icon. No changes for E.\n\n"
                                          + "Click A again!\n"
                                          + "* A, C will have look of yellow boxes. No changes for B, D, E.\n\n"
                                          + "Click A again!\n"
                                          + "* A, C will be blue boxes with icon. And B, D will be red boxes. No changes for E.";
}
