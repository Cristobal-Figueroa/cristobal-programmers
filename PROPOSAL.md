# Project Proposal — StockWise: Inventory & Sales Manager

**Group:** Cristobal Programmers
**Members:** Cristobal Figueroa
**Course:** CSE 325 — .NET Software Development
**Week:** 03

---

## Title

**StockWise** — an inventory and sales management web application for small businesses, built with .NET and Blazor.

## Project Overview

Many small shops and family businesses still track their inventory on paper, notebooks, or messy spreadsheets. This leads to costly mistakes: products that run out without anyone noticing, sales that are never recorded, and no clear picture of which items actually make money. StockWise solves this problem by giving small business owners a single, simple place to manage their products, register sales, and see how their business is doing.

The target users are small shop owners and family businesses — mini markets, hardware stores, clothing shops, and similar operations — that need something simpler and more affordable than a full point-of-sale or ERP system. The app runs in any modern browser, so it works on the devices they already have.

StockWise is interesting and valuable because it focuses on the essentials: knowing what you have, recording what you sell, and seeing the results at a glance. Built with Blazor and Entity Framework Core, it demonstrates a complete .NET web application with real data persistence, user authentication, and business logic — realistic enough that an actual shop could use it.

## Project Scope

**IN scope:**

- User login (shop owner account)
- Product catalog: create, edit, delete products with price, cost, category, and stock quantity
- Categories for organizing products
- Sales register: record a sale by selecting products and quantities; stock decreases automatically
- Sales history with daily and weekly totals
- Dashboard: today's sales, total revenue, and low-stock alerts
- Search and filter products by name or category

**OUT of scope:**

- Multi-store or multi-branch support
- Online payments or card processing
- Official invoicing / tax document generation
- Barcode scanning or hardware integration
- Supplier management and purchase orders
- Native mobile app (the web app will be responsive instead)

## App Features

Users can:

1. Log in to the application with their account.
2. Create, edit, and delete products (name, price, cost, category, stock quantity, low-stock threshold).
3. Organize products into categories.
4. Register a sale by selecting products and quantities; stock is updated automatically.
5. View the sales history with daily and weekly totals.
6. See a dashboard with today's sales, total revenue, and low-stock alerts.
7. Search and filter the product catalog by name or category.

**User stories:**

- As a shop owner, I want to see which products are running low on stock so I can restock before they run out.
- As a shop owner, I want to register a sale in seconds so customers are not kept waiting.
- As a shop owner, I want a weekly sales report so I know which products sell best.
- As a shop owner, I want the app protected by a login so only I can see my business data.

Each feature is tracked as a card on the team's Trello board.

## Technical Considerations

- **Stack:** .NET 9, Blazor, Entity Framework Core, SQLite.
- **Data storage:** EF Core with SQLite database. Main entities: `User`, `Product`, `Category`, `Sale`, `SaleItem` (products and quantities per sale).
- **User accounts:** Yes — login required using ASP.NET Core Identity (passwords hashed; no plain-text storage).
- **External services:** None required. Optional: a charting library (e.g., Chart.js) for the dashboard sales visualization.
- **Device compatibility:** Responsive web application — works on desktop, tablet, and mobile browsers.
- **Security:** Authentication on all management pages, server-side validation, parameterized queries through EF Core (SQL injection safe), and anti-forgery tokens on forms.

## Project Links

- **GitHub Repository:** https://github.com/Cristobal-Figueroa/cristobal-programmers
- **Trello Board:** https://trello.com/b/z8xIyHvp/cristobal-programmers

## Group Leader

**Week 04 leader:** Cristobal Figueroa (currently the only member of the group).
