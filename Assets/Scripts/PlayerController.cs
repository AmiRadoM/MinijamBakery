using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public MouseLook camera;
    public LayerMask InteractableLayers;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			RaycastHit hit;
			if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 100, InteractableLayers))
			{
				GameObject oven = hit.transform.GetComponentInParent<Interactable>().gameObject;
				transform.position = oven.transform.position + hit.transform.GetComponentInParent<Interactable>().playerPositionOffset;
				transform.eulerAngles = hit.transform.GetComponentInParent<Interactable>().playerRotation;
				camera.xRotationClamp = hit.transform.GetComponentInParent<Interactable>().xRotationClamp;
				camera.yRotationClamp = hit.transform.GetComponentInParent<Interactable>().yRotationClamp;
			}
		}
	}
}
