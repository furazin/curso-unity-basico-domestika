using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    public float minX;
    public float maxX;
    public float waitingTime = 2f;

    private GameObject target; 
    // Start is called before the first frame update
    void Start()
    {
        UpdateTarget();
        StartCoroutine("PatrolToTarget");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateTarget(){
        if (target == null) {
            target = new GameObject("Target");
            target.transform.position = new Vector2(minX,transform.position.y);
            return;
        }

        if (target.transform.position.x == minX) {
            target.transform.position = new Vector2(maxX,transform.position.y);
            transform.localScale = new Vector3(1,1,1);
        } else {
            if (target.transform.position.x == maxX) {
                target.transform.position = new Vector2(minX,transform.position.y);
                transform.localScale = new Vector3(-1,1,1);
            }
        }
    }

    IEnumerator PatrolToTarget() {
        // Coroutine to move enemy
        while(Vector2.Distance(transform.position,target.transform.position) > 0.05f) {  // While I'm not close to target enemy
            //  Move to the target
            Vector2 direction = target.transform.position - transform.position;
            float xDirection = direction.x;

            transform.Translate(direction.normalized * speed * Time.deltaTime);

            yield return null;
        }

        Debug.Log("Target reached");
        transform.position = new Vector2(target.transform.position.x,transform.position.y);

        Debug.Log("Waiting for " + waitingTime);
        yield return new WaitForSeconds(waitingTime);

        Debug.Log("Waited enough");
        UpdateTarget();
        StartCoroutine("PatrolToTarget");
    }
}
