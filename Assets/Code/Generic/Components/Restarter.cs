using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    public InteractableList things;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown("r"))
        { //If you press R
            things.items = new List<Interactable>(); // BAD CODE
            SceneManager.LoadScene("SampleScene"); //Load scene called Game
        }
    }
}
