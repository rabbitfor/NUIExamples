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
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

class HelloWorldExample : NUIApplication
{
    /// <summary>
    /// Override to create the required scene
    /// </summary>
    protected override void OnCreate()
    {
        base.OnCreate();

        Window window = NUIApplication.GetDefaultWindow();
        window.BackgroundColor = Color.Black;
        string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

        var textField = new TextField()
        {
            BackgroundColor = Color.White,
            Size = new Size (200, 30),
            EnableClearButton = true,
            Position = new Position(10, 10)
        };
        window.Add(textField);

        var button = new Button()
        {
            Size = new Size(200, 30),
            Position = new Position(10, 70),
            Focusable = true,
            Text = "Remove focus from TextField"
        };
        button.Clicked += OnButtonClicked;
        window.Add(button);

        
    }

    private void OnButtonClicked(object sender, EventArgs args)
    {
        FocusManager.Instance.SetCurrentFocusView((View)sender);
        
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
        Tizen.NUI.EnvironmentVariable.SetEnvironmentVariable("DALI_DPI_HORIZONTAL", "75");
        Tizen.NUI.EnvironmentVariable.SetEnvironmentVariable("DALI_DPI_VERTICAL", "75");

        HelloWorldExample example = new HelloWorldExample();
        example.Run(args);
    }
}