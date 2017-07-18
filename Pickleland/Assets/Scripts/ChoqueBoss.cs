using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoqueBoss : MonoBehaviour {

    private int vidas = 300;
    public GameObject lastTriggerGo = null;
    public AudioClip clipHit;
    public AudioClip clipDeath;

    public static int killed = 0;
    public int everyDeathNumber = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.tag == "Boss" && other.tag == "Bala")
        {
            GameObject go = Utils.FindTaggedParent(other.gameObject);
            if (go == lastTriggerGo)
                return;
            lastTriggerGo = go;

            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            if (go != null && other.tag == "Bala")
            {
                Destroy(other.gameObject);

                // restar vida si la tuviera
                vidas--;
                // 
                if (vidas <= 0)
                {
                    // Sumar puntos
                    int points = PlayerPrefs.GetInt("Points");
                    points += 50;
                    PlayerPrefs.SetInt("Points", points);

                    // audio y destruccion del objeto
                    AudioSource.PlayClipAtPoint(clipDeath, this.gameObject.transform.position);
                    Destroy(this.gameObject);

                    killed++;

                    int currentLives = PlayerPrefs.GetInt("Lifes");
                    if (killed % everyDeathNumber == 0 && currentLives < 5)
                    {
                        print("subiendo viiiida loooko");
                        PlayerPrefs.SetInt("Lifes", currentLives + 1);
                    }

                }
                else
                {
                    AudioSource.PlayClipAtPoint(clipHit, other.transform.position);
                    this.BlinkPlayer(2); // llamamos a la corutina de parpadeo 
                }

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
            this.gameObject.GetComponentInChildren<Renderer>().enabled = !this.gameObject.GetComponentInChildren<Renderer>().enabled;

            //wait for a bit
            yield return new WaitForSeconds(seconds);
        }

        //make sure renderer is enabled when we exit
        this.gameObject.GetComponentInChildren<Renderer>().enabled = true;
    }
}
