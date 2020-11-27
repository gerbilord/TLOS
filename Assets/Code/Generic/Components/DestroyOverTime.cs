using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField]
    private float destroyDelay;


    // Update is called once per frame
    void FixedUpdate()
    {
        destroyDelay -= Time.fixedDeltaTime;
        if(destroyDelay <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
