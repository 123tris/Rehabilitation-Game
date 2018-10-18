using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageViewer : MonoBehaviour
{
    public MeasureDepth mMeasureDepth;
    public MultiSourceManager mMultiSource;

    public RawImage mRawImage;
    public RawImage mRawDepth;

    void Update()
    {
        mRawImage.texture = mMultiSource.GetColorTexture();

        mRawDepth.texture = mMeasureDepth.mDepthTexture;
    }
}
