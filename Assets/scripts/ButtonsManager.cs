using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class ButtonsManager : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
{
    public Dialog dialog;
    public Inventory inventoryManager;
    private int inventoryCount;
    private int cost;

    //public Button OTone;
    //public Button OTsecond;
    //public Button OT3;
    //public Button OT4;
    // Start is called before the first frame update
    void Start()
    {
        //OTone = GetComponent<Button>();
        //OTone.onClick.AddListener(handleOT);
        //OTsecond = GetComponent<Button>();
        //OTsecond.onClick.AddListener(handleOT);
        //OT3 = GetComponent<Button>();
        //OT3.onClick.AddListener(handleOT);
        //OT4 = GetComponent<Button>();
        //OT4.onClick.AddListener(handleOT);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            //Debug.Log("Mouse Over: " + eventData.pointerCurrentRaycast.gameObject.tag);
            if (eventData.pointerCurrentRaycast.gameObject.tag == "OTButton")
            {
                string[] text = { "this will const you 3 irons !" };
                dialog.changeTheDialog(text);
            }
            if (eventData.pointerCurrentRaycast.gameObject.tag == "RedFire")
            {
                string[] text = { "this will const you 5 irons !" };
                dialog.changeTheDialog(text);
            }
            if (eventData.pointerCurrentRaycast.gameObject.tag == "PF")
            {
                string[] text = { "this will const you 7 irons !" };
                dialog.changeTheDialog(text);
            }
        }
        
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exit");
    }

    public void handleOT()
    {
        int ironCount = inventoryManager.itemCount();
        print(ironCount);
        if (ironCount >= 3)
        {
            inventoryManager.GiveAnItem(3);
            print("item added");

            for (int i = 0; i <= 3; i++)
            {
                inventoryManager.RemovItem(1);
               
            }
            string[] text = { "you got it" };
            dialog.changeTheDialog(text);
        }
        else
        {
            string[] text = { "you don't have enough iron, get out!!" };
            dialog.changeTheDialog(text);
        }
    }
  

}
