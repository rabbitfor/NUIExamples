using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class DropDown0 : TestUnit
{
    public override void OnCreate(View root)
    {
        // dropDown0 : Test default DropDown.
        var dropdown0 = new DropDown()
        {
            BackgroundColor = Color.Blue,
        };
        dropdown0.AddItem(new DropDown.DropDownDataItem{ Text = "Orange" });
        dropdown0.AddItem(new DropDown.DropDownDataItem{ Text = "Apple" });
        dropdown0.AddItem(new DropDown.DropDownDataItem{ Text = "Banana" });
        root.Add(dropdown0);
    }

    public override string RunningDescription => "There is a dropdown box in the left-top corner.\nClick down arraw in the white box.\nAnd select one of items(Orange, Apple, Banana) in the list.";

    public override string PassCondition => "Check the box background color is blue when pressed.\nCheck the selected item text is showing correctly in the box.";
}
