using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Data;

var targetSite = "https://www.google.com/search?q=sinner+medvedev+live&sca_esv=602134022&rlz=1C1CHBF_itIT994IT995&sxsrf=ACQVn0_J_rvCvHIg2vTomgF_LniDUQeIpQ%3A1706440118439&ei=tjW2ZYWyGq2Nxc8PjPqL8AI&oq=sinner+medvedev+liv&gs_lp=Egxnd3Mtd2l6LXNlcnAiE3Npbm5lciBtZWR2ZWRldiBsaXYqAggAMgsQABiABBixAxiDATILEAAYgAQYsQMYgwEyCxAAGIAEGLEDGIMBMgsQABiABBixAxiDATILEAAYgAQYsQMYgwEyCxAAGIAEGLEDGIMBMgQQABgDMgQQABgDMgsQABiABBixAxiDATIFEAAYgARIhBdQnARY-g9wAngBkAEAmAGNAaABvgSqAQMxLjS4AQPIAQD4AQHCAgoQIxiABBiKBRgnwgIOEAAYgAQYigUYsQMYgwHCAg0QABiABBgNGLEDGIMBwgIGEAAYAxgNwgIHEAAYgAQYDeIDBBgAIEGIBgE&sclient=gws-wiz-serp";

EdgeDriver liveMonitor;

PrepareDrivers();

try
{
    liveMonitor.FindElement(By.Id("W0wltc")).Click();
    // ++++ Core Logic ++++
    while (true)
    {
        RefreshPage();
        ReadScore();
        WaitAFewTime();
    }
    // ++++ End Core Logic ++++
}
catch (Exception ex)
{
    LogException(ex);
}
finally
{
    CloseAllDrivers();
    SayTaskFinished();
}

void ReadScore()
{
    // TODO: Read score from the page
}

void PrepareDrivers()
{
    var deviceDriver = EdgeDriverService.CreateDefaultService();
    deviceDriver.HideCommandPromptWindow = true;

    EdgeOptions options = new();
    options.AddArguments("--disable-infobars");

    liveMonitor = new EdgeDriver(deviceDriver, options);
    liveMonitor.Manage().Window.Maximize();
    liveMonitor.Navigate().GoToUrl(targetSite);
}


void RefreshPage()
{
    liveMonitor.Navigate().Refresh();
}
static void WaitAFewTime()
{
    Thread.Sleep(1000);
}
static void LogException(Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex);
    Console.ResetColor();
}
static void SayTaskFinished()
{
    Console.WriteLine("Done!");
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}
void CloseAllDrivers()
{
    liveMonitor?.Quit();
}