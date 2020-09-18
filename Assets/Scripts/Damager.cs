using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField]
    private int _damageAmount = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        var damageable = collision.GetComponent<Damageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(_damageAmount);
        }
    }
}
