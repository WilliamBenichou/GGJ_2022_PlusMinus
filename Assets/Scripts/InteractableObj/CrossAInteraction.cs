using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossAInteraction : AInteractionController
{
    [SerializeField] private GameObject check;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void useObj(Player player)
    {
        base.useObj(player);
        //does something
        if (player.PlayerIndex == 1)
        {
            check.SetActive(true);
            this.gameObject.active = false;
        }
        
        

    }
}
