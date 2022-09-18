
title: Software documentation for Ecommerce App

---

# Software documentation for Ecommerce App

> **Software Name:** e-Commerce App: OurBooks  
> **Version:** When applicable
> **Date: **2022-09-19

## **Software summary **👀

The Ecommerce Web Application that provides the core features present in many common e-commerce applications. General functionality will include features such as creating and logging into an account, viewing products and my profile, as well as adding items to a cart and checking out. This application is specifically focused on a bookstore launching an ecommerce site. It's origin story is akin to how Amazon began as a small store selling new and used books.

## **Requirements \*\***☝️\*\*

1.  Login

-   Users are able to login via Saas, Auth0

2.  Register

-   Users also have the option to register via, Saas, Auth0

3.  Display Products

-   Products (books) are displayed on the homepage
-   Users are able to click on a product (book title) in order to read more details and add it to the cart
    -   The product details is an optional feature that worked naturally in the process of developing the application

4.  Cart

-   Users can see the items (books) they have added to the cart, or an empty page if nothing is in the cart

5.  Checkout

-   Users are able to purchase their items
-   Users see confirmation on the webpage and not just the console
    -   Need to be able to update database on backend

6.  View Previous Orders

    -   Need to be able to see previous orders

7.  User Profile

-   Users can see their profile after they are logged in and have been authenticated as the same user

## How-to guide 🐣

This application is not containerized in manner like Docker. Follow the guide below to get the application running when you want to try it out.

-   Open both the frontend (angular project) and backend (.net api) and run them via the CLI
    -   Angular — ng serve open
    -   .Net — dotnet run
-   Once both parts of the app are up and running you should be able to call the frontend using http&#x3A;//localhost:4200 within the browser. The typescript will transpile to Javascript, create Json as needed and use the Saas, Auth0 in order to login to the app, if so desired.

## FAQs 🙋🏽‍♂️

Answer and document frequently asked questions below.

### Does the application run in any browser?

Because of the universal standards of HTML5 and the services/languages used, the application should run on any browser without major issues.

Answer

### Why wasn't my request received?

Check to make sure that both the Angular and the .Net API are running. You can open multiple terminals in many if not all IDEs. The developers for this project used VS Code and Visual Studio.

### Question

Answer

## Additional Resources 🧩

These resources were helpful in getting the application running seamlessly:

-   <https://learn.microsoft.com/en-us/dotnet/>
-   <https://developer.mozilla.org/en-US/>
-   <https://www.w3.org/>
-   <https://angular.io/tutorial/>
-   <https://auth0.com/>
