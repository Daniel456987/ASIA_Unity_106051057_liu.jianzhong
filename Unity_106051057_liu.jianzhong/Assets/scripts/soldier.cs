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
        if (Input.GetKeyDown("space"))
        {
            ani.SetTrigger("跑");

            aud.PlayOneShot(soundBark, 0.6f);
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
