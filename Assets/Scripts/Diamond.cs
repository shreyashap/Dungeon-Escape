using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int gem = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
           
            if(player != null)
            {
                player.Diamonds += gem;
                Destroy(this.gameObject);

            }

        }
    }
}
