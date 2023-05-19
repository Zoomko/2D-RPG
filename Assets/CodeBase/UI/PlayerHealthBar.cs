using Assets.CodeBase.Combat;
using Assets.CodeBase.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : HealthBar
{
    public void SetDamagable(IDamagable damagable)
    {
        this.damagable = damagable;
        this.damagable.HPChanged += OnHealthChange;
    }
}
