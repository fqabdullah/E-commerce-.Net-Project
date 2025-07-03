using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using BlazorBay.Models;

namespace BlazorBay.Services
{
    public class CustomAuthProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _currentUser = new(new ClaimsIdentity());

        // Inject CartService via constructor
        private readonly CartService _cartService;

        public CustomAuthProvider(CartService cartService)
        {
            _cartService = cartService;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_currentUser));
        }

        public void SetUser(User user)
        {
            var identity = new ClaimsIdentity(new[]
            {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }, "CustomAuth");

            _currentUser = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void Logout()
        {
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

            // Use the injected CartService instance
            _cartService.Clear();
        }
    }
}
