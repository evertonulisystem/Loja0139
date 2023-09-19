namespace Loja139;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

[TestFixture]
public class SelecionarProdutoTest {
  private IWebDriver driver;

  [SetUp]
  public void SetUp() {
    new DriverManager().SetUpDriver(new ChromeConfig());
    driver = new ChromeDriver();
    //driver = new FirefoxDriver();
    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);    
  }

  [TearDown]
  protected void TearDown() {
    driver.Quit();    
  }

  [Test]
  public void FluxoSimples() {
    driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    driver.Manage().Window.Size = new System.Drawing.Size(1080, 1080);
    Assert.That(driver.Title, Is.EqualTo("Swag Labs"));
    driver.FindElement(By.CssSelector("*[data-test=\"username\"]")).Click();
    driver.FindElement(By.CssSelector("*[data-test=\"username\"]")).SendKeys("standard_user");
    driver.FindElement(By.CssSelector("*[data-test=\"password\"]")).Click();
    driver.FindElement(By.CssSelector("*[data-test=\"password\"]")).SendKeys("secret_sauce");
    driver.FindElement(By.CssSelector("*[data-test=\"login-button\"]")).Click();
    driver.FindElement(By.CssSelector("#item_4_title_link > .inventory_item_name")).Click();
    Assert.That(driver.FindElement(By.CssSelector(".inventory_details_name")).Text, Is.EqualTo("Sauce Labs Backpack"));
    Assert.That(driver.FindElement(By.CssSelector(".inventory_details_price")).Text, Is.EqualTo("$29.99"));
    driver.FindElement(By.CssSelector("*[data-test=\"add-to-cart-sauce-labs-backpack\"]")).Click();
    driver.FindElement(By.LinkText("1")).Click();
    Assert.That(driver.FindElement(By.CssSelector(".inventory_item_name")).Text, Is.EqualTo("Sauce Labs Backpack"));
    Assert.That(driver.FindElement(By.CssSelector(".inventory_item_price")).Text, Is.EqualTo("$29.99"));
    driver.FindElement(By.CssSelector("*[data-test=\"checkout\"]")).Click();
    Thread.Sleep(5000);
    driver.Close();
    }
}