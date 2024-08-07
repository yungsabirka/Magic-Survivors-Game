//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Magic Survivors/Input/GameplayInputActions.inputactions
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

public partial class @GameplayInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameplayInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameplayInputActions"",
    ""maps"": [
        {
            ""name"": ""KeyBoardAndMouse"",
            ""id"": ""af6f58df-38c5-4d5a-9e1f-15560034fb2b"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""bf934171-195f-4136-800b-eaa3c2977ca6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""7ad512bf-e9dc-4f8d-a955-1e8573080a6c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5438cf7a-d86c-49e6-b94b-2c64712baa0e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2c3db85b-4f39-4a94-9937-a3b35d72aa64"",
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
                    ""id"": ""78dfa057-ca57-4ee1-95b0-9132209ee2cd"",
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
                    ""id"": ""08f5b7e5-df59-4e6b-a279-b687e44df1f5"",
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
                    ""id"": ""afdbf6ff-56ad-4c37-9f23-984205d48a88"",
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
                    ""id"": ""aa8c3026-b02b-49bd-ab97-e2548bb80ad7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // KeyBoardAndMouse
        m_KeyBoardAndMouse = asset.FindActionMap("KeyBoardAndMouse", throwIfNotFound: true);
        m_KeyBoardAndMouse_Attack = m_KeyBoardAndMouse.FindAction("Attack", throwIfNotFound: true);
        m_KeyBoardAndMouse_Move = m_KeyBoardAndMouse.FindAction("Move", throwIfNotFound: true);
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

    // KeyBoardAndMouse
    private readonly InputActionMap m_KeyBoardAndMouse;
    private List<IKeyBoardAndMouseActions> m_KeyBoardAndMouseActionsCallbackInterfaces = new List<IKeyBoardAndMouseActions>();
    private readonly InputAction m_KeyBoardAndMouse_Attack;
    private readonly InputAction m_KeyBoardAndMouse_Move;
    public struct KeyBoardAndMouseActions
    {
        private @GameplayInputActions m_Wrapper;
        public KeyBoardAndMouseActions(@GameplayInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_KeyBoardAndMouse_Attack;
        public InputAction @Move => m_Wrapper.m_KeyBoardAndMouse_Move;
        public InputActionMap Get() { return m_Wrapper.m_KeyBoardAndMouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyBoardAndMouseActions set) { return set.Get(); }
        public void AddCallbacks(IKeyBoardAndMouseActions instance)
        {
            if (instance == null || m_Wrapper.m_KeyBoardAndMouseActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_KeyBoardAndMouseActionsCallbackInterfaces.Add(instance);
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
        }

        private void UnregisterCallbacks(IKeyBoardAndMouseActions instance)
        {
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
        }

        public void RemoveCallbacks(IKeyBoardAndMouseActions instance)
        {
            if (m_Wrapper.m_KeyBoardAndMouseActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IKeyBoardAndMouseActions instance)
        {
            foreach (var item in m_Wrapper.m_KeyBoardAndMouseActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_KeyBoardAndMouseActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public KeyBoardAndMouseActions @KeyBoardAndMouse => new KeyBoardAndMouseActions(this);
    public interface IKeyBoardAndMouseActions
    {
        void OnAttack(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
