using Assets.CodeBase.Combat;
using Assets.CodeBase.Player;
using Assets.CodeBase.Services;
using Assets.CodeBase.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.CodeBase.Factories
{
    public class HUDFactory : IHUDFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IPlayerFactory _playerFactory;
        private GameObject _hud;
        public HUDFactory(IStaticDataService staticDataService, IPlayerFactory playerFactory)
        {
            _staticDataService = staticDataService;
            _playerFactory = playerFactory;
        }
        public GameObject Create()
        {
            var prefab = _staticDataService.HUD;
            var _hud = GameObject.Instantiate(prefab);          
            var healthBar = _hud.GetComponentInChildren<PlayerHealthBar>();
            var healthable = _playerFactory.Player.GetComponent<IHealthable>();
            healthBar.SetHealthable(healthable);                       
            return _hud;
        }
    }
}
