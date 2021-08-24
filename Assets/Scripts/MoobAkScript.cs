using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MoobAkScript : MonoBehaviour
{
	GameObject[] wanderPoints;
	public AudioClip BEAN;
	AudioSource moobAUDIO;
	// Use this for initialization
	void Start ()
	{
		wanderPoints = GameObject.FindGameObjectsWithTag ("pointy");
		moobAUDIO = GetComponent<AudioSource> ();
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
		if (other.gameObject.GetComponent<Rigidbody> () != null && other.gameObject.GetComponent<NavMeshAgent> () == null) 
		{
			other.gameObject.GetComponent<Rigidbody> ().AddForce (-other.transform.position, ForceMode.Impulse);
			moobAUDIO.PlayOneShot(BEAN);
		}
	}
}

