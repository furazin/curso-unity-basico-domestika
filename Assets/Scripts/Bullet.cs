using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public Vector2 direction;
    public float livingTime = 3f;
    public Color initColor = Color.white;
    public Color finalColor;
    private SpriteRenderer spriteRender;
    private float startingTime;

    private void Awake() {
        startingTime = Time.time;
        spriteRender = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Destroy(gameObject,livingTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = direction.normalized * speed * Time.deltaTime;
        this.transform.Translate(movement);

        // Change bullet color over time
        float timeSinceStarted = Time.time - startingTime;
        float percentageCompleted = timeSinceStarted / livingTime;

        spriteRender.color = Color.Lerp(initColor,finalColor,percentageCompleted);
    }
}
