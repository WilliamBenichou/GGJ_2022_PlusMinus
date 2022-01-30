using System.Collections;
using UnityEngine;

public class TriggerTeleportToLight : MonoBehaviour
{
    public GameObject loadingScreen;
    public ATweener[] loadingTweens;
    public Transform tpPoint;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            StartCoroutine(StartLoading());
        }
    }

    private IEnumerator StartLoading()
    {
        loadingScreen.SetActive(true);
        foreach (ATweener tween in loadingTweens)
        {
            tween.PlayForward();
        }
        
        yield return new WaitForSeconds(1f);
        
        //teleport players, switch camera, disable light
        var gm = GameManager.Instance;
        for (int i = 0; i < 2; i++)
        {
            var pos = gm.players[i].transform.position;
            pos.x = tpPoint.position.x;
            pos.y = tpPoint.position.y;
            gm.players[i].transform.position = pos;
            gm.players[i].GetPlayerComponent<PlayerMovementController>().Disable();
        }
        gm.vCam1_main.gameObject.SetActive(true);
        gm.vCam2_dark.gameObject.SetActive(false);
        
        yield return new WaitForSeconds(1.5f);
        foreach (ATweener tween in loadingTweens)
        {
            tween.PlayReverse();
        }
        yield return new WaitForSeconds(1f);
        loadingScreen.SetActive(false);
        for (int i = 0; i < 2; i++)
        {
            gm.players[i].GetPlayerComponent<PlayerMovementController>().Enable();
        }
    }
}