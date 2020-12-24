using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent PickupEvent;
    
    public void Interact()
    {
        PickupEvent.Invoke();
    }

    public float GetPriority()
    {
        return 0;
    }
}