namespace UI.Services
{
    public class CartActionsService
    {
        public event Action? CartUpdated;

        public void UpdateCart()
        {
            CartUpdated?.Invoke();
        }
    }
}
