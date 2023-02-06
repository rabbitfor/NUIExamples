using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Xml;

namespace NUIXamlTemplate1
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();

            // // NOTE To use theme.xaml, uncomment below line.
            ThemeManager.ApplyTheme(new ApplicationTheme());
            // var theme = new ApplicationTheme();
            // var theme1 = new Theme(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "theme/ApplicationTheme.xaml");
            // var theme2 = new Theme();
            // using (var reader = XmlReader.Create(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "theme/ApplicationTheme.xaml"))
            // {
            //     Tizen.NUI.XamlBuild.PublicXamlLoader.Load(theme2, reader);
            // }


            Button button = new Button();
            button.Text = "Hello";
            button.Size = new Size(100, 100);
            Window.Instance.Add(button);

            XamlPage page = new XamlPage();
            Window.Instance.Add(page);
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
            var app = new Program();
            app.Run(args);
        }
    }
}
