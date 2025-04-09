# BlazorBay Documentation

# ENGLISH

## Project Overview

**BlazorBay** is a full-featured e-commerce UI built with **Blazor Server** and **.NET 8**, using:
- Entity Framework Core + SQLite for database persistence
- Shared state via `CartService`
- Responsive Bootstrap UI with toast notifications
- JS Interop for animated alerts
- Fully reactive component-based architecture

---

## 🔧 Key Concepts & File References

| Concept                            | File(s) Involved                          | Explanation |
|------------------------------------|-------------------------------------------|-------------|
| ✅ **State Management**            | `CartService.cs`, `App.razor`, `NavMenu.razor` | CartService is a singleton injected across components to persist cart state |
| ✅ **Two-way Data Binding**        | `ProductCrud.razor`                       | Uses `@bind-Value` in form inputs to sync `editProduct` model |
| ✅ **[Parameter]**                 | `ProductCard.razor`                       | Receives `Product` object from parent (`ProductList.razor`) |
| ✅ **[CascadingParameter]**        | `ProductCard.razor`, `Cart.razor`         | CartService is shared via cascading injection set in `App.razor` |
| ✅ **[Inject]**                    | `ProductCard.razor`, `Cart.razor`, `ProductCrud.razor` | Used for `IJSRuntime` and `AppDbContext` |
| ✅ **Event Binding (`@onclick`)** | `ProductCard.razor`, `Cart.razor`, `ProductCrud.razor` | Binds buttons to C# methods like `AddToCart()` |
| ✅ **Calling JavaScript from C#** | `ProductCard.razor`, `Cart.razor`         | Calls `cartNotification()` JS function to show Bootstrap toasts |
| ✅ **Bootstrap UI + Toasts**      | `MainLayout.razor`, `cart.js`, `_Host.cshtml` | Custom toasts are dynamically created for add/remove feedback |
| ✅ **Dependency Injection (DI)**  | `Program.cs`                              | Registers `CartService`, `DbContext`, and built-in services |

---

## 📁 Feature-to-File Mapping

| Feature              | File(s)                                    |
|----------------------|---------------------------------------------|
| Product display      | `ProductList.razor`, `ProductCard.razor`    |
| Shopping cart        | `Cart.razor`, `CartService.cs`              |
| Product admin CRUD   | `ProductCrud.razor`                         |
| Global layout/toasts | `MainLayout.razor`, `cart.js`, `_Host.cshtml` |
| App configuration    | `Program.cs`, `App.razor`                  |

---

## 🛠 Database Setup

### Step-by-step

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## 🚦 Test Instructions

| Feature             | Test Step |
|---------------------|-----------|
| Add to Cart         | On `/`, click “Add to Cart”. Toast appears. |
| Remove from Cart    | On `/cart`, click “Remove”. Red toast appears. |
| Create Product      | On `/admin/products`, fill and save. |
| Edit Product        | Click “Edit”, update, then “Save”. |
| Delete Product      | Click “Delete”. List updates. |
| Toast Notifications | Appear bottom-right, animated, per action. |

---

# ESPAÑOL

## Resumen del Proyecto

**BlazorBay** es una app e-commerce construida con Blazor Server:
- Persistencia con SQLite + EF Core
- Estado compartido con `CartService`
- Diseño con Bootstrap y toasts
- Interop JS para animaciones

---

## 🧠 Conceptos Clave y Archivos

| Concepto                      | Archivo(s)                                | Explicación |
|------------------------------|--------------------------------------------|-------------|
| ✅ Estado Compartido         | `CartService.cs`, `App.razor`, `NavMenu.razor` | Mantiene productos en el carrito |
| ✅ Enlace bidireccional      | `ProductCrud.razor`                       | Usa `@bind-Value` para editar productos |
| ✅ `[Parameter]`             | `ProductCard.razor`                       | Recibe producto del padre |
| ✅ `[CascadingParameter]`    | `ProductCard.razor`, `Cart.razor`         | `CartService` fluye desde `App.razor` |
| ✅ `[Inject]`                | `ProductCard.razor`, `Cart.razor`         | Inyecta servicios como `JSRuntime` o `DbContext` |
| ✅ Eventos (`@onclick`)     | Varias vistas                             | Asocia eventos de botón con métodos C# |
| ✅ Llamada JS desde C#       | `ProductCard.razor`, `Cart.razor`         | Ejecuta toasts con `cartNotification()` |
| ✅ UI Bootstrap + Toasts     | `MainLayout.razor`, `cart.js`, `_Host.cshtml` |
| ✅ DI                        | `Program.cs`                              | Configura inyecciones globales |

---

## 🛠 Crear Base de Datos

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## ✅ Probar Funcionalidades

| Función                | Cómo Probar |
|------------------------|-------------|
| Agregar al carrito     | Click en “Add to Cart” en `/` |
| Eliminar del carrito   | En `/cart`, click “Remove”    |
| Crear producto         | Llenar formulario en `/admin/products` |
| Editar producto        | Click en “Edit” → “Save”      |
| Notificaciones         | Toasts verdes/rojos visibles  |

---

# FRANÇAIS

## Aperçu du Projet

**BlazorBay** est une interface e-commerce utilisant :
- SQLite + EF Core pour les données
- `CartService` pour gérer le panier
- UI réactive avec Bootstrap
- Notifications toast animées via JS

---

## 🧠 Concepts et Fichiers

| Concept                      | Fichier(s)                                | Explication |
|-----------------------------|--------------------------------------------|-------------|
| ✅ Gestion d’état            | `CartService.cs`, `App.razor`              | Partage du panier via service singleton |
| ✅ Liaison bidirectionnelle | `ProductCrud.razor`                       | Liaisons avec `@bind-Value` |
| ✅ `[Parameter]`            | `ProductCard.razor`                       | Reçoit un produit |
| ✅ `[CascadingParameter]`   | `ProductCard.razor`, `Cart.razor`         | Accès global à `CartService` |
| ✅ `[Inject]`               | `ProductCard.razor`, `Cart.razor`         | Injection de dépendances |
| ✅ Évènements `@onclick`   | Sur boutons                              | Clics déclenchent des actions |
| ✅ Interop JS               | `ProductCard.razor`, `Cart.razor`         | Appelle `cartNotification()` JS |
| ✅ Bootstrap Toasts         | `MainLayout.razor`, `cart.js`, `_Host.cshtml` |
| ✅ DI                       | `Program.cs`                              | Enregistre les services globaux |

---

## 🛠 Générer la Base de Données

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## ✅ Tester les Fonctionnalités

| Fonction              | Étapes |
|-----------------------|--------|
| Ajouter un produit    | Cliquer “Add to Cart” sur `/` |
| Supprimer un article  | Cliquer “Remove” dans `/cart` |
| CRUD Produits         | Créer, modifier, supprimer sur `/admin/products` |
| Notifications         | Toasts dynamiques en bas à droite (vert/rouge) |
