using UnityEngine;

public class GameSystems : Feature
{
    public GameSystems(Contexts contexts, GameConfig gameConfig, LevelConfig levelConfig, UserConfig userConfig) : base("Game")
    {
        var game = contexts.game;
        SetupUniqueComponents(game, levelConfig, userConfig);
        CreatePlayhead(game, gameConfig, levelConfig);
        CreatePlayers(game, gameConfig, levelConfig);
        Add(new PitchMovementSystem(contexts));
        Add(new BeatMovementSystem(contexts));
        Add(new LinkPositionSystem(contexts));
    }

    private void SetupUniqueComponents(GameContext game, LevelConfig levelConfig, UserConfig userConfig)
    {
        game.ReplaceBeatsPerSecond(levelConfig.BPM / 60f);
        game.ReplaceCellSize(levelConfig.CellSize.x, levelConfig.CellSize.y);
        game.ReplaceGridSize(levelConfig.Columns, levelConfig.Rows);
        game.ReplaceRootPitch(userConfig.Root);
        game.ReplaceCurrentPitch(userConfig.Root);
    }

    private void CreatePlayhead(GameContext game, GameConfig gameConfig, LevelConfig levelConfig)
    {
        var playhead = game.CreateEntity();
        playhead.AddPosition2D(new Vector2(levelConfig.CellSize.x * -levelConfig.Columns * 0.5f, 0));
        playhead.AddView(Object.Instantiate(gameConfig.PlayHead));
        playhead.isBeatMovable = true;
    }

    private void CreatePlayers(GameContext game, GameConfig gameConfig, LevelConfig levelConfig)
    {
        var pos = new Vector2(levelConfig.CellSize.x * -levelConfig.Columns * 0.5f, 0);
        CreatePlayer(game, gameConfig.APlayer, pos);
    }

    private void CreatePlayer(GameContext game, GameObject prefab, Vector2 position)
    {
        var player = game.CreateEntity();
        player.AddPosition2D(position);
        player.AddPitchMovementLerpSpeed(1f);
        var clone = Object.Instantiate(prefab);
        player.AddView(clone);
        player.isBeatMovable = true;
        player.isPitchMovable = true;
    }
}
