using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags : MonoBehaviour
{
    [SerializeField] public List<Tag> tags;

    public void Add(Tag tag)
    {
        if(!tags.Contains(tag))
        {
            tags.Add(tag);
        }
    }

    public void Remove(Tag tag)
    {
        if(tags.Contains(tag))
        {
            tags.Remove(tag);
        }
    }

    public bool Contains(Tag tag)
    {
        return tags.Contains(tag);
    }
}
