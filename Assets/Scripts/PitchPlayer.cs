using UnityEngine;


public class PitchPlayer : MonoBehaviour
{
    [SerializeField] private LevelConfig _level;
    [SerializeField] private bool _lerp;
    private PitchDetector _pitchDetector;
    private UserConfig _user;
    private float _top, _bottom;

    private void Awake()
    {
        var halfHeight = _level.CellSize.y * _level.Rows * 0.5f;
        _top = halfHeight;
        _bottom = -_top;
    }

    private void Update()
    {
        var pitch = _pitchDetector.DetectedPitches.Peek();
        var clampedPitch = Mathf.Clamp(pitch, _user.Root, _user.Root * 2);
        var normalizedPitch = ErisMath.Normalize(clampedPitch, _user.Root, _user.Root * 2);
        var height = Mathf.Lerp(_bottom, _top, normalizedPitch);
        var pos = transform.position;
        pos.y = height;
        if (_lerp)
        {
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
        }
        else
        {
            transform.position = pos;
        }
    }

    public void Init(PitchDetector pitchDetector, UserConfig userConfig)
    {
        _pitchDetector = pitchDetector;
        _user = userConfig;
    }
}
