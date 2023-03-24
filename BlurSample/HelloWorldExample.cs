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
using Tizen.NUI.Components.Extension;
using Tizen.NUI.BaseComponents;

class HelloWorldExample : NUIApplication
{
    View rootView;

    protected override void OnCreate()
    {
        base.OnCreate();

        string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

        var bg = new ImageView() {
            ResourceUrl = resourcePath + "background-magnifier.jpg",
        };
        NUIApplication.GetDefaultWindow().Add(bg);

        const int itemPadding = 50;
        const int itemWidth = 300;
        const int itemHeight = 100;

        for (var i = 0; i < 3; i++)
        {
            var posY = itemPadding * (i + 1) + itemHeight * i;
            var container = new View()
            {
                Position = new Position(100, posY),
                Size = new Size(itemWidth, itemHeight),
                BackgroundColor = Color.White,
                ClippingMode = ClippingModeType.ClipChildren,
                CornerRadius = 10,
            };
            NUIApplication.GetDefaultWindow().Add(container);
            
            var blurView = new GaussianBlurView(30, 8.0f, PixelFormat.RGBA8888, 0.5f, 0.5f, false) {
                WidthResizePolicy = ResizePolicyType.Fixed,
                HeightResizePolicy = ResizePolicyType.Fixed,
                Size = new Size(itemWidth, itemHeight),
            };
            container.Add(blurView);
            
            var content = new ImageView() {
                ResourceUrl = resourcePath + "background-magnifier.jpg",
                Position = new Position(-100, -posY),
            };
            blurView.Add(content);
            blurView.Activate();
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
