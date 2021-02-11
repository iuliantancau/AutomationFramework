using Base.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.PageObjects.CommonScreens
{
    class Header
    {
        BritDriver Driver;

        public Header(BritDriver driver)
        {
            Driver = driver;
        }
    }
}
