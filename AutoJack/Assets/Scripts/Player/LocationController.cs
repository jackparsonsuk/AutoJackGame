using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocationController : MonoBehaviour
{
    Locations curLocation;
    public GameObject LocationText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enteredTag = collision.gameObject.tag;
        var newLocation = getLocation(enteredTag);
        if (newLocation != curLocation)
        {
            curLocation = newLocation;
            updateLocationText();
        }
    }

    private void updateLocationText()
    {

        switch (curLocation)
        {
            case Locations.grass:
                LocationText.GetComponent<TextMeshProUGUI>().text = "Welcome to the grass lands, nice and easy.";
                break;
            case Locations.sand:
                LocationText.GetComponent<TextMeshProUGUI>().text = "Welcome to the sand lands, its a bit dry here.";
                break;
            case Locations.water:
                LocationText.GetComponent<TextMeshProUGUI>().text = "Welcome to the water lands, time to get wet!";
                break;
        }
        LocationText.transform.gameObject.SetActive(true);
        StartCoroutine(DisableText(5));

    }

    private IEnumerator DisableText(int v)
    {
        yield return new WaitForSeconds(v);
        LocationText.transform.gameObject.SetActive(false);

    }

    private Locations getLocation(string enteredTag)
    {
        switch (enteredTag)
        {
            case "Grass":
                return Locations.grass;
            case "Sand":
                return Locations.sand;
            case "Water":
                return Locations.water;
            default:
                return Locations.grass;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        curLocation = Locations.grass;
    }


    public enum Locations
    {
        grass,
        sand,
        water
    }
}
