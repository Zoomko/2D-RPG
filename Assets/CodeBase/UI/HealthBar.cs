using Assets.CodeBase.Combat;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Image _healthImageTarget;
        [SerializeField]
        private TextMeshProUGUI _text; 
        protected IDamagable damagable;            

        public void ResetValue(int maxHP)
        {
            _text.text = PrintHP(maxHP, maxHP);
            _healthImageTarget.fillAmount = 1f;
        }

        public void OnHealthChange(int currentHP, int maxHP, int damage)
        {
            _text.text = PrintHP(currentHP, maxHP);
            _healthImageTarget.fillAmount = (float)currentHP / maxHP;
        }

        private static string PrintHP(int currentHP, int maxHP)
        {
            return currentHP.ToString() + "/" + maxHP.ToString();
        }
    }
}