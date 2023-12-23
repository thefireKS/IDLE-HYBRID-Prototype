using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TurretCapturing : MonoBehaviour
{
    [SerializeField] private TurretParameters _turretParameters;
    [SerializeField] private Image _barImage;
    [SerializeField] private MeshRenderer _turretBody;

    private TurretAttack _turretAttack;
    
    public bool _isCaptured;
    
    private bool _isAbleToCapture = false;
    public int _currentCapturersCount = 0;
    private float _currentCaptureTimer = 0f, _captureTime;
    private Color _captureColor;
    private Material _captureMaterial;
    public capturedBy _captureData = capturedBy.NOBODY;

    public enum capturedBy { NOBODY, PLAYER, ENEMY }

    private void Start()
    {
        _turretAttack = GetComponent<TurretAttack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_isCaptured && _captureData == capturedBy.ENEMY)
            {
                _isCaptured = false;
                _currentCaptureTimer = 0f;
            }

            _captureTime = _turretParameters.playerParameters.captureTime;
            _captureColor = _turretParameters.playerColor;
            _captureMaterial = _turretParameters.playerMaterial;
            _captureData = capturedBy.PLAYER;
        }
        else if (other.CompareTag("Enemy"))
        {
            if (_isCaptured && _captureData == capturedBy.PLAYER)
            {
                _isCaptured = false;
                _currentCaptureTimer = 0f;
            }
            
            _captureTime = _turretParameters.enemyParameters.captureTime;
            _captureColor = _turretParameters.enemyColor;
            _captureMaterial = _turretParameters.enemyMaterial;
            _captureData = capturedBy.ENEMY;
        }
        else
            return;
        
        
        _currentCapturersCount++;
        _isAbleToCapture = true;

        _barImage.fillAmount = 0;
        _barImage.color = _captureColor;

        if (_currentCapturersCount > 1)
            _currentCaptureTimer = 0f;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player") && !other.CompareTag("Enemy")) return;
        
        _isAbleToCapture = false;
        _currentCapturersCount--;
    }

    private void Update()
    {
        if(_isCaptured || _currentCapturersCount > 1) return;
        
        if (_isAbleToCapture)
        {
            _currentCaptureTimer += Time.deltaTime;
            if (_currentCaptureTimer > _captureTime)
            {
                _isCaptured = true;
                _turretBody.material = _captureMaterial;
                _turretAttack.SetTurretTarget(_captureData);
            }
        }
        else
        {
            _currentCaptureTimer -= Time.deltaTime;
            if (_currentCaptureTimer < 0f)
                _currentCaptureTimer = 0f;
        }
        
        _barImage.fillAmount = _currentCaptureTimer / _captureTime;
    }
}
