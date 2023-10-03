using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    [SerializeField]
    private GameObject bullets;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform gun;
    private Transform muzzle;

    private float rateOfFire = 200f;
    private float nextShot;

    private int mag;
    private Text magText;

    public Joystick joystick;

    public float speed = 15f;
    private Quaternion rota;
    Vector3 moveVector = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        muzzle = gun.GetChild(0);
        magText = GameObject.Find("FireButton").transform.GetChild(0).GetComponent<Text>();
        mag = 10;
        magText.text = mag.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            moveVector = (Vector3.up * joystick.Vertical + Vector3.left * -joystick.Horizontal);
            if (moveVector.y > 0)
            {
                rota = Quaternion.LookRotation(Vector3.forward, moveVector);
                player.transform.rotation = Quaternion.Slerp(player.transform.rotation, rota, Time.deltaTime * speed);
            }
        }
    }

    
    public void fireBullet()
    {
        if (Time.time > nextShot && mag > 0 && Time.timeScale != 0)
        {
            GameObject temp;
            temp = Instantiate(bullets, muzzle.transform.position, muzzle.transform.rotation);
            temp.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, 0.1f));
            nextShot = Time.time + rateOfFire / 1000;
            mag--;
            magText.text = mag.ToString();
            Destroy(temp, 2f);
        }
    }
}
