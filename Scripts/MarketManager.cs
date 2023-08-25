using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketManager : MonoBehaviour
{
    [SerializeField] private GameObject marketPanel;
    [SerializeField] private GameObject playerController;
    private string itemSold;

    public void setSoldItem(string item)
    {
        itemSold = item;
    }

    public void sellItem()
    {
        switch (itemSold)
        {
            case "garbage":
                int itemavil = playerController.GetComponent<FirstPersonController>().ItemGot(itemSold);
                if (itemavil > 0)
                {
                    playerController.GetComponent<FirstPersonController>().RemoveItem("garbage", 1);
                    playerController.GetComponent<FirstPersonController>().AddMoney(2);
                }
                break;

            default:
                Debug.LogError("Cannot find Item: " + itemSold);
                break;
        }   
    }

    public void exitMenu()
    {
        itemSold = "null";
        marketPanel.SetActive(false);
    }
}
