using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManagerStartMenu : MonoBehaviour
{
    [SerializeField] private UIDocument _document;
    [SerializeField] private string _sceneName;
    
    [Header("Audio")]
    [SerializeField] private AudioClip _EnteraudioClip;
    [SerializeField] private AudioClip _ClickaudioClip;
    [SerializeField] private AudioSource _audioSource;

    private Button btnStart;
    
    private List<Button> btns;

    void OnEnable()
    {
        if (!_document)
        {
            _document = GetComponent<UIDocument>();
        }

        if (_document)
        {
            btnStart = _document.rootVisualElement.Q<Button>("btn-start");
            btnStart?.RegisterCallback<ClickEvent>(OnStartClicked);
            
            btns = _document.rootVisualElement.Query<Button>().ToList();
            foreach (var btn in btns)
            {
                btn.RegisterCallback<PointerEnterEvent>(OnPointerEntered);
            }
        }
    }

    private void OnPointerEntered(PointerEnterEvent evt)
    {
        _audioSource.PlayOneShot(_EnteraudioClip);
    }

    private void OnStartClicked(ClickEvent evt)
    {
       _audioSource.PlayOneShot(_ClickaudioClip);
       StartCoroutine(AfterClick());
    }

    private IEnumerator AfterClick()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(_sceneName);
    }
}
