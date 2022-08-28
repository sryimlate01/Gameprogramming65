using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scripts : MonoBehaviour
{
    public int PlayerAct;
    private Animator anim;

    float playerInput;
    public int speed;

    public int countCoin;
    public Text showCoin;

    private Rigidbody2D PlayerRigid2D;
    public float jumpVelocity;
    public bool groundCheck;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        PlayerRigid2D = GetComponent<Rigidbody2D>();

        UpdateDataToScene();
    }
    private void Update()
    {
        showCoin.text = countCoin.ToString();
        playerInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(playerInput, 0, 0);

        if (playerInput == 0)
        {
            PlayerAct = 0;
        }
        if (playerInput < 0)
        {
            PlayerAct = 1;
            ChangeDirection(-1);
        }
        if (playerInput > 0)
        {
            PlayerAct = 1;
            ChangeDirection(1);
        }
        jumpCheck();

        SaveDataToGameObject();
    }

    void ChangeDirection(int direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    private void FixedUpdate()
    {
        PlayerWalk();
    }
    void PlayerWalk()
    {
        anim.SetInteger("PlayerAct", PlayerAct);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            countCoin += 1;
        }
    }
    void jumpCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerRigid2D.velocity = Vector2.up * jumpVelocity;
            groundCheck = false;
        }
    }
    void SaveDataToGameObject()
    {
        SaveData.coin = countCoin;
    }
    void UpdateDataToScene()
    {
        countCoin = SaveData.coin;
    }
}