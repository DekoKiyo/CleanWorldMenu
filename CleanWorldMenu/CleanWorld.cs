using Rage;

namespace CleanWorldMenu;

internal static class CleanWorld
{
    internal static void ClearWorld(bool livingPeds = true, bool deadPeds = true, bool livingVehicles = true, bool deadVehicles = true, bool persistentEntities = true, bool reloadWorld = true)
    {
        if (!livingPeds && !deadPeds && !livingVehicles && !deadVehicles && !persistentEntities && !reloadWorld) livingPeds = true;
        World.CleanWorld(livingPeds, deadPeds, livingVehicles, deadVehicles, persistentEntities, reloadWorld);
    }
}