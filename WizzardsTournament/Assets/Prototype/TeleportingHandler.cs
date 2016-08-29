using UnityEngine;
using System.Collections;

public class TeleportingHandler : MonoBehaviour {

    public Camera camera;
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray teleportingHit = new Ray(camera.transform.position, camera.transform.forward);

        Debug.DrawRay(camera.transform.position, camera.transform.forward);
        if (Input.GetKeyDown(KeyCode.T))
        {
            

            if (Physics.Raycast(teleportingHit, out hit))
            {
                if (hit.collider.tag.Equals("Platform"))
                {
                    Transform teleportingPosition = hit.collider.GetComponent<Prototype.PlatformHandler>().spawningPosition;
                    transform.position = teleportingPosition.position;
                }
            }
        }
    }
}
