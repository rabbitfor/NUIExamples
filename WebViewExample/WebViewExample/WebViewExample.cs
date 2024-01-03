using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace WebViewExample
{
    class Program : NUIApplication
    {
        private WebView mWebView;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            string path = "file://" + Tizen.Applications.Application.Current.DirectoryInfo.Resource + "test.html";
            // string path = "https://terms.account.samsung.com/contents/legal/kor/kor/customizedservicecontent.html";

            mWebView = new WebView();

            mWebView.AddJavaScriptMessageHandler( "Test1", (text) => {
                Tizen.Log.Info("JYJY", $" Handler1: {text}");
            });

            mWebView.AddJavaScriptMessageHandler( "Test2", (text) => {
                Tizen.Log.Info("JYJY", $" Handler2: {text}");
            });

            mWebView.AddJavaScriptMessageHandler( "Test3", (text) => {
                Tizen.Log.Info("JYJY", $" Handler3: {text}");
            });

            mWebView.LoadUrl(path);
            Tizen.Log.Info("JYJY", $"LoadUrl({path})");
            mWebView.Size2D = new Size2D(800, 800);
            NUIApplication.GetDefaultWindow().Add(mWebView);

            // FocusManager.Instance.SetCurrentFocusView(mWebView);

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
