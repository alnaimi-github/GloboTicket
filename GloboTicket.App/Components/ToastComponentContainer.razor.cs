using GloboTicket.App.Models;
using Microsoft.AspNetCore.Components;

namespace GloboTicket.App.Components;

public partial class ToastComponentContainer
{
    [Parameter]
    public List<NotificationModel> Notifications { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        Notifications = new List<NotificationModel>();

        // TODO: listen to notification publishes
    }

    public async Task ReceiveNotification(string title, string message)
    {
        var notification = new NotificationModel { Title = title, Message = message };

        Notifications.Add(notification);

        await InvokeAsync(StateHasChanged);
    }

    public void RemoveNotification(NotificationModel notification)
    {
        Notifications.Remove(notification);

        StateHasChanged();
    }
}