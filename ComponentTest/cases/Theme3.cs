using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class Theme3 : TestUnit
{
    public override void OnCreate(View root)
    {
        var theme1 = new Theme();
        theme1.AddStyle("Button", new ButtonStyle {
            BackgroundColor = Color.Blue,
            Position = new Position(100, 100)
        });

        var theme2 = new Theme();
        theme2.AddStyle("Button", new ButtonStyle {
            BackgroundColor = Color.Red,
            Size = new Size(100, 100),
        });

        theme1.Merge(theme2);
        root.Add(new Button(theme1.GetStyle("Button") as ButtonStyle)
        {
            Text = "Button1",
        });

        theme2.GetStyle("Button").SolidNull = true;
        theme1.Merge(theme2);
        root.Add(new Button(theme1.GetStyle("Button") as ButtonStyle)
        {
            Text = "Button2",
        });
    }

    public override string RunningDescription => "There are two red boxes.";

    public override string PassCondition => "The \"Button2\" is in the left-top corner.\nThe \"Button1\" is placed in the right-bottom corner of the \"Button2\"";
}
