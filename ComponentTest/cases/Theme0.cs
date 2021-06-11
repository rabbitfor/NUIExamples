using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;


// Test reuse of button style
public class Theme0 : TestUnit
{
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
                    PixelSize = 18,
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

    Theme theme1, theme2, theme3;

    public override void OnCreate(View root)
    {
        var buttonStyle1 = new ButtonStyle()
        {
            Size = new Size(160, 100),
            BackgroundColor = Color.Blue,
            Text = new TextLabelStyle
            {
                TextColor = Color.Black,
                PixelSize = 16,
            },
            Icon = new ImageViewStyle
            {
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image.jpg",
                Size = new Size(30, 30)
            },
            ThemeChangeSensitive = true,
        };
        var buttonStyle2 = new ButtonStyle()
        {
            Size = new Size(120, 120),
            BackgroundColor = Color.Red,
            Text = new TextLabelStyle
            {
                TextColor = Color.White,
                PixelSize = 18,
            },
            Icon = new ImageViewStyle
            {
                ResourceUrl = "",
                Size = new Size(0, 0)
            },
            ThemeChangeSensitive = true,
        };

        theme1 = new Theme();
        theme1.AddStyle("Button1", buttonStyle1);
        theme1.AddStyle("Button2", buttonStyle2);

        theme2 = new Theme();
        theme2.AddStyle("Button1", buttonStyle2);
        theme2.AddStyle("Button2", buttonStyle1);

        theme3 = new Theme();
        buttonStyle2.BackgroundColor = Color.Yellow;
        buttonStyle2.Text.TextColor = Color.Black;
        theme3.AddStyle("Button1", buttonStyle2);

        ThemeManager.ApplyTheme(theme1);

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
        clickCount = (clickCount + 1) % 3;
        if (clickCount == 0)
        {
            ThemeManager.ApplyTheme(theme1);
        }
        else if (clickCount == 1)
        {
            ThemeManager.ApplyTheme(theme2);
        }
        else
        {
            ThemeManager.ApplyTheme(theme3);
        }
    }

    public override string RunningDescription => "There are 3 blue boxes in left side with a small image: A, B, C.\n"
                                               + "There are 2 red boxes in the right with no image: B, C.";

    public override string PassCondition => "1. Click A\n"
                                          + "-> A, C will be red boxes. And B, D will be blue boxes with icon. No changes for E.\n\n"
                                          + "2. Click A again!\n"
                                          + "-> A, C will have look of yellow boxes. No changes for B, D, E.\n\n"
                                          + "3. Click A again!\n"
                                          + "-> A, C will be blue boxes with icon. And B, D will be red boxes. No changes for E.";
}
