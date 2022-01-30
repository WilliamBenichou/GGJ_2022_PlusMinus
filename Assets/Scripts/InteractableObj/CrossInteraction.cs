using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossInteraction : InteractionController
{
    [SerializeField] private GameObject cross;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void useObj(int player)
    {
        base.useObj(player);
        //does something
        if (player == 1)
        {
            this.gameObject.active = false;
        }

    }
}
