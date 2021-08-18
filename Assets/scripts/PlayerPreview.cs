using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreview : MonoBehaviour
{
    public GameObject menu;
    public Inventory inventory;
    public UIInventory uIInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //uIInventory.updateUI(inventory.GetTheArray());
            menu.SetActive(!menu.active);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && menu.active)
        {
            uIInventory.updateUI(inventory.GetTheArray());
        }
    }
}
