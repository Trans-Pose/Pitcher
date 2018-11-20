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

[Game]
public class PitchMovementLerpSpeedComponent : IComponent
{
    public float Value;
}

[Game]
public class PitchMovableComponent : IComponent { }