using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public bool Alive = true;

    public void Set(bool param)
    {
        Alive = param;
    }

    public bool Get()
    {
        return Alive;
    }
}
