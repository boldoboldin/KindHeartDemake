using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCtrl : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] private float shotSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(0f, shotSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 1.5f);
    }
}
