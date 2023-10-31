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
    protected override void OnCreate()
    {
        base.OnCreate();

        const float width = 300;
        const float height = 80;
        const float arbitraryFieldOfView = MathF.PI / 4.0f;
        string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

        var source = new TextLabel()
        {
            Text = "Hello World!",
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            PixelSize = 50,
            TextColor = new Color(1, 1, 1, 0.5f),
            Size = new Size(width, height)
        };
        Window.Instance.Add(source);

        var camera = new Camera();
        camera.SetInvertYAxis(true);
        camera.ParentOrigin = Tizen.NUI.ParentOrigin.Center;
        camera.SetAspectRatio(width / height);
        camera.Position = new Vector3(0.0f, 0.0f, height * 0.5f / MathF.Tan(arbitraryFieldOfView * 0.5f));
        camera.SetFieldOfView(arbitraryFieldOfView);
        camera.SetNearClippingPlane(1.0f);
        camera.SetType(CameraType.FreeLook);
        source.Add(camera);

        var renderTask = Window.Instance.GetRenderTaskList().CreateTask();
        renderTask.SetSourceView(source);
        renderTask.SetExclusive(false);
        renderTask.SetInputEnabled(true);
        renderTask.SetClearEnabled(true);
        renderTask.SetClearColor(Color.Transparent);
        renderTask.SetCamera(camera);
        renderTask.SetRefreshRate((uint)RenderTask.RefreshRate.REFRESH_ALWAYS);

        var frameBuffer = new FrameBuffer((uint)width, (uint)height, (uint)FrameBuffer.Attachment.Mask.NONE);
        renderTask.SetFrameBuffer(frameBuffer);
        var frameBufferUrl = frameBuffer.GenerateUrl(PixelFormat.RGBA8888, (int)width, (int)height);

        var image = new ImageView()
        {
            Size = new Size(width, height),
            PositionY = height,
            ResourceUrl = frameBufferUrl.ToString(),
            AlphaMaskURL = resourcePath + "mask.png"
        };
        Window.Instance.Add(image);
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
