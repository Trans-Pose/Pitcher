using UnityEngine;

public class LevelConfig : ScriptableObject
{
    [SerializeField] private float _bpm = 120f;
    public float BPM { get { return _bpm; } }
    [SerializeField] private int _rows = 8;
    public int Rows { get { return _rows; } }
    [SerializeField] private int _columns = 8;
    public int Columns { get { return _columns; } }
    [SerializeField] private Grid _grid;
    public Grid Grid { get { return _grid; } }
}
