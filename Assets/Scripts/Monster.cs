using System;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (!GlobalDefine.Instance.MONSTER_MOVE)
        {
            return;
        }

        Vector2 oldPosition = transform.position;
        float distance = Math.Abs(Vector2.Distance(oldPosition, player.position));
        if (distance <= 0.8f)
        {
            return;
        }
        transform.position = Vector2.MoveTowards(oldPosition, player.position, Time.fixedDeltaTime * 0.2f);
    }

}
