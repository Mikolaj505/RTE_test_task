using UnityEngine;

namespace MKubiak.RTETestTask.InteractionSystem
{
    public interface IInteractable
    {
        void OnSelected(PlayerFacade interactor);
        void OnDeselected(PlayerFacade interactor);
        void Interact(PlayerFacade interactor);
        GameObject GetRelatedGameObject();
    }
}