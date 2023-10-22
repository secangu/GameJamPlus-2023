using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene_sc : MonoBehaviour
{
    Animator animator;
    [SerializeField] AnimationClip fadeIn;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public IEnumerator ChangeScene(int scene)
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(fadeIn.length);
        SceneManager.LoadScene(scene);
    }
}
