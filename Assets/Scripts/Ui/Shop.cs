using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject panel;
    public int currentSelectedItem;
    public int currentItemCost;
    private Player player;
 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            
            if(player != null)
            {
                UIManager.Instance.OpenShop(player.Diamonds);
            }

            panel.SetActive(true);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            panel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        Debug.Log("Item Selected" + item);


        switch(item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelectio(138);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;

            case 1:
                UIManager.Instance.UpdateShopSelectio(29);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;

            case 2:
                UIManager.Instance.UpdateShopSelectio(-72);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if (player.Diamonds >= currentItemCost)
        {
            if(currentSelectedItem == 2)
            {
                GameManager.Instance.hasKeyToCastle = true;
            }
            player.Diamonds -= currentItemCost;
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
