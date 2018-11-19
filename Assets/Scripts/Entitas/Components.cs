using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class BeatsPerSecondComponent : IComponent
{
    public float BeatsPerSecond;
}

[Game, Unique]
public class UserRootNoteComponent : IComponent
{
    public float Note;
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

//[Game, Unique]
//public class 