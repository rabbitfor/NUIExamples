using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class Progress0 : TestUnit
{
    public override void OnCreate(View root)
    {       
        var progress0 = new Progress
        {
            Position = new Position(0, 20),
            CurrentValue = 30,
            BufferValue = 80,
        };
        root.Add(progress0);

        var progress1 = new Progress(new ProgressStyle
        {
            Size = new Size(300, 30),
            Position = new Position(0, 50),
            Track = new ImageViewStyle
            {
                BackgroundColor = Color.Red
            },
            Progress = new ImageViewStyle
            {
                BackgroundColor = Color.Blue
            },
            Buffer = new ImageViewStyle
            {
                BackgroundColor = Color.Yellow
            },
        })
        {
            CurrentValue = 30,
            BufferValue = 80,
        };
        root.Add(progress1);

        var progress2 = new Progress(progress1.Style)
        {
            Position = new Position(0, 100),
            CurrentValue = 30,
            BufferValue = 80,
        };
        root.Add(progress2);
    }

    public override string RunningDescription => "There are 3 bars.";

    public override string PassCondition => "* 1) Thin bar colored  blue> light-blue> grey.\n"
                                          + "* 2) Thick bar colored blue> yellow> red.\n"
                                          + "* 3) Same look as 2).\n";
}
