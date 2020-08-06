/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Wearable;

public class NUISampleApplication : NUIApplication
{
    public class TextButtonStyle : StyleBase
    {
        public TextButtonStyle()
        {
        }

        protected override ViewStyle GetViewStyle()
        {
            ButtonStyle style = new ButtonStyle
            {
                IsSelectable = true,
                Overlay = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { Pressed = "/home/jy/2019/dali/fhub-nui/Tizen.FH.NUI/res/images/FH3/3.Button/rectangle_btn_press_overlay.png", Other = "" },
                    Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) }
                },

                Text = new TextLabelStyle
                {
                    PositionUsesPivotPoint = true,
                    PointSize = new Selector<float?> { All = 20 },
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextColor = new Selector<Color>
                    {
                        Normal = new Color(0, 0, 0, 1),
                        Pressed = new Color(0, 0, 0, 0.7f),
                        Selected = new Color("#24c447"),
                        Disabled = new Color(0, 0, 0, 0.4f),
                    },
                    Text = "Hello",
                }
            };
            return style;
        }
    }

    public class UtilityBasicButtonStyle : TextButtonStyle
    {
        protected override ViewStyle GetViewStyle()
        {
            // if (Content != null)
            // {
            //     ViewStyle contentStyle = (ViewStyle)global::System.Activator.CreateInstance(Content.GetType());
            //     contentStyle.CopyFrom(Content as ViewStyle);
            //     return contentStyle;
            // }
            ButtonStyle style = base.GetViewStyle() as ButtonStyle;
            style.ImageShadow = new ImageShadow
            {
                Url = "/home/jy/2019/dali/fhub-nui/Tizen.FH.NUI/res/images/FH3/3.Button/rectangle_btn_shadow.png",
                Border = new Rectangle(5, 5, 5, 5)
            };
            style.BackgroundColor = Color.Transparent;
            style.SolidNull = true;
            return style;
        }
    }

    public class FamilyBasicButtonStyle : TextButtonStyle
    {
        protected override ViewStyle GetViewStyle()
        {
            ButtonStyle style = base.GetViewStyle() as ButtonStyle;
            style.ImageShadow = new ImageShadow
            {
                Url = "/home/jy/2019/dali/fhub-nui/Tizen.FH.NUI/res/images/FH3/3.Button/rectangle_btn_shadow.png",
                Border = new Rectangle(5, 5, 5, 5)
            };
            style.Text.TextColor.Selected = new Color("#0ea1e6");
            return style;
        }
    }

    protected override void OnCreate()
    {
        base.OnCreate();

        Initialize();
    }

    void Initialize()
    {
        var resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        NUIApplication.GetDefaultWindow().BackgroundColor = Color.White;
        var root = NUIApplication.GetDefaultWindow();

        // var resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        var theme = new Theme("/home/jy/2019/dali/NUIExamples/HelloWorld/res/TestTheme.xaml");
        var buttonStyle = theme.GetStyle("Button") as ButtonStyle;
        var checkBoxStyle = theme.GetStyle("CheckBox") as ButtonStyle;
        var switchStyle = theme.GetStyle("Switch") as SwitchStyle;

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

    bool clickCount = false;

    public void OnClick(object target, ClickedEventArgs args)
    {
        if (clickCount)
        {
            Tizen.NUI.Components.StyleManager.Instance.Theme = "Theme1";
        }
        else
        {
            Tizen.NUI.Components.StyleManager.Instance.Theme = "Theme2";
        }

        clickCount = !clickCount;
    }

    public void OnKeyEvent(object sender, Window.KeyEventArgs e)
    {
        if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
        {
            Exit();
        }
        else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Return")
        {
            // Tizen.Log.Info("JYJY", "view7.Track.Size(" + view7.Track.Size.Width + ", " + view7.Track.Size.Height + ")");
        }
    }


    static void Main(string[] args)
    {
        NUISampleApplication example = new NUISampleApplication();
        example.Run(args);
    }
}
