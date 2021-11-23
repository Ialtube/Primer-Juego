using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{

    public Text collectedFruits;
    public int frutas;
    public GameObject transition;

    // Update is called once per frame
    private void Start()
    {
        frutas = transform.childCount;
    }
    void Update()
    {
        FruitsCollected();
        collectedFruits.text = transform.childCount.ToString();

    }
    public void FruitsCollected()
    {
        if (transform.childCount == 0)
        {
            transition.SetActive(true);
            Invoke("ChangeScene", 1);
            PlayerPrefs.DeleteAll();
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
