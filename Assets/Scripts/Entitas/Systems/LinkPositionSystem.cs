using System.Collections.Generic;
using Entitas;

public class LinkPositionSystem : ReactiveSystem<GameEntity>
{
    public LinkPositionSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position2D);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition2D && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            e.view.GameObject.transform.position = e.position2D.Value;
        }
    }
}