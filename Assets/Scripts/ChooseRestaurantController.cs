using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRestaurantController : MonoBehaviour {

    public Color highlightedColor;

    public GameObject restaurantItemPrefab;
    public Transform content;
    public List<GameObject> listOfRestaurantItems = new List<GameObject>();
    public GameObject addRestaurant;


    public int currentChoosedItem = 0;

    public bool axesUsed;
    public bool dialogWindowOpened;

    private RestaurantList restaurants = new RestaurantList();
    public DialogContainer dialogContainer;
	// Use this for initialization
	void Start () {
        restaurants = FileManager.ReadAllRestaurants();
        for (int i = 0; i < restaurants.Restaurants.Count; i++)
        {
            GameObject go = Instantiate(restaurantItemPrefab, content);
            go.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1f - 0.2f * (i + 1));
            go.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1f - 0.2f * (i));
            go.GetComponent<RestaurantItem>().CreateItem(i, restaurants.Restaurants[i].Name, restaurants.Restaurants[i].Date);
            listOfRestaurantItems.Add(go);
        }
        ChangeChoosedItem();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Vertical") > 0 && !axesUsed && !dialogWindowOpened)
        {
            OnUpScroll();
        }
        else if (Input.GetAxisRaw("Vertical") < 0 && !axesUsed && !dialogWindowOpened)
        {
            OnDownScroll();
        }
        else if (Input.GetAxisRaw("Cancel") > 0 && !axesUsed)
        {
            BackButtonPressed();
        }
        else if (Input.GetAxisRaw("Submit") > 0 && !axesUsed && !dialogWindowOpened)
        {
            SubmitButtonPressed();
        }
        else if(Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Cancel") == 0)
        {
            axesUsed = false;
        }
	}

    void OnUpScroll()
    {
        if (listOfRestaurantItems.Count > 0 && currentChoosedItem > 0)
        {
            currentChoosedItem--;
        }
        else if (currentChoosedItem == 0)
        {
            currentChoosedItem = listOfRestaurantItems.Count;
        }
        ChangeChoosedItem();
        axesUsed = true;
    }

    void OnDownScroll()
    {
        if (listOfRestaurantItems.Count > 0 && currentChoosedItem < listOfRestaurantItems.Count)
        {
            currentChoosedItem++;
        }
        else if (currentChoosedItem == listOfRestaurantItems.Count)
        {
            currentChoosedItem = 0;
        }
        ChangeChoosedItem();
        axesUsed = true;
    }

    void ChangeChoosedItem()
    {
        Clear();
        ScrollRect.Scroll(listOfRestaurantItems, currentChoosedItem, 5);
        if (currentChoosedItem == 0)
        {
            addRestaurant.GetComponent<Image>().color = highlightedColor;
        }
        else
        {
            listOfRestaurantItems[currentChoosedItem - 1].GetComponent<Image>().color = highlightedColor;
        }
    }

    void BackButtonPressed()
    {
        if (dialogWindowOpened)
        {
            CloseDialogWindow();
        }
        else
        {
            SceneLoader.LoadSceneAsync(0);
        }
        axesUsed = true;
    }
    
    void CloseDialogWindow()
    {
        dialogContainer.CloseDialogs();
        dialogWindowOpened = false;
    }

    void Clear()
    {
        foreach (var item in listOfRestaurantItems)
        {
            item.GetComponent<Image>().color = new Color(255, 255, 255);
        }
        addRestaurant.GetComponent<Image>().color = new Color(255, 255, 255);
    }

    void SubmitButtonPressed()
    {
        dialogWindowOpened = true;
        if(currentChoosedItem == 0)
        {
            dialogContainer.ShowDialog(0);
        }
        else
        {

        }
        axesUsed = false;
    }

}
