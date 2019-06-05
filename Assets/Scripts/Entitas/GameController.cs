using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private LevelConfig[] _levelConfigs;
    [SerializeField] private UserConfig _userConfig;
    private GameContext _gameContext;
    private Systems _systems;

    private void Awake()
	{
        _systems = AddSystems();
        _systems.Initialize();
    }

    private Systems AddSystems()
    {
        var contexts = Contexts.sharedInstance;
        return new Feature("Systems")
            .Add(new GameSystems(contexts, _gameConfig, _levelConfigs[0], _userConfig));   
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private void OnDestroy()
    {
        _systems.TearDown();
    }
}
