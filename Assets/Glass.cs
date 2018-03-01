using UnityEngine;
using System.Collections;

public class Glass : MonoBehaviour {
		public GameObject score;
		public AudioClip basket;

    // Use this for initialization
    void Start () {
        Debug.Log("I am alive and my name is " + basket);
    }

    // Update is called once per frame
    void Update () {

    }

		void OnCollisionEnter()
    {
				AudioSource audio = GetComponent<AudioSource>();

				audio.Play();
    }

    void OnTriggerEnter()
    {
        int currentScore = int.Parse(score.GetComponent<UnityEngine.UI.Text>().text) + 1; //add 1 to the score
        score.GetComponent<UnityEngine.UI.Text>().text = currentScore.ToString();
        AudioSource.PlayClipAtPoint(basket, transform.position); //play basket sound
    }
}
