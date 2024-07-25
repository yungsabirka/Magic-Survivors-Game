using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour, IInitializable
{
    [Tooltip("The components must extend from IInitializable")]
    [SerializeField] private List<Component> _initializerComponents;

    public void Initialize()
    {
        foreach (var component in _initializerComponents)
        {
            if (component is IInitializable)
                (component as IInitializable).Initialize();  
            else
                throw new System.Exception("All components must be IInitializable");
        }
    }
}
