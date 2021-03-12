using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

// Test reuse of button style
public class Button0 : TestUnit
{
    public override void OnCreate(View root)
    {       
        var button0 = new Button();
        button0.Text = "Button0";
        root.Add(button0);

        var style = button0.Style;
        style.Position = new Position(0, 100);
        style.BackgroundColor = new Selector<Color>
        {
            Normal = Color.Blue,
            Pressed = Color.Red,
        };
        style.CornerRadius = 20;
        style.Text.Text = "Button1";
        var button1 = new Button(style);
        root.Add(button1);

        style = button1.Style;
        style.Position = new Position(0, 200);
        style.BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image.jpg";
        style.CornerRadius = 10;
        style.Text.Text = "Button2";
        var button2 = new Button(style);
        root.Add(button2);
    }

    public override string RunningDescription => "* Button0: Grey background.\n" +
                                                 "* Button1: Blue background.\n" +
                                                 "* Button2: Rounded image background.";

    public override string PassCondition => "* Button0: Darken when click." + Environment.NewLine +
                                            "* Button1: Rounded red when click." + Environment.NewLine +
                                            "* Button2: No background change when click.";
}
