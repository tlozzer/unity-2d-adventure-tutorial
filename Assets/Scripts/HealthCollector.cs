using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HealthCollector
{
    bool NeedHealth();
    void AddHealth(int amount);
}
