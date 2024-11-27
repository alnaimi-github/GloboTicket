using GloboTicket.App.Services;
using GloboTicket.App.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace GloboTicket.App.Components;

public partial class ShoppingCartWidget
{
    [Inject] 
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    [Inject]
    public ComponentStateChangedObserver Observer { get; set; } = null!;

    [Inject]
    public IShoppingCartService ShoppingCartService { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    private int _shoppingCartItemCount = 0;

    private Guid? _userId = null;

    protected override async Task OnInitializedAsync()
    {
        AuthenticationState state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = state.User;
        var userId = user.FindFirst(c => c.Type.Contains("nameidentifier"))?.Value;
        if (!userId.IsNullOrEmpty())
        {
            _userId = Guid.Parse(userId!);
        }

        Observer.OnStateChanged += UpdateCountAsync;

        await UpdateCountAsync();
    }

    private async Task UpdateCountAsync()
    {
        if (_userId == null)
        {
            _shoppingCartItemCount = 0;
            return;
        }

        _shoppingCartItemCount = await ShoppingCartService.GetCountAsync((Guid)_userId);
        StateHasChanged();
    }

    private void NavigateToCart()
    {
        NavigationManager.NavigateTo("cart");
    }
}