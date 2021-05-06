// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/InputPlayer.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputPlayer : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputPlayer()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputPlayer"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""87987f31-add6-4a09-b415-ed76b5391ca7"",
            ""actions"": [
                {
                    ""name"": ""MovementLeftRight"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3fc05b21-10cb-42c5-ac0e-cc5cc952e075"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""5ef2a5f9-ed7c-4a52-be27-4995c789c5de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0a3c4116-7c5a-4fe6-a6b7-b3e88f349c4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4a721fa7-2bec-4eb5-95bd-351ee503c75a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GrabWall"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d9722d6c-7104-4df8-a97d-c47510210bd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d5200e8b-bd8c-4e39-ae69-b1768c46302b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwapWeapon"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cfc62462-06c6-4fd6-8baf-0e8eea1768e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""923db5a3-3b0b-4b30-b3f6-3d1a6253eb91"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementLeftRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0a6e13fc-8d23-44b0-a3a4-b84259ad17bf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""MovementLeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f5478a52-7fca-4ab2-95a5-21413c97c254"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""MovementLeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""cb6db547-c1ab-4b2f-83c8-d5cf3ccb673e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementLeftRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c6c2d37e-b5f2-431a-ae8b-206c3e665e39"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""MovementLeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a723dcb5-e165-42a6-ba4c-a331327a705d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""MovementLeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""16d26cde-6cde-43b2-9406-79cd2a2defd5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36c70b1b-6e41-4d64-89a6-f3cd90bb9380"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""969fd704-6218-454b-817f-73151ff163dd"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""552e9838-293e-44ea-8485-97c71f72a415"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bab870b-a719-4b53-bf15-62edc4117fc9"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f04c299-11de-498a-a9e2-19ca91cc29cd"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97685ed7-1708-454c-b0a4-7b86f40785e2"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""GrabWall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93862273-be7c-4054-8bb6-0e80d1b54d2f"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""GrabWall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd4832eb-bebd-469e-9de9-5f05563ee073"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5cd09228-2012-43be-85d2-8f16b9fab006"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b082374-0be4-4737-95a6-6801ca5b680a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""SwapWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6554fd18-2aa9-4957-8b9a-4a0b3259abf3"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""SwapWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PlayerScheme"",
            ""bindingGroup"": ""PlayerScheme"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MovementLeftRight = m_Player.FindAction("MovementLeftRight", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
        m_Player_Melee = m_Player.FindAction("Melee", throwIfNotFound: true);
        m_Player_GrabWall = m_Player.FindAction("GrabWall", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_SwapWeapon = m_Player.FindAction("SwapWeapon", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_MovementLeftRight;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Shoot;
    private readonly InputAction m_Player_Melee;
    private readonly InputAction m_Player_GrabWall;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_SwapWeapon;
    public struct PlayerActions
    {
        private @InputPlayer m_Wrapper;
        public PlayerActions(@InputPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementLeftRight => m_Wrapper.m_Player_MovementLeftRight;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
        public InputAction @Melee => m_Wrapper.m_Player_Melee;
        public InputAction @GrabWall => m_Wrapper.m_Player_GrabWall;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @SwapWeapon => m_Wrapper.m_Player_SwapWeapon;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MovementLeftRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementLeftRight;
                @MovementLeftRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementLeftRight;
                @MovementLeftRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementLeftRight;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Melee.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee;
                @Melee.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee;
                @Melee.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee;
                @GrabWall.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabWall;
                @GrabWall.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabWall;
                @GrabWall.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabWall;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @SwapWeapon.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon;
                @SwapWeapon.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon;
                @SwapWeapon.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementLeftRight.started += instance.OnMovementLeftRight;
                @MovementLeftRight.performed += instance.OnMovementLeftRight;
                @MovementLeftRight.canceled += instance.OnMovementLeftRight;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Melee.started += instance.OnMelee;
                @Melee.performed += instance.OnMelee;
                @Melee.canceled += instance.OnMelee;
                @GrabWall.started += instance.OnGrabWall;
                @GrabWall.performed += instance.OnGrabWall;
                @GrabWall.canceled += instance.OnGrabWall;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @SwapWeapon.started += instance.OnSwapWeapon;
                @SwapWeapon.performed += instance.OnSwapWeapon;
                @SwapWeapon.canceled += instance.OnSwapWeapon;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_PlayerSchemeSchemeIndex = -1;
    public InputControlScheme PlayerSchemeScheme
    {
        get
        {
            if (m_PlayerSchemeSchemeIndex == -1) m_PlayerSchemeSchemeIndex = asset.FindControlSchemeIndex("PlayerScheme");
            return asset.controlSchemes[m_PlayerSchemeSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovementLeftRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
        void OnGrabWall(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnSwapWeapon(InputAction.CallbackContext context);
    }
}
