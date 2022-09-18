using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainbutt : MonoBehaviour
{
    // Start is called before the first frame update
    public int funny;
    public Animator curtain;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loading(int i)
    {
        funny = i;
        curtain.SetTrigger("FALL");
        
    }

    public void actuallyLoad()
    {
        SceneManager.LoadScene(funny);
    }
}
