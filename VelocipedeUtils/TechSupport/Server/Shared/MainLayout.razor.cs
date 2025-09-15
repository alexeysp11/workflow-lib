using Microsoft.AspNetCore.Components;

namespace VelocipedeUtils.Examples.TechSupport.Server.Shared;

public partial class MainLayout : LayoutComponentBase
{
    private bool _drawerOpen = true;

    private void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }
}