// GENERATED AUTOMATICALLY FROM 'Assets/Jons Stuff/Player/ControlScripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""532dbabf-1bb4-4b11-90c4-5af7641383b1"",
            ""actions"": [
                {
                    ""name"": ""Four Direction Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5b020c68-23e1-4bb9-bdd5-1b6e583a381a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseX"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d4f27db9-2767-4bb4-bc3d-9bfd099eb747"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0798c51e-1b79-49c2-9406-45de87f58488"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePos"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d0681d96-62c2-4082-be28-e9adc18d91cb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""23ee375f-2d7b-4912-bec1-f9716bdd5b0c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Four Direction Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6e440de2-eb6b-4f60-b0b4-ba4fbbaa1d7c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Four Direction Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f5218466-e0b4-4512-b820-a57b0a30947b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Four Direction Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""23a52ebf-e841-4f4c-a1d9-a7ea8320dc14"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Four Direction Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ef514b7c-2401-4b11-946b-b89ae850cdbc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Four Direction Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d093c695-9bf5-4816-81b5-23375f825b72"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b58e9cda-f967-4d9d-a254-76c118229f3d"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73e433ca-739c-4119-9d3e-6b8a4c408f64"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_FourDirectionMovement = m_Movement.FindAction("Four Direction Movement", throwIfNotFound: true);
        m_Movement_MouseX = m_Movement.FindAction("MouseX", throwIfNotFound: true);
        m_Movement_MouseY = m_Movement.FindAction("MouseY", throwIfNotFound: true);
        m_Movement_MousePos = m_Movement.FindAction("MousePos", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_FourDirectionMovement;
    private readonly InputAction m_Movement_MouseX;
    private readonly InputAction m_Movement_MouseY;
    private readonly InputAction m_Movement_MousePos;
    public struct MovementActions
    {
        private @PlayerControls m_Wrapper;
        public MovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @FourDirectionMovement => m_Wrapper.m_Movement_FourDirectionMovement;
        public InputAction @MouseX => m_Wrapper.m_Movement_MouseX;
        public InputAction @MouseY => m_Wrapper.m_Movement_MouseY;
        public InputAction @MousePos => m_Wrapper.m_Movement_MousePos;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @FourDirectionMovement.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnFourDirectionMovement;
                @FourDirectionMovement.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnFourDirectionMovement;
                @FourDirectionMovement.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnFourDirectionMovement;
                @MouseX.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseX;
                @MouseX.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseX;
                @MouseX.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseX;
                @MouseY.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseY;
                @MouseY.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseY;
                @MouseY.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseY;
                @MousePos.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMousePos;
                @MousePos.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMousePos;
                @MousePos.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMousePos;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @FourDirectionMovement.started += instance.OnFourDirectionMovement;
                @FourDirectionMovement.performed += instance.OnFourDirectionMovement;
                @FourDirectionMovement.canceled += instance.OnFourDirectionMovement;
                @MouseX.started += instance.OnMouseX;
                @MouseX.performed += instance.OnMouseX;
                @MouseX.canceled += instance.OnMouseX;
                @MouseY.started += instance.OnMouseY;
                @MouseY.performed += instance.OnMouseY;
                @MouseY.canceled += instance.OnMouseY;
                @MousePos.started += instance.OnMousePos;
                @MousePos.performed += instance.OnMousePos;
                @MousePos.canceled += instance.OnMousePos;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IMovementActions
    {
        void OnFourDirectionMovement(InputAction.CallbackContext context);
        void OnMouseX(InputAction.CallbackContext context);
        void OnMouseY(InputAction.CallbackContext context);
        void OnMousePos(InputAction.CallbackContext context);
    }
}
