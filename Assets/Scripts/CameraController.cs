using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject m_Player;

    private Vector3 m_Offset;

	// Use this for initialization
	void Start () {
        // 由摄像机指向游戏物体的向量
        m_Offset = m_Player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = m_Player.transform.position - m_Offset;
	}
}
