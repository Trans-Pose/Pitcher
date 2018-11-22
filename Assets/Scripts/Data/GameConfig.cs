using UnityEngine;

[CreateAssetMenu(fileName ="GameConfig", menuName ="Data/Config/Game")]
public class GameConfig : ScriptableObject
{
    [SerializeField] private GameObject _playhead;
    public GameObject PlayHead { get { return _playhead; } }
    [SerializeField] private GameObject _xPlayer;
    public GameObject XPlayer { get { return _xPlayer; } }
    [SerializeField] private GameObject _yPlayer;
    public GameObject YPlayer { get { return _yPlayer; } }
    [SerializeField] private GameObject _aPlayer;
    public GameObject APlayer { get { return _aPlayer; } }
    [SerializeField] private GameObject _bPlayer;
    public GameObject BPlayer { get { return _bPlayer; } }
}
