using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Basic Projectile", menuName ="Scriptable Objects/Powers/Basic Projectile")]
public class BasicProjectile : ScriptableObject
{
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    public float playerUseTime;

    [SerializeField]
    private float startDistance;

    public void Shoot(Vector2 userStartPos, Vector2 userDirection, Animator userAnimator=null, Rigidbody2D userRigidbody2D = null)
    {
        float facingRotation = Mathf.Atan2(userDirection.y, userDirection.x) * Mathf.Rad2Deg;

        GameObject newProjectile = Instantiate(projectile, userStartPos + userDirection * startDistance, Quaternion.Euler(0f, 0f, facingRotation));

        GenericProjectileMovement temp = newProjectile.GetComponent<GenericProjectileMovement>();
        if(temp)
        {
            temp.Setup(userDirection);
        }
    }
}
