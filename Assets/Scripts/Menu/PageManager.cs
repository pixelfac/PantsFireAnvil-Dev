using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Managers the different Canvas Pages in How To Play
public class PageManager : MonoBehaviour
{
    [SerializeField] GameObject[] pages;

    int currentPageIndex;

    void Start()
    {
        currentPageIndex = 0;

        ChangePage(currentPageIndex);
    }

    void ChangePage(int pageIndex)
	{
        Debug.Log("currentPage: " + currentPageIndex);

        for (int i=0; i < pages.Length; i++)
		{
            if (i == pageIndex)
			{
                pages[i].SetActive(true);
                Debug.Log("enable page " + i);
			}
            else
			{
                pages[i].SetActive(false);
                Debug.Log("disable page " + i);
			}
		}
	}

    public void NextPage()
	{
        currentPageIndex++;

        ChangePage(currentPageIndex);
	}

    public void PrevPage()
	{
        currentPageIndex--;

        ChangePage(currentPageIndex);
	}
}
