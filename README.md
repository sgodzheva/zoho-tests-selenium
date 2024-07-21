## Zoho Tests Selenium
 - [Introduction](#introduction)
 - [Technologies Used](#technologies-used)
 - [Project Structure](#project-structure)
 - [Running the Tests](#running-the-tests)
 - [Motivation](#motivation)

## Introduction
 [Zoho Invoice](https://invoice.zohocloud.ca/) is a comprehensive invoicing software that helps manage customers, products(items), quotes, and invoices. The tests in this project ensure that the key functionalities of Zoho Invoice work as expected.

## Technologies Used
 - C#
 - Selenium WebDriver
 - NUnit
 - Visual Studio

## Project Structure
This project follows the Page Object Model approach and you can find the Page Models in the [Pages](/src/Zoho.Tests.Selenium/Pages) directory.
The tests, at least for now, are organized by feature or major functionality (Customers, Quotes etc). Each folder also contains test cases written in a markdown format.
Automation code that often repeats is organized into separate classes and can be found in the [Automations](/src/Zoho.Tests.Selenium/Automations) folder.

```
Zoho.Tests.Selenium/
├── Automations/
│   ├── Automation1.cs 
│	└── Automation2.cs
├── Pages/
│   ├── PageName1.cs  
│   └── PageName2.cs  
└── Tests/
	└── Functionality/
		├── _TestCases.md
		├── Test1.cs
		└── Test2.cs
```

## Running the tests
To run the tests you should setup several environment variables:

###### ZOHO_TESTS_USERNAME
The username used for login in Zoho Invoice

###### ZOHO_TESTS_PASSWORD
The password used for login in Zoho Invoice

###### ZOHO_TESTS_ACCOUNT_NUMBER
After you register in Zoho and land on the home page, you can find the account number in the URL. For Example, the account number for the URL below is `120200521861`
```
https://invoice.zohocloud.ca/app/120200521861#/home/gettingstarted
```

###### ZOHO_TESTS_SESSION_LOCATION
There is a limit of 20 logins per day, so the tests store and reuse the browser session. This environment variable points to the path where the session should be stored. For example:
```
D:\Tests\cookies

```

## Motivation

### Why Zoho Invoice?
There are more inputs and logic in Zoho Invoice as compared to other websites. It's also free and anyone can register an account and run the tests.

### Why the tests do not use the html element ids, but target relative xPaths instead?
Yes, it would have been easier and better to use ids or a dedicated testing attribute (such as 'data-test-id'), but the websites ids (`id="ember195"`) are not static and vary between browser sessions. Additionally, using a relative xPath, shows different ways of finding html elements, as opposed to getting an element by id every time.