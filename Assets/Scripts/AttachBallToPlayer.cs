using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachBallToPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject ball;
    public bool isAttached = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isAttached = !isAttached;
        }
        if (isAttached) ball.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z + 1);
    }
}
