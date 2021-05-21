using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    private Transform _firePoint;
    public GameObject shooter;
    private void Awake() {
        _firePoint = transform.Find("FirePoint");
    }
    
    void Start()
    {
        Invoke("Shoot",1f);
        Invoke("Shoot",2f);
        Invoke("Shoot",3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot() {
        if (bulletPrefab != null && shooter != null  && _firePoint != null) {
            GameObject bulletObject = Instantiate(bulletPrefab, _firePoint.position,  Quaternion.identity) as GameObject;

            Bullet bulletComponent = bulletObject.GetComponent<Bullet>();

            if (shooter.transform.localScale.x < 0f) { // looking left
                bulletComponent.direction = Vector2.left;
            }
            else { // looking right
                bulletComponent.direction = Vector2.right;
            }
        }
    }
}
