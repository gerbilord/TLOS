using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToggleSource : GenericSource
{
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && this.gameObject.GetComponent<BinaryAnimation>().isActive)
        {
            SetPriority(other);
            interactableList.Add(this);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetPriority(other);
            if (this.gameObject.GetComponent<BinaryAnimation>().isActive)
            {
                interactableList.Add(this);
            }
            else
            {
                interactableList.Remove(this);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactableList.Remove(this);
        }
    }
}
