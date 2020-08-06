using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class View0 : TestUnit
{
    public override void OnCreate(View root)
    {
        var view0 = new View
        {
            Size = new Size(100, 100),
            BackgroundColor = Color.Red,
        };
        root.Add(view0);

        var view1 = new View
        {
            Size = new Size(100, 100),
            Position = new Position(0, 100),
            BackgroundColor = Color.Green,
            BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image.jpg",
        };
        root.Add(view1);

        var view2 = new View
        {
            Size = new Size(100, 100),
            Position = new Position(0, 200),
            BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image.jpg",
            BackgroundColor = Color.Blue,
        };
        root.Add(view2);

        var view3 = new View
        {
            Size = new Size(100, 100),
            Position = new Position(0, 300),
            Opacity = 0.2f,
            BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image.jpg",
        };
        root.Add(view3);
    }

    public override string RunningDescription => "";

    public override string PassCondition => "From the top to bottom,\nRed box\nGirl\nBlue box\nBlurred girl";
}
