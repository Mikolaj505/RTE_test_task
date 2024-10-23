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
            RegisterToSet();
        }

        private void OnDisable()
        {
            UnregisterFromSet();
        }

        public void RegisterToSet()
        {
            _set.Add(_interactable);
        }

        public void UnregisterFromSet()
        {
            _set.Remove(_interactable);
        }
    }
}