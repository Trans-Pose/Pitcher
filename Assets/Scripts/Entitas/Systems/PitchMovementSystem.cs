using Entitas;
using UnityEngine;

public class PitchMovementSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _group;
    private readonly float _top, _bottom;
    private readonly float _root, _octave;
    private readonly GameContext _gameContext;

    public PitchMovementSystem(Contexts contexts)
    {
        _gameContext = contexts.game;
        _group = _gameContext.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.Position2D,
                GameMatcher.PitchMovable,
                GameMatcher.PitchMovementLerpSpeed
                ));
        _top = _gameContext.gridSize.Rows * 0.5f * _gameContext.cellSize.Y;
        _bottom = -_top;
        _root = _gameContext.rootPitch.Value;
        _octave = _root * 2f;
    }

    public void Execute()
    {
        foreach (var e in _group.GetEntities())
        {
            // Find normalization of pitch
            var clampedPitch = Mathf.Clamp(_gameContext.currentPitch.Value, _root, _octave);
            var normalizedPitch = ErisMath.Normalize(clampedPitch, _root, _octave);

            // Find y position of pitch & then lerp there by deltaTime & speed
            var v = e.position2D.Value;
            var pitchHeight = Mathf.Lerp(_bottom, _top, normalizedPitch);
            v.y = Mathf.Lerp(v.y, pitchHeight, Time.deltaTime * e.pitchMovementLerpSpeed.Value);
            e.ReplacePosition2D(v);
        }
    }
}
