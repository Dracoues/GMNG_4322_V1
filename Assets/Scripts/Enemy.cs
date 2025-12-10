using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] tempPoints;

    private int i;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, tempPoints[i].position) < 0.25f)
        {
            i++;
            if(i == tempPoints.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, tempPoints[i].position, speed * Time.deltaTime);

        spriteRenderer.flipX = (transform.position.x-tempPoints[i].position.x) < 0f;

    }
}
