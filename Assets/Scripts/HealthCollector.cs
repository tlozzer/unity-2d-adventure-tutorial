using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HealthCollector
{
    bool NeedHealth();
    void ChangeHealth(int amount);
}
