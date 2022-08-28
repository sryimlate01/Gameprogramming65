using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    public float rotateSpeed;
    public AudioSource playSound;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, -rotateSpeed, 0, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playSound.Play();
            Destroy(gameObject);
        }
    }
}
