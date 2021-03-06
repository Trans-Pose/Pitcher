//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly BeatMovableComponent beatMovableComponent = new BeatMovableComponent();

    public bool isBeatMovable {
        get { return HasComponent(GameComponentsLookup.BeatMovable); }
        set {
            if (value != isBeatMovable) {
                var index = GameComponentsLookup.BeatMovable;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : beatMovableComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherBeatMovable;

    public static Entitas.IMatcher<GameEntity> BeatMovable {
        get {
            if (_matcherBeatMovable == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BeatMovable);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBeatMovable = matcher;
            }

            return _matcherBeatMovable;
        }
    }
}
