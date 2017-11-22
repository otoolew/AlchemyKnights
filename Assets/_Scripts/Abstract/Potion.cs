using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Items/Potion")]
public class Potion : Item {
    public string potionUse;
    public string potionPurpose;
    public string potionActiveIngredient;
    public string potionHalfLife;
    public string potionWarning;
}
