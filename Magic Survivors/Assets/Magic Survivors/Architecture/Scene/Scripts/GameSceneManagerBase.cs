public sealed class GameSceneManagerBase : SceneManagerBase
{
    public override void InitializeSceneMap()
    {
        _sceneConfigMap[GameplaySceneConfig.Name] = new GameplaySceneConfig();
        _sceneConfigMap[ShopSceneConfig.Name] = new ShopSceneConfig();
    }
}

