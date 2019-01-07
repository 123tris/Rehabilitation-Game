using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestRawImageDepth : MonoBehaviour
{
    MeasureDepthCalibration mdc;

    RawImage m_RawImage;

    void Start()
    {
        mdc = FindObjectOfType<MeasureDepthCalibration>();
        m_RawImage = GetComponent<RawImage>();
    }

    public void Update()
    {
        m_RawImage.texture = mdc.mDepthTexture;
    }
}
