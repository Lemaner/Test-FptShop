using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
namespace Test_Fpt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //tat man hinh den
            ChromeDriverService chrome = ChromeDriverService.CreateDefaultService();
            chrome.HideCommandPromptWindow = true;
            //dieu huong trinh duyet
            IWebDriver driver = new ChromeDriver(chrome);
            driver.Navigate().GoToUrl("https://fptshop.com.vn/");


            // -------- 1. Đăng nhập ---------
            IWebElement e_loginbtn = driver.FindElement(By.XPath("/html/body/header/div/div/ul/li[3]/a"));
            e_loginbtn.Click();
            IWebElement e_next = driver.FindElement(By.XPath("/html/body/div[6]/div/div[1]/div[3]/button"));
            // Click lần 1 chưa nhập sdt 
            e_next.Click();
            Thread.Sleep(4000);
            // Nhập sdt và click lần 2
            IWebElement e_phoneNumber = driver.FindElement(By.Name("phoneNumber"));
            e_phoneNumber.SendKeys("0762086559");
            e_next.Click();
            // Dừng 2s để load
            Thread.Sleep(2000);
            IWebElement e_changePhone = driver.FindElement(By.XPath("/html/body/div[6]/div/div[2]/div[2]/div[2]/a"));
            e_changePhone.Click();
            e_phoneNumber.SendKeys("0762086559");
            e_next.Click();
            Thread.Sleep(2000);
            IWebElement e_accept = driver.FindElement(By.XPath("/html/body/div[6]/div/div[2]/div[3]/button"));
            // Click lần 1 chưa nhập code từ điện thoại và xem kết quả
            e_accept.Click();
            // Click lần 2 nhập sai code và xem kết quả
            Thread.Sleep(5000);
            e_accept.Click();
            Thread.Sleep(10000);
            //Gửi lại code
            IWebElement e_sendCode = driver.FindElement(By.LinkText("Gửi lại mã OTP cho tôi"));
            e_sendCode.Click();
            // Dừng 10s để nhập code và sau đó click lần 2
            Thread.Sleep(10000);
            e_accept.Click();
            // Dừng 2s để load
            Thread.Sleep(2000);


            // ------- 2. Mua sắm ---------
            IWebElement e_browse = driver.FindElement(By.Id("key"));
            e_browse.SendKeys("iphone 15");
            IWebElement e_Ibrowse = driver.FindElement(By.ClassName("search-button"));
            e_Ibrowse.Click();
            Thread.Sleep(8000);
            IWebElement e_image = driver.FindElement(By.XPath("/html/body/div[2]/div/section/div/div[2]/div/div[1]/div[1]/a/span/img"));
            e_image.Click();
            IWebElement e_btnBuyNow = driver.FindElement(By.Id("btn-buy-now"));
            e_btnBuyNow.Click();
            Thread.Sleep(20000);
            // Hoàn tất đặt hàng và xem kết quả
            IWebElement e_btnbuy = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/div[1]/div[4]/div/div/div[2]/button"));
            e_btnbuy.Click();
            Thread.Sleep(5000);
            IWebElement e_iDelete = driver.FindElement(By.XPath("//html/body/div[1]/div/div/div/div[1]/div/div/div/div/div[2]/div/div/div/div/div[2]/div[2]/div[1]/i"));
            e_iDelete.Click();
            IWebElement e_returnDelete = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div/div/div[3]/button[1]"));
            e_returnDelete.Click();
            //Thực hiện lại lần nữa và xóa
            e_iDelete.Click();
            IWebElement e_delete = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div/div/div[3]/button[2]"));
            e_delete.Click();

        }   

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
