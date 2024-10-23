using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MKubiak.RTETestTask.InteractionSystem
{
    public class InteractLabelUIController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _interactLabel;
        [SerializeField] private string _interactionText = "Press '{0}' to ...";
        [SerializeField] private InputActionReference _interactInputAction;

        public void Show()
        {
            _interactLabel.text = string.Format(_interactionText, _interactInputAction.action.GetBindingDisplayString());
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}