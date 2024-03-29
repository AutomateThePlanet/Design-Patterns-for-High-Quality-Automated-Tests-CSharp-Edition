﻿// Copyright 2024 Automate The Planet Ltd.
// Author: Anton Angelov
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
using System.Threading;
using OpenQA.Selenium;

namespace TestsReadabilityDemos.Third;

public class CartPage
{
    private readonly Driver _driver;

    public CartPage(Driver driver)
    {
        _driver = driver;
        SearchSection = new SearchSection(_driver);
        MainMenuSection = new MainMenuSection(_driver);
        CartInfoSection = new CartInfoSection(_driver);
        BreadcrumbSection = new BreadcrumbSection(_driver);
    }

    public SearchSection SearchSection { get;  }
    public MainMenuSection MainMenuSection { get; }
    public CartInfoSection CartInfoSection { get; }
    public BreadcrumbSection BreadcrumbSection { get; }

    private Element CouponCodeTextField => _driver.FindElement(By.Id("coupon_code"));
    private Element ApplyCouponButton => _driver.FindElement(By.CssSelector("[value*='Apply coupon']"));
    private Element QuantityBox => _driver.FindElement(By.CssSelector("[class*='input-text qty text']"));
    private Element UpdateCart => _driver.FindElement(By.CssSelector("[value*='Update cart']"));
    private Element MessageAlert => _driver.FindElement(By.CssSelector("[class*='woocommerce-message']"));
    private Element TotalSpan => _driver.FindElement(By.XPath("//*[@class='order-total']//span"));
    private Element ProceedToCheckout => _driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));

    public void ApplyCoupon(string coupon)
    {
        CouponCodeTextField.TypeText(coupon);
        ApplyCouponButton.Click();
        Thread.Sleep(2000);

    }

    public void IncreaseProductQuantity(int newQuantity)
    {
        QuantityBox.TypeText(newQuantity.ToString());
        UpdateCart.Click();
        Thread.Sleep(4000);
    }

    public void ClickProceedToCheckout()
    {
        ProceedToCheckout.Click();
    }

    public string GetTotal()
    {
        return TotalSpan.Text;
    }

    public string GetMessageNotification()
    {
        return MessageAlert.Text;
    }
}
