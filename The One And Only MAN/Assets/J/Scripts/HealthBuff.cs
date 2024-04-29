using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/HealthBuff")]
public class HealthBuff : PowerUpEffects
{
    public int amount = 0;

    public override void Apply(GameObject target)
    {
        target.GetComponent<playerHealthUI>().health += amount;
    }
}
