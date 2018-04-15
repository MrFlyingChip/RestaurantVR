using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestaurantItem : MonoBehaviour {

    public int id;
    public Text RestaurantName;
    public Text RestaurantDate;

    public void CreateItem(int id, string restaurantName, string restaurantDate)
    {
        this.id = id;
        RestaurantName.text = restaurantName;
        RestaurantDate.text = restaurantDate;
    }
}
