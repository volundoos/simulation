using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetect : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private string selectableTag = "CabinetDoor";
    [SerializeField] private Material defaultMaterial;

    private Transform _selection;
    public float speed = 1;

    private void Update()
    {
        if(_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 2000))
        {
            var selection = hit.transform;
            Debug.Log(transform.name);
            if(selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if(selection != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    if (Input.GetMouseButton(0))
                    {
                        Quaternion rotateDegrees = Quaternion.Euler(0, 90, 0);
                        selection.rotation = Quaternion.Lerp(selection.rotation, rotateDegrees, Time.deltaTime* speed);
                        
                    }
                }
                _selection = selection;
            }
        }
        
    }
}
