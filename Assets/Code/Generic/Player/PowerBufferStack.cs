using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Power Buffer", menuName = "Scriptable Objects/Player/Power Buffer Stack")]
public class PowerBufferStack : ScriptableObject // IPowerBuffer
{
    [SerializeField] private GenericPower defaultPower;

    private Stack<GenericPower> powerBuffer;
    public int maxSize;


    // Start is called before the first frame update
    private void OnEnable()
    {
        powerBuffer = new Stack<GenericPower>();
    }

    public void RemoveAllPowers()
    {
        powerBuffer.Clear();
    }

    public GenericPower[] ToArray()
    {
        return powerBuffer.ToArray();
    }

    public void AddPower(GenericPower newPower)
    {
        if(powerBuffer.Count < maxSize)
        {
            powerBuffer.Push(newPower);
        }
    }

    public GenericPower UsePower()
    {
        if(powerBuffer.Count == 0)
        {
            return defaultPower;
        }
        else
        {
            return powerBuffer.Pop();
        }
    }
}
