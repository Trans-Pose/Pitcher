using UnityEngine;


public class Playhead : MonoBehaviour
{
    [SerializeField] private LevelConfig _level;
    private Vector3 _start, _end;
    private float _timer, _loopDuration;

    private void Awake()
	{
        var columnsPerSecond = _level.BPM / 60f;
        _loopDuration = _level.Columns / columnsPerSecond;
        var gridWidth = _level.CellSize.x * _level.Columns;
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
