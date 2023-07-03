using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    // 이 함수는 버튼 클릭 시 호출됩니다.
    public void ExitGame()
    {
        // 게임 종료 코드
        Application.Quit();
    }
}
