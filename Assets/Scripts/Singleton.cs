using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//where contrains the type of T so we can use "as" later
public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    [SerializeField] protected bool dontDestroyOnLoad = true;
    static T instance;

    public static T Instance
    {
        //gets a value for 'instance'
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                //if GameObject doesn't exist, make one
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        //if no instance exists, make this the instance
        //else Destroy
        if (instance == null)
        {
            instance = this as T;
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
