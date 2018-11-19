//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gridSizeEntity { get { return GetGroup(GameMatcher.GridSize).GetSingleEntity(); } }
    public GridSizeComponent gridSize { get { return gridSizeEntity.gridSize; } }
    public bool hasGridSize { get { return gridSizeEntity != null; } }

    public GameEntity SetGridSize(int newColumns, int newRows) {
        if (hasGridSize) {
            throw new Entitas.EntitasException("Could not set GridSize!\n" + this + " already has an entity with GridSizeComponent!",
                "You should check if the context already has a gridSizeEntity before setting it or use context.ReplaceGridSize().");
        }
        var entity = CreateEntity();
        entity.AddGridSize(newColumns, newRows);
        return entity;
    }

    public void ReplaceGridSize(int newColumns, int newRows) {
        var entity = gridSizeEntity;
        if (entity == null) {
            entity = SetGridSize(newColumns, newRows);
        } else {
            entity.ReplaceGridSize(newColumns, newRows);
        }
    }

    public void RemoveGridSize() {
        gridSizeEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GridSizeComponent gridSize { get { return (GridSizeComponent)GetComponent(GameComponentsLookup.GridSize); } }
    public bool hasGridSize { get { return HasComponent(GameComponentsLookup.GridSize); } }

    public void AddGridSize(int newColumns, int newRows) {
        var index = GameComponentsLookup.GridSize;
        var component = (GridSizeComponent)CreateComponent(index, typeof(GridSizeComponent));
        component.Columns = newColumns;
        component.Rows = newRows;
        AddComponent(index, component);
    }

    public void ReplaceGridSize(int newColumns, int newRows) {
        var index = GameComponentsLookup.GridSize;
        var component = (GridSizeComponent)CreateComponent(index, typeof(GridSizeComponent));
        component.Columns = newColumns;
        component.Rows = newRows;
        ReplaceComponent(index, component);
    }

    public void RemoveGridSize() {
        RemoveComponent(GameComponentsLookup.GridSize);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGridSize;

    public static Entitas.IMatcher<GameEntity> GridSize {
        get {
            if (_matcherGridSize == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GridSize);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGridSize = matcher;
            }

            return _matcherGridSize;
        }
    }
}