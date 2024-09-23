using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private InventoryController inventory;
    public GameObject itemButton;
    public string itemName;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<InventoryController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == true && inventory.slots[i].transform.GetComponent<Slots>().amount < 2) //Change this number for stack size
                {
                    if (itemName == inventory.slots[i].transform.GetComponentInChildren<Spawn>().itemName) //Can Stack
                    {
                        Destroy(gameObject);
                        inventory.slots[i].GetComponent<Slots>().amount += 1;
                        break;
                    }
                } else if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    inventory.slots[i].GetComponent<Slots>().amount += 1;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
    
}
