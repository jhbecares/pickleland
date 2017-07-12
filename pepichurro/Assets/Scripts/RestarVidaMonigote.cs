using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestarVidaMonigote : MonoBehaviour {

    private int vidas;
    public GameObject lastTriggerGo = null;
    public AudioClip clipHit;
    public AudioClip clipDeath;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        vidas = PlayerPrefs.GetInt("Lifes");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BalaEnemigo")
        {
            GameObject go = Utils.FindTaggedParent(other.gameObject);
            if (go == lastTriggerGo)
                return;
            lastTriggerGo = go;

            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            if (go != null && other.tag == "BalaEnemigo")
            {

                Destroy(other.gameObject);

                // TODO parpadeo

                // restar vida si la tuviera
                vidas--;
                // 
                if (vidas <= 0)
                {
                    // audio y destruccion del objeto
                    AudioSource.PlayClipAtPoint(clipDeath, this.gameObject.transform.position);
                    Destroy(this.gameObject);
                }
                else
                {
                    AudioSource.PlayClipAtPoint(clipHit, other.transform.position);
                }

                PlayerPrefs.SetInt("Lifes", vidas);
            }
        }
    }
}
