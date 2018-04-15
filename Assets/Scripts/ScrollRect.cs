using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRect : MonoBehaviour {

	public static void Scroll(List<GameObject> listOfRestaurantItems, int currentChoosedItem, int maxItems)
    {
        float upEdge = 1f;
        if (currentChoosedItem > maxItems)
        {
            upEdge = 1f + (1f / maxItems) * (currentChoosedItem - maxItems);
        }
        for (int i = 0; i < listOfRestaurantItems.Count; i++)
        {    
            listOfRestaurantItems[i].GetComponent<RectTransform>().anchorMin = new Vector2(0, upEdge - 0.2f * (i + 1));
            listOfRestaurantItems[i].GetComponent<RectTransform>().anchorMax = new Vector2(1, upEdge - 0.2f * (i));
        }
    }
}
