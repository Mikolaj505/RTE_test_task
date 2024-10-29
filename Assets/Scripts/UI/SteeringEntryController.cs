using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MKubiak.RTETestTask
{
    public class SteeringEntryController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _inputLabel;
        [SerializeField] private InputActionReference _input;

        private void OnEnable()
        {
            Setup();
        }

        public void Setup()
        {
            _inputLabel.text = _input?.action?.GetBindingDisplayString() ?? "??";
        }
    }
}
