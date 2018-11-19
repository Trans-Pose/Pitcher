//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity userRootNoteEntity { get { return GetGroup(GameMatcher.UserRootNote).GetSingleEntity(); } }
    public UserRootNoteComponent userRootNote { get { return userRootNoteEntity.userRootNote; } }
    public bool hasUserRootNote { get { return userRootNoteEntity != null; } }

    public GameEntity SetUserRootNote(float newNote) {
        if (hasUserRootNote) {
            throw new Entitas.EntitasException("Could not set UserRootNote!\n" + this + " already has an entity with UserRootNoteComponent!",
                "You should check if the context already has a userRootNoteEntity before setting it or use context.ReplaceUserRootNote().");
        }
        var entity = CreateEntity();
        entity.AddUserRootNote(newNote);
        return entity;
    }

    public void ReplaceUserRootNote(float newNote) {
        var entity = userRootNoteEntity;
        if (entity == null) {
            entity = SetUserRootNote(newNote);
        } else {
            entity.ReplaceUserRootNote(newNote);
        }
    }

    public void RemoveUserRootNote() {
        userRootNoteEntity.Destroy();
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

    public UserRootNoteComponent userRootNote { get { return (UserRootNoteComponent)GetComponent(GameComponentsLookup.UserRootNote); } }
    public bool hasUserRootNote { get { return HasComponent(GameComponentsLookup.UserRootNote); } }

    public void AddUserRootNote(float newNote) {
        var index = GameComponentsLookup.UserRootNote;
        var component = (UserRootNoteComponent)CreateComponent(index, typeof(UserRootNoteComponent));
        component.Note = newNote;
        AddComponent(index, component);
    }

    public void ReplaceUserRootNote(float newNote) {
        var index = GameComponentsLookup.UserRootNote;
        var component = (UserRootNoteComponent)CreateComponent(index, typeof(UserRootNoteComponent));
        component.Note = newNote;
        ReplaceComponent(index, component);
    }

    public void RemoveUserRootNote() {
        RemoveComponent(GameComponentsLookup.UserRootNote);
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

    static Entitas.IMatcher<GameEntity> _matcherUserRootNote;

    public static Entitas.IMatcher<GameEntity> UserRootNote {
        get {
            if (_matcherUserRootNote == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.UserRootNote);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUserRootNote = matcher;
            }

            return _matcherUserRootNote;
        }
    }
}
