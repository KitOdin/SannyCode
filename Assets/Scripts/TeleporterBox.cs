using UnityEngine;
using System.Collections;

public class TeleporterBox : MonoBehaviour
{
	GameObject[] wanderPoints;
	AudioSource temmie;
	public AudioClip bong;
	// Use this for initialization
	void Start ()
	{
		wanderPoints = GameObject.FindGameObjectsWithTag ("pointy");
		temmie = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision other)
	{
		if (other.transform.tag == "Player") 
		{
			other.transform.position = wanderPoints [UnityEngine.Random.Range (0, wanderPoints.Length - 1)].transform.position;
			temmie.PlayOneShot (bong);
		}
	}

}

