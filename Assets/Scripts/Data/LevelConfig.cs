using UnityEngine;

[CreateAssetMenu(fileName ="Level", menuName ="Data/Config/Level")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private float _bpm = 120f;
    public float BPM { get { return _bpm; } }
    [SerializeField] private int _rows = 12;
    public int Rows { get { return _rows; } }
    [SerializeField] private int _columns = 8;
    public int Columns { get { return _columns; } }
    [SerializeField] private Vector2 _cellSize = Vector2.one;
    public Vector2 CellSize { get { return _cellSize; } }
}
