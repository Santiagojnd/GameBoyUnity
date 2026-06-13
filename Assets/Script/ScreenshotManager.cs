using UnityEngine;

public class ScreenshotManager : MonoBehaviour
{
    public void TomarCaptura()
    {
        string nombreArchivo = "captura_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";

        ScreenCapture.CaptureScreenshot(nombreArchivo);

        Debug.Log("Captura guardada: " + nombreArchivo);
    }
}