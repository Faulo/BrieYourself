//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Settings/PlayerActions.inputactions
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

namespace BrieYourself.Characters
{
    public partial class @PlayerActions : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Avatar"",
            ""id"": ""25f10aee-91cd-42e1-94d7-b7b40312e8ab"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""7eefc787-68c4-423a-b99f-382d179c5e78"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""529dcf5a-2dd9-4175-902c-3e0d0b750f4c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""0b683c13-ebf6-4f35-9008-45f858ca954f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StickLook"",
                    ""type"": ""PassThrough"",
                    ""id"": ""03627173-01ea-49db-bf01-968b70be5c69"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""Value"",
                    ""id"": ""7a8905ce-2fe2-4ad5-88c1-bbac5d55b59b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ccabded2-878f-4e16-9500-4ddfdd80bdb6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""0ccccd2d-7e7c-47f5-888b-0d5f68288c43"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4dee5ccc-e0fa-4de3-93dd-16b2202ae2e2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fdd8941f-405e-4914-ba0e-e56cb62fc3d9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""90e55a45-5534-400b-9817-d705f02a55bf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7184121c-5e66-4436-8173-2f7b377f9984"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""92bc8fd2-d4a3-4d6b-9e39-c68d58627c3e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6fbb7e89-ba77-4bf3-b6ed-8ddd1c7b260c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69965ad2-fa2e-46c3-b0a9-6ada45ce3f40"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f28da3b7-6d8c-408d-b800-b30095a71398"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd4d5c9a-ab2b-44d9-aaa4-6451d7623d1d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StickLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50a94638-8051-4d44-9483-cf858a3afefc"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Avatar
            m_Avatar = asset.FindActionMap("Avatar", throwIfNotFound: true);
            m_Avatar_Move = m_Avatar.FindAction("Move", throwIfNotFound: true);
            m_Avatar_Jump = m_Avatar.FindAction("Jump", throwIfNotFound: true);
            m_Avatar_Interact = m_Avatar.FindAction("Interact", throwIfNotFound: true);
            m_Avatar_StickLook = m_Avatar.FindAction("StickLook", throwIfNotFound: true);
            m_Avatar_MouseLook = m_Avatar.FindAction("MouseLook", throwIfNotFound: true);
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

        // Avatar
        private readonly InputActionMap m_Avatar;
        private IAvatarActions m_AvatarActionsCallbackInterface;
        private readonly InputAction m_Avatar_Move;
        private readonly InputAction m_Avatar_Jump;
        private readonly InputAction m_Avatar_Interact;
        private readonly InputAction m_Avatar_StickLook;
        private readonly InputAction m_Avatar_MouseLook;
        public struct AvatarActions
        {
            private @PlayerActions m_Wrapper;
            public AvatarActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Avatar_Move;
            public InputAction @Jump => m_Wrapper.m_Avatar_Jump;
            public InputAction @Interact => m_Wrapper.m_Avatar_Interact;
            public InputAction @StickLook => m_Wrapper.m_Avatar_StickLook;
            public InputAction @MouseLook => m_Wrapper.m_Avatar_MouseLook;
            public InputActionMap Get() { return m_Wrapper.m_Avatar; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(AvatarActions set) { return set.Get(); }
            public void SetCallbacks(IAvatarActions instance)
            {
                if (m_Wrapper.m_AvatarActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_AvatarActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_AvatarActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_AvatarActionsCallbackInterface.OnMove;
                    @Jump.started -= m_Wrapper.m_AvatarActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_AvatarActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_AvatarActionsCallbackInterface.OnJump;
                    @Interact.started -= m_Wrapper.m_AvatarActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_AvatarActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_AvatarActionsCallbackInterface.OnInteract;
                    @StickLook.started -= m_Wrapper.m_AvatarActionsCallbackInterface.OnStickLook;
                    @StickLook.performed -= m_Wrapper.m_AvatarActionsCallbackInterface.OnStickLook;
                    @StickLook.canceled -= m_Wrapper.m_AvatarActionsCallbackInterface.OnStickLook;
                    @MouseLook.started -= m_Wrapper.m_AvatarActionsCallbackInterface.OnMouseLook;
                    @MouseLook.performed -= m_Wrapper.m_AvatarActionsCallbackInterface.OnMouseLook;
                    @MouseLook.canceled -= m_Wrapper.m_AvatarActionsCallbackInterface.OnMouseLook;
                }
                m_Wrapper.m_AvatarActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @StickLook.started += instance.OnStickLook;
                    @StickLook.performed += instance.OnStickLook;
                    @StickLook.canceled += instance.OnStickLook;
                    @MouseLook.started += instance.OnMouseLook;
                    @MouseLook.performed += instance.OnMouseLook;
                    @MouseLook.canceled += instance.OnMouseLook;
                }
            }
        }
        public AvatarActions @Avatar => new AvatarActions(this);
        public interface IAvatarActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnStickLook(InputAction.CallbackContext context);
            void OnMouseLook(InputAction.CallbackContext context);
        }
    }
}
