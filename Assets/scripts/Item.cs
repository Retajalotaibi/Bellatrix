using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public int id;
    public int count;
    public string title;
    public string description;
    public Sprite image;
    public Dictionary<string, int> status = new Dictionary<string, int>();

    public Item(int id,int count, string title, string description, Dictionary<string , int>status)
    {
        this.id = id;
        this.count = count;
        this.title = title;
        this.description = description;
        this.image = Resources.Load<Sprite>("Sprite/Item" + title);
        this.status = status;
    }
    public Item(Item item)
    {
        this.id = item.id;
        this.count = item.count;
        this.title = item.title;
        this.description = item.description;
        this.image = Resources.Load<Sprite>("Sprite/Item" + title);
        this.status = item.status;
    }
}
