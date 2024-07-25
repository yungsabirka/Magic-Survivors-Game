using System.Collections;
using UnityEngine;

public class ProjectileDestroyer : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private void Start()
    {
        StartCoroutine(WaitAndDestroy());
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}

