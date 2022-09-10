using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneralController : MonoBehaviour
{
    public GameObject VersionNumberText;
    // Start is called before the first frame update
    void Start()
    {
        VersionNumberText.GetComponent<TextMeshProUGUI>().text = Application.version;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
