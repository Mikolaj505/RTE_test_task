using UnityEngine;

namespace MKubiak.RTETestTask.InteractionSystem
{
    public class InteractionSetRegisterer : MonoBehaviour
    {
        [SerializeField] private InteractionsRuntimeSet _set;
        private IInteractable _interactable;

        private void Awake()
        {
            _interactable = GetComponent<IInteractable>();
        }

        private void OnEnable()
        {
            _set.Add(_interactable);
        }

        private void OnDisable()
        {
            _set.Remove(_interactable);
        }
    }
}