using UnityEngine;

public class KayakHealthIndicator : MonoBehaviour
{
    private MaterialPropertyBlock m_PropertyBlock;
    private Renderer kayak;
    readonly Color[] colorArray = new Color[4];
    private GameManager gameManager;

    private void Awake()
    {
        #region Colors
        colorArray[0] = new Color(0.765283f, 0.13546f, 0.1722588f);    // red
        colorArray[1] = new Color(0.7529413f, 0.3294118f, 0.1982467f); // orange
        colorArray[2] = new Color(0.7529413f, 0.9803922f, 0.1960784f);  // yellow
        colorArray[3] = new Color(0.2196079f, 0.5882353f, 0.1372549f);  // green    
        #endregion
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        m_PropertyBlock = new MaterialPropertyBlock();
        kayak = GetComponent<Renderer>();
    }

    void Update()
    {
        SetColorIndicator(gameManager.Health);
    }

    public void SetColorIndicator(int _currentHealth)
    {

        if (_currentHealth <= 25)
        {
            m_PropertyBlock.SetColor("_Color", colorArray[0]);
            kayak.GetComponent<Renderer>().SetPropertyBlock(m_PropertyBlock);
        }
        else if (_currentHealth > 25 && _currentHealth <= 50)
        {
            m_PropertyBlock.SetColor("_Color", colorArray[1]);
            kayak.GetComponent<Renderer>().SetPropertyBlock(m_PropertyBlock);
        }
        else if (_currentHealth > 50 && _currentHealth <= 75)
        {
            m_PropertyBlock.SetColor("_Color", colorArray[2]);
            kayak.GetComponent<Renderer>().SetPropertyBlock(m_PropertyBlock);
        }
        else if (_currentHealth > 75)
        {
            m_PropertyBlock.SetColor("_Color", colorArray[3]);
            kayak.GetComponent<Renderer>().SetPropertyBlock(m_PropertyBlock);
        }
    }
}

