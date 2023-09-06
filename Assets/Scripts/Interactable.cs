using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string infor;

    private void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {

    }
}
