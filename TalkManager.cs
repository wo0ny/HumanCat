using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    
    Dictionary<int, string[]> talkData;
    
        
    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    void GenerateData()
    {
        //id = 1000 : Maru 1001:siru 1002: Haru
        talkData.Add(1000, new string[]{"자네는 설마 시루마스터인가..?", "이게 무슨 일인지...."});
        talkData.Add(1002, new string[]{"오 자네는 시루마스터", "내 모자를 보았는가?"});
        
        
        //id = 100 : 표지판
        talkData.Add(100,new string[]{"하마찌 마을에 오신것을 환영합니다.", "하마찌 마을의 표지판이다."});
    }

    public string GetTalk(int id, int talkIndex) //Object의 id , string배열의 index
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex]; //해당 아이디의 해당
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}