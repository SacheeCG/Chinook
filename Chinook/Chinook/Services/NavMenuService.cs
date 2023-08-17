namespace Chinook.Services
{
    public class NavMenuService: INavMenuService
    {
        public event Action OnReloadTestComponentRequested;
        public NavMenuService() { }

        public void RequestReloadTestComponent()
        {
            OnReloadTestComponentRequested?.Invoke();
        }
    }
}
