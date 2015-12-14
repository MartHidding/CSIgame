using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuzzleTextMesh : MonoBehaviour {

    //Alle publieke variabelen voor GameObjecten die in Unity toegewezen kunnen worden
    public GameObject playerCamera;
    public GameObject pcCamera;
    public GameObject pc;
    public GameObject hintPanel;
    public GameObject answers;
    public GameObject question;
    public GameObject solutionA;
    public GameObject solutionB;
    public GameObject solutionY;
    public GameObject accesGranted;
    public GameObject accesDenied;
    public GameObject desktopBackground;
    public GameObject mouseMove;
    public GameObject main;
    public GameObject sub;

    public GameObject projectsTrigger;
    public GameObject personalTrigger;
    public GameObject assetsTrigger;
    public GameObject noteTrigger;
    public GameObject scriptsTrigger;
    public GameObject texturesTrigger;
    public GameObject objectsTrigger;
    public GameObject UITrigger;
    public GameObject codeTrigger;
    public GameObject visualsTrigger;
    public GameObject mailTrigger;
    public GameObject moviesTrigger;
    public GameObject musicTrigger;
    public GameObject relatedTrigger;

    public GameObject projectsFolder;
    public GameObject personalFolder;
    public GameObject assetsFolder;
    public GameObject noteFile;
    public GameObject scriptsFolder;
    public GameObject texturesFolder;
    public GameObject objectsFolder;
    public GameObject UIFolder;
    public GameObject codeFolder;
    public GameObject visualsFolder;
    public GameObject mailFolder;
    public GameObject moviesFolder;
    public GameObject musicFolder;
    public GameObject relatedFolder;

    //De variabelen voor de tekst in de hints
    public Text hintText;
    public Text hintContinueText;

    //De verschillende boolean variabelen die gebruikt worden om dingen te controleren
    private bool playerCameraActive;
    private bool pcOn;
    private bool answersActive;
    private bool solved;
    private bool projectsFolderSelected;
    private bool personalFolderSelected;
    private bool assetsFolderSelected;
    private bool noteFileSelected;
    private bool scriptsFolderSelected;
    private bool texturesFolderSelected;
    private bool objectsFolderSelected;
    private bool UIFolderSelected;
    private bool codeFolderSelected;
    private bool visualsFolderSelected;
    private bool mailFolderSelected;
    private bool moviesFolderSelected;
    private bool musicFolderSelected;
    private bool relatedFolderSelected;
    private bool projectsActive;
    private bool personalActive;
    private bool assetsActive;
    private bool desktopOn;
    private bool folderSelected;
    private bool fileSelected;

    //De string variabelen die gebruikt worden om te kijken wat de speler heeft aangegeven
    private string answer;
    private string acces;

    // Use this for initialization
    void Start () {
        //Verschillende GameObjecten aanzetten
        playerCamera.SetActive(true);
        playerCameraActive = true;


        //Verschillende GameObjecten uitzetten
        pcCamera.SetActive(false);
        hintPanel.SetActive(false);
        answers.SetActive(false);
        answersActive = false;
        question.SetActive(false);
        solutionA.SetActive(false);
        solutionB.SetActive(false);
        solutionY.SetActive(false);
        accesGranted.SetActive(false);
        accesDenied.SetActive(false);
        desktopBackground.SetActive(false);
        mouseMove.SetActive(false);
        projectsFolder.SetActive(false);
        personalFolder.SetActive(false);
        assetsFolder.SetActive(false);
        noteFile.SetActive(false);
        scriptsFolder.SetActive(false);
        texturesFolder.SetActive(false);
        objectsFolder.SetActive(false);
        UIFolder.SetActive(false);
        codeFolder.SetActive(false);
        visualsFolder.SetActive(false);
        mailFolder.SetActive(false);
        moviesFolder.SetActive(false);
        musicFolder.SetActive(false);
        relatedFolder.SetActive(false);

        //De tekst en string variabelen die leeg worden gezet
        hintText.text = "";
        hintContinueText.text = "";
        acces = "";

        //De verschillende booleans die standaard op "false" staan
        pcOn = false;
        desktopOn = false;
        folderSelected = false;
        fileSelected = false;
        projectsActive = false;
        personalActive = false;
        assetsActive = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("360_BackButton"))  //Controleer of de "BackButton" wordt ingedrukt
        {
            TogglePcView(); //Roep de methode TogglePcView aan
        }

        if (playerCameraActive == false)        //Controleer of de playerCamera aanstaat
        {
            if (solved == false)        //Als de puzzel niet opgelost is
            {
                if (pcOn == false)      //Als de pc uitstaat
                {
                    hintPanel.SetActive(true);                      //Zet de hintPanel GameObject aan
                    hintText.text = "Druk op X om de pc te starten";     //Zet de tekst voor in de hintPanel
                }
                else                       //Als de pc aanstaat
                {
                    hintPanel.SetActive(false);         //Zet de hintPanel GameObject uit
                    hintText.text = "";                 //Zet de tekst voor in de hintPanel leeg
                    question.SetActive(true);           //Zet de question GameObject aan
                    answers.SetActive(true);            //Zet de answers GameObject aan
                    answersActive = true;               //Zet de boolean answersActive op "true"
                }

                if (Input.GetButtonDown("360_XButton") && pcOn == false)        //Als de "XButton" wordt ingedrukt
                {
                    pcOn = true;        //Zet de boolean pcOn op "true"
                    pc.GetComponent<Renderer>().material.color = Color.white;   //Zet de kleur van de achtergrond van de pc
                    question.SetActive(true);       //Zet de question GameObject aan
                    answers.SetActive(true);        //Zet de answers GameObject aan
                    answersActive = true;           //Zet de boolean answersActive op "true"
                    hintPanel.SetActive(false);     //Zet de hintPanel GameObject uit
                    hintText.text = "";             //Zet de tekst vor in de hintPanel leeg
                }

                if (answersActive)                  //Als de antwoorden aanstaan
                {
                    AnswerQuestion();               //Roept de methode AnswerQuestion() aan
                }
            }
            else                //Als de puzzel opgelost is
            {
                if (acces != "granted")         //Als de speler nog geen toegang heeft tot de pc
                {
                    Verifying();                //Roept de methode Verifying() aan
                }
                else                            //Als de speler toegang heeft tot de pc
                {
                    GoToDesktopBackground();    //Roept de methode GoToDesktopBackground() aan
                }
            }
        }
    }

    void TogglePcView()             //De methode TogglePCView
    {
        if (playerCameraActive)     //Controleer of de playerCamera aanstaat
        {
            playerCamera.SetActive(false);      //playerCamera uitzetten
            pcCamera.SetActive(true);           //pcCamera aanzetten
            playerCameraActive = false;         //Zet de boolean playerCameraActive op "false"
            gameObject.GetComponent<XboxController>().enabled = false;  //de XboxController script uitzetten
            mouseMove.GetComponent<MouseScript>().enabled = true;       //Zet de script voor het bewegen van de muis aan
        }
        else                        //Als de playerCamera uitstaat
        {
            playerCamera.SetActive(true);       //playerCamera aanzetten
            pcCamera.SetActive(false);          //pcCamera uitzetten
            playerCameraActive = true;          //Zet de boolean playerCameraActive op "true"
            hintText.text = "";                 //Zet de hintText leeg
            gameObject.GetComponent<XboxController>().enabled = true;  //de XboxController script aanzetten
            hintPanel.SetActive(false);         //Zet de hintPanel  GameObject uit
            answers.SetActive(false);           //Zet de answers GameObject uit
            answersActive = false;              //Zet de boolean answersActive op "false"
            mouseMove.GetComponent<MouseScript>().enabled = false;      //Zet de script voor het bewegen van de muis uit
        }
    }

    void AnswerQuestion()       //De methode AnswerQuestion()
    {
        if (Input.GetButtonDown("360_AButton"))     //Als de "AButton" wordt ingedrukt
        {
            answers.SetActive(false);               //Zet de answers GameObject uit
            answersActive = false;                  //Zet de boolean answersActive op "false"
            question.SetActive(false);              //Zet de question GameObject uit
            solutionA.SetActive(true);              //Zet de solutionA GameObject aan
            solved = true;                          //Zet de boolean solved op "true"
            answer = "A";                           //Zet welk antwoord gekozen is; hier "A"
            hintPanel.SetActive(true);              //Zet de hintPanel GameObject aan
            hintContinueText.text = "Druk op X om verder te gaan"; //Zet de tekst voor in de hintPanel
        }
        else if (Input.GetButtonDown("360_BButton"))    //Als de "BButton" wordt ingedrukt
        {
            answers.SetActive(false);               //Zet de answers GameObject uit
            answersActive = false;                  //Zet de boolean answersActive op "false"
            question.SetActive(false);              //Zet de question GameObject uit
            solutionB.SetActive(true);              //Zet de solutionB GameObject aan
            solved = true;                          //Zet de boolean solved op "true"
            answer = "B";                           //Zet welk antwoord gekozen is; hier "B"
            hintPanel.SetActive(true);              //Zet de hintPanel GameObject aan
            hintContinueText.text = "Druk op X om verder te gaan"; //Zet de tekst voor in de hintPanel
        }
        else if (Input.GetButtonDown("360_YButton"))    //Als de "YButton" wordt ingedrukt
        {
            answers.SetActive(false);               //Zet de answers GameObject uit
            answersActive = false;                  //Zet de boolean answersActive op "false"
            question.SetActive(false);              //Zet de question GameObject uit
            solutionY.SetActive(true);              //Zet de solutionY GameObject aan
            solved = true;                          //Zet de boolean solved op "true"
            answer = "Y";                           //Zet welk antwoord gekozen is; hier "Y"
            hintPanel.SetActive(true);              //Zet de hintPanel GameObject aan
            hintContinueText.text = "Druk op X om verder te gaan"; //Zet de tekst voor in de hintPanel
        }
        else           //Als er niks wordt ingedrukt
        {
            answers.SetActive(true);        //Zet de answers GameObject aan
            answersActive = true;           //Zet de boolean answersActive op "true"
        }
    }

    void Verifying()        //De methode Verifying()
    {
        if (Input.GetButtonDown("360_XButton"))     //Als de "XButton" wordt ingedrukt
        {
            //Hier worden een aantal GameObjecten uitgezet
            solutionY.SetActive(false);
            solutionA.SetActive(false);
            solutionB.SetActive(false);
            question.SetActive(false);
            hintPanel.SetActive(false);
            hintContinueText.text = "";     //Hier wordt de hint tekst leeg gemaakt

            if (answer == "B")              //Als het antwoord B is gekozen
            {
                accesGranted.SetActive(true);       //Het GameObject accesGranted wordt aangezet
                accesDenied.SetActive(false);       //Het GameObject accesDenies wordt uitgezet
                acces = "granted";                  //Zet of er acces is; hier is het "granted"
                hintPanel.SetActive(true);          //Zet de hintPanel GameObject aan
                hintContinueText.text = "Druk op X om verder te gaan"; //Zet de tekst voor in de hintPanel
            }
            else                            //Als er een ander antwoord is gekozen dan B
            {
                accesDenied.SetActive(true);        //Het GameObject accesDenies wordt aangezet
                acces = "denied";                   //Zet of er acces is; hier is het "denied"
                solved = false;                     //Zet de boolean solved op "false"
            }
        }
    }

    void GoToDesktopBackground()        //De methode GoToDesktopBackground()
    {
        if (Input.GetButtonDown("360_XButton")) //Als de "XButton" wordt ingedrukt
        {
            desktopOn = true;                   //Zet de boolean desktopOn op "true"
            //Hier worden een aantal GameObject aan en uit gezet
            mouseMove.SetActive(true);
            pc.SetActive(false);
            accesGranted.SetActive(false);
            hintPanel.SetActive(false);
            hintContinueText.text = "";         //Maakt de tekst voor in de hintPanel leeg
        }

        if (desktopOn)          //Als desktopOn "true" is
        {
            //Hier worden een aantal variabelen uit andere scripts gehaald
            projectsFolderSelected = projectsTrigger.GetComponent<FolderMouseOver>().projectsFolderSelected;
            personalFolderSelected = personalTrigger.GetComponent<FolderMouseOver1>().personalFolderSelected;
            assetsFolderSelected = assetsTrigger.GetComponent<FolderMouseOver2>().assetsFolderSelected;

            noteFileSelected = noteTrigger.GetComponent<NoteFileMouseOver>().noteFileSelected;
            scriptsFolderSelected = scriptsTrigger.GetComponent<ScriptsFolderMouseOver>().scriptsFolderSelected;
            texturesFolderSelected = texturesTrigger.GetComponent<TexturesFolderMouseOver>().texturesFolderSelected;
            objectsFolderSelected = objectsTrigger.GetComponent<ObjectsFolderMouseOver>().objectsFolderSelected;
            UIFolderSelected = UITrigger.GetComponent<UIFolderMouseOver>().UIFolderSelected;
            codeFolderSelected = codeTrigger.GetComponent<CodeFolderMouseOver>().codeFolderSelected;
            visualsFolderSelected = visualsTrigger.GetComponent<VisualsFolderMouseOver>().visualsFolderSelected;
            mailFolderSelected = mailTrigger.GetComponent<MailFolderMouseOver>().mailFolderSelected;
            moviesFolderSelected = moviesTrigger.GetComponent<MoviesFolderMouseOver>().moviesFolderSelected;
            musicFolderSelected = musicTrigger.GetComponent<MusicFolderMouseOver>().musicFolderSelected;
            relatedFolderSelected = relatedTrigger.GetComponent<RelatedFolderMouseOver>().relatedFolderSelected;


            if (folderSelected == false)        //Als er geen folder geselecteerd is
            {
                //Hier worden een aantal triggers uitgezet
                HighlightOff();
                noteTrigger.SetActive(false);
                scriptsTrigger.SetActive(false);
                texturesTrigger.SetActive(false);
                objectsTrigger.SetActive(false);
                UITrigger.SetActive(false);
                codeTrigger.SetActive(false);
                visualsTrigger.SetActive(false);
                mailTrigger.SetActive(false);
                moviesTrigger.SetActive(false);
                musicTrigger.SetActive(false);
                relatedTrigger.SetActive(false);
                main.SetActive(true);
                sub.SetActive(false);
                SelectFolder();                 //Roep de SelectFolder() methode aan
            }
            else if (fileSelected == false)     //Als er geen file geselecteerd is
            {
                SelectFile();                   //Roep de SelectFile() methode aan
            }
            else                                //Als er zowel een folder als een file is geselecteerd
            {
                if (Input.GetButtonDown("360_BButton")) //Als de "BButton" wordt ingedrukt
                {
                    BackToFolder();             //Roep de BackToFolder() methode aan
                }
            }
        }
    }

    void SelectFolder()         //De SelectFolder() methode
    {
        if (projectsFolderSelected)                 //Als de projects folder is geselecteerd
        {
            desktopBackground.SetActive(false);     //Zet de desktopBackground uit
            //noteTrigger.SetActive(true);
            projectsFolder.SetActive(true);         //Zet de projects folder aan
            //Hier worden een paar booleans op "true" gezet
            folderSelected = true;
            projectsActive = true;
            noteTrigger.SetActive(true);            //Zet de noteTrigger aan
            codeTrigger.SetActive(true);            //Zet de codeTrigger aan
            visualsTrigger.SetActive(true);            //Zet de visualsTrigger aan
            main.SetActive(false);
            sub.SetActive(true);
        }
        else if (personalFolderSelected)            //Als de personal folder is geselecteerd
        {
            desktopBackground.SetActive(false);     //Zet de desktopBackground uit
            personalFolder.SetActive(true);         //Zet de personal folder aan
            mailTrigger.SetActive(true);
            moviesTrigger.SetActive(true);
            musicTrigger.SetActive(true);
            relatedTrigger.SetActive(true);
            //Hier worden een paar booleans op "true" gezet
            folderSelected = true;
            personalActive = true;
            main.SetActive(false);
            sub.SetActive(true);
        }
        else if (assetsFolderSelected)              //Als de assets folder is geselecteerd
        {
            desktopBackground.SetActive(false);     //Zet de desktopBackground uit
            assetsFolder.SetActive(true);           //Zet de assets folder aan
            //Hier worden een paar booleans op "true" gezet
            folderSelected = true;
            assetsActive = true;
            //Hier worden een aantal triggers aangezet
            scriptsTrigger.SetActive(true);
            texturesTrigger.SetActive(true);
            objectsTrigger.SetActive(true);
            UITrigger.SetActive(true);
            main.SetActive(false);
            sub.SetActive(true);
        }
        else
        {
            desktopBackground.SetActive(true);     //Zet de desktopBackground aan
            //Hier worden de folders en een aantal triggers uitgezet
            projectsFolder.SetActive(false);
            personalFolder.SetActive(false);
            assetsFolder.SetActive(false);
            HighlightOff();
            noteTrigger.SetActive(false);
            scriptsTrigger.SetActive(false);
            texturesTrigger.SetActive(false);
            objectsTrigger.SetActive(false);
            UITrigger.SetActive(false);
            codeTrigger.SetActive(false);
            visualsTrigger.SetActive(false);
            mailTrigger.SetActive(false);
            moviesTrigger.SetActive(false);
            musicTrigger.SetActive(false);
            relatedTrigger.SetActive(false);
            main.SetActive(true);
            sub.SetActive(false);
        }
    }

    void SelectFile()       //De SelectFile() methode
    {
        if (Input.GetButtonDown("360_BButton"))     //Als de "BButton" wordt ingedrukt
        {
            desktopBackground.SetActive(true);      //Zet de desktop background aan
            //Hier worden de folders uitgezet
            projectsFolder.SetActive(false);
            personalFolder.SetActive(false);
            assetsFolder.SetActive(false);
            HighlightOff();
            noteTrigger.SetActive(false);
            scriptsTrigger.SetActive(false);
            texturesTrigger.SetActive(false);
            objectsTrigger.SetActive(false);
            visualsTrigger.SetActive(false);
            UITrigger.SetActive(false);
            codeTrigger.SetActive(false);
            mailTrigger.SetActive(false);
            moviesTrigger.SetActive(false);
            musicTrigger.SetActive(false);
            relatedTrigger.SetActive(false);
            main.SetActive(true);
            sub.SetActive(false);
            //Hier worden een aantal booleans op "false" gezet
            folderSelected = false;
            projectsActive = false;
            personalActive = false;
            assetsActive = false;
        }

        if (noteFileSelected)                       //Als de note file geselecteerd is
        {
            noteFile.SetActive(true);               //Zet de note file aan
            projectsFolder.SetActive(false);        //Zet de projects folder uit
            fileSelected = true;                    //Zet de fileSelected boolean op "true"
            sub.SetActive(false);
        }
        else if (scriptsFolderSelected)             //Als de scripts folder geselecteerd is
        {
            scriptsFolder.SetActive(true);          //Zet de scripts folder aan
            assetsFolder.SetActive(false);          //Zet de assets folder uit
            fileSelected = true;                    //Zet de fileSelected boolean op "true"
            sub.SetActive(false);
        }
        else if (texturesFolderSelected)             //Als de textures folder geselecteerd is
        {
            texturesFolder.SetActive(true);          //Zet de textures folder aan
            assetsFolder.SetActive(false);          //Zet de assets folder uit
            fileSelected = true;                    //Zet de fileSelected boolean op "true"
            sub.SetActive(false);
        }
        else if (objectsFolderSelected)             //Als de textures folder geselecteerd is
        {
            objectsFolder.SetActive(true);          //Zet de objects folder aan
            assetsFolder.SetActive(false);          //Zet de assets folder uit
            fileSelected = true;                    //Zet de fileSelected boolean op "true"
            sub.SetActive(false);
        }
        else if (UIFolderSelected)                  //Als de UI folder geselecteerd is
        {
            UIFolder.SetActive(true);               //Zet de UI folder aan
            assetsFolder.SetActive(false);          //Zet de assets folder uit
            fileSelected = true;                    //Zet de fileSelected boolean op "true"
            sub.SetActive(false);
        }
        else if (codeFolderSelected)                //Als de code folder geselecteerd is
        {
            codeFolder.SetActive(true);             //Zet de code folder aan
            projectsFolder.SetActive(false);        //Zet de projects folder uit
            fileSelected = true;                    //Zet de fileSelected boolean op "true"
            sub.SetActive(false);
        }
        else if (visualsFolderSelected)             //Als de visuals folder geselecteerd is
        {
            visualsFolder.SetActive(true);          //Zet de visuals folder aan
            projectsFolder.SetActive(false);        //Zet de projects folder uit
            fileSelected = true;                    //Zet de fileSelected boolean op "true"
            sub.SetActive(false);
        }
        else if (mailFolderSelected)                //Als de mail folder geselecteerd is
        {
            mailFolder.SetActive(true);             //Zet de mail folder aan
            personalFolder.SetActive(false);        //Zet de personal folder uit
            fileSelected = true;                    //Zet de fileSelected boolean op "true"
            sub.SetActive(false);
        }
        else if (musicFolderSelected)               //Als de music folder geselecteerd is
        {
            musicFolder.SetActive(true);            //Zet de music folder aan
            personalFolder.SetActive(false);        //Zet de personal folder uit
            fileSelected = true;                    //Zet de fileSelected boolean op "true"
            sub.SetActive(false);
        }
        else if (moviesFolderSelected)              //Als de movies folder geselecteerd is
        {
            moviesFolder.SetActive(true);           //Zet de movies folder aan
            personalFolder.SetActive(false);        //Zet de personal folder uit
            fileSelected = true;                    //Zet de fileSelected boolean op "true"
            sub.SetActive(false);
        }
        else if (relatedFolderSelected)             //Als de related folder geselecteerd is
        {
            relatedFolder.SetActive(true);          //Zet de related folder aan
            personalFolder.SetActive(false);        //Zet de personal folder uit
            fileSelected = true;                    //Zet de fileSelected boolean op "true"
            sub.SetActive(false);
        }

    }

    void BackToFolder()     //De BackToFolder() methode
    {
        if (projectsActive)                         //Als de projects folder actief is
        {
            projectsFolder.SetActive(true);         //Zet de projects folder aan
            HighlightOff();                         //Roep de methode HighlightOff aan
            noteFile.SetActive(false);              //Zet de note file uit
            scriptsFolder.SetActive(false);         //Zet de scriptsfolder uit
            texturesFolder.SetActive(false);        //Zet de texturesfolder uit
            objectsFolder.SetActive(false);         //Zet de objectsfolder uit
            UIFolder.SetActive(false);              //Zet de UIfolder uit
            codeFolder.SetActive(false);            //Zet de codefolder uit
            visualsFolder.SetActive(false);         //Zet de visualsfolder uit
            mailFolder.SetActive(false);            //Zet de mailfolder uit
            moviesFolder.SetActive(false);          //Zet de moviesfolder uit
            musicFolder.SetActive(false);           //Zet de musicfolder uit
            relatedFolder.SetActive(false);         //Zet de relatedfolder uit
            folderSelected = true;                  //Zet de folderSeleceted boolean op "true"
            fileSelected = false;                   //Zet de fileSelected boolean op "false"
            sub.SetActive(true);
        }
        else if (personalActive)                    //Als de personal folder actief is
        {
            personalFolder.SetActive(true);         //Zet de personal folder aan
            HighlightOff();                         //Roep de methode HighlightOff aan
            noteFile.SetActive(false);              //Zet de note file uit
            scriptsFolder.SetActive(false);         //Zet de scriptsfolder uit
            texturesFolder.SetActive(false);        //Zet de texturesfolder uit
            objectsFolder.SetActive(false);         //Zet de objectsfolder uit
            UIFolder.SetActive(false);              //Zet de UIfolder uit
            codeFolder.SetActive(false);            //Zet de codefolder uit
            visualsFolder.SetActive(false);         //Zet de visualsfolder uit
            mailFolder.SetActive(false);            //Zet de mailfolder uit
            moviesFolder.SetActive(false);          //Zet de moviesfolder uit
            musicFolder.SetActive(false);           //Zet de musicfolder uit
            relatedFolder.SetActive(false);         //Zet de relatedfolder uit
            folderSelected = true;                  //Zet de folderSeleceted boolean op "true"
            fileSelected = false;                   //Zet de fileSelected boolean op "false"
            sub.SetActive(true);
        }
        else if (assetsActive)                      //Als de assets folder actief is
        {
            assetsFolder.SetActive(true);           //Zet de assets folder aan
            HighlightOff();                         //Roep de methode HighlightOff aan
            noteFile.SetActive(false);              //Zet de note file uit
            scriptsFolder.SetActive(false);         //Zet de scriptsfolder uit
            texturesFolder.SetActive(false);        //Zet de texturesfolder uit
            objectsFolder.SetActive(false);         //Zet de objectsfolder uit
            UIFolder.SetActive(false);              //Zet de UIfolder uit
            codeFolder.SetActive(false);            //Zet de codefolder uit
            visualsFolder.SetActive(false);         //Zet de visualsfolder uit
            mailFolder.SetActive(false);            //Zet de mailfolder uit
            moviesFolder.SetActive(false);          //Zet de moviesfolder uit
            musicFolder.SetActive(false);           //Zet de musicfolder uit
            relatedFolder.SetActive(false);         //Zet de relatedfolder uit
            folderSelected = true;                  //Zet de folderSeleceted boolean op "true"
            fileSelected = false;                   //Zet de fileSelected boolean op "false"
            sub.SetActive(true);
        }
    }

    void HighlightOff()
    {
        noteTrigger.GetComponent<NoteFileMouseOver>().HighlightOff();
        scriptsTrigger.GetComponent<ScriptsFolderMouseOver>().HighlightOff();
        texturesTrigger.GetComponent<TexturesFolderMouseOver>().HighlightOff();
        objectsTrigger.GetComponent<ObjectsFolderMouseOver>().HighlightOff();
        UITrigger.GetComponent<UIFolderMouseOver>().HighlightOff();
        codeTrigger.GetComponent<CodeFolderMouseOver>().HighlightOff();
        visualsTrigger.GetComponent<VisualsFolderMouseOver>().HighlightOff();
        mailTrigger.GetComponent<MailFolderMouseOver>().HighlightOff();
        moviesTrigger.GetComponent<MoviesFolderMouseOver>().HighlightOff();
        musicTrigger.GetComponent<MusicFolderMouseOver>().HighlightOff();
        relatedTrigger.GetComponent<RelatedFolderMouseOver>().HighlightOff();
    }
}
