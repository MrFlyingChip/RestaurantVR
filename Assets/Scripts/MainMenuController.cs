using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public bool axesUsed;
    public List<GameObject> menuItems;
    public int currentMenuItem;

    public Color normalColor;
    public Color highlightedColor;

    private void Start()
    {
        ChangeChoosedItem();
    }

    public void OnChooseRestaurantButtonPressed()
    {
        SceneLoader.LoadSceneAsync(1);
    }

	public void OnExitButtonPressed()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0 && !axesUsed)
        {
            OnUpScroll();
        }
        else if (Input.GetAxisRaw("Vertical") < 0 && !axesUsed)
        {
            OnDownScroll();
        }
        else if (Input.GetAxisRaw("Submit") > 0 && !axesUsed)
        {
            OnSubmitButtonClicked();
        }
        else if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Submit") == 0)
        {
            axesUsed = false;
        }
    }

    void OnSubmitButtonClicked()
    {
        menuItems[currentMenuItem].GetComponent<Button>().onClick.Invoke();
        axesUsed = true;
    }

    void OnUpScroll()
    {
        if (currentMenuItem == 0)
        {
            currentMenuItem = menuItems.Count - 1;
        }
        else
        {
            currentMenuItem--;
        }
        ChangeChoosedItem();
        axesUsed = true;
    }

    void OnDownScroll()
    {
        if (currentMenuItem == (menuItems.Count - 1))
        {
            currentMenuItem = 0;
        }
        else
        {
            currentMenuItem++;
        }
        ChangeChoosedItem();
        axesUsed = true;
    }

    void ChangeChoosedItem()
    {
        Clear();
        menuItems[currentMenuItem].GetComponent<Image>().color = highlightedColor;
    }

    void Clear()
    {
        foreach (var item in menuItems)
        {
            item.GetComponent<Image>().color = normalColor;
        }
    }
}
