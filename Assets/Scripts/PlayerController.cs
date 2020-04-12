using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text timeText;
    public Text recordText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    public float recordTime;
    public float actualTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        actualTime = 0;
        recordTime = GetRecord();
        countText.text = "Coins:" + count.ToString() + "/9";
        timeText.text = "0";
        recordText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    // Se llama antes de cada frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            ResetScore();
        }
        if (count >= 2)
        {
            if (actualTime < recordTime)
            {
                //texto felicidades
                recordText.gameObject.SetActive(true);
                recordTime = actualTime;
                SaveScore(recordTime);
            }
            winText.gameObject.SetActive(true);
            winText.text = "Your time:" + actualTime.ToString("F2") + " Record:" + recordTime.ToString("F2");
        }
        else
        {
            actualTime = Time.time;
            timeText.text = actualTime.ToString();

        }
        
    }
        
        
    
    // Se llama antes de calcular las fisicas
    // Meter las fisicas aqui
    void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);

        rb.AddForce(movement*speed);
        if (Input.GetKeyDown("space") & transform.position.y==0.5)
        {
            Vector3 jump = new Vector3(0.0f, 200.0f, 0.0f);
            GetComponent<Rigidbody>().AddForce(jump);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            ++count;
            countText.text = "Coins:" + count.ToString() + "/9";

        }
    }
    public float GetRecord()
    {
        return PlayerPrefs.GetFloat("Record", 0.0f);
    }

    public void SaveScore(float recordTime)
    {
        PlayerPrefs.SetFloat("Record", recordTime);
    }

    public void ResetScore()
    {
        PlayerPrefs.SetFloat("Record", 100.0f);
    }
}
