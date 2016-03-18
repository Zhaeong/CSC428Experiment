using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Transform SpawnPointA;
    public Transform SpawnPointB;

    public int numPickups;
    public int totalCubes;
    public int numFailures;
    public int numSeconds;
    private bool bRestart, bCheckpointB;

    private float timer;
	// Use this for initialization
	void Start () {
        numPickups = 0;
        numFailures = 0;
        timer = numSeconds;
        bRestart = false;
        bCheckpointB = false;
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer < 0)
            bRestart = true;

        if(numPickups == totalCubes)
            bRestart = true;
    }




    void OnGUI()
    {
        if (bRestart)
        {
            Time.timeScale = 0;
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 150, 100), "Restart"))
            {
                Time.timeScale = 1;
                bRestart = false;
                timer = numSeconds;
                SceneManager.LoadScene(0);
                

            }
        }
        GUI.Box(new Rect(10, 10, 150, 25), "Cubes Picked Up: " + numPickups + "/" + totalCubes);
        GUI.Box(new Rect(10, 40, 150, 25), "Errors: " + numFailures);
        GUI.Box(new Rect(Screen.width - 150, 10, 150, 25), "Time Left: " + timer.ToString("0"));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "CheckPoint2")
        {

            bCheckpointB = true;
        }
        if (other.tag == "Respawn")
        {
            numFailures += 1;
            if (bCheckpointB)
                transform.position = SpawnPointB.position;
            else
                transform.position = SpawnPointA.position;
        }
    }
}
