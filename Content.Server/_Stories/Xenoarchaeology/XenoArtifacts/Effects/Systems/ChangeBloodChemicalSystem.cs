using Content.Server.Xenoarchaeology.XenoArtifacts.Effects.Components;
using Content.Server.Xenoarchaeology.XenoArtifacts.Events;
using Robust.Shared.Random;

namespace Content.Server.Xenoarchaeology.XenoArtifacts.Effects.Systems;

public sealed class ChangeBloodChemicalArtifactSystem : EntitySystem
{
    [Dependency] private readonly IRobustRandom _random = default!;
    [Dependency] private readonly EntityLookupSystem _lookup = default!;

    public const string NodeDataUsesAmount = "nodeDataUsesAmount";

    public override void Initialize()
    {
        SubscribeLocalEvent<ChangeBloodChemicalArtifactComponent, ArtifactActivatedEvent>(OnActivate);
    }

    private string GetRandomReagent()
    {
        var blood = Comp.BloodWeight;
        var useful = Comp.UsefulWeight;
        var fun = Comp.FunWeight;

        var sum = blood + useful + fun;
        var rand = _random.NextFloat(0f, sum);

        if (rand <= blood)
        {
            var reagent = _random.Pick(Comp.BloodChemicals);
            return reagent;
        }

        else if (rand > blood and rand < blood + useful)
        {
            var reagent = _random.Pick(Comp.UsefulChemicals);
            return reagent;
        }

        else if (rand > blood + useful)
        {
            var reagent = _random.Pick(Comp.FunChemicals);
        }
    }

    private void OnActivate(EntityUid uid, ChangeBloodChemicalArtifactComponent component, ArtifactActivatedEvent args)
    {
        if (!_artifact.TryGetNodeData(uid, NodeDataUsesAmount, out int amount))
            amount = 0;

        if (amount >= component.maxUses)
            return;

        var hasBlood = GetEntityQuery<BloodstreamComponent>();
        foreach (var target in _lookup.GetEntitiesInRange(uid, component.Range))
        {
            var newBloodreagent = GetRandomReagent();

            if (!hasBlood.TryGetComponent(target, out var fl))
                continue;
            _bloodstream.ChangeBloodReagent(target, newBloodreagent)
        }

        _artifact.SetNodeData(uid, NodeDataUsesAmount, amount + 1);
    }
}