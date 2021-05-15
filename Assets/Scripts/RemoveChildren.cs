using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveChildren : MonoBehaviour
{
    void Awake()
    {
        transform.DetachChildren();
    }

}
