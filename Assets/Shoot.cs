using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
  public GameObject ball; //reference to the ball prefab, set in editor
  private Vector3 throwSpeed = new Vector3(0, 16, 3.5f); //This value is a sure basket, we'll modify this using the forcemeter
  public Vector3 ballPos; //starting ball position
  private bool thrown = false; //if ball has been thrown, prevents 2 or more balls
  private GameObject ballClone; //we don't use the original prefab

  public GameObject availableShotsGO; //ScoreText game object reference
  private int availableShots = 5;

  public GameObject gameOver; //game over text
	// Use this for initialization
	void Start()
	{
	    /* Increase Gravity */
	    Physics.gravity = new Vector3(0, -20, 0);
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{
			/* Shoot ball on Tap */
      if (Input.GetButton("Fire1") && !thrown && availableShots > 0)
      {
          thrown = true;
          availableShots--;
          availableShotsGO.GetComponent<UnityEngine.UI.Text>().text = availableShots.ToString();

          ballClone = Instantiate(ball, ballPos, transform.rotation) as GameObject;
          throwSpeed.y = throwSpeed.y + 1/1000;
          throwSpeed.z = throwSpeed.z + 1/1000;

          ballClone.GetComponent<Rigidbody>().AddForce(throwSpeed, ForceMode.Impulse);
          GetComponent<AudioSource>().Play(); //play shoot sound
      }
			/* Remove Ball when it hits the floor */

      if (ballClone != null && ballClone.transform.position.y < -16)
      {
          Destroy(ballClone);
          thrown = false;
          throwSpeed = new Vector3(0, 16, 3.5f);//Reset perfect shot variable
					/* Check if out of shots */

            if (availableShots == 0)
            {
                Instantiate(gameOver, new Vector3(0.31f, 0.2f, 0), transform.rotation);
                Invoke("restart", 2);
            }
        }
    }
		void restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
