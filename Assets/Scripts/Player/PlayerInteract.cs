using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _camera;
    private float maxDistanceCanInteract = 5f;
    private bool canInteract;
    [SerializeField] private LayerMask maskItem;

    private PlayerUI playerUI;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<PlayerMove>().cam;
        playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * maxDistanceCanInteract, Color.red);

        canInteract = Physics.Raycast(ray, out RaycastHit hitInfor, maxDistanceCanInteract, maskItem);
        if (canInteract)
        {
            Interactable interactable = hitInfor.collider.GetComponent<Interactable>();
            playerUI.UpdateText(interactable.infor);
        }


    }
}
