using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 이 스크립트가 부착된 오브젝트의 모든 자식 오브젝트를 순회합니다.
        foreach (Transform child in transform)
        {
            // 자식 오브젝트에 Capsule Collider 컴포넌트가 이미 있는지 확인합니다.
            if (child.GetComponent<CapsuleCollider>() == null)
            {
                // 자식 오브젝트에 Capsule Collider 컴포넌트를 추가합니다.
                child.gameObject.AddComponent<CapsuleCollider>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
