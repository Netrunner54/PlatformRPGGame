using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenChest : MonoBehaviour
{
    private bool isConnectingPlayer = false;
    public LayerMask WhatIsPalyer;
    private bool WasOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isConnectingPlayer && !WasOpened)
        {
            if (Input.GetKeyDown("e"))
            {
                Open();
                WasOpened = true;
            }
        }
    }

    private void Open()
    {
        Debug.Log("TTTTTTTTTTTTTTTTTTTTTTT");
    }

    private void FixedUpdate()
    {
        if (!WasOpened)
        {
            isConnectingPlayer = Physics2D.OverlapCircle(gameObject.transform.position, 0.7f, WhatIsPalyer);
        }
    }
}
