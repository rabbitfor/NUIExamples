/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using System.ComponentModel;
using System;
using Tizen.Applications.ThemeManager;
using System.Collections.Generic;
using System.Collections.ObjectModel;

class HelloWorldExample : NUIApplication
{
    View rootView;
    int count = 0;
    ThemeLoader themeLoader;

    // private ContentPage firstPage, secondPage;
    private Button firstButton, secondButton;

    // public HelloWorldExample() : base(new Size2D(1280, 720), new Position2D(0, 0))
    // {
    // }

    protected override void OnAppControlReceived(Tizen.Applications.AppControlReceivedEventArgs e)
    {
        base.OnAppControlReceived(e);
        NUIApplication.GetDefaultWindow().Show();
    }

    protected override void OnCreate()
    {
        base.OnCreate();

        themeLoader = new ThemeLoader();

        var mainPage = new ContentPage()
        {
            UseThemeBackgroundColor = true,
            ThemeChangeSensitive = true,
            AppBar = new AppBar()
            {
                ThemeChangeSensitive = true,
                AutoNavigationContent = false,
                Title = "NUI theme sample",
            },
            Content = new ScrollableBase()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(20, 20)
                },
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                Padding = new Extents(30, 30, 20, 20)
            }
        };

        mainPage.Content.Add(CreateClickableItem("Theme change", "Change theme", delegate() {
            // NUIApplication.GetDefaultWindow().Hide();
            if (themeLoader.CurrentTheme.Id == "org.tizen.default-dark-theme")
            {
                var theme = themeLoader.LoadTheme("org.tizen.default-light-theme");
                Tizen.Log.Info("JYJY", $"Id: {theme.Id}, Version: {theme.Version}");
                themeLoader.CurrentTheme = theme;
            }
            else
            {
                var theme = themeLoader.LoadTheme("org.tizen.default-dark-theme");
                Tizen.Log.Info("JYJY", $"Id: {theme.Id}, Version: {theme.Version}");
                themeLoader.CurrentTheme = theme;
            }
        }));
        
        mainPage.Content.Add(CreateItem("RadioButton", CreateRadioButtonExample()));

        mainPage.Content.Add(CreateItem("Switch", CreateSwitchExample()));
        
        mainPage.Content.Add(CreateClickableItem("AlertDialog", "Click to post alert", delegate() {
            var dialogPage = new DialogPage()
            {
                ScrimColor = new Color("#888888BB"),
                Content = new AlertDialog()
                {
                    ThemeChangeSensitive = true,
                    Title = "Notice",
                    Message = "Please click close button to dismiss",
                    // Actions =  actions,
                },
            };

            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(dialogPage);
            // DialogPage.ShowAlertDialog("Notice", "Please touch outer area to dismiss");
        }));

        mainPage.Content.Add(CreateItem("CheckBox", CreateCheckBoxExample()));

        NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(mainPage);
    }

    private View CreateItem(string title, View content)
    {
        var item = new View()
        {
            WidthResizePolicy = ResizePolicyType.FillToParent,
            HeightResizePolicy = ResizePolicyType.FitToChildren,
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            },
            BackgroundColor = new Color("#88888860"),
            CornerRadius = 16.0f,
            Padding = 20,
        };
        item.Add(new TextLabel()
        {
            PixelSize = 22.0f,
            Text = title,
            ThemeChangeSensitive = true,
            Padding = new Extents(0, 0, 0, 20)
        });
        item.Add(content);
        return item;
    }

    private View CreateClickableItem(string title, string subtitle, Action clicked)
    {
        var item = new View()
        {
            WidthResizePolicy = ResizePolicyType.FillToParent,
            HeightResizePolicy = ResizePolicyType.FitToChildren,
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            },
            BackgroundColor = new Color("#88888860"),
            CornerRadius = 16.0f,
            Padding = 20,
            LeaveRequired = true,
        };
        item.TouchEvent += (s, e) => {
            var state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                ((View)s).BackgroundColor = new Color("#888888BB");
            }
            else if (state == PointStateType.Up)
            {
                ((View)s).BackgroundColor = new Color("#88888860");
                clicked?.Invoke();
            }
            else if (state == PointStateType.Leave || state == PointStateType.Interrupted)
            {
                ((View)s).BackgroundColor = new Color("#88888860");
            }
            return false;
        };
        item.Add(new TextLabel()
        {
            PixelSize = 22.0f,
            Text = title,
            ThemeChangeSensitive = true,
            Padding = new Extents(0, 0, 0, 20)
        });
        item.Add(new TextLabel()
        {
            PixelSize = 32.0f,
            Text = subtitle,
            ThemeChangeSensitive = true,
            VerticalAlignment = VerticalAlignment.Center,
        });
        return item;
    }

    private View CreateRadioButtonExample()
    {
        var view = new View()
        {
            WidthResizePolicy = ResizePolicyType.FillToParent,
            HeightResizePolicy = ResizePolicyType.FitToChildren,
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            },
        };
        var radio1 = new RadioButton() { Text = "Always on", ThemeChangeSensitive = true, Padding = 7 };
        var radio2 = new RadioButton() { Text = "10 minutes", ThemeChangeSensitive = true, Padding = 7 };
        var radio3 = new RadioButton() { Text = "1 minutes", ThemeChangeSensitive = true, Padding = 7 };

        var group = new RadioButtonGroup();
        group.Add(radio1);
        group.Add(radio2);
        group.Add(radio3);

        view.Add(radio1);
        view.Add(radio2);
        view.Add(radio3);

        radio1.IsSelected = true;

        return view;
    }

    private View CreateSwitchExample()
    {
        var view = new View()
        {
            WidthResizePolicy = ResizePolicyType.FillToParent,
            HeightResizePolicy = ResizePolicyType.FitToChildren,
        };
        var textLabel = new TextLabel()
        {
            ThemeChangeSensitive = true,
            Text = "Auto update : on"
        };
        view.Add(textLabel);

        var switchButton = new Switch()
        {
            ThemeChangeSensitive = true,
            ParentOrigin = ParentOrigin.CenterRight,
            PivotPoint = PivotPoint.CenterRight,
            PositionUsesPivotPoint = true,
            IsSelected = true,
        };
        switchButton.SelectedChanged += (s, e) => {
            textLabel.Text = $"Daily auto update : {(((Switch)s).IsSelected ? "on" : "off")}";
        };
        view.Add(switchButton);
        return view;
    }

    private View CreateAlertDialogExample()
    {
        var button = new Button()
        {
            ThemeChangeSensitive = true,
            Text = "Click to post alert!"
        };
        button.Clicked += (s, e) => {
            // var dialogPage = new DialogPage()
            // {
            //     Content = new AlertDialog()
            //     {
            //         ThemeChangeSensitive = true,
            //         Title = "Notice",
            //         Message = "Please click close button to dismiss",
            //         // Actions =  actions,
            //     },
            // };

            // NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(dialogPage);
            DialogPage.ShowAlertDialog("Notice", "Please touch outer area to dismiss");
        };

        return button;
    }

    private View CreateCheckBoxExample()
    {
        var view = new View()
        {
            WidthResizePolicy = ResizePolicyType.FillToParent,
            HeightResizePolicy = ResizePolicyType.FitToChildren,
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            },
        };
        var check1 = new CheckBox() { Text = "Food", ThemeChangeSensitive = true, Padding = 7 };
        var check2 = new CheckBox() { Text = "Animal", ThemeChangeSensitive = true, Padding = 7 };
        var check3 = new CheckBox() { Text = "Vehicle", ThemeChangeSensitive = true, Padding = 7 };

        view.Add(check1);
        view.Add(check2);
        view.Add(check3);

        check2.IsSelected = true;
        check3.IsSelected = true;

        return view;
    }

    private View CreateTimePickerExample()
    {
        // var timePicker = new TimePicker()
        // {
        //     // ParentOrigin = ParentOrigin.Center,
        //     // PivotPoint = PivotPoint.Center,
        //     // PositionUsesPivotPoint = true,
        //     Size = new Size(200, 200),
        //     Hour = 12,
        //     Minute = 30,
        //     Is24HourView = false,
        // };
        // // timePicker.TimeChanged += TimeChanged;
        // // window.Add(timePicker);
        // return timePicker;
        return null;
    }

    private void FullGC()
    {
        global::System.GC.Collect();
        global::System.GC.WaitForPendingFinalizers();
        global::System.GC.Collect();
    }

    /// <summary>
    /// Called when any key event is received.
    /// Will use this to exit the application if the Back or Escape key is pressed
    /// </summary>
    private void OnKeyEvent( object sender, Window.KeyEventArgs eventArgs )
    {
        if( eventArgs.Key.State == Key.StateType.Down )
        {
            switch( eventArgs.Key.KeyPressedName )
            {
                case "Escape":
                case "Back":
                {
                    Exit();
                }
                break;
            }
        }
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread] // Forces app to use one thread to access NUI
    static void Main(string[] args)
    {
        HelloWorldExample example = new HelloWorldExample();
        example.Run(args);
    }
}
