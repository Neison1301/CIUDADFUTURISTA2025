using UnityEngine;
using UnityEditor;

public static class ConstruirCiudad
{
    [MenuItem("TA5/Construir Ciudad")]
    static void Build()
    {
        foreach (var n in new[]{"Ciudad","Piso","Camino"})
        {
            var old = GameObject.Find(n);
            if(old != null) Object.DestroyImmediate(old);
        }

        Material matPiso = GetMat("Mat_Piso", new Color(0.15f,0.18f,0.22f));
        Material matAzul = GetMat("Mat_AzulFuturista", new Color(0.1f,0.6f,1f));
        Material matGris = GetMat("Mat_GrisFuturista", new Color(0.6f,0.65f,0.7f));
        Material matNeon = GetMat("Mat_Neon", new Color(0f,1f,0.9f));
        matNeon.SetColor("_EmissionColor", new Color(0f,1f,0.9f));
        matNeon.EnableKeyword("_EMISSION");

        GameObject ciudad = new GameObject("Ciudad");

        var piso = GameObject.CreatePrimitive(PrimitiveType.Plane);
        piso.name = "Piso_Ciudad";
        piso.transform.position = new Vector3(0,0,30);
        piso.transform.localScale = new Vector3(6,1,10);
        piso.GetComponent<Renderer>().material = matPiso;
        piso.transform.parent = ciudad.transform;

        var camino = GameObject.CreatePrimitive(PrimitiveType.Cube);
        camino.name = "Camino_Principal";
        camino.transform.position = new Vector3(0,0.05f,30);
        camino.transform.localScale = new Vector3(4,0.1f,65);
        camino.GetComponent<Renderer>().material = matNeon;
        camino.transform.parent = ciudad.transform;

        GameObject portal = new GameObject("ZonaA_Portal");
        portal.transform.parent = ciudad.transform;
        CrearCubo("Portal_Columna_Izq", new Vector3(-3,2,0), new Vector3(1,4,1), matAzul, portal);
        CrearCubo("Portal_Columna_Der", new Vector3(3,2,0), new Vector3(1,4,1), matAzul, portal);
        CrearCubo("Portal_Arco_Superior", new Vector3(0,4.5f,0), new Vector3(7,1,1), matGris, portal);
        CrearCubo("Portal_Cartel", new Vector3(0,3.5f,0), new Vector3(4,0.8f,0.3f), matNeon, portal);

        GameObject plaza = new GameObject("ZonaB_Plaza");
        plaza.transform.parent = ciudad.transform;
        var basePlaza = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        basePlaza.name = "Plaza_Base";
        basePlaza.transform.position = new Vector3(0,0.2f,30);
        basePlaza.transform.localScale = new Vector3(8,0.4f,8);
        basePlaza.GetComponent<Renderer>().material = matGris;
        basePlaza.transform.parent = plaza.transform;

        CrearCubo("Edificio_1", new Vector3(-10,5,25), new Vector3(5,10,5), matAzul, plaza);
        CrearCubo("Edificio_2", new Vector3(10,7,25), new Vector3(5,14,5), matGris, plaza);
        CrearCubo("Edificio_3", new Vector3(-10,4,38), new Vector3(5,8,5), matGris, plaza);
        CrearCubo("Edificio_4", new Vector3(10,6,38), new Vector3(5,12,5), matAzul, plaza);
        CrearCubo("Edificio_5_Plaza", new Vector3(-6,3,32), new Vector3(3,6,3), matAzul, plaza);
        CrearCubo("Edificio_6_Plaza", new Vector3(6,3,28), new Vector3(3,6,3), matGris, plaza);

        var luzPlaza = new GameObject("Luz_Plaza");
        luzPlaza.transform.position = new Vector3(0,8,30);
        var pl = luzPlaza.AddComponent<Light>();
        pl.type = LightType.Point; pl.intensity = 80; pl.range = 30; pl.color = Color.cyan;
        luzPlaza.transform.parent = plaza.transform;

        GameObject torre = new GameObject("ZonaC_Torre");
        torre.transform.parent = ciudad.transform;
        var torreCil = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        torreCil.name = "Torre_Observacion";
        torreCil.transform.position = new Vector3(0,10,60);
        torreCil.transform.localScale = new Vector3(3,20,3);
        torreCil.GetComponent<Renderer>().material = matAzul;
        torreCil.transform.parent = torre.transform;

        var esfera = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        esfera.name = "Torre_Cupula";
        esfera.transform.position = new Vector3(0,21,60);
        esfera.transform.localScale = new Vector3(4,2,4);
        esfera.GetComponent<Renderer>().material = matNeon;
        esfera.transform.parent = torre.transform;

        CrearCubo("Torre_Base", new Vector3(0,1,60), new Vector3(8,2,8), matGris, torre);

        var cam = Camera.main;
        if(cam != null) cam.transform.position = new Vector3(0,2,-8);

        Debug.Log("Ciudad Futurista 2050 construida");
    }

    static void CrearCubo(string nombre, Vector3 pos, Vector3 escala, Material mat, GameObject padre)
    {
        var o = GameObject.CreatePrimitive(PrimitiveType.Cube);
        o.name = nombre;
        o.transform.position = pos;
        o.transform.localScale = escala;
        o.GetComponent<Renderer>().material = mat;
        o.transform.parent = padre.transform;
    }

    static Material GetMat(string nombre, Color color)
    {
        string path = "Assets/_TA5/Materials/" + nombre + ".mat";
        var m = AssetDatabase.LoadAssetAtPath<Material>(path);
        if(m == null)
        {
            m = new Material(Shader.Find("Universal Render Pipeline/Lit"));
            if(m.shader == null) m = new Material(Shader.Find("Standard"));
            m.color = color;
            AssetDatabase.CreateAsset(m, path);
        }
        return m;
    }
}