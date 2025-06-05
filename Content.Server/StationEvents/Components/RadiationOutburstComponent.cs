using Content.Server.StationEvents.Events;

namespace Content.Server.StationEvents.Components;

[RegisterComponent, Access(typeof(RadiationOutburstComponent))]
public sealed partial class RadiationOutburstComponent : Component
{
    [DataField]
    public int severity = 5;

    [DataField]
    public int maxSeverity = 5;
}