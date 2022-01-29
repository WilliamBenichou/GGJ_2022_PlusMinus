// GENERATED AUTOMATICALLY FROM 'Assets/Settings/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Controls"",
            ""id"": ""bf21d4bd-5115-4177-a95c-5e3393551c60"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""cd6c772d-3dc7-4369-a4ca-2bdc7ab1509e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d2ff03f6-8732-49fd-ba52-a690a1aafda1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""28bf82e8-3b04-4277-8ee1-4dee8322588f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aeec0d58-a89a-4267-890d-2dd059097cbf"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player_1"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cda7a4ae-c60b-4ce1-825d-6906d45812b7"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player_2"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10e08e30-200a-41a6-9840-f457319bedb0"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player_1;Player_2"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34b482c4-46cf-4941-90ee-77ef4fb4b1e5"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player_1"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0401319f-54b7-4a79-b4fa-bb88b70b1163"",
                    ""path"": ""<Keyboard>/rightCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player_2"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ea6d85c-78e9-4886-a3d0-a4ced10fd792"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player_1;Player_2"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""66d53e16-717e-4590-9056-0b0933a6ac95"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c09840e0-4ace-498f-bb6c-365a6f299f37"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player_1"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e7ad7ec7-0271-442e-8de3-8b2e58bb8982"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player_2"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""21eb5f0f-3881-4beb-abd7-4eef8717e52b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player_1"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""eb0476b2-b601-47d2-828a-27a1fa6b14a1"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player_2"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""75e40d04-4f27-40a7-bb5f-50188bc3cdcc"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": ""Player_1;Player_2"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00cf65d8-f812-4306-b1ad-252063c3c6e5"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Player_1"",
            ""bindingGroup"": ""Player_1"",
            ""devices"": []
        },
        {
            ""name"": ""Player_2"",
            ""bindingGroup"": ""Player_2"",
            ""devices"": []
        }
    ]
}");
        // Controls
        m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
        m_Controls_Move = m_Controls.FindAction("Move", throwIfNotFound: true);
        m_Controls_Jump = m_Controls.FindAction("Jump", throwIfNotFound: true);
        m_Controls_Interact = m_Controls.FindAction("Interact", throwIfNotFound: true);
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

    // Controls
    private readonly InputActionMap m_Controls;
    private IControlsActions m_ControlsActionsCallbackInterface;
    private readonly InputAction m_Controls_Move;
    private readonly InputAction m_Controls_Jump;
    private readonly InputAction m_Controls_Interact;
    public struct ControlsActions
    {
        private @GameControls m_Wrapper;
        public ControlsActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Controls_Move;
        public InputAction @Jump => m_Wrapper.m_Controls_Jump;
        public InputAction @Interact => m_Wrapper.m_Controls_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJump;
                @Interact.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
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
            }
        }
    }
    public ControlsActions @Controls => new ControlsActions(this);
    private int m_Player_1SchemeIndex = -1;
    public InputControlScheme Player_1Scheme
    {
        get
        {
            if (m_Player_1SchemeIndex == -1) m_Player_1SchemeIndex = asset.FindControlSchemeIndex("Player_1");
            return asset.controlSchemes[m_Player_1SchemeIndex];
        }
    }
    private int m_Player_2SchemeIndex = -1;
    public InputControlScheme Player_2Scheme
    {
        get
        {
            if (m_Player_2SchemeIndex == -1) m_Player_2SchemeIndex = asset.FindControlSchemeIndex("Player_2");
            return asset.controlSchemes[m_Player_2SchemeIndex];
        }
    }
    public interface IControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
