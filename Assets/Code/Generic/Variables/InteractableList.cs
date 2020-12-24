using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Interactable List", menuName = "Scriptable Objects/Items/Interactable List")]
public class InteractableList : ScriptableObject
{
    public List<Interactable> items = new List<Interactable>();

    private void OnEnable()
    {
        items = new List<Interactable>();
    }
    public void Add(Interactable i)
    {
        if (!items.Contains(i)) items.Add(i);
    }

    public void Remove(Interactable i)
    {
        if (items.Contains(i)) items.Remove(i);
    }
}
