using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    [SerializeField] private GameObject slice;
    [SerializeField] private PostProcessVolume volume;
    [SerializeField] private Camera _camera;
    
    
    private Vignette _vignette;
    

    #region singleton

    public static PostProcessingController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion
    private void Start()
    {
        PostProcessProfile profile = volume.profile;
        _vignette = profile.GetSetting<Vignette>();
        _camera = Camera.main;
    }

    public void VignetteCenterControl()
    {
        
        Vector3 slicePos = slice.transform.position;
        Vector3 centerPos = _camera.WorldToViewportPoint(slicePos);
        centerPos = Camera.main.WorldToViewportPoint(slice.transform.position);
        _vignette.center.value = centerPos;
    }
}
