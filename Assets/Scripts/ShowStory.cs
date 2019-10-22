using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowStory : MonoBehaviour
{

    public Text Story;
    public bool show = true;
    // Start is called before the first frame update
    void Start()
    {
      Story = GetComponent<Text> ();
      Story.text="Levi Ackermann, often formally referred to as Captain Levi, is the squad captain of the Special Operations Squad within the Scout Regiment, and is said to be humanity's strongest soldier";
      Story.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.T))
      {
          show=!show;
          Story.enabled = show;
      }
    }
}
