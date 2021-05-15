using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveChildren : MonoBehaviour
{
    void Awake()
    {
        //unparents all children
        //then kills itself
        transform.DetachChildren();
        Destroy(gameObject);
    }

}
