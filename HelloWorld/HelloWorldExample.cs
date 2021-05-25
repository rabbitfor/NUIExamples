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
    List<TextLabel> list = new List<TextLabel>();
    Timer timer;
    View rootView;
    const int interval = 3000;
    const int maxCount = 1000;
    int count = 0;

    protected override void OnCreate()
    {
        base.OnCreate();

        var themeLoader = new ThemeLoader();
        var theme = themeLoader.LoadTheme("org.tizen.default-dark-theme");
        Tizen.Log.Info("JYJY", $"Id: {theme.Id}, Version: {theme.Version}");
        themeLoader.CurrentTheme = theme;

        rootView = new View(new ViewStyle() {
            BackgroundColor = new Selector<Color>()
            {
                Normal = Color.Red,
                Pressed = Color.White
            }
        })
        {
            EnableControlState = true,
            WidthResizePolicy = ResizePolicyType.FillToParent,
            HeightResizePolicy = ResizePolicyType.FillToParent,
        };
        NUIApplication.GetDefaultWindow().Add(rootView);

        var button = new Button();

        // var theme = new Tizen.NUI.Theme(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "nui_theme_dark.xaml");

    }
    bool OnTick(object sender, Timer.TickEventArgs e)
    {
        if (list.Count > 0)
        {
            for (var i = 0; i < maxCount; i++)
            {
                rootView.Remove(list[i]);
                list[i].Dispose();
                list[i] = null;
            }

            list.Clear();
            FullGC();
            Tizen.Log.Info("JYJY", $"Clear text labels {count++}\n");
        }
        else
        {
            Show();
            Tizen.Log.Info("JYJY", $"Create text labels {count++}\n");
        }
        return true;
    }

    void Show()
    {
        for (int i = 0; i < maxCount; i++)
        {
            var t = new TextLabel()
            {
                Text = "Hello World" + i.ToString() + "!",
                Position = new Position((float)((i/500)*100), (float)(i%500)),
            };
            list.Add(t);
            rootView.Add(t);
        }
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
