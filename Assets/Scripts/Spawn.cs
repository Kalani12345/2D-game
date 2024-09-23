using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ItemPrefab;
    private Transform player;
    public string itemName;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPostion = new Vector2(player.position.x + 2, player.position.y); //The + is an offset
        Instantiate(ItemPrefab, playerPostion, Quaternion.identity);
    }
}
