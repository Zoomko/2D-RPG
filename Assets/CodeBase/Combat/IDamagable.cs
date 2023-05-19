using System;

namespace Assets.CodeBase.Combat
{
    public interface IDamagable
    {
        void GetDamage(int damage);
        //Where 1-st argment is currentHP, 2-en is maxHP, 3-th is damage
        event Action<int, int, int> HPChanged;
    }
}