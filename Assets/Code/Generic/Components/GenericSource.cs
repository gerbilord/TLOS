using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericSource : MonoBehaviour
{
    private bool playerInRange;
    public UnityEvent PickupEvent;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire3") && playerInRange)
        {
            this.transform.root.gameObject.SetActive(false); // TODO object pooling/destroy?
            PickupEvent.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
