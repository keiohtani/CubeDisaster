using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropCubes : MonoBehaviour {

    public GameObject startMenuPanel;
    public GameObject scorePanel;
    public Transform enemy;
    int dropRate = 70;
    bool isDropping = false;

	// Use this for initialization
	void Start () {
        startMenuPanel.SetActive(true);
        scorePanel.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
        if(isDropping){
            if (Time.frameCount % dropRate == 0)
            {
                if (dropRate > 10)
                {
                    dropRate--;
                }

                Instantiate(enemy, new Vector3(Random.Range(-9, 9), transform.position.y, transform.position.z), transform.rotation, transform);

            }
        }
	}

    public void StartSwitch(){
        isDropping = !isDropping;
        startMenuPanel.SetActive(false);
    }

    public void Restart(){
        SceneManager.LoadScene("Main");
        OnCollision.score = 0;
    }
}
