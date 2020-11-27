using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GenericProjectileMovement : MonoBehaviour
{
    [SerializeField] // TODO why do i need this?
    private Rigidbody2D myRigidbody2D;

    [SerializeField] // TODO why do i need this?
    private float mySpeed;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Setup(Vector2 moveDirection)
    {
        myRigidbody2D.velocity = moveDirection.normalized * mySpeed;
    }
}
