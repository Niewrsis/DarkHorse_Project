using SceneSystem;
using System.Collections;
using UnityEngine;

public class AfterFirstCutscene : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void Start()
    {
        StartCoroutine(Cor());
    }
    private IEnumerator Cor()
    {
        yield return new WaitForSeconds(22);
        SceneChanger.ChangeScene(7);
    }
}
