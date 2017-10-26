using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Health : ScriptableObject {
    public int healthPoints;
    public abstract int SubtractHealth(int amount, GameObject go);
    public abstract int AddHealth(int amount, GameObject go);
}
