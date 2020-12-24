using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class CollideReaction : MonoBehaviour
{
    public List<Tag> reactionList;

    public UnityEvent reactEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckForReaction(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckForReaction(other);
    }

    private void CheckForReaction(Collider2D other)
    {
        Tags otherTags = other.gameObject.GetComponent<Tags>();

        if (otherTags && otherTags.tags.Any(item => reactionList.Contains(item)))
        {
            reactEvent.Invoke();
        }
    }
}
