using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObj : MonoBehaviour
{
    [SerializeField] private bool plusReached = false;
    [SerializeField] private bool minusReached = false;
    [SerializeField] public int firstReach{ get; private set; }
    [SerializeField] private int color;
    
    [SerializeField] private Color[] hl_c = new Color[]{};
    [SerializeField] private  SpriteRenderer hl_renderer;


    public void Reached(int player)
    {
 
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

    public void PlayerOOS(int player)
    {
        //if 2 players
        if (plusReached && minusReached)
        {
            if (player == firstReach)//changement de first reach
            {
                if (player == 0)
                {
                    firstReach = 1;
                    plusReached = false;
                    hl_renderer.color= hl_c[1];
                }
                else
                {
                    firstReach = 0;
                    minusReached = false;
                    hl_renderer.color= hl_c[0];
                }
            }
            else //pas de changement de first reach
            {
                if (player == 0)
                {
                    plusReached = false;
                    hl_renderer.color= hl_c[1];
                }
                else
                {
                    minusReached = false;
                    hl_renderer.color= hl_c[0];
                }
            }
            
        }
        else//if 1 player
        {
            firstReach = -1;
            if (player == 0)
            {
                plusReached = false;
                hl_renderer.enabled = false;
            }
            else
            {
                minusReached = false;
                hl_renderer.enabled = false;
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        firstReach = -1;
        hl_renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    
}
