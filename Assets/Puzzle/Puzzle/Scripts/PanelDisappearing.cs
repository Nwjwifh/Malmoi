using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDisappearing : MonoBehaviour
{
    public float delay = 10f; // 패널이 사라지는데까지의 딜레이 시간
    private bool isPanelActive = true; // 패널이 활성화된 상태인지 여부

    void Start()
    {
        StartCoroutine(DisappearAfterDelay());
    }

    IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        // 딜레이 시간이 지난 후에 실행될 코드
        isPanelActive = false;
        gameObject.SetActive(false); // 패널 비활성화
    }

    void Update()
    {
        if (isPanelActive)
        {
            // 패널이 활성화된 동안 추가적인 동작이 필요한 경우 여기에 작성합니다.
        }
    }
}
