using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class Theme1 : TestUnit
{
    public class Popup1 : Tizen.NUI.Components.StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            return new PopupStyle()
            {
                Size = new Size(500, 200),
                BackgroundColor = Color.White,
                BoxShadow = new Shadow(6.0f, Color.Blue, extents: new Vector2(5, 5)),
                Title = new TextLabelStyle
                {
                    TextColor = Color.Black,
                    PointSize = 16,
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
                        PointSize = 12,
                    },
                    ParentOrigin = ParentOrigin.BottomLeft,
                    PivotPoint = PivotPoint.BottomLeft,
                    PositionUsesPivotPoint = true
                }
            };
        }
    }

    public class Popup2 : Popup1
    {
        protected override ViewStyle GetViewStyle()
        {
            var result = (PopupStyle)base.GetViewStyle();
            result.BackgroundColor = Color.Black;
            result.Title.Text = "PopupStyle2";
            result.Title.TextColor = Color.Cyan;
            result.Buttons.SizeHeight = 80;
            result.Buttons.BackgroundColor = new Selector<Color>
            {
                Pressed = Color.Cyan,
                Other = Color.Black,
            };
            result.Buttons.Text.TextColor = new Selector<Color>
            {
                Pressed = Color.Black,
                Other = Color.White,
            };
            return result;
        }
    }

    int clickCount = 0;
    Popup popup0, popup1;

    public override void OnCreate(View root)
    {       
        Tizen.NUI.Components.StyleManager.Instance.Theme = "Theme1";

        Tizen.NUI.Components.StyleManager.Instance.RegisterStyle("Popup1", "Theme1", typeof(Popup1));
        Tizen.NUI.Components.StyleManager.Instance.RegisterStyle("Popup2", "Theme1", typeof(Popup2));
        Tizen.NUI.Components.StyleManager.Instance.RegisterStyle("Popup2", "Theme2", typeof(Popup1));
        Tizen.NUI.Components.StyleManager.Instance.RegisterStyle("Popup1", "Theme2", typeof(Popup2));

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
                Tizen.NUI.Components.StyleManager.Instance.Theme = "Theme1";
            }
            else if (clickCount == 1)
            {
                Tizen.NUI.Components.StyleManager.Instance.Theme = "Theme2";
            }
        }
    }

    public override string RunningDescription => "There are two popups.\n PopupStyle1 is white background with cyan buttons.\nPopupStyle2 is black background.";

    public override string PassCondition => "Click 'ChangeTheme' button in the bottom popup.\nThe style of two popup are interchanged.";
}
