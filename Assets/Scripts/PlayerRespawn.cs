using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour

{

    private float checkPointX, checkPointY;

    public Animator animator;


    void Start()
    {
        if (PlayerPrefs.GetFloat("checkPointX") != 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointX"), (PlayerPrefs.GetFloat("checkPointY"))));
        }
        
    }

    public void checkPointConfirm(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointX", x);
        PlayerPrefs.SetFloat("checkPointY", y);
    }

    public void PlayerDamage()
    {
        animator.Play("hitFrog");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
