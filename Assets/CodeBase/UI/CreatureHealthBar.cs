using Assets.CodeBase.Combat;
using Assets.CodeBase.Player;
using Assets.CodeBase.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureHealthBar : HealthBar
{
    private void Awake()
    {
        this._healthable = GetComponentInParent<IHealthable>();
        this._healthable.HealthChanged += OnHealthChange;
    }
}
