using System.Collections;
using UnityEngine;

public class WizardProjectileMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (_speed <= 0)
            return;

        transform.Translate(_speed * Time.deltaTime * Vector3.right);
    }
}

