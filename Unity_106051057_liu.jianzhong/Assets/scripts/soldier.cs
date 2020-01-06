using UnityEngine;

public class soldier : MonoBehaviour
{
    [Header("速度")]
    [Range(1, 2000)]
    public int speed = 10;
    [Tooltip("旋轉速度")]
    [Range(1, 200)]
    public float turn = 20.5f;
    public bool mission;
    public string name = "soldier";

    [Header("檢視物品位置")]
    public Rigidbody rigCatch;


    private void OnTriggerStay(Collider other)
    {
        print(other.name);

        if (other.name == "核彈" && ani.GetCurrentAnimatorStateInfo(0).IsName("shoot"))
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());

            other.GetComponent<HingeJoint>().connectedBody = rigCatch;
            GameObject.Find("核彈").GetComponent<CapsuleCollider>().enabled = false;
        }

        if (other.name == "感應區" && ani.GetCurrentAnimatorStateInfo(0).IsName("shoot"))
        {
            GameObject.Find("核彈").GetComponent<HingeJoint>().connectedBody = null;
        }
    }

    public Transform tran;
    public Rigidbody rig;
    public Animator ani;
    public AudioSource aud;
    public AudioClip soundBark;

    private void Update()
    {
        Turn();
        Run();
        Bark();
        Catch();
    }

    private void Run()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("射")) return;
        float v = Input.GetAxis("Vertical");
        rig.AddForce(tran.forward * speed * v * Time.deltaTime);
        ani.SetBool("走路開關", v != 0);
    }

    private void Turn()
    {
        float h = Input.GetAxis("Horizontal");
        tran.Rotate(0, turn * h * Time.deltaTime, 0);
    }

    private void Bark()
    {
        if (Input.GetKey("space"))
        {
            ani.SetBool("跑步",true);
            ani.SetBool("走路開關", false);

            aud.PlayOneShot(soundBark, 0.6f);
        }
        else
        {
            ani.SetBool("跑步", false);
        }
    }

    private void Catch()
    {
        if (Input.GetMouseButton(0))
        {
            ani.SetTrigger("射");
        }
    }
}
