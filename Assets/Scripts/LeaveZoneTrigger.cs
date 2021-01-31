using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveZoneTrigger : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    private Coroutine launchedCoroutine;
    [SerializeField] private Transform teleportLocation;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("HasEnteredLeaveZone");
            launchedCoroutine = StartCoroutine(TeleportCountdown(other.gameObject));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("HasLeftLeaveZone");
            StopCoroutine(launchedCoroutine);
        }
    }

    IEnumerator TeleportCountdown(GameObject player)
    {
        for(int i = 5; i >= 0; i--)
        {
            manager.SendPlayerMessage($"Leaving in {i}");
            yield return new WaitForSecondsRealtime(1);
        }
        manager.SendPlayerMessage(string.Empty);
        player.transform.position = teleportLocation.position;
    }
}
