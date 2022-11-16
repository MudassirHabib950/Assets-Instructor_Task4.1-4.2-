using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerSize : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        Player.transform.localScale = new Vector3(3.0f,3.0f,3.0f);
    }
}
