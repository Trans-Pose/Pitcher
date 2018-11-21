using Entitas;
using UnityEngine;

public class BeatMovementSystem : IExecuteSystem
{
    private IGroup<GameEntity> _group;
    private readonly float _start, _end, _loopDuration;
    private float _timer;

    public BeatMovementSystem(Contexts contexts)
    {
        var game = contexts.game;
        _group = game.GetGroup(GameMatcher.AllOf(GameMatcher.BeatMovable, GameMatcher.Position2D));
        var columns = game.gridSize.Columns;
        _loopDuration = columns / game.beatsPerSecond.Value;
        var gridWidth = game.cellSize.X * columns;
        _end = gridWidth * 0.5f;
        _start = -_end;
    }

    public void Execute()
    {
        foreach (var e in _group.GetEntities())
        {
            var pos = e.position2D.Value;
            pos.x = Mathf.Lerp(_start, _end, _timer / _loopDuration);
            e.ReplacePosition2D(pos);
            _timer = (_timer + Time.deltaTime) % _loopDuration;
        }
    }
}
