using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int gameCoin = 0;
    public GameObject targetUI;
    public Text targetText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GetCoin(int value)
    {
        gameCoin += value;
        targetText.text = gameCoin.ToString();
        if (gameCoin >= 3)
        {
            targetUI.SetActive(true);
        }
    }

}
