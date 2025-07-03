
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
| **State Management**            | `CartService.cs`, `App.razor`, `NavMenu.razor` | CartService is a singleton injected across components to persist cart state |
| **Two-way Data Binding**        | `ProductCrud.razor`                       | Uses `@bind-Value` in form inputs to sync `editProduct` model |
| **[Parameter]**                 | `ProductCard.razor`                       | Receives `Product` object from parent (`ProductList.razor`) |
| **[CascadingParameter]**        | `ProductCard.razor`, `Cart.razor`         | CartService is shared via cascading injection set in `App.razor` |
| **[Inject]**                    | `ProductCard.razor`, `Cart.razor`, `ProductCrud.razor` | Used for `IJSRuntime` and `AppDbContext` |
| **Event Binding (`@onclick`)** | `ProductCard.razor`, `Cart.razor`, `ProductCrud.razor` | Binds buttons to C# methods like `AddToCart()` |
| **Calling JavaScript from C#** | `ProductCard.razor`, `Cart.razor`         | Calls `cartNotification()` JS function to show Bootstrap toasts |
| **Bootstrap UI + Toasts**      | `MainLayout.razor`, `cart.js`, `_Host.cshtml` | Custom toasts are dynamically created for add/remove feedback |
| **Dependency Injection (DI)**  | `Program.cs`                              | Registers `CartService`, `DbContext`, and built-in services |

---
