using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class UIInventory : MonoBehaviour
{
    public TextMeshProUGUI inventoryText;
    private int index;
    //z   public Inventory inventory;
    private List<string> sentences = new List<string>();
    string text = "";
    // Start is called before the first frame update
    void Start()
    {
        /// updateUI(inventory.GetTheArray());
        StartTyping();
    }

    public void updateUI(List<Item> items)
    {
        text = "";
        sentences.Clear();
        inventoryText.text = "";
        foreach (Item item in items)
        {
            text += item.count + "- " + item.title + "\n";
        }
        sentences.Add(text);
        StartTyping();
    }
    public void StartTyping()
    {
        StartCoroutine(Type());
    }


    IEnumerator Type()
    {
        if (sentences.Count != 0)
        {
            foreach (char letter in sentences[sentences.Count - 1].ToCharArray())
            {
                inventoryText.text += letter;
                yield return new WaitForSeconds(0.02f);
            }

        }
    }
}
