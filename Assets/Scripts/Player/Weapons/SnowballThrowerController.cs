using Fusion;
using UnityEngine;

namespace MKubiak.RTETestTask.Weapons
{
    public class SnowballThrowerController : NetworkBehaviour, IWeaponController
    {
        [SerializeField] private WeaponConfig _config;
        [SerializeField] private NetworkPrefabRef _snowballPrefab;
        [SerializeField] private GameObject _heldSnowbalVisual;

        private bool _isHoldingASnowball;

        [Networked] private float Ammo {get; set;}

        private float _ammoToAddNextTick;

        public void AddAmmo(float amount)
        {
            _ammoToAddNextTick += amount;
        }

        public override void Render()
        {
            if (Ammo > 0 && _isHoldingASnowball == false)
            {
                _heldSnowbalVisual.SetActive(true);
                _isHoldingASnowball = true;
            }
        }

        public override void FixedUpdateNetwork()
        {
            Ammo += _ammoToAddNextTick;
            _ammoToAddNextTick = 0;
        }

        public WeaponConfig GetWeaponConfig()
        {
            return _config;
        }

        public void OnFireDown()
        {
            if (Ammo > 0)
            {
                Debug.Log($"Fire!!!");
                Ammo--;
            }
        }
    }
}