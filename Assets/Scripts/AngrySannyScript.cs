using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Collections;

public class AngrySannyScript : MonoBehaviour
{
	Transform player;
	AudioSource asas;
	public AudioClip bong;
	// Use this for initialization
	void Start ()
	{
		player = FindObjectOfType<PlayerController> ().transform;
		asas = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<NavMeshAgent> ().SetDestination (player.position);
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "Player")
		{
			SceneManager.LoadScene ("GameOver");
		}	
	}
}

