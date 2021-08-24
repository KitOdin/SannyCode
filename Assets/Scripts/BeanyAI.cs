using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class BeanyAI : MonoBehaviour
{
	GameObject[] wanderPoints;
	public AudioClip BEAN;
	AudioSource beann;
	// Use this for initialization
	void Start ()
	{
		wanderPoints = GameObject.FindGameObjectsWithTag ("pointy");
		beann = GetComponent<AudioSource> ();
		RESET();
	}

	// Update is called once per frame
	void Update ()
	{
		if (GetComponent<NavMeshAgent> ().velocity.magnitude <= 0.1f) 
		{
			RESET ();
		}
	}
	void RESET()
	{
		GetComponent<NavMeshAgent> ().SetDestination (wanderPoints [UnityEngine.Random.Range (0, wanderPoints.Length - 1)].transform.position);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			other.transform.position = wanderPoints [UnityEngine.Random.Range (0, wanderPoints.Length - 1)].transform.position;
			beann.PlayOneShot (BEAN);
		}
	}
}