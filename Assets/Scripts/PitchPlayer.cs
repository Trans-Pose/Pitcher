using UnityEngine;


public class PitchPlayer : MonoBehaviour
{
    [SerializeField] private LevelConfig _level;
    private PitchDetector _pitchDetector;
    private UserConfig _user;
    private float _top, _bottom;

	private void Awake()
	{
        var halfHeight = _level.Grid.cellSize.y * _level.Rows * 0.5f;
        _top = _level.Grid.transform.position.y + halfHeight;
        _bottom = _level.Grid.transform.position.y - halfHeight;
    }

    private void Update()
    {
        var pitch = _pitchDetector.DetectedPitches.Peek();
        var clampedPitch = Mathf.Clamp(pitch, _user.Root, _user.Octave);
        var normalizedPitch = ErisMath.Normalize(clampedPitch, _user.Root, _user.Octave);
        var height = Mathf.Lerp(_bottom, _top, normalizedPitch);
        transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }

    public void Init(PitchDetector pitchDetector, UserConfig userConfig)
    {
        _pitchDetector = pitchDetector;
        _user = userConfig;
    }
}
