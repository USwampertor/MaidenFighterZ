//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.0
//     from Assets/MaidenFighterZInputAction.inputactions
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

public partial class @MaidenFighterZInputAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MaidenFighterZInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MaidenFighterZInputAction"",
    ""maps"": [
        {
            ""name"": ""InGame"",
            ""id"": ""e477f182-ee19-4f92-8f90-d523929a08e0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""770459f4-b0c3-4aa8-adcd-49b957c2b736"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LP"",
                    ""type"": ""Button"",
                    ""id"": ""4756b4b5-c290-4b64-bca9-1465b83db1ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MP"",
                    ""type"": ""Button"",
                    ""id"": ""fe8b33bc-b07d-4513-8a44-6928a522caef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HP"",
                    ""type"": ""Button"",
                    ""id"": ""21bc0330-c588-4588-be99-acbc069ee192"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LK"",
                    ""type"": ""Button"",
                    ""id"": ""2631a73a-06ad-4762-9633-d807b549d639"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MK"",
                    ""type"": ""Button"",
                    ""id"": ""80ec86bc-a9e7-4c63-ae5f-4220873528d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HK"",
                    ""type"": ""Button"",
                    ""id"": ""54039d78-7ad9-4c4c-a0d7-260410a9a185"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5a2576ad-fd5c-4c2a-8e05-e6b785abe78f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b36bb04f-a3c8-4460-9e5d-011bf578c581"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""068775d1-8b25-4b3e-b03a-b3c32ef78eef"",
                    ""path"": ""<SwitchProControllerHID>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch Pro Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b30bf374-7d2d-4fb8-a698-4a1d9f522c1b"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4 Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""8538e340-3253-4227-a6be-1efefa968404"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""4fcf88f5-4c7f-4c5c-ae3b-e789e2ce04f1"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""ea6a97b6-76c1-4f41-ae4a-de23faae62af"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""a42b4fe1-31f8-4867-a696-d0191765afec"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""8959ef44-867c-425b-ba04-73b115646cde"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f2c3d1a2-98a5-4970-b5bc-fb1bdb612975"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9c002f0-c077-4aa6-b84c-544d3c119785"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3aa4fd67-43f4-4d8c-8e00-32eb57eeb0cc"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""LP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""364bee59-182d-455b-b029-13480c297818"",
                    ""path"": ""<SwitchProControllerHID>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch Pro Controller"",
                    ""action"": ""LP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3dc48b19-1087-43f4-b022-e0a23924909c"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4 Controller"",
                    ""action"": ""LP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""929b7f49-d63a-42cd-87f7-13894d5876b6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6960f79d-0218-4f66-a60d-975c25fac598"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""HP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b50965b-747b-4a13-8e7a-9b1ffb9ab7a3"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7e77b49-416b-4110-85bd-2c3a8c6cde54"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44c4cdca-3575-4b0e-964f-01e09e264ef2"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""HK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Xbox Controller"",
            ""bindingGroup"": ""Xbox Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Switch Pro Controller"",
            ""bindingGroup"": ""Switch Pro Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<SwitchProControllerHID>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""PS4 Controller"",
            ""bindingGroup"": ""PS4 Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // InGame
        m_InGame = asset.FindActionMap("InGame", throwIfNotFound: true);
        m_InGame_Move = m_InGame.FindAction("Move", throwIfNotFound: true);
        m_InGame_LP = m_InGame.FindAction("LP", throwIfNotFound: true);
        m_InGame_MP = m_InGame.FindAction("MP", throwIfNotFound: true);
        m_InGame_HP = m_InGame.FindAction("HP", throwIfNotFound: true);
        m_InGame_LK = m_InGame.FindAction("LK", throwIfNotFound: true);
        m_InGame_MK = m_InGame.FindAction("MK", throwIfNotFound: true);
        m_InGame_HK = m_InGame.FindAction("HK", throwIfNotFound: true);
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

    // InGame
    private readonly InputActionMap m_InGame;
    private List<IInGameActions> m_InGameActionsCallbackInterfaces = new List<IInGameActions>();
    private readonly InputAction m_InGame_Move;
    private readonly InputAction m_InGame_LP;
    private readonly InputAction m_InGame_MP;
    private readonly InputAction m_InGame_HP;
    private readonly InputAction m_InGame_LK;
    private readonly InputAction m_InGame_MK;
    private readonly InputAction m_InGame_HK;
    public struct InGameActions
    {
        private @MaidenFighterZInputAction m_Wrapper;
        public InGameActions(@MaidenFighterZInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_InGame_Move;
        public InputAction @LP => m_Wrapper.m_InGame_LP;
        public InputAction @MP => m_Wrapper.m_InGame_MP;
        public InputAction @HP => m_Wrapper.m_InGame_HP;
        public InputAction @LK => m_Wrapper.m_InGame_LK;
        public InputAction @MK => m_Wrapper.m_InGame_MK;
        public InputAction @HK => m_Wrapper.m_InGame_HK;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void AddCallbacks(IInGameActions instance)
        {
            if (instance == null || m_Wrapper.m_InGameActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InGameActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @LP.started += instance.OnLP;
            @LP.performed += instance.OnLP;
            @LP.canceled += instance.OnLP;
            @MP.started += instance.OnMP;
            @MP.performed += instance.OnMP;
            @MP.canceled += instance.OnMP;
            @HP.started += instance.OnHP;
            @HP.performed += instance.OnHP;
            @HP.canceled += instance.OnHP;
            @LK.started += instance.OnLK;
            @LK.performed += instance.OnLK;
            @LK.canceled += instance.OnLK;
            @MK.started += instance.OnMK;
            @MK.performed += instance.OnMK;
            @MK.canceled += instance.OnMK;
            @HK.started += instance.OnHK;
            @HK.performed += instance.OnHK;
            @HK.canceled += instance.OnHK;
        }

        private void UnregisterCallbacks(IInGameActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @LP.started -= instance.OnLP;
            @LP.performed -= instance.OnLP;
            @LP.canceled -= instance.OnLP;
            @MP.started -= instance.OnMP;
            @MP.performed -= instance.OnMP;
            @MP.canceled -= instance.OnMP;
            @HP.started -= instance.OnHP;
            @HP.performed -= instance.OnHP;
            @HP.canceled -= instance.OnHP;
            @LK.started -= instance.OnLK;
            @LK.performed -= instance.OnLK;
            @LK.canceled -= instance.OnLK;
            @MK.started -= instance.OnMK;
            @MK.performed -= instance.OnMK;
            @MK.canceled -= instance.OnMK;
            @HK.started -= instance.OnHK;
            @HK.performed -= instance.OnHK;
            @HK.canceled -= instance.OnHK;
        }

        public void RemoveCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInGameActions instance)
        {
            foreach (var item in m_Wrapper.m_InGameActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InGameActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InGameActions @InGame => new InGameActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_XboxControllerSchemeIndex = -1;
    public InputControlScheme XboxControllerScheme
    {
        get
        {
            if (m_XboxControllerSchemeIndex == -1) m_XboxControllerSchemeIndex = asset.FindControlSchemeIndex("Xbox Controller");
            return asset.controlSchemes[m_XboxControllerSchemeIndex];
        }
    }
    private int m_SwitchProControllerSchemeIndex = -1;
    public InputControlScheme SwitchProControllerScheme
    {
        get
        {
            if (m_SwitchProControllerSchemeIndex == -1) m_SwitchProControllerSchemeIndex = asset.FindControlSchemeIndex("Switch Pro Controller");
            return asset.controlSchemes[m_SwitchProControllerSchemeIndex];
        }
    }
    private int m_PS4ControllerSchemeIndex = -1;
    public InputControlScheme PS4ControllerScheme
    {
        get
        {
            if (m_PS4ControllerSchemeIndex == -1) m_PS4ControllerSchemeIndex = asset.FindControlSchemeIndex("PS4 Controller");
            return asset.controlSchemes[m_PS4ControllerSchemeIndex];
        }
    }
    public interface IInGameActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLP(InputAction.CallbackContext context);
        void OnMP(InputAction.CallbackContext context);
        void OnHP(InputAction.CallbackContext context);
        void OnLK(InputAction.CallbackContext context);
        void OnMK(InputAction.CallbackContext context);
        void OnHK(InputAction.CallbackContext context);
    }
}
