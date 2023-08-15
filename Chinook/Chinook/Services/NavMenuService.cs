namespace Chinook.Services
{
    public class NavMenuService
    {
        public event Action OnReloadTestComponentRequested;
        public NavMenuService() { }

        public void RequestReloadTestComponent()
        {
            OnReloadTestComponentRequested?.Invoke();
        }
    }
}
