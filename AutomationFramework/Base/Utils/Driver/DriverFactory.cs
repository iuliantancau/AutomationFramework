using System.Threading;

namespace Base.Utils.Driver
{
    class DriverFactory
    {
        private static readonly ThreadLocal<BritDriver> BritDrivers = new ThreadLocal<BritDriver>();       

        public void CreateDrivers(Browsers browserName)
        {
            BritDrivers.Value = new BritDriver(browserName);
            BritDrivers.Value.WebDriver.Manage().Window.Maximize();          
        }            

        public BritDriver GetBritDriver()
        {
            return BritDrivers.Value;
        }

        public void QuitDrivers()
        {
            BritDrivers.Value.WebDriver.Quit();
        }
    }
}
