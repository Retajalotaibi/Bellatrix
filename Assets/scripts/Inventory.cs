using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    static protected List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;
    public UIInventory uIInventory;
    // needed methods
    public void GiveAnItem(int id)
    {
        print("added");
        Item itemToAdd = itemDatabase.GetItem(id);
        Item existingItem = CheckForItem(id);
        if (existingItem != null)
        {
            int index = characterItems.IndexOf(existingItem);
            characterItems[index].count++;
        }
        else
        {
            characterItems.Add(itemToAdd);
        }
        uIInventory.updateUI(characterItems);
    }

    public Item CheckForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }
    public Item CheckForItem(string name)
    {
        return characterItems.Find(item => item.title == name);
    }

    public void RemovItem(int id)
    {
        Item item = CheckForItem(id);
        if (item != null)
        {
            characterItems.Remove(item);
        }

    }
    public List<Item> GetTheArray()
    {
        return characterItems;
    }
    public int itemCount()
    {
        Item item = CheckForItem(1);
        if (item != null)
         {
            return item.count;
        }
        return 0;

    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }
}
