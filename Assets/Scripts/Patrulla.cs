using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrulla : MonoBehaviour {

	[SerializeField]
	GameObject points;
	int totalPoints;

	int actualPoint;

	NavMeshAgent navMeshComponent;

	[SerializeField]
	GameObject player;

	public float distanceToChase = 3;

	// Use this for initialization
	void Start () {
		actualPoint = 0;
		navMeshComponent = GetComponent<NavMeshAgent>();
		totalPoints = points.transform.childCount;
		navMeshComponent.destination = points.transform.GetChild (actualPoint).transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if ((player.transform.position - transform.position).magnitude <= distanceToChase) {
			navMeshComponent.destination = player.transform.position;
		} else {
			if (navMeshComponent.remainingDistance <= 0.1) {
				actualPoint = (actualPoint + 1) % totalPoints;
				navMeshComponent.destination = points.transform.GetChild (actualPoint).transform.position;
			}
		}
	}
}
