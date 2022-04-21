using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation


/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.


/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{
    [SerializeField] float sensitivityX = 1f;
    [SerializeField] float sensitivityY = 5f;
    [SerializeField] float xClamp = 85f;
    float mouseX, mouseY;
    float xRotation = 0f;

    public Image reticle;
    public GameObject creaturePanel;
    private TextMeshProUGUI creatureName, creatureScanPercentage;
    public GameObject currentTarget, newTarget;
    private float scanPercentage;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (!reticle) {
            reticle = GameObject.Find("Reticle").GetComponent<Image>();
        }
        if (!creaturePanel) {
            creaturePanel = GameObject.Find("Creature Panel");
        }
        creatureName = creaturePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        creatureScanPercentage = creaturePanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        if (!TriggerEnityCreation.DNAopened) {
            transform.Rotate(Vector3.up, mouseX * .2f * Time.deltaTime);
            transform.GetChild(0).Rotate(Vector3.right, -mouseY * sensitivityY * Time.deltaTime);
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
            //Vector3 targetRotation = transform.eulerAngles;
            //targetRotation.x = xRotation;

            newTarget = RayCheck();
            if (currentTarget != null) {
                if (Input.GetKey(KeyCode.E)) {
                    scanPercentage += 10 * Time.deltaTime;
                }
                if (scanPercentage > 100.00f) {
                    scanPercentage = 100.00f;
                }
            }
            ToggleUI();
        }
    }

    public void ReceiveInput(Vector2 mouseInput) {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }

    private GameObject RayCheck() {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 25f)) {
            if (hit.collider.CompareTag("Creature")) {
                reticle.color = Color.Lerp(reticle.color, Color.red, Time.deltaTime * 3);
                reticle.transform.localScale = Vector3.Lerp(reticle.transform.localScale, new Vector3(0.5f, 0.5f, 1), Time.deltaTime * 2);
                return hit.collider.gameObject;
            } else {
                reticle.color = Color.Lerp(reticle.color, Color.black, Time.deltaTime * 3);
                reticle.transform.localScale = Vector3.Lerp(reticle.transform.localScale, new Vector3(0.2f, 0.2f, 1), Time.deltaTime * 2);
                return null;
            }
        } else {
            reticle.color = Color.Lerp(reticle.color, Color.black, Time.deltaTime * 3);
            reticle.transform.localScale = Vector3.Lerp(reticle.transform.localScale, new Vector3(0.2f, 0.2f, 1), Time.deltaTime * 2);
            return null;
        }
    }

    private void ToggleUI() {
        if (newTarget && newTarget != currentTarget) {
            currentTarget = newTarget;
            scanPercentage = 0.00f;
        }
        if (!newTarget) {
            creaturePanel.SetActive(false);
        } else {
            creaturePanel.SetActive(true);
        }
        if (currentTarget) {
            creatureName.text = "Creature Name: " + currentTarget.name;
            creatureScanPercentage.text = "Scan Percentage: " + scanPercentage.ToString("N2") + "%";
        }
    }
}