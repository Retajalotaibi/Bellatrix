
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float typingSpeed;
    public GameObject continueBtn;
    private int index;
   

    private void Start()
    {
       
        StartCoroutine(Type());
    }

    private void Update()
    {
        if (textDisplay.text == sentences[index] && continueBtn.active)
        {
            continueBtn.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
                textDisplay.text += letter;
                yield return new WaitForSeconds(0.02f);
        }
    }

    public void NextSentence()
    {
        continueBtn.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());

        }
        else
        {
            textDisplay.text = "";
            continueBtn.SetActive(false);
        }

    }

    public void changeTheDialog(string[] newDialog)
    {
        if (textDisplay.text == sentences[index])
        {
            // clear the array 
            Array.Clear(sentences, 0, sentences.Length);
            sentences = newDialog;
            // set the text to an empty ""
            textDisplay.text = "";
            index = 0;
            StartCoroutine(Type());

        }

    }
    public void changeTheDialogShop(string[] newDialog)
    {

            print("kjksh");
            // clear the array 
            Array.Clear(sentences, 0, sentences.Length);
            sentences = newDialog;
            //// set the text to an empty ""
            //textDisplay.text = "";
            StartCoroutine(Type());
    }
}
