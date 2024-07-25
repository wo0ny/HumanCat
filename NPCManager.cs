using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class NPCMove
{
    [Tooltip("NPCMove를 체크할때 NPC가 움직임")] 
    public bool NPCmove;

    public string[] direction;  //npc 움직이는 방향
    
    [Range(1,5)]
    public int frequency;    //npc 움직이는 방향의 빠르기 속도
    
    
}

public class NPCManager : MonoBehaviour
{
    [SerializeField]
    public NPCMove npc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
