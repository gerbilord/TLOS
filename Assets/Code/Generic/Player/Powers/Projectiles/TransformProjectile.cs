using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformProjectile : MonoBehaviour
{
    public BasicProjectile fireProjectile;
    public Tag fireTag;

    public BasicProjectile waterProjectile;
    public Tag waterTag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponentInChildren<Tags>().Contains(fireTag))
        {
            Destroy(this.gameObject);
            fireProjectile.Shoot(this.transform.position, this.GetComponentInChildren<Rigidbody2D>().velocity);
        }
        else if (collision.GetComponentInChildren<Tags>().Contains(waterTag))
        {
            Destroy(this.gameObject);
            waterProjectile.Shoot(this.transform.position, this.GetComponentInChildren<Rigidbody2D>().velocity);
        }
    }
}
