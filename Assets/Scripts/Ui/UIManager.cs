using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
       get
        {
            if(_instance  == null)
            {
                Debug.LogError("UIManager Error");
            }
            return _instance;
        }
    }


    public Text playerGemCount;
    public Image selectionImage;
    public Text gemCountText;
    public Image[] heathBars;

    private void Awake()
    {
        _instance = this;
    }

    public void OpenShop(int gemCount)
    {
        playerGemCount.text = "" + gemCount + "G";
    }

    public void UpdateShopSelectio(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }
    public void UpdateGemCount(int count)
    {
        gemCountText.text = "" + count;
    }
    
    public void UpdateLives(float liveRemaining)
    {
        for(int i = 0; i <= liveRemaining; i++)
        {
            if(i == liveRemaining)
            {
                heathBars[i].enabled = false;
            }
        }
    }
}
