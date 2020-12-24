using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class DestroyOnCollide : MonoBehaviour
{
    public List<Tag> thingsThatDestroyMe;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Tags otherTags = other.gameObject.GetComponent<Tags>();

        if (otherTags && otherTags.tags.Any(item => thingsThatDestroyMe.Contains(item)))
        {
            Destroy(this.gameObject);
        }
    }
}
