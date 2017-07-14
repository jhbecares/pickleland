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
        PlayerPrefs.SetInt("ShieldSet", -1);
    }
	
	// Update is called once per frame
	void Update () {
        vidas = PlayerPrefs.GetInt("Lifes");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BalaEnemigo" && PlayerPrefs.GetInt("ShieldSet") != 1)
        {
            GameObject go = Utils.FindTaggedParent(other.gameObject);
            if (go == lastTriggerGo)
                return;
            lastTriggerGo = go;

            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            if (go != null && other.tag == "BalaEnemigo")
            {

                Destroy(other.gameObject);

                this.BlinkPlayer(4);

                // restar vida si la tuviera
                vidas--;
                // 
                if (vidas <= 0)
                {
                    // audio y destruccion del objeto
                    AudioSource.PlayClipAtPoint(clipDeath, this.gameObject.transform.position);
                    Destroy(this.gameObject);
                    Application.LoadLevel("GameOver");
                }
                else
                {
                    AudioSource.PlayClipAtPoint(clipHit, other.transform.position);
                }

                PlayerPrefs.SetInt("Lifes", vidas);
            }
        }
        else if (other.tag == "BalaEnemigo" && PlayerPrefs.GetInt("ShieldSet") == 1)
        {
            GameObject go = Utils.FindTaggedParent(other.gameObject);
            if (go == lastTriggerGo)
                return;
            lastTriggerGo = go;

            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            if (go != null)
            {
                Destroy(other.gameObject);
                AudioSource.PlayClipAtPoint(clipHit, other.transform.position);
            }
        }
        else if (other.tag == "EnemyPickle" && PlayerPrefs.GetInt("ShieldSet") == 1)
        {
            GameObject go = Utils.FindTaggedParent(other.gameObject);
            if (go == lastTriggerGo)
                return;
            lastTriggerGo = go;

            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            if (go != null)
            {
                Destroy(other.gameObject);
                // TODO: sonido?
               // AudioSource.PlayClipAtPoint(clipHit, other.transform.position);
            }
            PlayerPrefs.SetInt("ShieldSet", -1);
            ShieldManager.shieldCount = ShieldManager.shieldTime;
        }
        else if (other.tag == "EnemyPickle" && PlayerPrefs.GetInt("ShieldSet") == -1)
        {
            // borrar vida
            GameObject go = Utils.FindTaggedParent(other.gameObject);
            if (go == lastTriggerGo)
                return;
            lastTriggerGo = go;

            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            if (go != null)
            {
                Destroy(other.gameObject);

                this.BlinkPlayer(4);

                // restar vida si la tuviera
                vidas--;
                // 
                if (vidas <= 0)
                {
                    // audio y destruccion del objeto
                    // AudioSource.PlayClipAtPoint(clipDeath, this.gameObject.transform.position);
                    
                    Destroy(this.gameObject);
                    Application.LoadLevel("GameOver");
                }
                else
                {
                    AudioSource.PlayClipAtPoint(clipHit, other.transform.position);
                }

                PlayerPrefs.SetInt("Lifes", vidas);
            }
        } 
    }

    void BlinkPlayer(int numBlinks)
    {
        StartCoroutine(DoBlinks(numBlinks, 0.05f));
    }

    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for (int i = 0; i < numBlinks * 2; i++)
        {
            //toggle renderer
            this.gameObject.GetComponent<Renderer>().enabled = !this.gameObject.GetComponent<Renderer>().enabled;

            //wait for a bit
            yield return new WaitForSeconds(seconds);
        }

        //make sure renderer is enabled when we exit
        this.gameObject.GetComponent<Renderer>().enabled = true;
    }
}
