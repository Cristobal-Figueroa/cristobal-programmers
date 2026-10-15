# StockWise — Inventory & Sales Manager

A Blazor web application for small shops to manage inventory and register daily sales.
Built by **Cristobal Figueroa** (Cristobal Programmers) for BYU-Idaho CSE 325.

## Features

- **User authentication** — ASP.NET Core Identity (register / login / logout)
- **Dashboard** — today's sales, last-7-days totals, product count, low-stock alerts, recent sales
- **Products** — full CRUD with search, category filter, and low-stock badges
- **Categories** — create and delete categories (deletion blocked when in use)
- **Sales register** — cart-style sale entry, stock validation, automatic stock decrement
- **Sales history** — every sale with line-item detail and unit-price snapshot
- **Error handling** — friendly messages on every operation plus model validation

## Tech Stack

- .NET 9 — Blazor Web App (Interactive Server)
- Entity Framework Core + SQLite
- ASP.NET Core Identity
- Bootstrap (template theme, customized branding)

## Getting Started

```powershell
cd StockWise
dotnet run
```

Open `http://localhost:5000` (or the port shown in the console).

The database is created automatically on startup with demo data.

### Demo account

| Field    | Value                |
|----------|----------------------|
| Email    | `admin@stockwise.dev` |
| Password | `Admin123!`           |

You can also register your own account from the Register page.

## Usage Guide

1. **Sign in** with the demo account (or register a new one).
2. **Dashboard** shows the store status at a glance.
3. **Products → New Product** to add items (name, category, price, cost, stock, low-stock threshold).
4. **New Sale**: pick a product, set quantity, click *Add item*, then *Register Sale* — stock decreases automatically.
5. **Sales** lists all sales; click *Details* to see line items.
6. Products under their threshold appear as **Low Stock** on the dashboard and product list.

## Project Structure

```
StockWise/
├── Components/        # Blazor pages and layout
│   ├── Account/       # Identity pages (register, login, manage)
│   ├── Layout/        # MainLayout + NavMenu
│   └── Pages/         # Dashboard, Products, Categories, Sales
├── Data/              # ApplicationDbContext + DbSeeder + migrations
├── Helpers/           # FormatHelper (CLP currency)
├── Models/            # Product, Category, Sale, SaleItem
└── Program.cs         # Services, middleware, seed
```

## Deployment

The project includes a `Dockerfile` ready for platforms like Render, Railway, or Azure Container Apps.
