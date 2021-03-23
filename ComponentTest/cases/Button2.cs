using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class Button2 : TestUnit
{
    public override void OnCreate(View root)
    {
        var resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

        root.Add(new Button()
        {
            IconPadding = 10,
            TextPadding = 10,
            IconURL = resourcePath + "image.jpg",
            Text = "Very very very long long long long button text!!"
        });

        root.Add(new Button()
        {
            Position = new Position(0, 100),
            IconPadding = 10,
            TextPadding = 10,
            IconURL = resourcePath + "image.jpg",
        });

        root.Add(new Button()
        {
            Position = new Position(0, 200),
            IconPadding = 10,
            TextPadding = 10,
            Text = "Very very very long long long long button text!!"
        });
    }

    public override string RunningDescription => "";

    public override string PassCondition => "";
}
