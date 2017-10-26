using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Stats/EnemyStats")]
public class EnemyStats : ScriptableObject {
	public int maxHealth;
	public int attackPower;
    public float attackRate;
}
