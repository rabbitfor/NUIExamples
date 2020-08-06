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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

public class NUISampleApplication : NUIApplication
{
    private TestUnit currentTest;
    private View currentView;
    private TextLabel runningDescription;
    private TextLabel passCondition;
    private int currentIndex;
    private List<string> list = new List<string>();


    public NUISampleApplication() : base(new Size2D(600, 800), new Position2D(0, 0))
    {
    }

    protected override void OnCreate()
    {
        base.OnCreate();

        var window = NUIApplication.GetDefaultWindow();
        window.BackgroundColor = Color.White;
        window.KeyEvent += OnKeyEvent;

        Assembly assembly = this.GetType().Assembly;

        Type testUnitType = typeof(TestUnit);

        foreach (Type type in assembly.GetTypes())
        {
            if (testUnitType.IsAssignableFrom(type) && true != type.IsAbstract && true == type.IsClass)
            {
                list.Add(type.Name);
            }
        }

        Next();
    }

    public void Next()
    {
        if (currentIndex >= list.Count) return;

        string testName = list[currentIndex++];
        TestUnit testUnit = this.GetType().Assembly.CreateInstance(testName) as TestUnit;

        if (testUnit == null)
        {
            Next();
            return;
        }

        var window = NUIApplication.GetDefaultWindow();

        if (currentTest != null)
        {
            currentTest.OnDestroy(currentView);
            window.Remove(currentView);
            currentView = null;
        }
        currentTest = testUnit;

        if (!runningDescription)
        {
            runningDescription = new TextLabel
            {
                TextColor = Color.Black,
                MultiLine = true,
                BackgroundColor = Color.Yellow,
                PointSize = 10,
                Size = new Size(600, 150),
                Position = new Position(0, 500),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.TopLeft,
                PivotPoint = PivotPoint.TopLeft,
            };
            window.Add(runningDescription);
        }

        if (!passCondition)
        {
            passCondition = new TextLabel
            {
                TextColor = Color.Black,
                MultiLine = true,
                BackgroundColor = Color.Magenta,
                PointSize = 10,
                Size = new Size(600, 150),
                Position = new Position(0, 650),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.TopLeft,
                PivotPoint = PivotPoint.TopLeft,
            };
            window.Add(passCondition);
        }

        currentView = TestUtils.CreateEmptyView();
        testUnit.OnCreate(currentView);
        runningDescription.Text = "<TC: " + testName + ">\n\n[First Look]\n\n" + testUnit.RunningDescription;
        passCondition.Text = "[Pass Condition]\n\n" +testUnit.PassCondition;
        window.Add(currentView);
    }

    public void OnKeyEvent(object sender, Window.KeyEventArgs e)
    {
        Tizen.Log.Info("JYJY", e.Key.KeyPressedName);
        if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
        {
            Exit();
        }
        else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Return")
        {
            Next();
        }
    }

    static void Main(string[] args)
    {
        NUISampleApplication example = new NUISampleApplication();
        example.Run(args);
    }
}
