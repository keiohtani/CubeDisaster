using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCollision : MonoBehaviour {
    
    public static int score = 0;
    public AudioClip audioClip;
    public ParticleSystem particle;

    private AudioSource audioSource;

	private void Start()
	{
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
	}

	private IEnumerator DestroyGameObject(){
        gameObject.GetComponent<BoxCollider>().enabled = false;
        score += 100;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    void GameOver()
    {
        GameObject.Find("Canvas").transform.Find("ScorePanel").gameObject.SetActive(true);
        GameObject.Find("FinalScore").GetComponent<Text>().text = "Score\n" + OnCollision.score;
    }

	private void OnCollisionEnter(Collision collision)
	{
        audioSource.Play();
        if (collision.gameObject.name == "GroundCube"){
            Instantiate(particle, transform.position, transform.rotation);
            particle.Emit(1);
            //Destroy(gameObject);
            StartCoroutine(DestroyGameObject());

        }

        if (collision.gameObject.name == "MainCube"){
            Destroy(collision.gameObject);
            GameOver();
        }
	}

}
