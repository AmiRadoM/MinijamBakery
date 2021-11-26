using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public MouseLook camera;
    public LayerMask InteractableLayers;

	private void Update()
	{
		if (Input.GetKey(KeyCode.E))
		{
			RaycastHit hit;
			print("A");
			if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 100, InteractableLayers))
			{
				transform.position = hit.transform.position + hit.transform.GetComponentInParent<Interactable>().playerPositionOffset;
				transform.eulerAngles = hit.transform.GetComponentInParent<Interactable>().playerRotation;
			}
		}
	}
}
