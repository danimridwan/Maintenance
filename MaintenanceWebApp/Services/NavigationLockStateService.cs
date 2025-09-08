namespace MaintenanceWebApp.Services
{
    public class NavigationLockStateService
    {
        public bool ShouldBypass { get; private set; } = false;

        public void RequestBypass()
        {
            ShouldBypass = true;
        }

        public void Reset()
        {
            ShouldBypass = false;
        }
    }
}
