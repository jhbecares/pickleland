using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoqueEnemigo : MonoBehaviour {

    private int vidas = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        print("collider");
        print("game object: " + this.gameObject.tag);
        if (this.gameObject.tag == "EnemyPickle" && other.tag == "Bala")
        {
            GameObject go = Utils.FindTaggedParent(other.gameObject);
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            if (go != null && other.tag == "Bala")
            {

                Destroy(other.gameObject);
                
                print("On trigger enter: " + vidas);
                // TODO parpadeo

                // restar vida si la tuviera
                vidas--;
                // 
                if (vidas <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        else
        {
            print("que maji");
        }
    }
}
