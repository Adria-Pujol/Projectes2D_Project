// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Enemies/Boss/BossInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @BossInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @BossInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BossInput"",
    ""maps"": [
        {
            ""name"": ""BossMap"",
            ""id"": ""d2bb3745-9553-4999-8b5d-42aac6db7020"",
            ""actions"": [
                {
                    ""name"": ""Attack1"",
                    ""type"": ""PassThrough"",
                    ""id"": ""dde44b04-f9fb-47eb-b114-397dc828dd0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack2"",
                    ""type"": ""PassThrough"",
                    ""id"": ""95424648-fa6e-465f-868b-6df8d084414a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack3"",
                    ""type"": ""PassThrough"",
                    ""id"": ""37e8cfe8-658d-4611-9cdf-17b210d28def"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Enrage"",
                    ""type"": ""PassThrough"",
                    ""id"": ""51bd912b-aeb2-4b9e-bea6-9c72b65ded52"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3e82f855-6b24-4353-b82b-08226f1dda91"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e19b399-1af5-4721-a81a-c1c28730c3c1"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e93e3877-6286-4038-a77c-5e551956a039"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5338867-0665-40cb-bd4d-244718835273"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enrage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // BossMap
        m_BossMap = asset.FindActionMap("BossMap", throwIfNotFound: true);
        m_BossMap_Attack1 = m_BossMap.FindAction("Attack1", throwIfNotFound: true);
        m_BossMap_Attack2 = m_BossMap.FindAction("Attack2", throwIfNotFound: true);
        m_BossMap_Attack3 = m_BossMap.FindAction("Attack3", throwIfNotFound: true);
        m_BossMap_Enrage = m_BossMap.FindAction("Enrage", throwIfNotFound: true);
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

    // BossMap
    private readonly InputActionMap m_BossMap;
    private IBossMapActions m_BossMapActionsCallbackInterface;
    private readonly InputAction m_BossMap_Attack1;
    private readonly InputAction m_BossMap_Attack2;
    private readonly InputAction m_BossMap_Attack3;
    private readonly InputAction m_BossMap_Enrage;
    public struct BossMapActions
    {
        private @BossInput m_Wrapper;
        public BossMapActions(@BossInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack1 => m_Wrapper.m_BossMap_Attack1;
        public InputAction @Attack2 => m_Wrapper.m_BossMap_Attack2;
        public InputAction @Attack3 => m_Wrapper.m_BossMap_Attack3;
        public InputAction @Enrage => m_Wrapper.m_BossMap_Enrage;
        public InputActionMap Get() { return m_Wrapper.m_BossMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BossMapActions set) { return set.Get(); }
        public void SetCallbacks(IBossMapActions instance)
        {
            if (m_Wrapper.m_BossMapActionsCallbackInterface != null)
            {
                @Attack1.started -= m_Wrapper.m_BossMapActionsCallbackInterface.OnAttack1;
                @Attack1.performed -= m_Wrapper.m_BossMapActionsCallbackInterface.OnAttack1;
                @Attack1.canceled -= m_Wrapper.m_BossMapActionsCallbackInterface.OnAttack1;
                @Attack2.started -= m_Wrapper.m_BossMapActionsCallbackInterface.OnAttack2;
                @Attack2.performed -= m_Wrapper.m_BossMapActionsCallbackInterface.OnAttack2;
                @Attack2.canceled -= m_Wrapper.m_BossMapActionsCallbackInterface.OnAttack2;
                @Attack3.started -= m_Wrapper.m_BossMapActionsCallbackInterface.OnAttack3;
                @Attack3.performed -= m_Wrapper.m_BossMapActionsCallbackInterface.OnAttack3;
                @Attack3.canceled -= m_Wrapper.m_BossMapActionsCallbackInterface.OnAttack3;
                @Enrage.started -= m_Wrapper.m_BossMapActionsCallbackInterface.OnEnrage;
                @Enrage.performed -= m_Wrapper.m_BossMapActionsCallbackInterface.OnEnrage;
                @Enrage.canceled -= m_Wrapper.m_BossMapActionsCallbackInterface.OnEnrage;
            }
            m_Wrapper.m_BossMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attack1.started += instance.OnAttack1;
                @Attack1.performed += instance.OnAttack1;
                @Attack1.canceled += instance.OnAttack1;
                @Attack2.started += instance.OnAttack2;
                @Attack2.performed += instance.OnAttack2;
                @Attack2.canceled += instance.OnAttack2;
                @Attack3.started += instance.OnAttack3;
                @Attack3.performed += instance.OnAttack3;
                @Attack3.canceled += instance.OnAttack3;
                @Enrage.started += instance.OnEnrage;
                @Enrage.performed += instance.OnEnrage;
                @Enrage.canceled += instance.OnEnrage;
            }
        }
    }
    public BossMapActions @BossMap => new BossMapActions(this);
    public interface IBossMapActions
    {
        void OnAttack1(InputAction.CallbackContext context);
        void OnAttack2(InputAction.CallbackContext context);
        void OnAttack3(InputAction.CallbackContext context);
        void OnEnrage(InputAction.CallbackContext context);
    }
}
