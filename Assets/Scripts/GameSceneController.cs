using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    public float blockPointer = -10;
    public float safeMargin = 20;
    public GameObject[] blockPrefabs;
    public playerController player;
    public Camera gameCamera;
    public Text Score;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            gameCamera.transform.position = new Vector3
            (player.transform.position.x, 
            gameCamera.transform.position.y, 
            gameCamera.transform.position.z);

            Score.text = "Score :" + Mathf.Floor(player.transform.position.x);

            while(blockPointer < player.transform.position.x + safeMargin)
            {
                GameObject blockObject = GameObject.Instantiate<GameObject> (blockPrefabs[0]);
                blockObject.transform.SetParent (this.transform);
                blockController block = blockObject.GetComponent<blockController> ();

                GameObject blockObject2 = GameObject.Instantiate<GameObject> (blockPrefabs[1]);
                blockObject2.transform.SetParent (this.transform);
                blockController block2 = blockObject.GetComponent<blockController> ();

                blockObject.transform.position = new Vector3 (blockPointer + block.size/2,0,0);
                blockPointer += block.size;
            }
        }
        else
        {
            if(!isGameOver){
                isGameOver = true;
                Score.text  += "\nPress R to restart";
            }
        }
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene (SceneManager.GetActiveScene().name);
        }

    }
}
