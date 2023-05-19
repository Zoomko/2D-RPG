using Assets.CodeBase.Combat;
using Assets.CodeBase.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureHealthBar : HealthBar
{
    private void Awake()
    {
        this.damagable = GetComponentInParent<IDamagable>();
        this.damagable.HPChanged += OnHealthChange;
    }
}
