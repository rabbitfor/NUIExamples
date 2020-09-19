using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class Switch1 : TestUnit
{
    Switch switchButton;
    View root;

    public override void OnCreate(View root)
    {
        this.root = root;
        root.BackgroundColor = Color.Black;
        
        var button = new Button()
        {
            Text = "Click to Attach!",
            Size = new Size(150, 40),
            Position = new Position(10, 10),
        };
        root.Add(button);
        button.Clicked += OnClicked;

        switchButton = new Switch
        {
            IsSelected = true,
            Position = new Position(10, 60),
        };
    }

    public override string RunningDescription => "Click the button.\n";

    public override string PassCondition => "A switch will show up with selected state.\nThumb left and background blue.\n";

    private void OnClicked(object target, ClickedEventArgs args)
    {
        root.Add(switchButton);
    }  
}
