using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractionController : MonoBehaviour
{
    private bool plusReached = false;
    private bool minusReached = false;
    private int firstReach = -1;

    
    [SerializeField] private Color[] hl_c = new Color[]{};
    [SerializeField] private  SpriteRenderer hl_renderer;


    public void Reached(int player)
    {
        int color;
        //first to reach
        if (!minusReached && !plusReached)
        {
            firstReach = player;
        }
        //note which player has reached
        if (player == 0)
        {
            plusReached = true;
        }
        else
        {
            minusReached = true;
        }
        //if both players have reached
        if (plusReached && minusReached)
        {
            color = 2;
        }
        else
        {
            color = firstReach;
        }
        
        hl_renderer.enabled = true;
        hl_renderer.color = hl_c[color];
       
    }

    // Start is called before the first frame update
    void Start()
    {
        hl_renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    
}
