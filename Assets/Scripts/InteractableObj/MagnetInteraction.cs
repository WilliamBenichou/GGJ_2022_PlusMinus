using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetInteraction : AInteractionController
{
    [SerializeField] private bool isPlus;
    [SerializeField] private GameObject magnet;
    [SerializeField] private float launchSpeed = 2.0f;
    [SerializeField] private float attractSpeed = 0.5f;

    [SerializeField] private TweenRotation tr;
    [SerializeField] private CapsuleCollider2D magnetLaunchPad;
    [SerializeField] private float currAttraction = 0f;
    [SerializeField] private LayerMask playerMask;
    private int plusDir = 1;
    private int angleDir = 0;
    private ContactFilter2D contactFilter = new ContactFilter2D();
    
    
    private enum states
    {
        stopped,
        launch,
        attract,
        loaded
    };

    [SerializeField] private states state = states.stopped;
    

    // Start is called before the first frame update
    void Start()
    {
        contactFilter.SetLayerMask(playerMask);
        if (!isPlus)
        {
            plusDir = -1;
            angleDir = -360;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case states.stopped:
                break;
            case states.launch:
                break;
            case states.attract:
                currAttraction += attractSpeed * Time.deltaTime;
                if (currAttraction >= 1f)
                {
                    currAttraction = 1f;
                    state = states.loaded;
                }

                float zRotation;
                if (isPlus)
                {
                    zRotation = Mathf.Lerp(0f, 67.766f, currAttraction);
                }
                else
                {
                    zRotation = Mathf.Lerp(0f, -67.766f, currAttraction);
                }
                
                //float Rz = magnet.transform.rotation.eulerAngles.z * attractSpeed + Time.deltaTime;
                magnet.transform.rotation = Quaternion.Euler(0f,0f,zRotation);
                break;
            case states.loaded:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public override void startUseObj(Player player)
    {
        base.startUseObj(player);
        if ((player.PlayerIndex == 0 && isPlus) || (player.PlayerIndex == 1 && !isPlus))
        {
            state = states.attract;
        }
    }

    public override void cancelUseObj(Player player)
    {
        base.cancelUseObj(player);
        if (((player.PlayerIndex == 0 && isPlus) || (player.PlayerIndex == 1 && !isPlus)) && state != states.loaded)
        {
            state = states.stopped;
        }
    }
    
    public override void useObj(Player player)//joueur inverse
    {
        base.useObj(player);
        if (((player.PlayerIndex == 0 && !isPlus) || (player.PlayerIndex == 1 && isPlus) ) && state == states.loaded)
        {
            tr.startValue = new Vector3(0f,0f,magnet.transform.rotation.eulerAngles.z + angleDir);
            tr.PlayForward(); 
            state = states.launch;
            currAttraction = 0f;
            Collider2D[] colliders = new Collider2D[2];
            magnetLaunchPad.OverlapCollider(contactFilter, colliders);
            foreach (var collider in colliders)
            {
                var moveController = collider.gameObject.GetComponent<Player>().GetPlayerComponent<PlayerMovementController>();
                moveController.EnableFlyMode();
                //moveController.Disable();
                //moveController.PlayerRigidbody2D.isKinematic = false;
                moveController.PlayerRigidbody2D.AddForce(new Vector2(1f * plusDir,1f) * launchSpeed);
            }
            
            /*var moveController = player.GetPlayerComponent<PlayerMovementController>();
            moveController.Disable();
            moveController.PlayerRigidbody2D.isKinematic = false;
            moveController.PlayerRigidbody2D.AddForce(new Vector2(1f * plusDir,1f) * launchSpeed);*/
            
        }
    }
}
