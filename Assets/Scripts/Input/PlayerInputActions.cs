//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace MKubiak.RTETestTask.Input
{
    public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerMap"",
            ""id"": ""b5b8a64c-8293-4bad-ae3a-0e38c3e8511c"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""e2b7ecd8-79a7-4ce0-adb1-86943e7d386d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""d4825f0b-4051-42e4-bebf-cf5e3b7aea15"",
                    ""expectedControlType"": ""Delta"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""6961f1cf-0585-4dd0-a473-7636918e5a38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""a1f5c29c-6c60-4649-9505-153b3bb1c36e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShowUI"",
                    ""type"": ""Button"",
                    ""id"": ""8b7d132c-9cb9-42d2-8266-b3e2f36b795e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""436667be-eb8e-474b-848c-690792026f47"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f46d8eb7-942c-4f61-ae76-94ae8b1b45c5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0e268f85-4984-4490-bce0-f4a63205fac6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c6adfcbd-5a2d-4224-8aee-8c620b591dd4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""df89b7e2-02a7-47ed-9775-1dd7a828160b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8cb7e04a-0d1e-435f-917e-ea9e3de8e9f5"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.1,y=0.1)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""034e2939-15cf-49d8-a1e4-a9429b49c465"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71338acf-7cd6-4f08-9f78-41e1826f4aab"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac510985-b2a6-49fa-b1e4-63eadde519db"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShowUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerMap
            m_PlayerMap = asset.FindActionMap("PlayerMap", throwIfNotFound: true);
            m_PlayerMap_Movement = m_PlayerMap.FindAction("Movement", throwIfNotFound: true);
            m_PlayerMap_Look = m_PlayerMap.FindAction("Look", throwIfNotFound: true);
            m_PlayerMap_Interact = m_PlayerMap.FindAction("Interact", throwIfNotFound: true);
            m_PlayerMap_Fire = m_PlayerMap.FindAction("Fire", throwIfNotFound: true);
            m_PlayerMap_ShowUI = m_PlayerMap.FindAction("ShowUI", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // PlayerMap
        private readonly InputActionMap m_PlayerMap;
        private List<IPlayerMapActions> m_PlayerMapActionsCallbackInterfaces = new List<IPlayerMapActions>();
        private readonly InputAction m_PlayerMap_Movement;
        private readonly InputAction m_PlayerMap_Look;
        private readonly InputAction m_PlayerMap_Interact;
        private readonly InputAction m_PlayerMap_Fire;
        private readonly InputAction m_PlayerMap_ShowUI;
        public struct PlayerMapActions
        {
            private @PlayerInputActions m_Wrapper;
            public PlayerMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_PlayerMap_Movement;
            public InputAction @Look => m_Wrapper.m_PlayerMap_Look;
            public InputAction @Interact => m_Wrapper.m_PlayerMap_Interact;
            public InputAction @Fire => m_Wrapper.m_PlayerMap_Fire;
            public InputAction @ShowUI => m_Wrapper.m_PlayerMap_ShowUI;
            public InputActionMap Get() { return m_Wrapper.m_PlayerMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerMapActions set) { return set.Get(); }
            public void AddCallbacks(IPlayerMapActions instance)
            {
                if (instance == null || m_Wrapper.m_PlayerMapActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PlayerMapActionsCallbackInterfaces.Add(instance);
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @ShowUI.started += instance.OnShowUI;
                @ShowUI.performed += instance.OnShowUI;
                @ShowUI.canceled += instance.OnShowUI;
            }

            private void UnregisterCallbacks(IPlayerMapActions instance)
            {
                @Movement.started -= instance.OnMovement;
                @Movement.performed -= instance.OnMovement;
                @Movement.canceled -= instance.OnMovement;
                @Look.started -= instance.OnLook;
                @Look.performed -= instance.OnLook;
                @Look.canceled -= instance.OnLook;
                @Interact.started -= instance.OnInteract;
                @Interact.performed -= instance.OnInteract;
                @Interact.canceled -= instance.OnInteract;
                @Fire.started -= instance.OnFire;
                @Fire.performed -= instance.OnFire;
                @Fire.canceled -= instance.OnFire;
                @ShowUI.started -= instance.OnShowUI;
                @ShowUI.performed -= instance.OnShowUI;
                @ShowUI.canceled -= instance.OnShowUI;
            }

            public void RemoveCallbacks(IPlayerMapActions instance)
            {
                if (m_Wrapper.m_PlayerMapActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPlayerMapActions instance)
            {
                foreach (var item in m_Wrapper.m_PlayerMapActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PlayerMapActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public PlayerMapActions @PlayerMap => new PlayerMapActions(this);
        public interface IPlayerMapActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnFire(InputAction.CallbackContext context);
            void OnShowUI(InputAction.CallbackContext context);
        }
    }
}
