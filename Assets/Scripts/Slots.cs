using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slots : MonoBehaviour
{
    private InventoryController inventory;
    public int i;
    public TextMeshProUGUI amountText;
    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        amountText.text = amount.ToString();

        //Turns off yexy if nothings there
        if (amount >= 1)
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true; //The 1(it starts from 0) is the first child under slot (1), amount. It then gets a component which is TextMeshProUGUI. It then enables it(the checkmark)
        }
        else
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        }

        if (transform.childCount == 2)//This is the amount of child under the slot if add more gui change this number
        {
            inventory.isFull[i] = false;
        }
             
    }

    public void DropItem()
    {
        if (amount > 1) //If its stacked
        {
            amount -= 1;
            transform.GetComponentInChildren<Spawn>().SpawnDroppedItem(); //I think that last part is calling the function in spawn script
        }
        else
        {
            amount -= 1;
            GameObject.Destroy(transform.GetComponentInChildren<Spawn>().gameObject);
            transform.GetComponentInChildren<Spawn>().SpawnDroppedItem();
        }
    }
}
