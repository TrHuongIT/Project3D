using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController characterController;
    private float moveSpeed = 5f;
    private Vector3 movePosition;

    private bool isGround;
    private Vector3 fallDirection;
    private float gravity = -9.8f;
    private float jumpPower = 5f;

    public Camera cam;
    private float rotX = 0f;
    private float sensitivyX = 70f;
    private float sensitivyY = 70f;

    private bool isSprint;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        movePosition = Vector3.zero;
        fallDirection = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = characterController.isGrounded;
    }

    public void Move(Vector2 input)
    {
        movePosition.x = input.x;
        movePosition.z = input.y;

        characterController.Move(transform.TransformDirection(movePosition) * moveSpeed * Time.deltaTime);

        if(isGround && fallDirection.y < 0)
        {
            fallDirection.y = -2f;
        }

        fallDirection.y += gravity * Time.deltaTime;

        characterController.Move(fallDirection * Time.deltaTime);

    }

    public void Jump()
    {
        if (isGround)
        {
            fallDirection.y = jumpPower;
        }
    }

    public void Look(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        rotX -= mouseY * sensitivyY * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, -85f, 85f);
        cam.transform.localRotation = Quaternion.Euler(rotX, 0f, 0f);


        transform.Rotate(Vector3.up * mouseX * sensitivyX * Time.deltaTime);

    }

    public void Sprint()
    {
        isSprint = !isSprint;
        if (isSprint)
        {
            moveSpeed = 10f;
        } else
        {
            moveSpeed = 5f;
        }
    }
}
