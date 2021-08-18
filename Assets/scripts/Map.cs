using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    public void ChangeToShopScene()
    {
        print("shop");
        SceneManager.LoadScene(12);
    }

    public void changeToBoss()
    {
        print("boss");
        SceneManager.LoadScene(11);
    }
}
