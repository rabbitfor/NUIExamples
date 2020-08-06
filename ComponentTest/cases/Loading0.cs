using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class Loading0 : TestUnit
{
    public override void OnCreate(View root)
    {
        string[] imageArray = new string[20];
        for (int i = 0; i < 20; i++)
        {
            imageArray[i] = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Loading0/activityindicator_full" + i.ToString("00000") + ".png";
            Tizen.Log.Info("JYJY", imageArray[i] + "\n");
        }
        
        // loading0 : Default Loading.
        var loading0 = new Loading();
        loading0.Size = new Size(100, 100);
        loading0.ImageArray = imageArray;
        // loading0.Name = "Loading0";
        root.Add(loading0);

        // loading1 : Loading with style.
        var loading1 = new Loading(new LoadingStyle
        {
            Size = new Size(100, 100),
            Position = new Position(0, 100),
            Images  = imageArray
        });
        root.Add(loading1);
    }

    public override string RunningDescription => "";

    public override string PassCondition => "Two circles are cycling.";
}
