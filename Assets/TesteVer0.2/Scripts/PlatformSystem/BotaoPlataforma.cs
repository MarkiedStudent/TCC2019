﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoPlataforma : MonoBehaviour {

    public GameObject plataforma;
    public Vector3 distancia;
    public float velocidade;
    public bool negativo;
    public bool travado;
    public Renderer renderer;

    ActivePlatform plataformaAtiva;
    bool apertado;

    // Use this for initialization
    void Start ()
    {
        plataformaAtiva = plataforma.GetComponent<ActivePlatform>();
        apertado = false;
        renderer = GetComponent<Renderer>();

        if(travado)
        {
            renderer.material.SetColor("_Color", Color.blue);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!travado && !apertado)
        {
            renderer.material.SetColor("_Color", Color.cyan);
        }

        if (!travado && apertado)
        {
            if (!plataformaAtiva.Foi && !negativo)
            {
                plataformaAtiva.Vai(distancia, velocidade);
            }
            else if (plataformaAtiva.Foi && negativo)
            {
                plataformaAtiva.Volta(distancia, velocidade);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!travado && Input.GetKeyDown(KeyCode.E))
        {
            apertado = true;
            renderer.material.SetColor("_Color", Color.black);
        }
    }
}
