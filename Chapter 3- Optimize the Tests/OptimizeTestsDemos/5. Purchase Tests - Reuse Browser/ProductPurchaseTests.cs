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
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace StabilizeTestsDemos.FifthVersion;

/*
 * The order of test execution is important. The tests should be executed in the following order:
 * CompletePurchaseSuccessfully_WhenNewClient
 * CompletePurchaseSuccessfully_WhenExistingClient
 * CorrectOrderDataDisplayed_WhenNavigateToMyAccountOrderSection
 *
 * This is the expected behavior showing that this is not the best practice.
 */
[TestClass]
[ExecutionBrowser(Browser.Chrome, BrowserBehavior.ReuseIfStarted)]
public class ProductPurchaseTests : BaseTest
{
    private static string _purchaseEmail;
    private static string _purchaseOrderNumber;

    [TestMethod]
    public void CompletePurchaseSuccessfully_WhenNewClient()
    {
        AddRocketToShoppingCart();
        ApplyCoupon();
        IncreaseProductQuantity();
        var proceedToCheckout = Driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
        proceedToCheckout.Click();
        Driver.WaitUntilPageLoadsCompletely();
        var billingFirstName = Driver.FindElement(By.Id("billing_first_name"));
        billingFirstName.TypeText("Anton");
        var billingLastName = Driver.FindElement(By.Id("billing_last_name"));
        billingLastName.TypeText("Angelov");
        var billingCompany = Driver.FindElement(By.Id("billing_company"));
        billingCompany.TypeText("Space Flowers");
        var billingCountryWrapper = Driver.FindElement(By.Id("select2-billing_country-container"));
        billingCountryWrapper.Click();
        var billingCountryFilter = Driver.FindElement(By.ClassName("select2-search__field"));
        billingCountryFilter.TypeText("Germany");
        var germanyOption = Driver.FindElement(By.XPath("//*[contains(text(),'Germany')]"));
        germanyOption.Click();
        var billingAddress1 = Driver.FindElement(By.Id("billing_address_1"));
        billingAddress1.TypeText("1 Willi Brandt Avenue Tiergarten");
        var billingAddress2 = Driver.FindElement(By.Id("billing_address_2"));
        billingAddress2.TypeText("Lützowplatz 17");
        var billingCity = Driver.FindElement(By.Id("billing_city"));
        billingCity.TypeText("Berlin");
        var billingZip = Driver.FindElement(By.Id("billing_postcode"));
        billingZip.TypeText("10115");
        var billingPhone = Driver.FindElement(By.Id("billing_phone"));
        billingPhone.TypeText("+00498888999281");
        var billingEmail = Driver.FindElement(By.Id("billing_email"));
        billingEmail.TypeText(GenerateUniqueEmail());
        _purchaseEmail = GenerateUniqueEmail();
        Driver.WaitForAjax();
        var placeOrderButton = Driver.FindElement(By.Id("place_order"));
        placeOrderButton.Click();
        Driver.WaitForAjax();
        var receivedMessage = Driver.FindElement(By.XPath("//h1"));

        Assert.AreEqual("Order received", receivedMessage.Text);
    }

    [TestMethod]
    [ExecutionBrowser(Browser.Firefox, BrowserBehavior.ReuseIfStarted)]
    public void CompletePurchaseSuccessfully_WhenExistingClient()
    {
        AddRocketToShoppingCart();
        ApplyCoupon();
        IncreaseProductQuantity();
        var proceedToCheckout = Driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
        proceedToCheckout.Click();
        Driver.WaitUntilPageLoadsCompletely();
        var loginHereLink = Driver.FindElement(By.LinkText("Click here to login"));
        loginHereLink.Click();
        Login("info@berlinspaceflowers.com");
        Driver.WaitForAjax();
        var placeOrderButton = Driver.FindElement(By.Id("place_order"));
        placeOrderButton.Click();
        Driver.WaitForAjax();
        var receivedMessage = Driver.FindElement(By.XPath("//h1[text() = 'Order received']"));

        Assert.AreEqual("Order received", receivedMessage.Text);

        var orderNumber = Driver.FindElement(By.XPath("//*[@id='post-7']/div/div/div/ul/li[1]/strong"));
        _purchaseOrderNumber = orderNumber.Text;

    }

    private void Login(string userName)
    {
        Driver.WaitForAjax();
        var userNameTextField = Driver.FindElement(By.Id("username"));
        userNameTextField.TypeText(userName);
        var passwordField = Driver.FindElement(By.Id("password"));
        passwordField.TypeText(GetUserPasswordFromDb(userName));
        var loginButton = Driver.FindElement(By.XPath("//button[@name='login']"));
        loginButton.Click();
    }

    private void IncreaseProductQuantity()
    {
        var quantityBox = Driver.FindElement(By.CssSelector("[class*='input-text qty text']"));
        quantityBox.TypeText("2");
        Driver.WaitForAjax();
        ////Thread.Sleep(5000);
        var updateCart = Driver.FindElement(By.CssSelector("[value*='Update cart']"));
        updateCart.Click();
        ////Thread.Sleep(4000);
        Driver.WaitForAjax();
        var totalSpan = Driver.FindElement(By.XPath("//*[@class='order-total']//span"));

        Assert.AreEqual("114.00€", totalSpan.Text);
    }

    private void ApplyCoupon()
    {
        var couponCodeTextField = Driver.FindElement(By.Id("coupon_code"));
        couponCodeTextField.TypeText("happybirthday");
        var applyCouponButton = Driver.FindElement(By.CssSelector("[value*='Apply coupon']"));
        applyCouponButton.Click();
        ////Thread.Sleep(5000);
        Driver.WaitForAjax();

        var messageAlert = Driver.FindElement(By.CssSelector("[class*='woocommerce-message']"));
        Assert.AreEqual("Coupon code applied successfully.", messageAlert.Text);
    }

    private void AddRocketToShoppingCart()
    {
        Driver.GoToUrl("http://demos.bellatrix.solutions/");
        var addToCartFalcon9 = Driver.FindElement(By.CssSelector("[data-product_id*='28']"));
        addToCartFalcon9.Click();
        Driver.WaitForAjax();
        var viewCartButton = Driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));
        viewCartButton.Click();
    }

    private string GetUserPasswordFromDb(string userName)
    {
        return "@purISQzt%%DYBnLCIhaoG6$";
    }

    private string GenerateUniqueEmail()
    {
        return $"{Guid.NewGuid()}@berlinspaceflowers.com";
    }
}
