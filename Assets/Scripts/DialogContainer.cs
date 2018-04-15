using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogContainer : MonoBehaviour {

    public List<GameObject> dialogs;
    public GameObject backscreen;

    public bool axesUsed;

    public ChooseRestaurantController controller;

    public void ShowDialog(int dialog)
    {
        backscreen.SetActive(true);
        dialogs[dialog].SetActive(true);
    }

    private void Update()
    {
       
    }

    public void CloseDialogs()
    {
        backscreen.SetActive(false);
        foreach (var item in dialogs)
        {
            item.SetActive(false);
        }      
    }
}
