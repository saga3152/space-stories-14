namespace Content.Server.Xenoarchaeology.XenoArtifacts.Effects.Components;

[RegisterComponent]
public sealed partial class ChangeBloodChemicalComponent : Component
{
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public List<ProtoId<ReagentPrototype>> BloodChemicals = new();

    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public List<ProtoId<ReagentPrototype>> UsefulChemicals = new();

    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public List<ProtoId<ReagentPrototype>> FunChemicals = new();

    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float BloodWeight = 7f;

    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float UsefulWeight = 2f;

    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float FunWeight = 1f;

    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float Range = 3f;

    [DataField("maxUses")]
    public int MaxUses = 3;
}
