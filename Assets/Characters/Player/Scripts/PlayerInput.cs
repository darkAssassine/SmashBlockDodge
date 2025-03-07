using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float MovementAxis { get; private set; }
    public bool Jump { get; private set; }
    public bool Down { get; private set; }
    public bool Dogde { get; private set; }
    public Vector2 AttackDir { get; private set; }
    public bool Attack { get; private set; }
    public bool Interact { get; private set; }

    [SerializeField, Header("InputAction")]
    private InputActionAsset playerActionAsset;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction downAction;
    private InputAction dogdeAction;
    private InputAction attackDirAction;
    private InputAction attackAction;
    private InputAction interactAction;

    private void Awake()
    {
        InputActionMap inputActionMap = playerActionAsset.FindActionMap("Base");

        moveAction = inputActionMap.FindAction("Movement");
        jumpAction = inputActionMap.FindAction("Jump");
        downAction = inputActionMap.FindAction("Down");
        dogdeAction = inputActionMap.FindAction("Dogde");
        attackDirAction = inputActionMap.FindAction("AttackDir");
        attackAction = inputActionMap.FindAction("Attack");
        interactAction = inputActionMap.FindAction("Interact");
    }

    private void Update()
    {
        EvaluateInputs();
    }

    private void EvaluateInputs()
    {
        MovementAxis = moveAction.ReadValue<float>();
        Jump = jumpAction.WasPressedThisFrame();
        Down = downAction.WasPressedThisFrame();
        Dogde = dogdeAction.WasPressedThisFrame();
        AttackDir = attackDirAction.ReadValue<Vector2>();
        Attack = attackAction.WasPressedThisFrame();
        Interact = interactAction.WasPressedThisFrame();
    }

    private void Start()
    {
        Enable();
    }

    private void OnDisable()
    {
        Disable();
    }

    private void Disable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        downAction.Disable();
        dogdeAction.Disable();
        attackAction.Disable();
        attackDirAction.Disable();
        interactAction.Disable();
    }

    private void Enable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        downAction.Enable();
        dogdeAction.Enable();
        attackAction.Enable();
        attackDirAction.Enable();
        interactAction.Enable();
    }
}
