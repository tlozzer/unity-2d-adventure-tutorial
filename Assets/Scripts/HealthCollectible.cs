using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField]
    private int _health = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var healthCollector = collision.GetComponent<HealthCollector>();

        if (healthCollector != null)
        {
            if (healthCollector.NeedHealth())
            {
                healthCollector.ChangeHealth(_health);
                Destroy(gameObject);
            }
        }
    }
}
