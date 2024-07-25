using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartdiaBox : MonoBehaviour
{
    public GameObject dialogueBox; // Inspector에서 할당할 대화창 GameObject

    private const string DialogueBoxKey = "DialogueBoxActive";
    void Start()
    {
        // 대화창의 활성화 상태를 PlayerPrefs에서 로드합니다.
        // 기본값은 true로 설정하여 처음 게임을 시작할 때 대화창이 활성화되게 합니다.
        bool isActive = PlayerPrefs.GetInt(DialogueBoxKey, 1) == 1;

        dialogueBox.SetActive(isActive);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // 엔터 키가 눌렸을 때
        {
            dialogueBox.SetActive(false); // 대화창 비활성화
            PlayerPrefs.SetInt(DialogueBoxKey, 0); // 대화창의 상태를 비활성화로 저장합니다.
        }
    }
}
