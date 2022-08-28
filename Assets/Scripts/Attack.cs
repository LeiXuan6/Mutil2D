using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject prefab;
    public GameObject parent;
    public float cd = 0.2f;
    private float nextAttackTime;
    public Transform attackPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time <= nextAttackTime)
            {
                return;
            }

            nextAttackTime = Time.time + cd;
            GameObject monsterGameObject = (GameObject)Instantiate(prefab, parent.transform);
            monsterGameObject.GetComponent<Skill>().attack = attackPos;
        }
    }
}
