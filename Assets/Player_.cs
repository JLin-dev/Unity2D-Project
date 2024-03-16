using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_ : MonoBehaviour
{
    public float speed; //移動速度
    public float jumpforce; // 跳躍力度
    Rigidbody2D myrig;//宣告自己的物件
    Animator myanim;//宣告動畫
    public float HP;
    public bool isHurt;

    public bool isGround;//檢測有沒有在地面
    public Transform checker;//檢測器的transform
    float checkRadius = 0.2f;//檢測器範圍大小
    public LayerMask GroundLayer;//地板的圖層

    public GameObject weapon;

    public Sprite[] Hp_sprite;
    public Image UI_hp;

    void Start()
    {
        CheckHpUI();
        myrig = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.Space)))
        {
            if(isGround && (HP > 0)){
                myrig.velocity = Vector2.up * jumpforce;
            }
        }
        if (!isHurt)
        {
            if ((Input.GetMouseButtonDown(0)) || (Input.GetKeyDown(KeyCode.Z)))
            {
                if (HP > 0)
                {
                    myanim.Play("player_attack");
                }
            }
        }
        if (transform.position.y < -10f)
        {
            FindObjectOfType<GM>().GameOverPanel_Show();
        }
    }
    private void FixedUpdate() //適用物理計算
    {

        isGround = Physics2D.OverlapCircle(checker.position, checkRadius, GroundLayer);

        if (HP > 0)
        {
            float move = Input.GetAxis("Horizontal");//水平量 介於 1~-1之間 適用於鍵盤左右鍵及搖桿左右移動
            float face = Input.GetAxisRaw("Horizontal");//水平量 只有1 0 -1, 沒有小數點
            myrig.velocity = new Vector2(speed * move, myrig.velocity.y);
            myanim.SetFloat("move", Mathf.Abs(move));

            if (face != 0)//face不為0 只能是1or-1
            {
                transform.localScale = new Vector3(face, 1, 1);//決定角色面向
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "hydro_slime") && (HP > 0))
        {
            myanim.Play("player_hurt");
            float dmg = collision.gameObject.GetComponent<Enemy>().damage;
            PlayerHurt(dmg);
        }

    }

    public void PlayerHurt(float damage)
    {
        HP -= damage;
        CheckHpUI();
        if ( HP <= 0 ) 
        {
            FindObjectOfType<GM>().GameOverPanel_Show();
        }
    }

    public void CheckHpUI()
    {
        UI_hp.sprite = Hp_sprite[(int)HP];
    }

    public void 受傷圖層()
    {
        isHurt = true;
        myanim.SetBool("isHurt", true);
        this.gameObject.layer = 11;
        weapon.gameObject.layer = 9;
    }
    public void 恢復原樣()
    {
        isHurt = false;
        myanim.SetBool("isHurt", false);
        this.gameObject.layer = 9;
        weapon.gameObject.layer = 9;
    }

}
