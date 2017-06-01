using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text m_CountText;
    public Text m_WinText;
    public GameObject PickUps;

    private Rigidbody m_Rigidbody;
    private int m_Count = 0;
    private int m_PickUpNums = 0;

	// Use this for initialization
	void Start () {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_PickUpNums = PickUps.transform.childCount;
	}

    private void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
#if UNITY_STANDALONE
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        m_Rigidbody.AddForce(movement * speed);
#endif
#if UNITY_ANDROID
        float horizontal = Input.acceleration.x;
        float vertical = Input.acceleration.y;
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        m_Rigidbody.AddForce(movement * speed);
#endif
        }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
            m_Count++;
            SetCountText();
            DisplayWinText();
        }
    }

    void SetCountText()
    {
        m_CountText.text = "Count: " + m_Count.ToString();
    }

    void DisplayWinText()
    {
        if (m_Count >= m_PickUpNums)
        {
            m_WinText.gameObject.SetActive(true);
        }
    }
}
