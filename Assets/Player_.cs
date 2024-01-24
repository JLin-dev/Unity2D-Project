using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player_ : MonoBehaviour
{
    public float speed; //���ʳt��
    public float jumpforce; // ���D�O��
    Rigidbody2D myrig;//�ŧi�ۤv������
    Animator myanim;//�ŧi�ʵe

    public bool isGround;//�˴����S���b�a��
    public Transform checker;//�˴�����transform
    float checkRadius = 0.2f;//�˴����d��j�p
    public LayerMask GroundLayer;//�a�O���ϼh

    void Start()
    {
        myrig = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.Space)))
        {
            if(isGround){
                myrig.velocity = Vector2.up * jumpforce;
            }
        }

        if ((Input.GetMouseButtonDown(0)) || (Input.GetKeyDown(KeyCode.Z)))
        {
            myanim.Play("player_attack");
        }
    }
    private void FixedUpdate() //�A�Ϊ��z�p��
    {
        isGround = Physics2D.OverlapCircle(checker.position, checkRadius, GroundLayer);

        float move = Input.GetAxis("Horizontal");//�����q ���� 1~-1���� �A�Ω���L���k��ηn�쥪�k����
        float face = Input.GetAxisRaw("Horizontal");//�����q �u��1 0 -1, �S���p���I
        myrig.velocity = new Vector2(speed * move, myrig.velocity.y);
        myanim.SetFloat("move",Mathf.Abs(move));

        if (face != 0)//face����0 �u��O1or-1
        {
            transform.localScale = new Vector3(face,1,1);//�M�w���⭱�V
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "hydro_slime")
        {
            myanim.Play("player_hurt");
        }

    }

}
