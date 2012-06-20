using OpenQA.Selenium;

namespace Coypu.Drivers.Selenium
{
    internal class WindowHandle : ElementFound
    {
        private readonly IWebDriver selenium;
        private readonly string windowHandle;

        public WindowHandle(IWebDriver selenium, string windowHandle)
        {
            this.selenium = selenium;
            this.windowHandle = windowHandle;
        }

        public string Id
        {
            get { throw new System.NotSupportedException(); }
        }

        public string Text
        {
            get
            {
                var currentWindowHandle = selenium.CurrentWindowHandle;
                try
                {
                    return ((ISearchContext)Native).FindElement(By.CssSelector("body")).Text;
                }
                finally
                {
                    SwitchTo(currentWindowHandle);
                }
            }
        }

        public string Value
        {
            get { throw new System.NotSupportedException(); }
        }

        public string Name
        {
            get { throw new System.NotSupportedException(); }
        }

        public string SelectedOption
        {
            get { throw new System.NotSupportedException(); }
        }

        public bool Selected
        {
            get { throw new System.NotSupportedException(); }
        }

        public object Native
        {
            get
            {
                SwitchTo(windowHandle);
                return selenium;
            }
        }

        private void SwitchTo(string windowName)
        {
            selenium.SwitchTo().Window(windowName);
        }

        public bool Stale
        {
            get
            {
                return !selenium.WindowHandles.Contains(windowHandle);
            }
        }

        public string this[string attributeName]
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}