using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public LayerMask WhatIsPlayer;
    public GameObject player;

    private bool isConnectingPlayer = false;
    private bool WasLooted = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isConnectingPlayer && Input.GetKeyDown("e"))
        {
            loot();
        }
    }

    private void FixedUpdate()
    {
        if (!WasLooted)
        {
            isConnectingPlayer = Physics2D.OverlapCircle(gameObject.transform.position, 0.7f, WhatIsPlayer);
        }
    }

    private void loot()
    {
        Debug.Log("Infiuwnufijanjkwfnmk");
        foreach(Item item in items)
        {
            if (item.type == "Alchemy")
            {
                player.GetComponent<AlchemicalIngreedients>().AddItem(item);
            }
            else
            {
                player.GetComponent<InventoryItems>().AddItem(item);
            }
        }
        Destroy(gameObject);
    }
}
