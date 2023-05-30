# Specflow_API

This repository contains a sample API test automation framework built using SpecFlow, RestSharp, and NUnit. The framework is designed to test the functionality of an API by executing various scenarios and validating the expected behavior.

## Prerequisites

- [.NET Framework](https://dotnet.microsoft.com/download) (minimum version: 4.7.2)
- [SpecFlow](https://specflow.org/) (installed via NuGet package)
- [RestSharp](https://restsharp.dev/) (installed via NuGet package)
- [NUnit](https://nunit.org/) (installed via NuGet package)

## The GitHub Actions workflow is configured to:

Run on every push event.
Use the latest version of the Ubuntu environment.
Set up the specified .NET Core SDK version.
Install dependencies, build the solution, and run the tests.
Publish the test results using the peaceiris/actions-gh-pages action.
Generate an Allure report using the simple-elf/allure-report-action action.
Deploy the generated report to GitHub Pages using the peaceiris/actions-gh-pages action.
