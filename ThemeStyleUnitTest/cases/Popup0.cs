using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class Popup0 : TestUnit
{

    private TextLabel[] createText = new TextLabel[2];

    private Popup popup0 = null;
    private Popup popup1 = null;
    private Popup popup2 = null;

    private static Color[] color = new Color[]
    {
        new Color(0.05f, 0.63f, 0.9f, 1),//#ff0ea1e6
        new Color(0.14f, 0.77f, 0.28f, 1),//#ff24c447
        new Color(0.75f, 0.46f, 0.06f, 1),//#ffec7510
        new Color(0.59f, 0.38f, 0.85f, 1),//#ff9762d9
    };

    public override void OnCreate(View root)
    {
        var resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        NUIApplication.GetDefaultWindow().BackgroundColor = Color.White;
        
        popup0 = new Popup();
        popup0.BackgroundColor = Color.Cyan;
        popup0.Title.Text = "Popup0";
        popup0.Size = new Size(500, 400);
        popup0.ButtonHeight = 60;
        popup0.AddButton("Left");
        popup0.AddButton("Right");
        popup0.PopupButtonClickEvent += Popup0ButtonClickedEvent;
        popup0.Post(NUIApplication.GetDefaultWindow());

        var style = new PopupStyle()
        {
            IncludeDefaultStyle = true,
            Size = new Size(500, 400),
            Position = new Position(60, 60),
            BackgroundColor = Color.Magenta,
            Title = new TextLabelStyle()
            {
                Text = "Popup1",
                TextColor = Color.White,
            },
            Buttons = new ButtonStyle()
            {
                CornerRadius = 0,
                SizeHeight = 60,
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(1, 1, 1, 1),
                    Pressed = new Color(1, 1, 1, 0.5f),
                },
                Overlay = new ImageViewStyle()
                {
                    BackgroundColor = new Selector<Color>()
                    {
                        Pressed = new Color(0, 0, 0, 0.1f),
                        Other = new Color(1, 1, 1, 0.1f),
                    },
                },
                Text = new TextLabelStyle()
                {
                    TextColor = new Color(0.05f, 0.63f, 0.9f, 1),
                }
            }
        };
        popup1 = new Popup(style);
        popup1.AddButton("Left");
        popup1.AddButton("Right");
        popup1.PopupButtonClickEvent += Popup1ButtonClickedEvent;
        popup1.Post(NUIApplication.GetDefaultWindow());
    }

    public override void OnDestroy(View root)
    {
        popup0?.Dismiss();
        popup1?.Dismiss();
    }

    private void Popup0ButtonClickedEvent(object sender, Popup.ButtonClickEventArgs e)
    {
        Popup obj = sender as Popup;
        if (obj != null)
        {
            popup0.Dismiss();             
        }
    }

    private void Popup1ButtonClickedEvent(object sender, Popup.ButtonClickEventArgs e)
    {
        Popup obj = sender as Popup;
        if (obj != null)
        {
            popup0.ContentView.Add(new TextLabel("Popup1: " + (e.ButtonIndex == 0 ? "Left" : "Right"))
            {
                // Position = new Position(0, 60),
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = Color.Magenta,
            });
            popup1.Dismiss();
        }
    }

    public override string TestDescription => "This tests creating popup with a style.";

    public override string RunningDescription => "There are two popups.";

    public override string PassCondition => "1. Click Left or Right button in Popup1\n"
                                          + "-> Popup1 disappear and Popup0 shows the choosen text (Left or Right)\n"
                                          + "2. Click Left or Right button in Popup0\n"
                                          + "-> Popup0 disappear";
}
