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

public class NUISampleApplication : NUIApplication
{
    // ThemeOptions
    // * PlatformThemeEnabled : Specify this flag when you want to change platform theme manually
    //                          or want to receive platform theme changed event.
    // * ThemeChangeSensitive : Basically, if you want a NUI View to automatically change its appearance
    //                          whenever the theme changes, you need to set "view.ThemeChangeSensitive = true"
    //                          for the view. It's "false" by default. However if this flag is specified,
    //                          the default value will be "true" so you won't be bother to set it for each view.
    //                          Please note that this flag makes NUI to track all views for theme update, therefore
    //                          it may slow down your application. It's recommended to use this option only when
    //                          absolutely necessary.
    public NUISampleApplication() : base(ThemeOptions.PlatformThemeEnabled)
    {
    }

    protected override void OnCreate()
    {
        base.OnCreate();

        Initialize();
    }

    Theme themeBlack, themeGreen;
    int clickCount = 0;

    void Initialize()
    {
        var root = NUIApplication.GetDefaultWindow();
        var resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

        // Load and apply theme from xaml file.
        themeBlack = new Theme(resourcePath + "Theme/Black.xaml");
        themeGreen = new Theme(resourcePath + "Theme/Green.xaml");
        ThemeManager.ApplyTheme(themeBlack);


        var themeChangeButton = new Button() {
            WidthResizePolicy = ResizePolicyType.FillToParent,
            SizeHeight = 70,
            Text = "Click to change theme",
        };
        themeChangeButton.Clicked += OnClicked;
        root.Add(themeChangeButton);
        root.BackgroundColor = Color.White;


        // [Sample 1]
        // Set style name you want to apply.
        root.Add(new TextLabel() {
            StyleName = "TextLabelTypeA",
            Position = new Position(30, 120),
            Text = "Hello World!",
            ThemeChangeSensitive = true
        });

        // [Sample 2]
        // You can also set style name using constructor.
        // Note that, BaseComponents(e.g. TextLabel) does not provide this way.
        root.Add(new Button("ButtonDefault") {
            Position = new Position(30, 180),
            Text = "Button",
            ThemeChangeSensitive = true
        });

        // [Sample 3-1]
        root.Add(new Switch("SwitchFancy") {
            Position = new Position(30, 280),
            ThemeChangeSensitive = true
        });

        // [Sample 3-2]
        // Set ThemeChangedSensitive to false if you don't want this view to be affected by theme changes.
        // Note that the ThemeChangedSensitive is "false" by default,
        // unless the application has ThemeOptions.ThemeChangeSensitive explitcitly.
        root.Add(new Switch("SwitchFancy") {
            Position = new Position(200, 280),
        });

        // [Sample 4-1]
        // The view without style name uses a style named its type name. ("Tizen.NUI.Components.CheckBox" in this case)
        root.Add(new CheckBox() {
            Position = new Position(30, 380),
        });

        // [Sample 4-2]
        // Set ThemeChangedSensitive to true if you want this view to be affected by theme changes.
        root.Add(new CheckBox() {
            Position = new Position(200, 380),
            ThemeChangeSensitive = true,
        });
    }

    private void OnClicked(object target, ClickedEventArgs args)
    {
        clickCount++;

        if ((clickCount) % 2 == 0) ThemeManager.ApplyTheme(themeBlack);
        else ThemeManager.ApplyTheme(themeGreen);
    }

    public void OnKeyEvent(object sender, Window.KeyEventArgs e)
    {
        if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
        {
            Exit();
        }
    }


    static void Main(string[] args)
    {
        NUISampleApplication example = new NUISampleApplication();
        example.Run(args);
    }
}
