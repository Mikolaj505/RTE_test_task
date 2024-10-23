using Fusion;
using UnityEngine;

namespace MKubiak.RTETestTask.InteractionSystem
{
    public class SnowPile : NetworkBehaviour, IInteractable
    {
        [SerializeField] private InteractLabelUIController _interactLabel;
        [SerializeField] private float _interactionCooldown = 3;

        [Networked] private float CooldownTimeLeft { get; set; } = 0f;

        private bool CanInteract => CooldownTimeLeft <= 0;

        private InteractionSetRegisterer _setRegisterer;
        private bool _enabled = true;

        private PlayerFacade _currentInteractor;

        private void Awake()
        {
            _setRegisterer = GetComponent<InteractionSetRegisterer>();
        }

        public void Interact(PlayerFacade interactor)
        {
            if (Runner.IsServer == false || CanInteract == false)
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

            _currentInteractor = interactor;
            _interactLabel.Show();
        }

        public void OnDeselected(PlayerFacade interactor)
        {
            if (interactor.HasInputAuthority == false)
            {
                return;
            }

            _currentInteractor = null;
            _interactLabel.Hide();
        }

        public GameObject GetRelatedGameObject()
        {
            return gameObject;
        }

        public override void FixedUpdateNetwork()
        {
            if (_enabled && CanInteract == false)
            {
                DisableInteraction();
            }
            else if (_enabled == false && CanInteract)
            {
                EnableInteraction();
            }

            if (Runner.IsServer && CanInteract == false)
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
            OnDeselected(_currentInteractor);
            _enabled = false;
        }

        private void HandleInteraction(PlayerFacade interactor)
        {
            CooldownTimeLeft = _interactionCooldown;
            Debug.Log($"We got interaction!!! {interactor.name}");

            DisableInteraction();
        }
    }
}