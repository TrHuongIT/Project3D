using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.BasicMoveActions playerMActions;

    private PlayerMove playerMove;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerMActions = playerInput.BasicMove;

        playerMove = GetComponent<PlayerMove>();

        playerMActions.Jump.performed += ctx => playerMove.Jump();
        playerMActions.Sprint.performed += ctx => playerMove.Sprint();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        playerMove.Move(playerMActions.Move.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        playerMove.Look(playerMActions.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerMActions.Enable();
    }

    private void OnDisable()
    {
        playerMActions.Disable();
    }
}
