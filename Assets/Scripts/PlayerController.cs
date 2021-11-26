using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public MouseLook camera;
    public LayerMask InteractableLayers;

	bool move;
	Vector3 newPos;

	private void Update()
	{

		if (Input.GetKeyDown(KeyCode.E) )
		{
			RaycastHit hit;
			if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 100, InteractableLayers))
			{
				
				camera.xRotationClamp = hit.transform.GetComponentInParent<Interactable>().xRotationClamp;
				camera.yRotationClamp = hit.transform.GetComponentInParent<Interactable>().yRotationClamp;
				transform.eulerAngles = hit.transform.GetComponentInParent<Interactable>().playerRotation;
				move = true;
				newPos = hit.transform.GetComponentInParent<Interactable>().transform.position + hit.transform.GetComponentInParent<Interactable>().playerPositionOffset;
			}
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			camera.xRotationClamp = new Vector2(-90,90);
			camera.yRotationClamp = new Vector2(0,360);
			move = true;
			newPos = new Vector3(-2,0,4);
		}

		if (move)
		{
			transform.position = Vector3.Lerp(transform.position , newPos, 2 * Time.deltaTime);
			if(transform.position == newPos)
			{
				move = false;
			}
			
		}
	}
}
