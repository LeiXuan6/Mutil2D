using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterFactory : MonoBehaviour
{
    public bool open;
    private Vector3[] positionArray;
    public GameObject player;
    public GameObject prefab;
    private float nextCreate;
    public int count;
    public float cd = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        positionArray = GetPosition(Camera.main, player.transform);
    }

    private void FixedUpdate()
    {
        if (open)
        {

            if (Time.time <= nextCreate)
            {
                return;
            }

            if ((int)Time.time %  30 == 0)
            {
                positionArray = GetPosition(Camera.main, player.transform, Random.Range(3, 15));
            }

            nextCreate = Time.time + cd;

            Vector3 pos;
            int random = Random.Range(0, positionArray.Length);
            if (random == 0)
            {
                pos = new Vector3(Random.Range(positionArray[0].x, positionArray[1].x), positionArray[0].y);
            } else if (random  == 1)
            {
                pos = new Vector3(positionArray[1].x, Random.Range( positionArray[1].y, positionArray[3].y));
            } else if (random == 2)
            {
                pos = new Vector3(Random.Range(positionArray[3].x, positionArray[2].x), positionArray[3].y);
            }else
            {
                pos = new Vector3(positionArray[2].x, Random.Range(positionArray[2].y, positionArray[0].y));
            }

            GameObject monsterGameObject = (GameObject)Instantiate(prefab, pos, transform.rotation, transform);
            monsterGameObject.GetComponent<Monster>().player = player.transform;
            count++;
            
        }
    }

    public static Vector3[] GetPosition(Camera theCamera, Transform tx, float distance = 8.5f)
    {
        Vector3[] corners = new Vector3[4];

        float halfFOV = (theCamera.fieldOfView * 0.5f) * Mathf.Deg2Rad;
        float aspect = theCamera.aspect;

        float height = distance * Mathf.Tan(halfFOV);
        float width = height * aspect;

        // UpperLeft
        corners[0] = tx.position - (tx.right * width);
        corners[0] += tx.up * height;
        corners[0] += tx.forward * distance;
        corners[0].z = 0;

        // UpperRight
        corners[1] = tx.position + (tx.right * width);
        corners[1] += tx.up * height;
        corners[1] += tx.forward * distance;
        corners[1].z = 0;

        // LowerLeft
        corners[2] = tx.position - (tx.right * width);
        corners[2] -= tx.up * height;
        corners[2] += tx.forward * distance;
        corners[2].z = 0;

        // LowerRight
        corners[3] = tx.position + (tx.right * width);
        corners[3] -= tx.up * height;
        corners[3] += tx.forward * distance;
        corners[3].z = 0;

        return corners;
    }
}
