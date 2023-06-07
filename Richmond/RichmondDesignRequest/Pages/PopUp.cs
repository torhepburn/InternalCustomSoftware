using Microsoft.AspNetCore.Components;

namespace RichmondDesignRequest.Pages
{
    public class PopUp
    {
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public string Message { get; set; }
        [Parameter]
        public EventCallback OnClose { get; set; }
        public bool IsVisible { get; set; }
        public async Task ClosePopup()
        {
            IsVisible = false;
            await OnClose.InvokeAsync();
        }
        public void Dispose()
        {
            ClosePopup().Wait(); // Ensures the popup is closed when the component is disposed
        }

        public void ShowPopup()
        {
            IsVisible = true;
        }

        
    }
}
