using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class Theme1 : TestUnit
{
    int clickCount = 0;
    Popup popup0, popup1;
    Theme theme1, theme2;

    public override void OnCreate(View root)
    {
        var popupStyle1 = new PopupStyle()
        {
            Size = new Size(500, 200),
            BackgroundColor = Color.White,
            BoxShadow = new Shadow(6.0f, Color.Blue, extents: new Vector2(5, 5)),
            Title = new TextLabelStyle
            {
                TextColor = Color.Black,
                PixelSize = 16,
                Text = "PopupStyle1"
            },
            Buttons = new ButtonStyle
            {
                SizeHeight = 50,
                BackgroundColor = new Selector<Color>
                {
                    Pressed = Color.Black,
                    Other = Color.Cyan,
                },
                Text = new TextLabelStyle
                {
                    TextColor = new Selector<Color>
                    {
                        Pressed = Color.White,
                        Other = Color.Black,
                    },
                    PixelSize = 12,
                },
                ParentOrigin = ParentOrigin.BottomLeft,
                PivotPoint = PivotPoint.BottomLeft,
                PositionUsesPivotPoint = true
            },
            ThemeChangeSensitive = true,
        };

        var popupStyle2 = popupStyle1.Clone() as PopupStyle;
        popupStyle2.BackgroundColor = Color.Black;
        popupStyle2.Title.Text = "PopupStyle2";
        popupStyle2.Title.TextColor = Color.Cyan;
        popupStyle2.Buttons.SizeHeight = 80;
        popupStyle2.Buttons.BackgroundColor = new Selector<Color>
        {
            Pressed = Color.Cyan,
            Other = Color.Black,
        };
        popupStyle2.Buttons.Text.TextColor = new Selector<Color>
        {
            Pressed = Color.Black,
            Other = Color.White,
        };

        theme1 = new Theme();
        theme1.AddStyle("Popup1", popupStyle1);
        theme1.AddStyle("Popup2", popupStyle2);

        theme2 = new Theme();
        theme2.AddStyle("Popup1", popupStyle2);
        theme2.AddStyle("Popup2", popupStyle1);

        ThemeManager.ApplyTheme(theme1);

        popup0 = new Popup("Popup1");
        popup0.AddButton("ChangeTheme");
        popup0.AddButton("Close");
        popup0.PopupButtonClickEvent += PopupButtonClickedEvent;
        popup0.Post(NUIApplication.GetDefaultWindow());

        popup1 = new Popup("Popup2");
        popup1.Position = new Position(0, 210);
        popup1.AddButton("ChangeTheme");
        popup1.AddButton("Close");
        popup1.PopupButtonClickEvent += PopupButtonClickedEvent;
        popup1.Post(NUIApplication.GetDefaultWindow());
    }
    
    public override void OnDestroy(View root)
    {
        popup0?.Dismiss();
        popup1?.Dismiss();
    }

    private void PopupButtonClickedEvent(object sender, Popup.ButtonClickEventArgs e)
    {
        if (e.ButtonIndex == 1)
        {
            (sender as Popup)?.Dismiss();             
        }
        else
        {
            clickCount = (clickCount + 1) % 2;
            if (clickCount == 0)
            {
                ThemeManager.ApplyTheme(theme1);
            }
            else if (clickCount == 1)
            {
                ThemeManager.ApplyTheme(theme2);
            }
        }
    }

    public override string TestDescription => "This tests theme changing with popup components.";

    public override string RunningDescription => "There are two popups.\n* PopupStyle1 is white background with cyan buttons.\n* PopupStyle2 is black background.";

    public override string PassCondition => "1. Click 'ChangeTheme' button in the bottom popup.\nThe background color of two popup are interchanged.\n"
                                          + "2. Close bottom popup and then close left one.";
}
