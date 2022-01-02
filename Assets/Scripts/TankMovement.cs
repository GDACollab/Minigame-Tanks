using UnityEngine;
using UnityEngine.Audio;

namespace Complete
{
    public class TankMovement : MonoBehaviour
    {
        public float m_Speed = 12f;                 // How fast the tank moves forward and back.
        public float m_TurnSpeed = 180f;            // How fast the tank turns in degrees per second.
        public float m_PlayerNumber = 1;            // Player Identifier


        private string m_MovementAxisName;          // The name of the input axis for moving forward and back.
        private string m_TurnAxisName;              // The name of the input axis for turning.
        private Rigidbody m_Rigidbody;              // Reference used to move the tank.
        private float m_MovementInputValue;         // The current value of the movement input.
        private float m_TurnInputValue;             // The current value of the turn input.
        private float m_OriginalPitch;              // The pitch of the audio source at the start of the scene.

        private AudioSource MoveSFX;                  // Audio for tank movement


        private void Awake ()
        {
            m_Rigidbody = GetComponent<Rigidbody> ();   
            MoveSFX = GetComponent<AudioSource>();

            // sets volume for tank movement
            MoveSFX.volume = OptionsMenu.TankMovementVolume;
        }


        private void OnEnable ()
        {
            // When the tank is turned on, make sure it's not kinematic.
            m_Rigidbody.isKinematic = false;

            // Also reset the input values.
            m_MovementInputValue = 0f;
            m_TurnInputValue = 0f;
        }


        private void OnDisable ()
        {
            // When the tank is turned off, set it to kinematic so it stops moving.
            m_Rigidbody.isKinematic = true;
        }


        private void Start ()
        {
            // The axes names are based on player number.
            m_MovementAxisName = "Vertical" + m_PlayerNumber;
            m_TurnAxisName = "Horizontal" + m_PlayerNumber;
        }


        private void Update ()
        {
            // Store the value of both input axes.
            m_MovementInputValue = Input.GetAxisRaw (m_MovementAxisName);
            m_TurnInputValue = Input.GetAxisRaw (m_TurnAxisName);

            // Sound for tank movement
            if (!MoveSFX.isPlaying && (m_MovementInputValue != 0 || m_TurnInputValue != 0))
            {
                MoveSFX.Play();
            }
            else if (m_MovementInputValue == 0 && m_TurnInputValue == 0)
            {
                MoveSFX.Stop();
            }
        }


        private void FixedUpdate ()
        {
            // Adjust the rigidbodies position and orientation in FixedUpdate. Only allows the tank to move if it is not turning
            if (!Turn())
            {
                Move();
            }
            
        }


        private void Move ()
        {
            // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
            Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

            // Apply this movement to the rigidbody's position.
            m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        }


        private bool Turn ()
        {
            bool hasTurned = false;

            float maxTurnSpeed = m_TurnSpeed * Time.deltaTime;

            // Determine the number of degrees to be turned based on the input, speed and time between frames.
            float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

            // Returns true if the tank is turning
            if(turn != 0)
            {
                hasTurned = true;
            }

            // Make this into a rotation in the y axis.
            Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

            // Apply this rotation to the rigidbody's rotation.
            m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation);

            print(m_TurnInputValue);

            return hasTurned;
        }
    }
}