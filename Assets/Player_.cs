using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_ : MonoBehaviour
{
    public float speed; //���ʳt��
    public float jumpforce; // ���D�O��
    Rigidbody2D myrig;//�ŧi�ۤv������
    Animator myanim;//�ŧi�ʵe
    public float HP;
    public bool isHurt;

    public bool isGround;//�˴����S���b�a��
    public Transform checker;//�˴�����transform
    float checkRadius = 0.2f;//�˴����d��j�p
    public LayerMask GroundLayer;//�a�O���ϼh

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
    private void FixedUpdate() //�A�Ϊ��z�p��
    {

        isGround = Physics2D.OverlapCircle(checker.position, checkRadius, GroundLayer);

        if (HP > 0)
        {
            float move = Input.GetAxis("Horizontal");//�����q ���� 1~-1���� �A�Ω���L���k��ηn�쥪�k����
            float face = Input.GetAxisRaw("Horizontal");//�����q �u��1 0 -1, �S���p���I
            myrig.velocity = new Vector2(speed * move, myrig.velocity.y);
            myanim.SetFloat("move", Mathf.Abs(move));

            if (face != 0)//face����0 �u��O1or-1
            {
                transform.localScale = new Vector3(face, 1, 1);//�M�w���⭱�V
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

    public void ���˹ϼh()
    {
        isHurt = true;
        myanim.SetBool("isHurt", true);
        this.gameObject.layer = 11;
        weapon.gameObject.layer = 9;
    }
    public void ��_���()
    {
        isHurt = false;
        myanim.SetBool("isHurt", false);
        this.gameObject.layer = 9;
        weapon.gameObject.layer = 9;
    }

}
