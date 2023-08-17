namespace Chinook.Services
{
    public interface INavMenuService
    {
        public event Action OnReloadTestComponentRequested;
        public void RequestReloadTestComponent();
    }
}
