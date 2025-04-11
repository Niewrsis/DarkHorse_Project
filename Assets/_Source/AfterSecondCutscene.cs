using SceneSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class AfterSecondCutscene : MonoBehaviour
{
    [SerializeField] private VideoPlayer player;
    private void Start()
    {
        StartCoroutine(Cor());
    }
    private IEnumerator Cor()
    {
        yield return new WaitForSeconds((float)player.clip.length);
        SceneChanger.ChangeScene(0);
    }
}
