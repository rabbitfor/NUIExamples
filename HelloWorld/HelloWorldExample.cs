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

class HelloWorldExample : NUIApplication
{
    View rootView;

    protected override void OnCreate()
    {
        base.OnCreate();

        rootView = new View()
        {
            WidthResizePolicy = ResizePolicyType.FillToParent,
            HeightResizePolicy = ResizePolicyType.FillToParent,
            BackgroundColor = Color.White,
        };
        NUIApplication.GetDefaultWindow().Add(rootView);

        var button = new Button()
        {
            Text = "Start"
        };
        button.Clicked += (s, e) => {
            for (var i = 0; i < 1000; i++)
            {
                var view = new View() {
                    Size = new Size(10, 10),
                    Position = new Position(i, i),
                    BackgroundColor = Color.Blue
                };
                var size = view.Size;
                var pos = view.Position;
                var bg = view.BackgroundColor;
                var name = view.Name;
                var sensitive = view.Sensitive;
                rootView.Add(view);
            }
        };
        rootView.Add(button);
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