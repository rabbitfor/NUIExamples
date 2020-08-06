using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class ImageView0 : TestUnit
{
    public override void OnCreate(View root)
    {
        var view0 = new ImageView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image.jpg")
        {
            Size = new Size(100, 100),
            BackgroundColor = Color.Red,
        };
        root.Add(view0);

        var view1 = new ImageView
        {
            Size = new Size(100, 100),
            Position = new Position(0, 100),
            BackgroundColor = Color.Green,
            ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image.jpg",
        };
        root.Add(view1);

        var view2 = new ImageView
        {
            Size = new Size(100, 100),
            Position = new Position(0, 200),
            ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image.jpg",
            BackgroundColor = Color.Blue,
        };
        root.Add(view2);

        var view3 = new ImageView
        {
            Size = new Size(100, 100),
            Position = new Position(0, 300),
            Opacity = 0.2f,
            ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image.jpg",
        };
        root.Add(view3);

        var view4 = new ImageView(view0.Style)
        {
            PositionX = 100,
            Opacity = 0.5f,
        };
        root.Add(view4);

        var view5 = new ImageView(view1.Style)
        {
            PositionX = 100,
            Opacity = 0.5f,
        };
        root.Add(view5);

        var view6 = new ImageView(view2.Style)
        {
            PositionX = 100,
            Opacity = 0.5f,
        };
        root.Add(view6);

        var view7 = new ImageView(view3.Style)
        {
            PositionX = 100,
            Opacity = 0.5f,
        };
        root.Add(view7);

        var expected = new ImageView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "ImageView0/expected.png")
        {
            PositionX = 400,
        };
        root.Add(expected);
    }

    public override string RunningDescription => "There are 16 images";

    public override string PassCondition => " 8 images in the left and the other 8 images in the right should look same.";
}
