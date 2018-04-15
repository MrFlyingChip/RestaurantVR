using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BackgroundBehaviour : MonoBehaviour {

    public Sprite[] backgroundSprites;

	// Use this for initialization
	void Start () {
        LoadSprites();
    }
	
    private void LoadSprites()
    {
        backgroundSprites = Resources.LoadAll("Restaurants", typeof(Sprite)).Cast<Sprite>().ToArray();
    }

    public void ChangeSprite()
    {
        int index = Random.Range(0, backgroundSprites.Length);
        GetComponent<Image>().sprite = backgroundSprites[index];
    }

	// Update is called once per frame
	void Update () {
		
	}
}
