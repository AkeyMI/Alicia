using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button openMenu = default;
    [SerializeField] Button closeMenu = default;
    [SerializeField] Button exit = default;
    [SerializeField] Button backToMenu = default;
    [SerializeField] Button nextPage = default;
    [SerializeField] Button lastPage = default;

    [SerializeField] GameObject menu = default;

    [SerializeField] GameObject[] pages = default;

    private int currentPage = 0;

    private void Start()
    {
        openMenu.onClick.AddListener(OpenMenu);
        closeMenu.onClick.AddListener(CloseMenu);
        nextPage.onClick.AddListener(NextPage);
        lastPage.onClick.AddListener(LastPage);
    }

    public void OpenMenu()
    {
        menu.SetActive(false);
        openMenu.gameObject.SetActive(false);
        pages[currentPage].SetActive(true);
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        openMenu.gameObject.SetActive(true);
        currentPage = 0;
    }

    public void NextPage()
    {
        lastPage.gameObject.SetActive(true);

        pages[currentPage].SetActive(false);

        currentPage++;

        pages[currentPage].SetActive(true);

        if(currentPage > pages.Length)
        {
            nextPage.gameObject.SetActive(false);
        }
    }

    public void LastPage()
    {
        nextPage.gameObject.SetActive(true);

        pages[currentPage].SetActive(false);

        currentPage--;

        pages[currentPage].SetActive(true);

        if (currentPage < pages.Length)
        {
            lastPage.gameObject.SetActive(false);
        }
    }
}
