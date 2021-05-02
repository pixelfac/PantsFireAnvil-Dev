using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ToLevel1 : MonoBehaviour
{
    public void ToLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }
}
