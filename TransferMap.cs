using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
	public string transferMapName;

	public Transform target;
	
	private PlayerManager thePlayer;
	private CameraManager theCamera;
	
	public BoxCollider2D targetBound;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>();
        theCamera = FindObjectOfType<CameraManager>();

    }

   private void  OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.name == "Player") 
		{
			thePlayer.currentMapName = transferMapName;
			theCamera.SetBound(targetBound);
			//SceneManager.LoadScene(transferMapName);
			theCamera.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, theCamera.transform.position.z);
			thePlayer.transform.position = target.transform.position;
		}
	}
}
