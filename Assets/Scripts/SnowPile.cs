using Fusion;
using UnityEngine;

namespace MKubiak.RTETestTask.InteractionSystem
{
    public class SnowPile : NetworkBehaviour, IInteractable
    {
        [SerializeField] private InteractLabelUIController _interactLabel;

        public void Interact(PlayerFacade interactor)
        {
            if (Runner.IsServer == false)
            {
                return;
            }

            Debug.Log($"We got interaction!!! {interactor.name}");
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
    }
}