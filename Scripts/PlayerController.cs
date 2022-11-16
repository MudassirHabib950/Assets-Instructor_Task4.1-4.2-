using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private  Rigidbody playerRb;
    private  GameObject focalPoint;
    private float powerUpStrength = 15.0f;
    public float speed = 5.0f;
    public bool hasPowerup = false;
    public GameObject powerUpIndiactor;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
     playerRb = GetComponent<Rigidbody>();  
     focalPoint = GameObject.Find("Focal Point");
     Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerUpIndiactor.transform.position = transform.position + new Vector3(0,-0.5f,0);
    }
   private void OnTriggerEnter(Collider other)
   {
    if(other.CompareTag("PowerUp"))
    {
        hasPowerup = true;
        powerUpIndiactor.gameObject.SetActive(true);
        Destroy (other.gameObject);
        StartCoroutine(PowerUpCountdownRoutine());
       
    }
   }
   IEnumerator PowerUpCountdownRoutine()
   {
      yield return new WaitForSeconds(7);
      hasPowerup = false;
      powerUpIndiactor.gameObject.SetActive(false);
   }
   private void OnCollisionEnter(Collision collision)
   {
    Debug.Log(hasPowerup);
    hasPowerup = true;
    if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
    {
        Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
        Player.transform.localScale = new Vector3(3.0f,3.0f,3.0f);
        enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength,ForceMode.Impulse);
        Debug.Log("Collide with :" + collision.gameObject.name + "with powerup set to" + hasPowerup);
    }
   }
}
