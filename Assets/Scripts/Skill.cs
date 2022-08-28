using UnityEngine;

public class Skill : MonoBehaviour
{
    public float lifeTime = 1f;
    public float speed = 3f;
    private Vector3 targetPos;
    public Transform attack;
    private float time;
    private void Start()
    {

        this.transform.position = this.attack.position;
        this.targetPos = this.transform.localPosition + Vector3.right * 1f * speed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Debug.Log("击中了怪物");
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        
    }


    private void FixedUpdate()
    {
        this.time += Time.fixedDeltaTime;
        if (this.lifeTime > 0 && this.time >= this.lifeTime)
        {
            Destroy(this.gameObject);
            return;
        }

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, Time.fixedDeltaTime * speed);
    }
}
