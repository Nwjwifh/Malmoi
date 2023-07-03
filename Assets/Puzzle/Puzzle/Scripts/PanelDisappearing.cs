using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDisappearing : MonoBehaviour
{
    public float delay = 10f; // �г��� ������µ������� ������ �ð�
    private bool isPanelActive = true; // �г��� Ȱ��ȭ�� �������� ����

    void Start()
    {
        StartCoroutine(DisappearAfterDelay());
    }

    IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        // ������ �ð��� ���� �Ŀ� ����� �ڵ�
        isPanelActive = false;
        gameObject.SetActive(false); // �г� ��Ȱ��ȭ
    }

    void Update()
    {
        if (isPanelActive)
        {
            // �г��� Ȱ��ȭ�� ���� �߰����� ������ �ʿ��� ��� ���⿡ �ۼ��մϴ�.
        }
    }
}
