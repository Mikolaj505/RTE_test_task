﻿using Fusion;
using Fusion.Addons.KCC;
using UnityEngine;

namespace MKubiak.RTETestTask.Weapons
{
    public class SnowballThrowerController : NetworkBehaviour, IWeaponController
    {
        [SerializeField] private WeaponConfig _config;
        [SerializeField] private NetworkPrefabRef _snowballPrefab;
        [SerializeField] private GameObject _heldSnowbalVisual;
        [SerializeField] private Transform _throwOrigin;
        [SerializeField] private float _throwForwardOffset;
        [SerializeField] private float _damage;

        private PlayerFacade _playerFacade;

        private bool _isHoldingASnowball;

        [Networked] private float Ammo {get; set;}

        private float _ammoToAddNextTick;

        private void Awake()
        {
            _playerFacade = GetComponentInParent<PlayerFacade>();
        }

        public void AddAmmo(float amount)
        {
            _ammoToAddNextTick += amount;
        }

        public override void Render()
        {
            if (Ammo > 0 && _isHoldingASnowball == false)
            {
                SetHeldSnowballVisualActive(true);
            }
            else if (Ammo <= 0 && _isHoldingASnowball)
            {
                SetHeldSnowballVisualActive(false);
            }
        }

        private void SetHeldSnowballVisualActive(bool active)
        {
            _heldSnowbalVisual.SetActive(active);
            _isHoldingASnowball = active;
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
            if (HasStateAuthority == false)
            {
                return;
            }

            if (Ammo > 0)
            {
                var throwRotation = Quaternion.AngleAxis(_playerFacade.Motor.GetLookRotation().x, _throwOrigin.right) * _throwOrigin.rotation;
                var throwForwardDirection = throwRotation * Vector3.forward;

                Runner.Spawn(_snowballPrefab,
                    _throwOrigin.position + throwForwardDirection * _throwForwardOffset,
                    throwRotation,
                    Object.InputAuthority,
                    (runner, networkObject) =>
                    {
                        networkObject.GetComponentNoAlloc<SnowballController>().Fire(_damage);
                    });

                Ammo--;
            }
        }
    }
}