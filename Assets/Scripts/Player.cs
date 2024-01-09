using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    public int speed = 5;
    bool isMoving;
    private float statusUpTime = 10f;
    [SerializeField] LayerMask LimitLayer; //壁判定のレイヤーの変数

    public GameObject lightObject;
    private UnityEngine.Rendering.Universal.Light2D playerLight;

    private CountdownTimer timer;

    Animator animator;

    void Start()
    {
        // PlayerPrefs.DeleteAll();
        playerLight = lightObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        timer = FindObjectOfType<CountdownTimer>();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(isMoving == false)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            if(y != 0)
            {
                x = 0;
            }

            if(x != 0 || y != 0)
            {
                animator.SetFloat("InputX",x);
                animator.SetFloat("InputY",y);
            }
            
            StartCoroutine(Move(new Vector2(x,y)));
        }
        
        animator.SetBool("IsMove",isMoving);
    }


    //動くプログラム
    IEnumerator Move(Vector3 direction)
    {
        isMoving = true;
        Vector3 targetPos = transform.position  + direction;
        if(isWalkable(targetPos) == false)
        {
            isMoving = false;
            yield break;
        }
        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    } 


    //歩けるかどうかを調べるプログラム
    bool isWalkable(Vector3 targetPos)
    {
        return Physics2D.OverlapCircle(targetPos,0.5f,LimitLayer) == false;
    }
    
    //アイテム取得時のステータス変更
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpeedUp"))
        {
            StartSpeedBoost();
        }

        if (other.CompareTag("LightUp"))
        {
            StartLightBoost();
        }

        if (other.CompareTag("TimeUp"))
        {
            timer.AddTime(10f);
        }

        if (other.CompareTag("Clear"))
        {
            ScoreManager.instance.ClearScene();
            // SceneManager.LoadScene("Clear");
        }
    }

    //スピードアップ
    void StartSpeedBoost()
    {
        speed = 10;
        Invoke("EndSpeedBoost", statusUpTime);
    }

    void EndSpeedBoost()
    {
        speed = 5;
    }

    //ライトの範囲増加
    void StartLightBoost()
    {
        playerLight.pointLightOuterRadius *= 3f;
        Invoke("EndLightBoost",statusUpTime);
    }

    void EndLightBoost()
    {
        playerLight.pointLightOuterRadius /= 3f;
    }
    
}
