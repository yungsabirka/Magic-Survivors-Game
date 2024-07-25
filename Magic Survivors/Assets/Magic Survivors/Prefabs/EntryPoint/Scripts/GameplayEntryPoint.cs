using UnityEngine;

public class GameplayEntryPoint : MonoBehaviour
{
    private void Awake()
    {
        Game.Run();
        Game.OnGameInitialized += InitializeGame;
    }

    private void OnDisable()
    {
        Game.OnGameInitialized -= InitializeGame;
    }

    private void InitializeGame()
    {
        InitializePlayer();
        FindObjectOfType<CameraMover>().Initialize();
        FindObjectOfType<Spawner>().Initialize();
        InitializeUI();
    }

    private void InitializePlayer()
    {
        var playerHealth = FindObjectOfType<PlayerHealth>();
        var initializableComponents = new Component[]
        {
            playerHealth,
            playerHealth.GetComponent<InputController>(),
            playerHealth.GetComponent<PlayerAnimator>(),
            playerHealth.GetComponent<PlayerMover>(),
            playerHealth.GetComponent<PlayerAttacker>(),
        };
        foreach (var component in initializableComponents)
        {
            if (component is IInitializable)
                (component as IInitializable).Initialize();
            else
                throw new System.Exception("All components must be IInitializable");
        }
    }

    private void InitializeUI()
    {
        FindObjectOfType<MenuView>().Initialize();
        FindObjectOfType<PlayerHealthView>().Initialize();
        FindObjectOfType<PlayerLevelView>().Initialize();
        FindObjectOfType<PlayerMoneyView>().Initialize();
        FindObjectOfType<GameOverView>().Initialize();
        var bonusesPanelView = FindObjectOfType<BonusesPanelView>();
        var bonusesSpawner = FindObjectOfType<BonusesSpawner>();
        

        bonusesPanelView.HideBonuses();
        bonusesPanelView.SetBonusesSpawner(bonusesSpawner);
        bonusesPanelView.Initialize();
        bonusesSpawner.SetBonusesView(bonusesPanelView);
        bonusesSpawner.Initialize();
    }
}

