using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInteraction : InteractionController
{
    [SerializeField] private GameObject pencil;
    [SerializeField] private SpriteRenderer check_sprite;
    
    private static readonly int T_KEY_FALL = Animator.StringToHash("Fall");
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
        if (player == 0)
        {
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.gameObject.GetComponent<HighlightObj>().enabled = false;
            check_sprite.enabled = true;
            pencil.GetComponent<Animator>().SetTrigger(T_KEY_FALL);
            pencil.layer = LayerMask.NameToLayer("ground");

        }
        
        

    }
}
