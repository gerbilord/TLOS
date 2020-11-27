using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Power Queue", menuName = "Scriptable Objects/Player/Player Power Queue")]
public class PlayerPowerQueue : ScriptableObject
{
    [SerializeField] private GenericPower defaultPower;

    private List<GenericPower> powerQueue;
    public int maxSize;


    // Start is called before the first frame update
    void Start()
    {
        powerQueue = new List<GenericPower>();
    }

    public void AddPower(GenericPower newPower)
    {
        if(powerQueue.Count < maxSize)
        {
            powerQueue.Add(newPower);
        }
    }

    public GenericPower UsePower()
    {
        if(powerQueue.Count == 0)
        {
            return defaultPower;
        }
        else
        {
            GenericPower nextPower = powerQueue[powerQueue.Count - 1];
            powerQueue.RemoveAt(powerQueue.Count - 1);
            return nextPower;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
