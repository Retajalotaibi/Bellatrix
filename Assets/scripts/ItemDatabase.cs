using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string title)
    {
        return items.Find(item => item.title == title);
    }


    private void Awake()
    {
        BuildDatabase();
    }




    void BuildDatabase()
    {
        items = new List<Item>()
        {
        new Item(0, 1, "Metal heart", "A piece that will help the player moving", new Dictionary<string, int> {{"Value", 50} }),
        new Item(1, 1, "Iron", "Take this to the shop!", new Dictionary<string, int> { { "Value", 10 } }),
        new Item(2, 1, "Crystals", "Crystals helps to upgrade your weapons", new Dictionary<string, int> { { "Value", 15 } }),
        new Item(3, 1, "Oxygen tank", "Air capsules that Increases health", new Dictionary<string, int> { { "Value", 25 } }),
        new Item(4, 1, "Thunder glove", "Shoots an arrow that is filled with electricity", new Dictionary<string, int> { { "power", 10 } })};
    }

}
