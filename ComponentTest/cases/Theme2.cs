using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class Theme2 : TestUnit
{
    public override void OnCreate(View root)
    {       
        var resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        var theme = new Theme(resourcePath + "Theme2/TestTheme.xaml");
        var buttonStyle = theme.GetStyle(typeof(Button)) as ButtonStyle;
        var checkBoxStyle = theme.GetStyle(typeof(CheckBox)) as ButtonStyle;
        var switchStyle = theme.GetStyle(typeof(Switch)) as SwitchStyle;

        root.Add(new TextLabel(){
            Position = new Position(),
            Text = "Test1: " + (buttonStyle == null ? "FAIL" : "PASS"),
        });

        root.Add(new TextLabel(){
            Position = new Position(0, 30),
            Text = "Test2: " + ((checkBoxStyle == null ? false : (checkBoxStyle.Icon.Opacity == null ? false : (checkBoxStyle.Icon.Opacity.All == 0.8f))) ? "PASS" : "FAIL"),
        });
        root.Add(new TextLabel(){
            Position = new Position(0, 60),
            Text = "Test3: " + ((checkBoxStyle == null ? false : (checkBoxStyle.Icon.ResourceUrl == null ? false : !string.IsNullOrEmpty(checkBoxStyle.Icon.ResourceUrl.Selected))) ? "PASS" : "FAIL"),
        });

        root.Add(new TextLabel(){
            Position = new Position(0, 90),
            Text = "Test4: " + ((switchStyle == null ? false : (switchStyle.Track.Border == null ? false : (switchStyle.Track.Border.All == null))) ? "PASS" : "FAIL"),
        });

        root.Add(new TextLabel(){
            Position = new Position(0, 120),
            Text = "Test5: " + ((switchStyle == null ? false : (switchStyle.Track.Size == null ? false : switchStyle.Track.Size.Equals(new Size(96, 96)))) ? "PASS" : "FAIL"),
        });
    }

    public override string RunningDescription => "";

    public override string PassCondition => "Check all 5 test cases show 'PASS'";
}
