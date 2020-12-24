using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Generic Power", menuName = "Scriptable Objects/Powers/Generic Power")]
public class GenericPower : ScriptableObject
{
    [SerializeField]
    public BasicProjectile projectile;

    [SerializeField]
    public BasicProjectile melee;

}
