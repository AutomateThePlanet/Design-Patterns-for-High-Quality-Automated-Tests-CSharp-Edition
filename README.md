## Before You Get Started ##

You need to have prior experience in OOP programming language such as C#, Java, etc. I believe that you can get the book's ideas just from reading the presented code. However, it is recommended to download and run all of the solutions on your machine. 

**As a bonus to the book, you can find video recordings with explanations for each chapter.** To get them, you can join for free the book's LinkedIn group. There you can find even more info about design patterns in automated testing and best practices or use it as an easy way to reach me. Before joining, you need to provide proof that you purchased the book. Just go to https://bit.ly/3eGTAUl  (these are the video explanations for the Java edition if you are comfortable with Java and have purchased one of the books - drop me a line and I will give you access.)

To be able to build and execute the code, you will need a C# IDE, such as Visual Studio or Visual Studio Code. Also, you will need to install .NET Core 3.1+.

## Questions/Reader feedback/Errata ##

You can contact me at LinkedIn - [https://bit.ly/2NjWJ19](https://bit.ly/2NjWJ19) if you are having any problems with any aspect of the book, and I will do my best to address it.

## Foreword ##  

Since I usually skip the Foreword chapters of other books, I will try to be short. My core belief is that to achieve high-quality test automation that brings value- you need to understand core programming concepts such as SOLID and the usage of design patterns. After you master them, the usual career transition is into more architecture roles, such as choosing the best possible approaches for solving particular test automation challenges. This is the essence of the book. **No more “Hello world” examples but some serious literature about test automation practices!**
 
### Who Is This Book For?  ### 

The book is not a getting started guide. If you don't have any prior programming experience in writing automated tests through WebDriver, this book won't be very useful to you. I believe it might be invaluable for the readers that have a couple of years of experience and whose job is to create/maintain test automation frameworks, or to write high-quality reliable automated tests.

The book is written in C#. However, I believe that you can use the approaches and practices in every OOP language. If you have a Java background, you will get everything you need, don't worry.

Even if you don't get all the concepts from the first read, try to use and incorporate some of them, later you can return and reread them. I believe with the accumulation of experience using high-quality practices- you will become a hard-core test automation ninja!
If you are a Java person I suggest you to check the **[Java edition of the book](https://www.automatetheplanet.com/resources/#javabook-dp)**.

## What this book covers

### Chapter 1. Defining High-Quality Test Attributes

I think many terms are misunderstood and engineers are using them without fully understanding them, such as a library, framework, test framework. I believe this is the basic knowledge that all test engineers should have. The reader will learn about the top-quality attributes each test library should strive to have, which we will discuss in much more detail in the next chapters. Moreover, since we want to treat the test code as production one, we will talk about SOLID principles and how we can incorporate them into the development of the tests.

### Chapter 2. Optimizing and Refactoring Legacy Flaky Tests

We will discuss the Hermetic test pattern where each test should be isolated from others. Will learn about the Adapter design pattern where some of the unstable behaviours of WebDriver will be wrapped in a class and fixed. The same pattern will be used to improve the WebDriver API for locating elements and making it easier to use. Finally, we will talk about random run order principle where the tests should be able to run no matter their order.

### Chapter 3. Strategies for Speeding-up the Tests

After the tests are stabilized and always passing the next step is to improve their speed. One of the approaches will be login to a website through cookies instead of using the UI. Next, the readers will see how to reuse the WebDriver browser instead of restarting it all the time earning more than 40% decrease in test execution time. We will talk about how to handle asynchronous requests. And last but not least we will mention the “Black Hole Proxy” approach isolating 3rd party services’ requests, while further improving the speed of the automated tests.

### Chapter 4. Test Readability

Learn how to hide nitty-gritty low-level WebDriver API details in the so-called page objects, making the tests much more readable. Also, the readers will see how to create two different types of page objects depending on their needs. In the second part of the chapter, we will talk about coding standards - naming the variables and methods right, as well as placing the correct comments. At the end of the section, we will discuss various tools that can help us to enforce all these standards.

### Chapter 5. Enhancing the Test Maintainability and Reusability

We will talk about how to reuse more code across page objects by using the Template Method design pattern. Also, we will see a 3rd type of page object model where the assertions and elements will be used as properties instead of coming from base classes, which will introduce the benefits of the composition over the inheritance principle. In the second part of the chapter, we will discuss how to reuse common test workflows through the Facade design pattern. At the end of the section, we will talk about an enhanced version of the pattern where we can test different versions of the same web page (new and old).

### Chapter 6. API Usability

In this chapter, we will learn how to make the test library API easy to use, learn, and understand. First, we will talk about different approaches on how to use already developed page object models through the Singleton design pattern or Factory design pattern. After that, we will look at another approach called Fluent API or Chaining Methods. At the end of the section, we will discuss whether it is a good idea to expose the page objects elements to the users of your test library.

### Chapter 7. Building Extensibility in Your Test Library

If you create a well-designed library, most probably other teams can start using it too, so you need to be sure that your library is easily extensible. It should allow everyone to modify it and add new features to it without causing you to spend tons of time rewriting existing logic or making already written tests to fail. In this chapter, the reader will learn how to improve extensibility for finding elements by creating custom selectors through the Strategy design pattern. After that, we will investigate ways on how we can add additional behaviors to existing WebDriver actions via Observer design pattern or built-in EventFiringWebDriver.

### Chapter 8. Assessment System for Tests’ Architecture Design

In this chapter, we will look into an assessment system that can help you decide which design solution is better- for example, to choose one between 5 different versions of page objects. We will talk about the various criteria of the system and why they are essential. In the second part of the section, we will use the system to evaluate some of the design patterns we used previously and assign them ratings.

### Chapter 9. Benchmarking for Assessing Automated Test Components Performance

The evaluation of core quality attributes is not enough to finally decide which implementation is better or not. The test execution time should be a key component too. In this chapter, we will examine a library that can help us measure the performance of our automated tests’ components.

### Chapter 10. Test Data Preparation and Configuring Test Environments

One of the essential parts of each automated test is the test data which we use in it. It is important that the data is relevant and accessible. In the chapter, we will discuss how we can create such data through fixtures, APIs, DB layers or custom tools. Also, we will review how to set up the right way the environment in which the tests run.

### Appendix 1. Defining the Primary Problems that Test Automation Frameworks Solve

In the first appendix chapter, we will define the problems that the automation framework is trying to solve. To determine what is needed to deliver high-quality software, we need to understand what the issues are in the first place.

### Appendix 2. Most Exhaustive CSS Selectors Cheat Sheet

A big part of the job of writing maintainable and stable web automation is related to finding the proper element's selectors. Here will look into a comprehensive list of CSS selectors.

### Appendix 3. Most Exhaustive XPath Selectors Cheat Sheet

The other types of very useful locators are the XPath ones. Knowing them in detail can help you significantly improve the stability and the readability of your tests.
