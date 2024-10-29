using Fusion;
using MKubiak.RTETestTask.Weapons;
using UnityEngine;

namespace MKubiak.RTETestTask.InteractionSystem
{
    public class SnowPile : NetworkBehaviour, IInteractable
    {
        [SerializeField] private InteractLabelUIController _interactLabel;
        [SerializeField] private float _interactionCooldown = 3;
        [SerializeField] private WeaponConfig _snowThrowerWeaponConfig;
        [SerializeField] private float _ammoToAdd;

        [Networked] private float CooldownTimeLeft { get; set; } = 0f;

        private bool CanInteract => CooldownTimeLeft <= 0;

        private InteractionSetRegisterer _setRegisterer;
        private bool _enabled = true;

        private void Awake()
        {
            _setRegisterer = GetComponent<InteractionSetRegisterer>();
        }

        public void Interact(PlayerFacade interactor)
        {
            if (CanInteract == false)
            {
                return;
            }

            //Disable interaction immediely on the local player, CooldownTime would be later changed to match with server
            OnDeselected(interactor);
            CooldownTimeLeft = _interactionCooldown;

            if (Runner.IsServer == false)
            {
                return;
            }

            HandleInteraction(interactor);
        }

        public void OnSelected(PlayerFacade interactor)
        {
            if (interactor.HasInputAuthority == false)
            {
                return;
            }

            _interactLabel.Show();
        }

        public void OnDeselected(PlayerFacade interactor)
        {
            if (interactor.HasInputAuthority == false)
            {
                return;
            }

            _interactLabel.Hide();
        }

        public GameObject GetRelatedGameObject()
        {
            return gameObject;
        }

        public override void Render()
        {
            if (_enabled && CanInteract == false)
            {
                DisableInteraction();
            }
            else if (_enabled == false && CanInteract)
            {
                EnableInteraction();
            }
        }

        public override void FixedUpdateNetwork()
        {
            if (CanInteract == false)
            {
                CooldownTimeLeft -= Runner.DeltaTime;
            }
        }

        public void EnableInteraction()
        {
            _setRegisterer.RegisterToSet();
            _enabled = true;
        }

        public void DisableInteraction()
        {
            _setRegisterer.UnregisterFromSet();
            _enabled = false;
        }

        private void HandleInteraction(PlayerFacade interactor)
        {
            DisableInteraction();
            interactor.Weapons.GetWeapon(_snowThrowerWeaponConfig.ID).AddAmmo(_ammoToAdd);
        }
    }
}