using Assets.CodeBase.Combat;
using Assets.CodeBase.Player;
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
        protected IHealthable _healthable;

        public void OnHealthChange()
        {
            _healthImageTarget.fillAmount = (float)_healthable.CurrentHP / _healthable.MaxHP;
            PrintHP();
        }

        protected void PrintHP()
        {
            _text.text = _healthable.CurrentHP.ToString() + "/" + _healthable.MaxHP.ToString();
        }
    }
}