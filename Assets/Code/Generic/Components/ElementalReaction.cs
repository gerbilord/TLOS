using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class ElementalReaction : MonoBehaviour
{
    public List<ElementalEffect> reactionList;

    public UnityEvent reactEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ElementalType otherTypes = other.gameObject.GetComponent<ElementalType>();

        if (otherTypes && otherTypes.elementalEffects.Any(item => reactionList.Contains(item)))
        {
            reactEvent.Invoke();
        }
    }
}
