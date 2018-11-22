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
    }

    private Systems AddSystems()
    {
        var contexts = Contexts.sharedInstance;
        return new Feature("Systems")
            .Add(new GameSystems(contexts));   
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}
