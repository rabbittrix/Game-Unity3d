using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int powerupID;  // 0 = triple shot, 1 = speed boost, 2 = shields.
    
    [SerializeField]
    private AudioClip _clip;

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);	
        
        if(transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Collided with:" + other.name);

            //access the palyer
            Player player = other.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);

            if (player != null)
            {
                if(powerupID == 0)
                {
                    //enable triple shot
                    player.TripleShotPowerupOn();
                }
                else if (powerupID == 1)
                {
                    //enable speed boost here
                    player.SpeedBoostPowerupOn();
                }
                else if (powerupID == 2)
                {
                    //enable shields
                    player.EnableShields();                   
                }
                
            }
            //destroy ourself
            Destroy(this.gameObject);
        }
       
    }


}
