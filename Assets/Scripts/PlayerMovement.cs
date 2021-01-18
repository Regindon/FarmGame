using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float gravity = -9.81f;
    private Vector3 move;
    public CharacterController controller;
    public float speed = 12f;
    private Vector3 velocity;
    public Camera cam;
    
    public Transform groundCheck;
    public float groundDisctance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    private bool playerInBarn = false;
    private bool playerInHorse = false;
    private bool toMarket = false;
    private bool toMainScene = false;
    private bool playerInFence = false;
    private bool playerInMarket = false;
    public float milk;
    public float horseRent;
    public float sheepWool;
    public float playerMoney;
    public float marketSell;
    public float marketSellWool;
    public static float repair;
    

    private float repairFence;
    public Text marketText;
    public Text mainSceneText;
    public Text milkText;
    public Text horseRentText;
    public Text woolText;
    public Text canMilkText;
    public Text canRentText;
    public Text canWoolText;
    public Text money;
    public Text marketSellText;
    public Text marketSellWoolText;
    public Text repairToolkitAmountt;
    public Text buyRepairText;
    public Text canRepairText;
    public GameObject horseBrown;
    public GameObject horseBrown1;
    public GameObject horseBrown2;
    public GameObject fence;
    public GameObject fence1;
    public GameObject fence2;


    

    void Start()
    {
        playerMoney = PlayerPrefs.GetFloat("Money", playerMoney);
        milk = PlayerPrefs.GetFloat("Milk", milk);
        horseRent = PlayerPrefs.GetFloat("Rent", horseRent);
        sheepWool = PlayerPrefs.GetFloat("Wool", sheepWool);
        repair = PlayerPrefs.GetFloat("Repair", repair);
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerInBarn +" barn");
        //Debug.Log(milk+ " milk");
        //Debug.Log(sheepWool + " wool");
        //Debug.Log( playerInHorse + " horse area");
        //Debug.Log( horseRent + " horse rent");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDisctance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag=="Cow"&& playerInBarn==true && milk < 2 )
            {
                //check if player have more then 1 milk
                //activate text
                canMilkText.enabled = true;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    //get milk
                    milk += 1;
                    PlayerPrefs.SetFloat("Milk", milk);
                    

                }
            }
            else
            {
                canMilkText.enabled = false;
            }

            if (hit.collider.tag == "Horse" && playerInHorse == true && horseRent<3)
            {
                //check if player rent a horse before
                //activate text
                canRentText.enabled = true;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    //rent horse
                    horseRent += 1;
                    horseBrown.SetActive(false);
                    playerMoney += 1;
                    PlayerPrefs.SetFloat("Rent", horseRent);
                    PlayerPrefs.SetFloat("Money", playerMoney);
                    StartCoroutine(Respawn(horseBrown));

                }
            }
            else
            {
                if (hit.collider.tag == "Horse1" || hit.collider.tag == "Horse2" || hit.collider.tag == "Horse")
                {
                    if (playerInHorse == true)
                    {
                        canRentText.enabled = true;
                    }
                    if (horseRent >= 3)
                    {
                        canRentText.enabled = false;
                    }
                    
                }
                else
                {
                    canRentText.enabled = false;
                }
            }

            IEnumerator Respawn(GameObject horseBrown)
            {
                yield return new WaitForSeconds(60);
                horseBrown.SetActive(true);
                Instantiate(horseBrown);
            }
            
            
            if (hit.collider.tag == "Horse1" && playerInHorse == true && horseRent<3)
            {
                //check if player rent a horse before
                //activate text
                canRentText.enabled = true;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    //rent horse
                    horseRent += 1;
                    horseBrown1.SetActive(false);
                    playerMoney += 1;
                    PlayerPrefs.SetFloat("Rent", horseRent);
                    PlayerPrefs.SetFloat("Money", playerMoney);
                    StartCoroutine(Respawn1(horseBrown1));
                    
                }
            }
            else
            {
                
                if (hit.collider.tag == "Horse1" || hit.collider.tag == "Horse2" || hit.collider.tag == "Horse")
                {
                    if (playerInHorse == true)
                    {
                        canRentText.enabled = true;
                    }
                    if (horseRent >= 3)
                    {
                        canRentText.enabled = false;
                    }
                    
                    
                }
                else
                {
                    canRentText.enabled = false;
                }
            }
            
            IEnumerator Respawn1(GameObject horseBrown1)
            {
                yield return new WaitForSeconds(60);
                horseBrown1.SetActive(true);
                Instantiate(horseBrown1);
            }
            
            if (hit.collider.tag == "Horse2" && playerInHorse == true && horseRent<3)
            {
                //check if player rent a horse before
                //activate text
                canRentText.enabled = true;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    //rent horse
                    horseRent += 1;
                    horseBrown2.SetActive(false);
                    playerMoney += 10;
                    PlayerPrefs.SetFloat("Rent", horseRent);
                    PlayerPrefs.SetFloat("Money", playerMoney);
                    StartCoroutine(Respawn2(horseBrown2));
                    
                }
            }
            else
            {
                
                if (hit.collider.tag == "Horse1" || hit.collider.tag == "Horse2" || hit.collider.tag == "Horse")
                {
                    if (playerInHorse == true)
                    {
                        canRentText.enabled = true;
                    }
                    if (horseRent >= 3)
                    {
                        canRentText.enabled = false;
                    }
                    
                    
                }
                else
                {
                    canRentText.enabled = false;
                }
            }
            
            IEnumerator Respawn2(GameObject horseBrown2)
            {
                yield return new WaitForSeconds(60);
                horseBrown2.SetActive(true);
                Instantiate(horseBrown2);
            }
            
            

            if (hit.collider.tag == "Fence" && playerInFence== true)
            {
                //check if player rent a horse before
                //activate text
                canRepairText.enabled = true;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (repair >= 1)
                    {
                        repair -= 1;
                        PlayerPrefs.SetFloat("Repair", repair);
                        fence.GetComponent<MeshRenderer>().enabled = true;
                    }
                }
                else
                {
                    canRepairText.enabled = false;
                }
            }
            if (hit.collider.tag == "Fence" && playerInFence== true)
            {
                //check if player rent a horse before
                //activate text
                canRepairText.enabled = true;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (repair >= 1)
                    {
                        repair -= 1;
                        PlayerPrefs.SetFloat("Repair", repair);
                        fence1.GetComponent<MeshRenderer>().enabled = true;
                    }
                }
                else
                {
                    canRepairText.enabled = false;
                }
            }
            if (hit.collider.tag == "Fence" && playerInFence== true)
            {
                //check if player rent a horse before
                //activate text
                canRepairText.enabled = true;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (repair >= 1)
                    {
                        repair -= 1;
                        PlayerPrefs.SetFloat("Repair", repair);
                        fence2.GetComponent<MeshRenderer>().enabled = true;
                    }
                }
                else
                {
                    canRepairText.enabled = false;
                }
            }
            
            

            if (hit.collider.tag=="Sheep" && playerInBarn==true && sheepWool <1)
            {
                //check if player sheared wool before
                //activate text
                canWoolText.enabled = true;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    //shear sheep
                    sheepWool += 1;
                    PlayerPrefs.SetFloat("Wool", sheepWool);
                    
                }
            }
            else
            {
                canWoolText.enabled = false;
            }
            if (hit.collider.tag=="Market" && playerInMarket==true)
            {
                marketSellText.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //sell milk
                    if (milk >= 1)
                    {
                        milk -= 1;
                        playerMoney += 5;
                        PlayerPrefs.SetFloat("Milk", milk);
                        PlayerPrefs.SetFloat("Money", playerMoney);
                    }
                    
                }
            }
            else
            {
                marketSellText.enabled = false;
            }
            if (hit.collider.tag=="Market1" && playerInMarket==true)
            {
                marketSellWoolText.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //sell milk
                    if (sheepWool >= 1)
                    {
                        sheepWool -= 1;
                        playerMoney += 15;
                        PlayerPrefs.SetFloat("Wool", sheepWool);
                        PlayerPrefs.SetFloat("Money", playerMoney);

                    }
                    
                }
            }
            else
            {
                marketSellWoolText.enabled = false;
            }
            if (hit.collider.tag=="Market3" && playerInMarket==true)
            {
                buyRepairText.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    
                    if (playerMoney >= 20)
                    {
                        repair += 1;
                        playerMoney -= 10;
                        PlayerPrefs.SetFloat("Repair", repair);
                        PlayerPrefs.SetFloat("Money", playerMoney);

                    }
                    
                }
            }
            else
            {
               buyRepairText.enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && toMarket==true)
        {
            //load market scene
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.E)&& toMainScene==true)
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }

        milkText.text = milk.ToString();
        horseRentText.text = horseRent.ToString();
        woolText.text = sheepWool.ToString();
        money.text = (playerMoney.ToString() + "$");
        repairToolkitAmountt.text = repair.ToString();
        




    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("toMarketPlace"))
        {
            //activate text
            marketText.enabled = true;
            toMarket = true;

        }

        if (other.CompareTag("toMainScene"))
        {
            //activate text
            mainSceneText.enabled = true;
            toMainScene = true;
        }
        if (other.CompareTag("InBarn"))
        {
            playerInBarn = true;
        }
        if (other.CompareTag("InHorseArea"))
        {
            playerInHorse = true;
        }

        if (other.CompareTag("InMarketPlace"))
        {
            marketSellText.enabled = true;
            playerInMarket = true;
        }

        if (other.CompareTag("toRepairFence"))
        {
            canRepairText.enabled = true;
            playerInFence = true;
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("toMarketPlace"))
        {
            //disable mainscene text
            marketText.enabled = false;
            toMarket = false;
        }

        if (other.CompareTag("toMainScene"))
        {
            //disable market text
            mainSceneText.enabled = false;
            toMainScene = false;
        }

        if (other.CompareTag("InBarn"))
        {
            playerInBarn = false;
        }

        if (other.CompareTag("InHorseArea"))
        {
            playerInHorse = false;
        }
        if (other.CompareTag("InMarketPlace"))
        {
            marketSellText.enabled = false;
            playerInMarket = false;
        }
        if (other.CompareTag("toRepairFence"))
        {
            canRepairText.enabled = false;
            playerInFence = false;
        }
    }
}
