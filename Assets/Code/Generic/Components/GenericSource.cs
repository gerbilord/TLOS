using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericSource : Interactable
{
    protected float priority;
    protected Collider2D myBoxCollider;

    public InteractableList interactableList;

    private void Awake()
    {
        myBoxCollider = GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SetPriority(other);
            if(this.gameObject.activeSelf && this.gameObject.activeInHierarchy)
            {
                interactableList.Add(this);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            interactableList.Remove(this);
        }
    }

    private void OnDestroy()
    {
        interactableList.Remove(this);
    }

    private void OnDisable()
    {
        interactableList.Remove(this);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetPriority(other);
        }
    }
    protected void SetPriority(Collider2D other)
    {
        priority = Vector3.Distance(myBoxCollider.bounds.center, other.bounds.center);
    }

    public new float GetPriority()
    {
        return priority;
    }
}
