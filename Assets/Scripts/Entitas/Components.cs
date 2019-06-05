using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class Position2D : IComponent
{
    public Vector2 Value;
}

[Game, Unique]
public class BeatsPerSecondComponent : IComponent
{
    public float Value;
}

[Game, Unique]
public class RootPitchComponent : IComponent
{
    public float Value;
}

[Game, Unique]
public class CurrentPitchComponent : IComponent
{
    public float Value;
}

[Game, Unique]
public class GridSizeComponent : IComponent
{
    public int Columns;
    public int Rows;
}

[Game, Unique]
public class CellSizeComponent : IComponent
{
    public float X;
    public float Y;
}

[Game, Unique, FlagPrefix("should")]
public class DetectPitchComponent : IComponent { }

[Game]
public class ViewComponent : IComponent
{
    public GameObject GameObject;
}

[Game]
public class PitchMovementLerpSpeedComponent : IComponent
{
    public float Value;
}

[Game]
public class PitchMovableComponent : IComponent { }

[Game]
public class BeatMovableComponent : IComponent { }
