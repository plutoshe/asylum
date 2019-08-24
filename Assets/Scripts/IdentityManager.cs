using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdentityManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image Identity01;
    public Animator FemaleGlow;
    public Animator FemaleShow;
    public Image Identity02;
    public Animator MaleShow;

    public Text GameText;
    private int IdentityNum;
    void Start()
    {
        FemaleGlow.gameObject.SetActive(false);

        FemaleGlow.SetBool("GlowStart", false);
        FemaleShow.SetBool("Show", false);
        MaleShow.SetBool("Show", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            FemaleGlow.gameObject.SetActive(true);

            FemaleGlow.SetBool("GlowStart", true);
            FemaleShow.SetBool("Show", true);
            MaleShow.SetBool("Show", false);
            IdentityNum = 1;

        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            FemaleGlow.gameObject.SetActive(false);

            FemaleGlow.SetBool("GlowStart", false);
            FemaleShow.SetBool("Show", false);
            MaleShow.SetBool("Show", true);

            IdentityNum = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if(IdentityNum == 1)
            {
                GameText.text = "Female Character has been selected.";
            }
            else if(IdentityNum == 2)
            {
                GameText.text = "Male Character has been selected.";
            }


        }
    }
}
