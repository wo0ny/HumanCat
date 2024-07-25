using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public string startPoint;
    private PlayerManager thePlayer;
	private CameraManager theCamera;
    
    void Start()
    {
        theCamera = FindObjectOfType<CameraManager>();
        thePlayer = FindObjectOfType<PlayerManager>();

        if (theCamera == null || thePlayer == null)
        {
            Debug.LogError("The scene is missing a CameraManager or PlayerManager.");
            return; // Early exit if we didn't find what we're looking for
        }
    
        if (startPoint == thePlayer.currentMapName)
        {
            theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
