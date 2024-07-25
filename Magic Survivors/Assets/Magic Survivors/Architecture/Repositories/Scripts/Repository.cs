public abstract class Repository
{
    public virtual void OnCreate() { }

    public abstract void Initialize();

    public virtual void OnStart() { }

    public virtual void Save() { }

}
