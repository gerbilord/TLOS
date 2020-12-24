using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    [SerializeField] public InteractableList interactables;

    public void Update()
    {
        if(Input.GetButtonDown("Fire3") && interactables.items.Count > 0)
        {
            Interactable lowestPrioInteractable = interactables.items[0];
            for (int i = interactables.items.Count - 1; i >= 0; i--)
            {
                if(interactables.items[i].GetPriority() < lowestPrioInteractable.GetPriority())
                {
                    lowestPrioInteractable = interactables.items[i];
                }
            }
            lowestPrioInteractable.Interact();
        }
    }
}
