using UnityEngine;


public class Playhead : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    [SerializeField] private int _rows = 8;
    [SerializeField] private int _columns = 8;
    [SerializeField] private float _bpm = 120f;
    private Vector3 _start, _end;
    private float _timer, _loopDuration;

#if UNITY_EDITOR
    private void OnValidate()
    {
        var columnsPerSecond = _bpm / 60f;
        _loopDuration = _columns / columnsPerSecond;
    }
#endif

    private void Awake()
	{
        var columnsPerSecond = _bpm / 60f;
        _loopDuration = _columns / columnsPerSecond;
        var gridWidth = _grid.cellSize.x * _columns;
        _start = new Vector3(-gridWidth * 0.5f, 0f);
        _end = new Vector3(gridWidth * 0.5f, 0f);
        transform.position = _start;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(_start, _end, _timer / _loopDuration);
        _timer = (_timer + Time.deltaTime) % _loopDuration;
    }
}
