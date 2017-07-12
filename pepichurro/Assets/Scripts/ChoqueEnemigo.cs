using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoqueEnemigo : MonoBehaviour {

    private int vidas = 3;
    public GameObject lastTriggerGo = null;
    public AudioClip clipHit;
    public AudioClip clipDeath;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.tag == "EnemyPickle" && other.tag == "Bala")
        {
            GameObject go = Utils.FindTaggedParent(other.gameObject);
            if (go == lastTriggerGo)
                return;
            lastTriggerGo = go;

            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            if (go != null && other.tag == "Bala")
            {

                Destroy(other.gameObject);

                // TODO parpadeo

                // restar vida si la tuviera
                vidas--;
                // 
                if (vidas <= 0)
                {
                    AudioSource.PlayClipAtPoint(clipDeath, this.gameObject.transform.position);
                    Destroy(this.gameObject);
                }
                else
                {
                    AudioSource.PlayClipAtPoint(clipHit, other.transform.position);
                }
            }
        }
    }
}
