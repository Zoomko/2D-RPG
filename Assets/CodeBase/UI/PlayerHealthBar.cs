using Assets.CodeBase.Combat;
using Assets.CodeBase.Player;
using Assets.CodeBase.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : HealthBar
{
    public void SetHealthable(IHealthable healthable)
    {
        this._healthable = healthable;
        this._healthable.HealthChanged += OnHealthChange;
        OnHealthChange();
    }
}
