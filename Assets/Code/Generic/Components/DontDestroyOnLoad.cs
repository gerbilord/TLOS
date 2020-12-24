using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public string tagName;
    private GameObject instance;

    // Update is called once p    private static Player instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this.gameObject;
            DontDestroyOnLoad(this.gameObject); // BAD CODE
            return;
        }
        Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag(tagName);
        if (musicObject.Length > 1)
        {
            for (int i = 1; i < musicObject.Length; i++)
            {
                Destroy(musicObject[i]);
            }
        }
    }
}
