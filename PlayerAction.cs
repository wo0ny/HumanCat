using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
	public Vector3 vector;
	public Vector3 dirVec;
	static public PlayerManager instance;
	public float normalSpeed;
	public float runSpeed;

	public Animator anim;
	public Rigidbody2D rigid;
	public float h; 
	public float v;

	public int direction;
	protected bool isHorizonMove;

	public GameManager manager;

}
