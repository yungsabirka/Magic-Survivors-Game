using UnityEngine;

public class ShopEntryPoint : MonoBehaviour
{
    private void Awake()
    {
        Game.Run();
    }

    //private void OnEnable()
    //{
    //    Game.OnGameInitialized += Initialize;
    //}
    //private void OnDisable()
    //{
    //    Game.OnGameInitialized -= Initialize;
    //}

    //private void Initialize()
    //{
    //    var walletView = FindObjectOfType<WalletView>();
    //    walletView.Initialize();
    //}
}

