﻿using Fusion;
using MKubiak.RTETestTask.Input;
using MKubiak.RTETestTask.InteractionSystem;
using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class PlayerInteractionsController : NetworkBehaviour
    {
        [SerializeField] private InteractionsRuntimeSet _interactionsSet;
        [SerializeField] private float minDistanceToInteract;
        [SerializeField] private float updateInteractionsSelectionInterval = 0.3f;

        private PlayerFacade _playerFacade;
        private PlayerInputController _inputController;
        private IInteractable? _selectedInteractable;
        private Throttle _updateSelectionThrottle;

        private void Awake()
        {
            _playerFacade = GetComponent<PlayerFacade>();
            _updateSelectionThrottle = new Throttle(updateInteractionsSelectionInterval);
            _inputController = _playerFacade.Input;
        }

        private void Update()
        {
            if (_updateSelectionThrottle.IsReadyToUse(Time.time))
            {
                UpdateInteractionsSelection();
            }
        }

        public override void FixedUpdateNetwork()
        {
            if (_inputController.WasActivated(PlayerInputAction.Interact))
            {
                _selectedInteractable?.Interact(_playerFacade);
            }
        }

        private void UpdateInteractionsSelection()
        {
            var nearestInteractable = GetNearestItem();
            if (nearestInteractable != _selectedInteractable)
            {
                _selectedInteractable?.OnDeselected(_playerFacade);
            }

            _selectedInteractable = nearestInteractable;
            _selectedInteractable?.OnSelected(_playerFacade);
        }

        private IInteractable GetNearestItem()
        {
            float shortestDistance = Mathf.Infinity; // Initialize the shortest distance to infinity
            IInteractable nearestItem = null;

            foreach (var item in _interactionsSet.Items)
            {
                float distance = Vector3.SqrMagnitude(item.GetRelatedGameObject().transform.position - transform.position);
                
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;

                    if (distance > Mathf.Pow(minDistanceToInteract, 2))
                    {
                        continue;
                    }

                    nearestItem = item;
                }
            }

            return nearestItem;
        }
    }
}
