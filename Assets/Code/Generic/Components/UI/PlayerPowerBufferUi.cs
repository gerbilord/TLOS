using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPowerBufferUi : MonoBehaviour
{
    public Image[] elements; // replace this system yuck
    public Sprite fire;
    public PowerBufferStack powers;

    // Start is called before the first frame update
    void Start()
    {
        EraseUi();
    }

    private void EraseUi()
    {
        for( int i = 0; i < elements.Length; i++)
        {
            elements[i].gameObject.SetActive(false);
        }
    }

    private void Update() // DO WE NEED AN EVENT?!? WHY IS THERE NO EVENT JESUS.
    {
        EraseUi();
        for(int i = 0; i < powers.ToArray().Length; i++)
        {
            elements[i].gameObject.SetActive(true);
        }
    }

}
