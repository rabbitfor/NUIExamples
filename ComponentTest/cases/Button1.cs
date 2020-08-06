using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class Button1 : TestUnit
{
    public override void OnCreate(View root)
    {
        root.BackgroundColor = Color.Black;
        var button0 = new Button(new OverlayAnimationButtonStyle())
        {
            Text = "Hello World!",
            IconURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Button1/icon.png",
            IconPadding = new Extents(0, 0, 50, 0),
            Size = new Size(200, 200),
            CornerRadius = 100,
            PositionUsesPivotPoint = true,
            PivotPoint = PivotPoint.Center,
            ParentOrigin = ParentOrigin.Center,
        };
        root.Add(button0);
    }

    public override string RunningDescription => "There is a circle button with wearable icon and 'Hello World' text in the center.";

    public override string PassCondition => "* Icon and text get dimmed when pressed.\n* light circle is spreading out from the center when click.";
}
