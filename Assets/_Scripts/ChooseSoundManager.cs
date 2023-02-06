using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ChooseSoundManager : MonoBehaviour
{
    public Camera arCamera;
    public float front;
    public GameObject sound1Sphere;
    public GameObject sound2Sphere;
    public GameObject cylinder;
    public Slider maxSlider;
    public Slider minSlider;
    public TextMeshProUGUI maxDist;
    public TextMeshProUGUI minDist;

    // Start is called before the first frame update
    void Start()
    {
        OnSliderValueChanged();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClearButtonClicked()
    {
        SceneManager.LoadScene("ChooseSound");
    }

    public void OnSound1ButtonClicked()
    {
        Transform camTrans = arCamera.transform;
        Vector3 spherePos = camTrans.position + front * camTrans.forward;
        Instantiate(sound1Sphere, spherePos, Quaternion.identity);
    }

    public void OnSound2ButtonClicked()
    {
        Transform camTrans = arCamera.transform;
        Vector3 spherePos = camTrans.position + front * camTrans.forward;
        Instantiate(sound2Sphere, spherePos, Quaternion.identity);        
    }

    public void OnSliderValueChanged()
    {
        float max = maxSlider.value;
        float min = minSlider.value;
        maxSlider.minValue = min;   // MaxSliderの最小値をMinSliderの現在値に変更
        maxDist.text = max.ToString();
        minDist.text = min.ToString();

        // Cylinderの長さを変更
        Vector3 cylinderScale = cylinder.transform.localScale;
        cylinderScale.y = 0.5f * (max -min);
        cylinder.transform.localScale = cylinderScale;

        // Cylinderを移動
        Vector3 cylinderPos = cylinder.transform.localPosition;
        cylinderPos.z = min + (max - min) / 2;
        cylinder.transform.localPosition = cylinderPos;        
    }
}
